#pragma checksum "D:\CSharp projects\WarehouseApp\WarehouseApp\Views\Users\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ae722f4c9cb091542dcd21b93e4987a09b7e2c44"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Users_Login), @"mvc.1.0.view", @"/Views/Users/Login.cshtml")]
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
#line 1 "D:\CSharp projects\WarehouseApp\WarehouseApp\Views\_ViewImports.cshtml"
using WarehouseApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\CSharp projects\WarehouseApp\WarehouseApp\Views\_ViewImports.cshtml"
using WarehouseApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae722f4c9cb091542dcd21b93e4987a09b7e2c44", @"/Views/Users/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b3645009538b736d023dd1135a6442948d13793", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Users_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WarehouseApp.Models.LoginVM>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Users/Login"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\CSharp projects\WarehouseApp\WarehouseApp\Views\Users\Login.cshtml"
  
    ViewData["Title"] = "Login";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <br />\r\n    <h1 class=\"display-4\">Login</h1>\r\n    <br />\r\n    <br />\r\n</div>\r\n<div class=\"d-flex justify-content-center\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ae722f4c9cb091542dcd21b93e4987a09b7e2c444273", async() => {
                WriteLiteral("\r\n        <div class=\"form-group\" style=\"width: 22rem;\">\r\n            <label for=\"username\">Username</label>\r\n            ");
#nullable restore
#line 16 "D:\CSharp projects\WarehouseApp\WarehouseApp\Views\Users\Login.cshtml"
       Write(Html.TextBoxFor(m => m.Username,new {@class = "form-control"}));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n        <div class=\"form-group\" style=\"width: 22rem;\">\r\n            ");
#nullable restore
#line 19 "D:\CSharp projects\WarehouseApp\WarehouseApp\Views\Users\Login.cshtml"
       Write(Html.ValidationMessageFor(m => m.Username, null, new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n        <div class=\"form-group\" style=\"width: 22rem;\">\r\n            <label for=\"password\">Password</label>\r\n            ");
#nullable restore
#line 23 "D:\CSharp projects\WarehouseApp\WarehouseApp\Views\Users\Login.cshtml"
       Write(Html.PasswordFor(m => m.Password,new {@class = "form-control"}));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n        <div class=\"form-group\" style=\"width: 22rem;\">\r\n            ");
#nullable restore
#line 26 "D:\CSharp projects\WarehouseApp\WarehouseApp\Views\Users\Login.cshtml"
       Write(Html.ValidationMessageFor(m => m.Password, null, new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
        </div>
        <br />
        <div class=""d-flex justify-content-center"">
            <button type=""submit"" class=""btn btn-primary"">Login</button>
        </div>
        <br />
        <div class=""form-group"" style=""width: 22rem;"">
            ");
#nullable restore
#line 34 "D:\CSharp projects\WarehouseApp\WarehouseApp\Views\Users\Login.cshtml"
       Write(Html.ValidationMessage("AuthenticationFailed", null, new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n        <div class=\"form-group\" style=\"width: 22rem;\">\r\n            <br />\r\n            <br />\r\n            <p>Don\'t have an account? <a href=\"/Users/Register\">Create one from here!</a></p>\r\n        </div>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WarehouseApp.Models.LoginVM> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591