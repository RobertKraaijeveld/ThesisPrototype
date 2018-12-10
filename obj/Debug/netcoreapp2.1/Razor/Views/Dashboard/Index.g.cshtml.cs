#pragma checksum "C:\Projects\Afstudeerprototype\ThesisPrototype\Views\Dashboard\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c1820861b30b7837e1d4bccfb90c2a937f7b5f3b"
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
using ThesisPrototype.Utilities;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c1820861b30b7837e1d4bccfb90c2a937f7b5f3b", @"/Views/Dashboard/Index.cshtml")]
    public class Views_Dashboard_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ThesisPrototype.ViewModels.ShipViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(34, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(98, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 5 "C:\Projects\Afstudeerprototype\ThesisPrototype\Views\Dashboard\Index.cshtml"
  
    ViewData["Title"] = "Dashboard";

#line default
#line hidden
            BeginContext(145, 15, true);
            WriteLiteral("\r\n<h2>Welcome, ");
            EndContext();
            BeginContext(161, 18, false);
#line 9 "C:\Projects\Afstudeerprototype\ThesisPrototype\Views\Dashboard\Index.cshtml"
        Write(User.Identity.Name);

#line default
#line hidden
            EndContext();
            BeginContext(179, 35, true);
            WriteLiteral("!</h2>\r\n\r\n<div class=\"container\">\r\n");
            EndContext();
#line 12 "C:\Projects\Afstudeerprototype\ThesisPrototype\Views\Dashboard\Index.cshtml"
       bool addNewShipCardHasBeenDrawn = false; 

#line default
#line hidden
            BeginContext(265, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 14 "C:\Projects\Afstudeerprototype\ThesisPrototype\Views\Dashboard\Index.cshtml"
     foreach (var vesselViewModelGroup in Model.Split(6))
    {

#line default
#line hidden
            BeginContext(333, 23, true);
            WriteLiteral("    <div class=\"row\">\r\n");
            EndContext();
#line 17 "C:\Projects\Afstudeerprototype\ThesisPrototype\Views\Dashboard\Index.cshtml"
         foreach (var vesselViewModel in vesselViewModelGroup)
        {

#line default
#line hidden
            BeginContext(431, 94, true);
            WriteLiteral("            <div class=\"card col-xs shipThumbnail\">\r\n                <img class=\"card-img-top\"");
            EndContext();
            BeginWriteAttribute("src", " src=", 525, "", 584, 1);
#line 20 "C:\Projects\Afstudeerprototype\ThesisPrototype\Views\Dashboard\Index.cshtml"
WriteAttributeValue("", 530, Url.Content("~/images/" + @vesselViewModel.ImageName), 530, 54, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(584, 47, true);
            WriteLiteral(" />\r\n\r\n                <h5 class=\"card-header\">");
            EndContext();
            BeginContext(632, 24, false);
#line 22 "C:\Projects\Afstudeerprototype\ThesisPrototype\Views\Dashboard\Index.cshtml"
                                   Write(vesselViewModel.ShipName);

#line default
#line hidden
            EndContext();
            BeginContext(656, 2, true);
            WriteLiteral(" (");
            EndContext();
            BeginContext(659, 23, false);
#line 22 "C:\Projects\Afstudeerprototype\ThesisPrototype\Views\Dashboard\Index.cshtml"
                                                              Write(vesselViewModel.ShipImo);

#line default
#line hidden
            EndContext();
            BeginContext(682, 49, true);
            WriteLiteral(")</h5>\r\n                <div class=\"card-body\">\r\n");
            EndContext();
#line 25 "C:\Projects\Afstudeerprototype\ThesisPrototype\Views\Dashboard\Index.cshtml"
                     using (Html.BeginForm("DeleteShip", "Dashboard", FormMethod.Post))
                    {

#line default
#line hidden
            BeginContext(924, 44, true);
            WriteLiteral("                        <input type=\"hidden\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 968, "\"", 999, 1);
#line 27 "C:\Projects\Afstudeerprototype\ThesisPrototype\Views\Dashboard\Index.cshtml"
WriteAttributeValue("", 976, vesselViewModel.ShipId, 976, 23, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1000, 229, true);
            WriteLiteral(" name=\"shipId\"/>\r\n                        <button type=\"submit\" class=\"btn cardBtn\" onclick=\"return confirm(\'Are you sure you wish to delete this ship?\');\">\r\n                            Delete\r\n                        </button>\r\n");
            EndContext();
#line 31 "C:\Projects\Afstudeerprototype\ThesisPrototype\Views\Dashboard\Index.cshtml"
                    }

#line default
#line hidden
            BeginContext(1252, 24, true);
            WriteLiteral("\r\n                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\'", 1276, "\'", 1351, 1);
#line 33 "C:\Projects\Afstudeerprototype\ThesisPrototype\Views\Dashboard\Index.cshtml"
WriteAttributeValue("", 1283, Url.RouteUrl("shipDetails", new {shipId = @vesselViewModel.ShipId}), 1283, 68, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1352, 119, true);
            WriteLiteral("\r\n                       class=\"btn btn-primary cardBtn\">View details</a>\r\n                </div>\r\n            </div>\r\n");
            EndContext();
#line 37 "C:\Projects\Afstudeerprototype\ThesisPrototype\Views\Dashboard\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(1482, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 39 "C:\Projects\Afstudeerprototype\ThesisPrototype\Views\Dashboard\Index.cshtml"
         if (vesselViewModelGroup.Count < 4)
        {
            { addNewShipCardHasBeenDrawn = true; }

            

#line default
#line hidden
            BeginContext(1608, 38, false);
#line 43 "C:\Projects\Afstudeerprototype\ThesisPrototype\Views\Dashboard\Index.cshtml"
       Write(Html.Partial("_CreateShipCard", Model));

#line default
#line hidden
            EndContext();
#line 43 "C:\Projects\Afstudeerprototype\ThesisPrototype\Views\Dashboard\Index.cshtml"
                                                   
        }

#line default
#line hidden
            BeginContext(1659, 12, true);
            WriteLiteral("    </div>\r\n");
            EndContext();
#line 46 "C:\Projects\Afstudeerprototype\ThesisPrototype\Views\Dashboard\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(1678, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(1813, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 54 "C:\Projects\Afstudeerprototype\ThesisPrototype\Views\Dashboard\Index.cshtml"
     if (addNewShipCardHasBeenDrawn == false)
    {
        

#line default
#line hidden
            BeginContext(1878, 38, false);
#line 56 "C:\Projects\Afstudeerprototype\ThesisPrototype\Views\Dashboard\Index.cshtml"
   Write(Html.Partial("_CreateShipCard", Model));

#line default
#line hidden
            EndContext();
#line 56 "C:\Projects\Afstudeerprototype\ThesisPrototype\Views\Dashboard\Index.cshtml"
                                               
    }

#line default
#line hidden
            BeginContext(1925, 8, true);
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ThesisPrototype.ViewModels.ShipViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
