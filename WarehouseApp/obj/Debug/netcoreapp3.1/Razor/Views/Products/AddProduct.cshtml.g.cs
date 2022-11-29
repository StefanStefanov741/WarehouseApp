#pragma checksum "D:\CSharp projects\WarehouseApp\WarehouseApp\Views\Products\AddProduct.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9adf84d87df54d99518c275ebbc0ff77e6fc8952"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Products_AddProduct), @"mvc.1.0.view", @"/Views/Products/AddProduct.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9adf84d87df54d99518c275ebbc0ff77e6fc8952", @"/Views/Products/AddProduct.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b3645009538b736d023dd1135a6442948d13793", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Products_AddProduct : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WarehouseApp.Models.NewProductVM>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Products/AddProduct"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "D:\CSharp projects\WarehouseApp\WarehouseApp\Views\Products\AddProduct.cshtml"
  
    ViewData["Title"] = "Add a new product";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <br />\r\n    <h1 class=\"display-4\">Add a new product</h1>\r\n    <br />\r\n    <br />\r\n</div>\r\n<div class=\"d-flex justify-content-center\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9adf84d87df54d99518c275ebbc0ff77e6fc89524719", async() => {
                WriteLiteral("\r\n        <div class=\"form-group\" style=\"width: 40rem;\">\r\n            <label for=\"name\">Name</label>\r\n            ");
#nullable restore
#line 16 "D:\CSharp projects\WarehouseApp\WarehouseApp\Views\Products\AddProduct.cshtml"
       Write(Html.ValidationMessageFor(m => m.Name, null, new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            ");
#nullable restore
#line 17 "D:\CSharp projects\WarehouseApp\WarehouseApp\Views\Products\AddProduct.cshtml"
       Write(Html.TextBoxFor(m => m.Name, new { @placeholder = "Name", @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n        <div class=\"form-group\" style=\"width: 40rem;\">\r\n            <label for=\"buy_price\">Buy Price (in euro)</label>\r\n            ");
#nullable restore
#line 21 "D:\CSharp projects\WarehouseApp\WarehouseApp\Views\Products\AddProduct.cshtml"
       Write(Html.ValidationMessageFor(m => m.BuyPrice, null, new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            ");
#nullable restore
#line 22 "D:\CSharp projects\WarehouseApp\WarehouseApp\Views\Products\AddProduct.cshtml"
       Write(Html.TextBoxFor(m => m.BuyPrice, new { @placeholder = "Buy Price", @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n        <div class=\"form-group\" style=\"width: 40rem;\">\r\n            <label for=\"sell_price\">Sell Price (in euro)</label>\r\n            ");
#nullable restore
#line 26 "D:\CSharp projects\WarehouseApp\WarehouseApp\Views\Products\AddProduct.cshtml"
       Write(Html.ValidationMessageFor(m => m.SellPrice, null, new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            ");
#nullable restore
#line 27 "D:\CSharp projects\WarehouseApp\WarehouseApp\Views\Products\AddProduct.cshtml"
       Write(Html.TextBoxFor(m => m.SellPrice, new { @placeholder = "Sell Price", @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n        <div class=\"form-group\" style=\"width: 40rem;\">\r\n            <label for=\"quantity\">Quantity (units)</label>\r\n            ");
#nullable restore
#line 31 "D:\CSharp projects\WarehouseApp\WarehouseApp\Views\Products\AddProduct.cshtml"
       Write(Html.ValidationMessageFor(m => m.Quantity, null, new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            ");
#nullable restore
#line 32 "D:\CSharp projects\WarehouseApp\WarehouseApp\Views\Products\AddProduct.cshtml"
       Write(Html.TextBoxFor(m => m.Quantity, new { @placeholder = "Quantity", @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n        <div class=\"form-group\" style=\"width: 40rem;\">\r\n            <label for=\"category\">Category</label>\r\n            ");
#nullable restore
#line 36 "D:\CSharp projects\WarehouseApp\WarehouseApp\Views\Products\AddProduct.cshtml"
       Write(Html.DropDownListFor(m => m.Category, new List<SelectListItem>
                    {
                          new SelectListItem { Text = "Хранителни стоки", Value = "Хранителни стоки", Selected=true},
                          new SelectListItem { Text = "Канцеларски материали", Value = "Канцеларски материали"},
                          new SelectListItem { Text = "Строителни материали", Value = "Строителни материали"}
                    }, new { @style = "width:40rem", @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n        <div class=\"form-group\" style=\"width: 40rem;\">\r\n            <label for=\"code\">Code</label>\r\n            ");
#nullable restore
#line 45 "D:\CSharp projects\WarehouseApp\WarehouseApp\Views\Products\AddProduct.cshtml"
       Write(Html.ValidationMessageFor(m => m.Code, null, new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            ");
#nullable restore
#line 46 "D:\CSharp projects\WarehouseApp\WarehouseApp\Views\Products\AddProduct.cshtml"
       Write(Html.TextBoxFor(m => m.Code, new { @placeholder = "Code", @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n        <div class=\"form-group\" style=\"width: 40rem;\">\r\n            <label for=\"description\">Description</label>\r\n            ");
#nullable restore
#line 50 "D:\CSharp projects\WarehouseApp\WarehouseApp\Views\Products\AddProduct.cshtml"
       Write(Html.TextAreaFor(m => m.Description, new {@placeholder="Description",@style= "resize: none; height: 10rem;", @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n        <div class=\"form-group\" style=\"width: 40rem;\">\r\n            <label for=\"image\">Image</label>\r\n            ");
#nullable restore
#line 54 "D:\CSharp projects\WarehouseApp\WarehouseApp\Views\Products\AddProduct.cshtml"
       Write(Html.TextBoxFor(m => m.Image, new { @class= "control-fileupload", @type = "file",@accept= "image/png, image/jpg, image/jpeg" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 57 "D:\CSharp projects\WarehouseApp\WarehouseApp\Views\Products\AddProduct.cshtml"
       Write(Html.ValidationMessage("NameValidation", null, new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            ");
#nullable restore
#line 58 "D:\CSharp projects\WarehouseApp\WarehouseApp\Views\Products\AddProduct.cshtml"
       Write(Html.ValidationMessage("BPValidation", null, new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            ");
#nullable restore
#line 59 "D:\CSharp projects\WarehouseApp\WarehouseApp\Views\Products\AddProduct.cshtml"
       Write(Html.ValidationMessage("SPValidation", null, new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            ");
#nullable restore
#line 60 "D:\CSharp projects\WarehouseApp\WarehouseApp\Views\Products\AddProduct.cshtml"
       Write(Html.ValidationMessage("QuantityValidation", null, new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            ");
#nullable restore
#line 61 "D:\CSharp projects\WarehouseApp\WarehouseApp\Views\Products\AddProduct.cshtml"
       Write(Html.ValidationMessage("CodeValidation", null, new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            ");
#nullable restore
#line 62 "D:\CSharp projects\WarehouseApp\WarehouseApp\Views\Products\AddProduct.cshtml"
       Write(Html.ValidationMessage("DescriptionValidation", null, new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n        <div class=\"d-flex justify-content-center\">\r\n            <button type=\"submit\" class=\"btn btn-primary\">Add</button>\r\n        </div>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WarehouseApp.Models.NewProductVM> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591