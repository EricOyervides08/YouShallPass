#pragma checksum "/Users/diegopinones/Documents/TestApp/TestApp/TestApp/Views/Shared/Test.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "43298c6dce38be43c80a510992cec44bbcdffaed"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Test), @"mvc.1.0.view", @"/Views/Shared/Test.cshtml")]
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
#line 1 "/Users/diegopinones/Documents/TestApp/TestApp/TestApp/Views/_ViewImports.cshtml"
using TestApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/diegopinones/Documents/TestApp/TestApp/TestApp/Views/_ViewImports.cshtml"
using TestApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"43298c6dce38be43c80a510992cec44bbcdffaed", @"/Views/Shared/Test.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e25db771d30abaf29d3599c25e6deb12289bab6e", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Test : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Player>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1> Test</h1>\r\n\r\n<ul class=\"list-group\">\r\n");
#nullable restore
#line 5 "/Users/diegopinones/Documents/TestApp/TestApp/TestApp/Views/Shared/Test.cshtml"
     for (int i = 0; i < (int)ViewData["times"]; i++)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"list-group-item\"> \r\n            hola ");
#nullable restore
#line 8 "/Users/diegopinones/Documents/TestApp/TestApp/TestApp/Views/Shared/Test.cshtml"
            Write(Model.Nickname);

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n            <span class=\"badge badge-primary badge-pill\"> ");
#nullable restore
#line 9 "/Users/diegopinones/Documents/TestApp/TestApp/TestApp/Views/Shared/Test.cshtml"
                                                     Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span>\r\n        </li>\r\n");
#nullable restore
#line 11 "/Users/diegopinones/Documents/TestApp/TestApp/TestApp/Views/Shared/Test.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Player> Html { get; private set; }
    }
}
#pragma warning restore 1591