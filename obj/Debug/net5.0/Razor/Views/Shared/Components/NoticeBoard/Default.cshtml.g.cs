#pragma checksum "C:\Users\HP\Desktop\BackEnd\ElmirProje\Views\Shared\Components\NoticeBoard\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d5e45949071616ece5ebcdb0a313c777b6ba461f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_NoticeBoard_Default), @"mvc.1.0.view", @"/Views/Shared/Components/NoticeBoard/Default.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\HP\Desktop\BackEnd\ElmirProje\Views\_ViewImports.cshtml"
using ElmirProje.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5e45949071616ece5ebcdb0a313c777b6ba461f", @"/Views/Shared/Components/NoticeBoard/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"29ef22ffa81ee50f0ae1d3033a11c9ec7eff0742", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_NoticeBoard_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<NoticeBoard>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<div class=""row"">
    <div class=""col-md-6 col-sm-6 col-xs-12"">
        <div class=""notice-right-wrapper mb-25 pb-25"">
            <h3>TAKE A VIDEO TOUR</h3>
            <div class=""notice-video"">
                <div class=""video-icon video-hover"">
                    <a class=""video-popup"" href=""https://www.youtube.com/watch?v=to6Ghf8UL7o"">
                        <i class=""zmdi zmdi-play""></i>
                    </a>
                </div>
            </div>
        </div>
    </div>
    <div class=""col-md-6 col-sm-6 col-xs-12"">
        <div class=""notice-left-wrapper"">
            <h3>notice board</h3>
            <div class=""notice-left"">
");
#nullable restore
#line 21 "C:\Users\HP\Desktop\BackEnd\ElmirProje\Views\Shared\Components\NoticeBoard\Default.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"single-notice-left mb-23 pb-20\">\n        <h4>");
#nullable restore
#line 24 "C:\Users\HP\Desktop\BackEnd\ElmirProje\Views\Shared\Components\NoticeBoard\Default.cshtml"
       Write(item.Date.ToString("dd MMMM"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\n        <p>");
#nullable restore
#line 25 "C:\Users\HP\Desktop\BackEnd\ElmirProje\Views\Shared\Components\NoticeBoard\Default.cshtml"
      Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n    </div>");
#nullable restore
#line 26 "C:\Users\HP\Desktop\BackEnd\ElmirProje\Views\Shared\Components\NoticeBoard\Default.cshtml"
          }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </div>\n        </div>\n    </div>\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<NoticeBoard>> Html { get; private set; }
    }
}
#pragma warning restore 1591
