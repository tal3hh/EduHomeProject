using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using ElmirProje.Models;
using MailKit.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace ElmirProje.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _singInManager;
        readonly RoleManager<AppRole> _roleManager;

        public AccountController(RoleManager<AppRole> roleManager, SignInManager<AppUser> singInManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _singInManager = singInManager;
            _userManager = userManager;
        }



        public IActionResult SingUp()
        {
            return View(new UserCreatedModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SingUp(UserCreatedModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser()
                {
                    UserName = model.Username,
                    Email = model.Email
                };

                var identity = await _userManager.CreateAsync(user, model.Password);

                if (identity.Succeeded)
                {
                    await _roleManager.CreateAsync(new AppRole
                    {
                        Name = "Admin"
                    });

                    await _userManager.AddToRoleAsync(user, "Admin");


                    AppUser appUser = await _userManager.FindByEmailAsync(model.Email);

                    if (appUser == null)
                        return View();

                    var message = new MimeMessage();

                    message.From.Add(new MailboxAddress("EduHome", "netflixaze225@gmail.com"));

                    message.To.Add(new MailboxAddress(appUser.UserName, appUser.Email));
                    message.Subject = "Confirm Email";

                    string emailbody = string.Empty;

                    using (StreamReader streamReader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Templates", "Confirm.html")))
                    {
                        emailbody = streamReader.ReadToEnd();
                    }



                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var url = Url.Action(nameof(VerifyEmail), "Account", new { userId = user.Id, token = code }, Request.Scheme, Request.Host.ToString());


                    emailbody = emailbody.Replace("{{username}}", $"{appUser.UserName}").Replace("{{code}}", $"{url}");

                    message.Body = new TextPart(TextFormat.Html) { Text = emailbody };

                    using var smtp = new SmtpClient();

                    smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    smtp.Authenticate("netflixaze225@gmail.com", "Netflix564n");
                    smtp.Send(message);
                    smtp.Disconnect(true);


                    return RedirectToAction("SingUpEmail", "Account");
                }
                foreach (var error in identity.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View(model);
        }

        public async Task<IActionResult> VerifyEmail(string userId, string token)
        {
            if (userId == null || token == null) return BadRequest();

            AppUser user = await _userManager.FindByIdAsync(userId);

            if (user is null) return BadRequest();


            await _userManager.ConfirmEmailAsync(user, token);

            await _singInManager.SignInAsync(user, false);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult SingUpEmail()
        {
            return View();
        }


        public IActionResult Login()
        {
            return View(new UserLoginModel());
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Username);

                var result = await _singInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, true);

                if (result.Succeeded)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles.Contains("Admin"))
                    {
                        return RedirectToAction("Index", "AdminPanel", new { area = "Admin" });
                    }
                    else if (roles.Contains("Member"))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else if (result.IsLockedOut)
                {
                    var logouttime = await _userManager.GetLockoutEndDateAsync(user);
                    var minute = (logouttime.Value.UtcDateTime - DateTime.UtcNow).Minutes;

                    ModelState.AddModelError("", $"Hesabiniz {minute} deqiqeliyine muveqqeti olaraq baglanmisdir.");
                }
                else
                {
                    string message = string.Empty;

                    if (user != null)
                    {
                        var failedcount = await _userManager.GetAccessFailedCountAsync(user);
                        var count = _userManager.Options.Lockout.MaxFailedAccessAttempts - failedcount;

                        message = $"{count} defe de yalnis giris etseniz hesabiniz muveqqeti olarag baglanacaq.";
                    }

                    else if (user == null)
                    {
                        message = "Username ve password sehvdir.";
                    }

                    ModelState.AddModelError("", message);
                }
            }
            return View(model);
        }


        public async Task<IActionResult> SingOut()
        {
            await _singInManager.SignOutAsync();

            return RedirectToAction("Login");
        }
    }
}
