#pragma checksum "C:\Projects\Afstudeerprototype\ThesisPrototype\ThesisPrototype\Views\Dashboard\_CreateShipCard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fa1f56ed010a8c6fe0972a409b342f90a6e249fe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dashboard__CreateShipCard), @"mvc.1.0.view", @"/Views/Dashboard/_CreateShipCard.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Dashboard/_CreateShipCard.cshtml", typeof(AspNetCore.Views_Dashboard__CreateShipCard))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa1f56ed010a8c6fe0972a409b342f90a6e249fe", @"/Views/Dashboard/_CreateShipCard.cshtml")]
    public class Views_Dashboard__CreateShipCard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 119, true);
            WriteLiteral("\r\n<div id=\"createShipPanelPartialResult\"></div>\r\n\r\n<div class=\"card col-xs shipThumbnail\">\r\n\r\n    <img class=\"card-img\"");
            EndContext();
            BeginWriteAttribute("src", " src=", 119, "", 165, 1);
#line 6 "C:\Projects\Afstudeerprototype\ThesisPrototype\ThesisPrototype\Views\Dashboard\_CreateShipCard.cshtml"
WriteAttributeValue("", 124, Url.Content("~/images/add_new_icon.png"), 124, 41, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(165, 357, true);
            WriteLiteral(@" alt=""Add new ship"">

    <h5 class=""card-header"">Add new</h5>
    <div class=""card-body"">
        <button class=""btn btn-primary"" id=""getCreateNewShipPanelPartialBtn"">Add</button>
    </div>
</div>


<script type=""text/javascript"">
    $('#getCreateNewShipPanelPartialBtn').click(function () {
        console.log('Clicki');
        var url = '");
            EndContext();
            BeginContext(523, 39, false);
#line 18 "C:\Projects\Afstudeerprototype\ThesisPrototype\ThesisPrototype\Views\Dashboard\_CreateShipCard.cshtml"
              Write(Url.Action("GetCreateShipPanelPartial"));

#line default
#line hidden
            EndContext();
            BeginContext(562, 77, true);
            WriteLiteral("\';\r\n        $(\'#createShipPanelPartialResult\').load(url);\r\n    });\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
