#pragma checksum "C:\Users\Edd\source\repos\TestApp\TestApp\Views\Home\TestPost.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8e2e6ff03064d8b146697cc5e999b52e04c7bf90"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_TestPost), @"mvc.1.0.view", @"/Views/Home/TestPost.cshtml")]
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
#line 1 "C:\Users\Edd\source\repos\TestApp\TestApp\Views\_ViewImports.cshtml"
using TestApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Edd\source\repos\TestApp\TestApp\Views\_ViewImports.cshtml"
using TestApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e2e6ff03064d8b146697cc5e999b52e04c7bf90", @"/Views/Home/TestPost.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e25db771d30abaf29d3599c25e6deb12289bab6e", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_TestPost : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Person>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "TestPost", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\Edd\source\repos\TestApp\TestApp\Views\Home\TestPost.cshtml"
 if (ViewData["Error"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("     <div class=\"alert-danger\" role=\"alert\">");
#nullable restore
#line 9 "C:\Users\Edd\source\repos\TestApp\TestApp\Views\Home\TestPost.cshtml"
                                       Write(ViewData["Error"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 10 "C:\Users\Edd\source\repos\TestApp\TestApp\Views\Home\TestPost.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<!-- Formulario basico-->\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8e2e6ff03064d8b146697cc5e999b52e04c7bf904898", async() => {
                WriteLiteral(@"

    <label for=""name"">Name:</label>
    <input type=""text"" id=""name"" name=""name"" placeholder=""Input your name"" /><br />

    <label for=""age"">Age:</label>
    <input type=""number"" id=""age"" name=""age"" placeholder=""Input age"" /><br />

    <label for=""check"">Hobbies:</label><br />
    MTB<input type=""checkbox"" name=""check1"" value=""mtb"" /><br />
    Chess<input type=""checkbox"" name=""check2"" value=""chess"" /><br />
    Cinema<input type=""checkbox"" name=""check3"" value=""cinema"" /><br />

    <label for=""radio"">Radio:</label><br />
    MX <input type=""radio"" id=""Radio"" name=""country"" value=""MX"" /><br />
    US <input type=""radio"" id=""Radio"" name=""country"" value=""US"" /><br />
    CA <input type=""radio"" id=""Radio"" name=""country"" value=""CA"" /><br />

    <label for=""datetime"">Date:</label>
    <input type=""datetime"" /><br />

    <label for=""password"">Password:</label>
    <input type=""password"" /><br />



    <input type=""submit"" value=""Enviar"" />
");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 41 "C:\Users\Edd\source\repos\TestApp\TestApp\Views\Home\TestPost.cshtml"
 if (Model != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\r\n        <h1>\r\n            Persona\r\n        </h1>\r\n\r\n        <p>\r\n            ");
#nullable restore
#line 49 "C:\Users\Edd\source\repos\TestApp\TestApp\Views\Home\TestPost.cshtml"
       Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n            ");
#nullable restore
#line 50 "C:\Users\Edd\source\repos\TestApp\TestApp\Views\Home\TestPost.cshtml"
       Write(Model.Age);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </p>\r\n\r\n    </div>\r\n");
#nullable restore
#line 54 "C:\Users\Edd\source\repos\TestApp\TestApp\Views\Home\TestPost.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Person> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591