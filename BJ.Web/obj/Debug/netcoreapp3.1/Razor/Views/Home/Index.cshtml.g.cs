#pragma checksum "D:\9raya\ESPRIT\4TWIN\2 SEM\.NET\ProductStore.NET\BJ.Web\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f1d13a9d0d523e88c90d345d53674dc157778f8b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "D:\9raya\ESPRIT\4TWIN\2 SEM\.NET\ProductStore.NET\BJ.Web\Views\_ViewImports.cshtml"
using BJ.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\9raya\ESPRIT\4TWIN\2 SEM\.NET\ProductStore.NET\BJ.Web\Views\_ViewImports.cshtml"
using BJ.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1d13a9d0d523e88c90d345d53674dc157778f8b", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"868d266ed50169ec5ebb9b3cf06b6c51f378da71", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BJ.Domain.Product>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\9raya\ESPRIT\4TWIN\2 SEM\.NET\ProductStore.NET\BJ.Web\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Welcome</h1>\r\n    <p>Learn about <a href=\"https://docs.microsoft.com/aspnet/core\">building Web apps with ASP.NET Core</a>.</p>\r\n    <br />\r\n");
#nullable restore
#line 11 "D:\9raya\ESPRIT\4TWIN\2 SEM\.NET\ProductStore.NET\BJ.Web\Views\Home\Index.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h3>Name : ");
#nullable restore
#line 13 "D:\9raya\ESPRIT\4TWIN\2 SEM\.NET\ProductStore.NET\BJ.Web\Views\Home\Index.cshtml"
                  Write(item.Label);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n           <br/>\r\n");
#nullable restore
#line 15 "D:\9raya\ESPRIT\4TWIN\2 SEM\.NET\ProductStore.NET\BJ.Web\Views\Home\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h3>");
#nullable restore
#line 16 "D:\9raya\ESPRIT\4TWIN\2 SEM\.NET\ProductStore.NET\BJ.Web\Views\Home\Index.cshtml"
   Write(ViewBag.Number);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n    <h3>");
#nullable restore
#line 17 "D:\9raya\ESPRIT\4TWIN\2 SEM\.NET\ProductStore.NET\BJ.Web\Views\Home\Index.cshtml"
   Write(ViewData["Numero"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BJ.Domain.Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591