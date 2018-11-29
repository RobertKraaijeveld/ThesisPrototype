#pragma checksum "C:\Projects\Afstudeerprototype\ThesisPrototype\Views\Dashboard\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "521c332a41bc37993365e6b87e1e97cfbe65a067"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dashboard_Index), @"mvc.1.0.view", @"/Views/Dashboard/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Dashboard/Index.cshtml", typeof(AspNetCore.Views_Dashboard_Index))]
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
#line 1 "C:\Projects\Afstudeerprototype\ThesisPrototype\Views\Dashboard\Index.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Projects\Afstudeerprototype\ThesisPrototype\Views\Dashboard\Index.cshtml"
using ThesisPrototype;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"521c332a41bc37993365e6b87e1e97cfbe65a067", @"/Views/Dashboard/Index.cshtml")]
    public class Views_Dashboard_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<VesselViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(62, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(103, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 6 "C:\Projects\Afstudeerprototype\ThesisPrototype\Views\Dashboard\Index.cshtml"
  User currentUser = await UserManager.GetUserAsync(User);

#line default
#line hidden
            BeginContext(203, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 9 "C:\Projects\Afstudeerprototype\ThesisPrototype\Views\Dashboard\Index.cshtml"
  
    ViewData["Title"] = "Dashboard";

#line default
#line hidden
            BeginContext(250, 15, true);
            WriteLiteral("\r\n<h2>Welcome, ");
            EndContext();
            BeginContext(266, 21, false);
#line 13 "C:\Projects\Afstudeerprototype\ThesisPrototype\Views\Dashboard\Index.cshtml"
        Write(currentUser.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(287, 35, true);
            WriteLiteral("!</h2>\r\n\r\n<div class=\"container\">\r\n");
            EndContext();
#line 16 "C:\Projects\Afstudeerprototype\ThesisPrototype\Views\Dashboard\Index.cshtml"
     foreach (var vesselViewModelGroup in Model.Split(3))
    {

#line default
#line hidden
            BeginContext(388, 27, true);
            WriteLiteral("        <div class=\"row\">\r\n");
            EndContext();
#line 19 "C:\Projects\Afstudeerprototype\ThesisPrototype\Views\Dashboard\Index.cshtml"
         foreach(var vesselViewModel in vesselViewModelGroup)
        {

#line default
#line hidden
            BeginContext(489, 137, true);
            WriteLiteral("            <div class=\"card col-xs\" style=\"margin-right: 10px;\">\r\n                <img class=\"card-img-top\" height=\"100px\" width=\"100px\"");
            EndContext();
            BeginWriteAttribute("src", " src=", 626, "", 684, 1);
#line 22 "C:\Projects\Afstudeerprototype\ThesisPrototype\Views\Dashboard\Index.cshtml"
WriteAttributeValue("", 631, Url.Content("~/images/"+ @vesselViewModel.ImageName), 631, 53, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(684, 63, true);
            WriteLiteral(" />\r\n                \r\n                <h5 class=\"card-header\">");
            EndContext();
            BeginContext(748, 24, false);
#line 24 "C:\Projects\Afstudeerprototype\ThesisPrototype\Views\Dashboard\Index.cshtml"
                                   Write(vesselViewModel.ShipName);

#line default
#line hidden
            EndContext();
            BeginContext(772, 169, true);
            WriteLiteral("</h5>\r\n                <div class=\"card-body\">   \r\n                    <a href=\"#\" class=\"btn btn-primary\">View details</a>\r\n                </div>\r\n            </div>\r\n");
            EndContext();
#line 29 "C:\Projects\Afstudeerprototype\ThesisPrototype\Views\Dashboard\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(952, 16, true);
            WriteLiteral("        </div>\r\n");
            EndContext();
#line 31 "C:\Projects\Afstudeerprototype\ThesisPrototype\Views\Dashboard\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(975, 6, true);
            WriteLiteral("</div>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<User> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<VesselViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
