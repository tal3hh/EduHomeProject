#pragma checksum "C:\Users\HP\Desktop\BackEnd\ElmirProje\Areas\Admin\Views\CourseFeatures\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3e6e75da73f059c5b2a357ed398f2f1a1e704654"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_CourseFeatures_Details), @"mvc.1.0.view", @"/Areas/Admin/Views/CourseFeatures/Details.cshtml")]
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
#line 1 "C:\Users\HP\Desktop\BackEnd\ElmirProje\Areas\Admin\Views\_ViewImports.cshtml"
using ElmirProje.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e6e75da73f059c5b2a357ed398f2f1a1e704654", @"/Areas/Admin/Views/CourseFeatures/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92d2fe5fe10506ed27f78d0f85769725daabbb11", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_CourseFeatures_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CourseFeatures>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CourseFeaturesList", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "CourseFeatures", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-light"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3e6e75da73f059c5b2a357ed398f2f1a1e7046544918", async() => {
                WriteLiteral("\r\n    <div class=\"mb-3\">\r\n        <label class=\"form-label\">Course Title</label>\r\n        <div>\r\n            ");
#nullable restore
#line 8 "C:\Users\HP\Desktop\BackEnd\ElmirProje\Areas\Admin\Views\CourseFeatures\Details.cshtml"
       Write(Model.Course.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"mb-3\">\r\n        <label class=\"form-label\">Start</label>\r\n        <p>\r\n            ");
#nullable restore
#line 14 "C:\Users\HP\Desktop\BackEnd\ElmirProje\Areas\Admin\Views\CourseFeatures\Details.cshtml"
       Write(Model.Start);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </p>\r\n    </div>\r\n    <div class=\"mb-3\">\r\n        <label class=\"form-label\">Language</label>\r\n        <p>\r\n            ");
#nullable restore
#line 20 "C:\Users\HP\Desktop\BackEnd\ElmirProje\Areas\Admin\Views\CourseFeatures\Details.cshtml"
       Write(Model.Language);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </p>\r\n    </div>\r\n    <div class=\"mb-3\">\r\n        <label class=\"form-label\">Students</label>\r\n        <p>\r\n            ");
#nullable restore
#line 26 "C:\Users\HP\Desktop\BackEnd\ElmirProje\Areas\Admin\Views\CourseFeatures\Details.cshtml"
       Write(Model.Students);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </p>\r\n    </div>\r\n    <div class=\"mb-3\">\r\n        <label class=\"form-label\">ClassDuration</label>\r\n        <p>\r\n            ");
#nullable restore
#line 32 "C:\Users\HP\Desktop\BackEnd\ElmirProje\Areas\Admin\Views\CourseFeatures\Details.cshtml"
       Write(Model.ClassDuration);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </p>\r\n    </div>\r\n    <div class=\"mb-3\">\r\n        <label class=\"form-label\">Duration</label>\r\n        <p>\r\n            ");
#nullable restore
#line 38 "C:\Users\HP\Desktop\BackEnd\ElmirProje\Areas\Admin\Views\CourseFeatures\Details.cshtml"
       Write(Model.Duration);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </p>\r\n    </div>\r\n    <div class=\"mb-3\">\r\n        <label class=\"form-label\">CourseFee</label>\r\n        <p>\r\n            ");
#nullable restore
#line 44 "C:\Users\HP\Desktop\BackEnd\ElmirProje\Areas\Admin\Views\CourseFeatures\Details.cshtml"
       Write(Model.CourseFee);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </p>\r\n    </div>\r\n    <div class=\"mb-3\">\r\n        <label class=\"form-label\">SkillLevel</label>\r\n        <p>\r\n            ");
#nullable restore
#line 50 "C:\Users\HP\Desktop\BackEnd\ElmirProje\Areas\Admin\Views\CourseFeatures\Details.cshtml"
       Write(Model.SkillLevel);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </p>\r\n    </div>\r\n    <div class=\"mb-3\">\r\n        <label class=\"form-label\">Assesments</label>\r\n        <p>\r\n            ");
#nullable restore
#line 56 "C:\Users\HP\Desktop\BackEnd\ElmirProje\Areas\Admin\Views\CourseFeatures\Details.cshtml"
       Write(Model.Assesments);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </p>\r\n    </div>\r\n\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3e6e75da73f059c5b2a357ed398f2f1a1e7046548620", async() => {
                    WriteLiteral("Cancel");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CourseFeatures> Html { get; private set; }
    }
}
#pragma warning restore 1591
