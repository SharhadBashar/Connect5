#pragma checksum "C:\Users\sbashar\Connect\src\Montrium.Connect.PDF.Web\Views\Downloads\index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b854695d5714e552c9be89c8505923e22566d0f0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Downloads_index), @"mvc.1.0.view", @"/Views/Downloads/index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Downloads/index.cshtml", typeof(AspNetCore.Views_Downloads_index))]
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
#line 1 "C:\Users\sbashar\Connect\src\Montrium.Connect.PDF.Web\Views\_ViewImports.cshtml"
using Montrium.Connect.PDF.Web;

#line default
#line hidden
#line 2 "C:\Users\sbashar\Connect\src\Montrium.Connect.PDF.Web\Views\_ViewImports.cshtml"
using Montrium.Connect.PDF.Web.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b854695d5714e552c9be89c8505923e22566d0f0", @"/Views/Downloads/index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9fb50589b3ce452d54045208941925d7b32a0e14", @"/Views/_ViewImports.cshtml")]
    public class Views_Downloads_index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DownloadItem>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\sbashar\Connect\src\Montrium.Connect.PDF.Web\Views\Downloads\index.cshtml"
  
    ViewData["Title"] = "Downloads";

#line default
#line hidden
            BeginContext(79, 238, true);
            WriteLiteral("\r\n<div class=\"row\">\r\n    <h2>Downloads</h2>\r\n    <table class=\"table table-condensed\">\r\n        <thead>\r\n            <tr>\r\n                <th>Name</th>\r\n                <th>PDF</th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
            EndContext();
#line 16 "C:\Users\sbashar\Connect\src\Montrium.Connect.PDF.Web\Views\Downloads\index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
            BeginContext(374, 46, true);
            WriteLiteral("                <tr>\r\n                    <td>");
            EndContext();
            BeginContext(421, 9, false);
#line 19 "C:\Users\sbashar\Connect\src\Montrium.Connect.PDF.Web\Views\Downloads\index.cshtml"
                   Write(item.Name);

#line default
#line hidden
            EndContext();
            BeginContext(430, 33, true);
            WriteLiteral("</td>\r\n                    <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 463, "\"", 479, 1);
#line 20 "C:\Users\sbashar\Connect\src\Montrium.Connect.PDF.Web\Views\Downloads\index.cshtml"
WriteAttributeValue("", 470, item.Url, 470, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(480, 43, true);
            WriteLiteral(">Download</a></td>\r\n                </tr>\r\n");
            EndContext();
#line 22 "C:\Users\sbashar\Connect\src\Montrium.Connect.PDF.Web\Views\Downloads\index.cshtml"
            }

#line default
#line hidden
            BeginContext(538, 38, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DownloadItem>> Html { get; private set; }
    }
}
#pragma warning restore 1591
