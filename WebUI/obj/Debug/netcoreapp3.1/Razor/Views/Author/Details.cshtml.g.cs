#pragma checksum "C:\Users\90553\Desktop\kerem\kutuphane\WebUI\Views\Author\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6afbc24123810c3d4ed59b1f175edc516e37c532"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Author_Details), @"mvc.1.0.view", @"/Views/Author/Details.cshtml")]
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
#line 1 "C:\Users\90553\Desktop\kerem\kutuphane\WebUI\Views\_ViewImports.cshtml"
using WebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\90553\Desktop\kerem\kutuphane\WebUI\Views\_ViewImports.cshtml"
using WebUI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\90553\Desktop\kerem\kutuphane\WebUI\Views\_ViewImports.cshtml"
using kutuphane.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\90553\Desktop\kerem\kutuphane\WebUI\Views\_ViewImports.cshtml"
using Entity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6afbc24123810c3d4ed59b1f175edc516e37c532", @"/Views/Author/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b713321f9c76649aa17c316e42d7dcff4476621", @"/Views/_ViewImports.cshtml")]
    public class Views_Author_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Author>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\90553\Desktop\kerem\kutuphane\WebUI\Views\Author\Details.cshtml"
  
ViewData["Title"] = "Detail Author ";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"jumbotron jumbotron-fluid\">\r\n    <div class=\"container\">\r\n        <h1 class=\"display-4\">");
#nullable restore
#line 9 "C:\Users\90553\Desktop\kerem\kutuphane\WebUI\Views\Author\Details.cshtml"
                         Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 9 "C:\Users\90553\Desktop\kerem\kutuphane\WebUI\Views\Author\Details.cshtml"
                                     Write(Model.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>
        <p class=""lead"">This is a modified jumbotron that occupies the entire horizontal space of its parent.</p>
    </div>
</div>
<div class=""container"">
    <div class=""row"">       
        <div class=""col-md-12 p-0"">
           <table class=""table table-sm table-bordered table-striped"">          
                <tr>
                    <th>Name</th>
                    <td>");
#nullable restore
#line 19 "C:\Users\90553\Desktop\kerem\kutuphane\WebUI\Views\Author\Details.cshtml"
                   Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <th>Surname</th>\r\n                    <td>");
#nullable restore
#line 23 "C:\Users\90553\Desktop\kerem\kutuphane\WebUI\Views\Author\Details.cshtml"
                   Write(Model.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                \r\n           </table>\r\n         \r\n        </div>\r\n        \r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Author> Html { get; private set; }
    }
}
#pragma warning restore 1591
