#pragma checksum "C:\Projects\Afstudeerprototype\ThesisPrototype\ThesisPrototype\Views\Dashboard\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "317c0534dce3d9e4a65848ea0830ce2c29efb324"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dashboard_Details), @"mvc.1.0.view", @"/Views/Dashboard/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Dashboard/Details.cshtml", typeof(AspNetCore.Views_Dashboard_Details))]
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
#line 1 "C:\Projects\Afstudeerprototype\ThesisPrototype\ThesisPrototype\Views\Dashboard\Details.cshtml"
using ThesisPrototype.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"317c0534dce3d9e4a65848ea0830ce2c29efb324", @"/Views/Dashboard/Details.cshtml")]
    public class Views_Dashboard_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ChartViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/highcharts/highcharts.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/vitalets-datepicker/bootstrap-datepicker.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/vitalets-datepicker/datepicker.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(35, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Projects\Afstudeerprototype\ThesisPrototype\ThesisPrototype\Views\Dashboard\Details.cshtml"
  
    ViewData["Title"] = "Dashboard";

#line default
#line hidden
            BeginContext(111, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(169, 54, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9f1c3432a02841cbb487d89197cfebcc", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(223, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(225, 73, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0f89147f536640b5af67433af3d4aecd", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(298, 123, true);
            WriteLiteral("\r\n<script src=\"https://cdnjs.cloudflare.com/ajax/libs/highcharts/6.2.0/es-modules/masters/modules/boost.src.js\"></script>\r\n");
            EndContext();
            BeginContext(421, 73, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "58a1be8e3eea4b6298435e8b1d9440a1", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(494, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
            EndContext();
            BeginContext(526, 64, true);
            WriteLiteral("<div style=\"margin-bottom: 50px; text-align: center;\">\r\n    <h1>");
            EndContext();
            BeginContext(591, 16, false);
#line 18 "C:\Projects\Afstudeerprototype\ThesisPrototype\ThesisPrototype\Views\Dashboard\Details.cshtml"
   Write(ViewBag.ShipName);

#line default
#line hidden
            EndContext();
            BeginContext(607, 7, true);
            WriteLiteral(" (Imo: ");
            EndContext();
            BeginContext(615, 15, false);
#line 18 "C:\Projects\Afstudeerprototype\ThesisPrototype\ThesisPrototype\Views\Dashboard\Details.cshtml"
                           Write(ViewBag.ShipImo);

#line default
#line hidden
            EndContext();
            BeginContext(630, 3019, true);
            WriteLiteral(@") - Overview</h1>
</div>

<div class=""card mx-auto"" style=""width: 40rem; margin-bottom: 40px;"">
  <div class=""card-header"">
    Chart controls
  </div>

  <div class=""card-body"">
        <div class=""row"">
            <div class=""col-xs chartControlInput "">
                <label for=""beginDateInput"">From:</label>
                
                <!-- mm-dd-yyyy because JavaScript does not exactly excell at date parsing, and can only take this format... -->
                <div class=""input-append date"" style=""margin-bottom: -15px;"" id=""beginDate"" data-date-format=""mm-dd-yyyy"">
                    <input class=""span2"" size=""16"" type=""text"" id=""beginDateInput"">
                    <span class=""add-on""><i class=""icon-th""></i></span>
                </div>
                <small class=""form-text text-muted"">(MM-DD-YYYY)</small>
            </div>

            <div class=""col-xs chartControlInput "">
                <label for=""endDateInput"">To:</label>

                <!-- mm-dd-yyyy becau");
            WriteLiteral(@"se JavaScript does not exactly excell at date parsing, and can only take this format... -->
                <div class=""input-append date"" style=""margin-bottom: -15px;"" id=""endDate"" data-date-format=""mm-dd-yyyy"">
                    <input class=""span2"" size=""16"" type=""text"" id=""endDateInput"">
                    <span class=""add-on""><i class=""icon-th""></i></span>
                </div>
                <small class=""form-text text-muted"">(MM-DD-YYYY)</small>
            </div>
        </div>

        <div class=""row"">
            <div class=""col-xs chartControlInput"">
                <button id=""loadInteractiveChartButton"" class=""btn btn-light"">Reload charts</button>
            </div>
        </div>

        <div class=""row"" >
            <div id=""inputAlert"" class=""alert alert-danger"" style=""display: none; margin-top: 20px;"" role=""alert"">
                <strong>Please enter a valid date.</strong> 
            </div>
        </div>
    </div>
</div>

<script type=""text/javascript"">
 ");
            WriteLiteral(@"   $(document).ready(function() {
        //Setting datepicker starting vals
        $('#beginDate').datepicker({
            startDate: '1-1-2000',
            endDate: new Date()
        });

        $('#endDate').datepicker({
            startDate: '1-1-2000',
            endDate: new Date()
        });
        
        // (re)load chart click handler
        $('#loadInteractiveChartButton').click(function () {
            $('#inputAlert').css({display: ""none""});

            // checking inputs
            if($('#beginDateInput').val() == """" || $('#endDateInput').val() == """")
            {
                $('#inputAlert').css({display: ""block""});
            }
            else
            {
                var fromDateUnixMilliTs = Date.parse($('#beginDateInput').val());
                var endDateUnixMilliTs = Date.parse($('#endDateInput').val());

                $.ajax({
                    url: ""/Dashboard/GetCharts?shipId=");
            EndContext();
            BeginContext(3650, 14, false);
#line 93 "C:\Projects\Afstudeerprototype\ThesisPrototype\ThesisPrototype\Views\Dashboard\Details.cshtml"
                                                 Write(ViewBag.ShipId);

#line default
#line hidden
            EndContext();
            BeginContext(3664, 620, true);
            WriteLiteral(@"&rangeBeginTs="" + fromDateUnixMilliTs + ""&rangeEndTs="" + endDateUnixMilliTs,
                    dataType: ""json""
                })
                .done(function (ret) {
                    for(var i = 0; i < ret.length; i++) {
                        var currChartJson = ret[i];
                        CreateKpiChart(currChartJson.id, 
                                       'spline', 
                                       currChartJson.title, 
                                       currChartJson.series);
                    };
                });
            }
        });
    });
</script>


");
            EndContext();
#line 112 "C:\Projects\Afstudeerprototype\ThesisPrototype\ThesisPrototype\Views\Dashboard\Details.cshtml"
 foreach (var defaultChart in @Model)
{

#line default
#line hidden
            BeginContext(4378, 8, true);
            WriteLiteral("    <div");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 4386, "\"", 4407, 1);
#line 114 "C:\Projects\Afstudeerprototype\ThesisPrototype\ThesisPrototype\Views\Dashboard\Details.cshtml"
WriteAttributeValue("", 4391, defaultChart.Id, 4391, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4408, 69, true);
            WriteLiteral("></div>\r\n    <script type=\"text/javascript\">\r\n        CreateKpiChart(");
            EndContext();
            BeginContext(4478, 15, false);
#line 116 "C:\Projects\Afstudeerprototype\ThesisPrototype\ThesisPrototype\Views\Dashboard\Details.cshtml"
                  Write(defaultChart.Id);

#line default
#line hidden
            EndContext();
            BeginContext(4493, 61, true);
            WriteLiteral(",\r\n                       \'spline\', \r\n                       ");
            EndContext();
            BeginContext(4555, 45, false);
#line 118 "C:\Projects\Afstudeerprototype\ThesisPrototype\ThesisPrototype\Views\Dashboard\Details.cshtml"
                  Write(Html.Raw(Json.Serialize(@defaultChart.title)));

#line default
#line hidden
            EndContext();
            BeginContext(4600, 27, true);
            WriteLiteral(", \r\n                       ");
            EndContext();
            BeginContext(4628, 46, false);
#line 119 "C:\Projects\Afstudeerprototype\ThesisPrototype\ThesisPrototype\Views\Dashboard\Details.cshtml"
                  Write(Html.Raw(Json.Serialize(@defaultChart.series)));

#line default
#line hidden
            EndContext();
            BeginContext(4674, 19, true);
            WriteLiteral(");\r\n    </script>\r\n");
            EndContext();
#line 121 "C:\Projects\Afstudeerprototype\ThesisPrototype\ThesisPrototype\Views\Dashboard\Details.cshtml"
}

#line default
#line hidden
            BeginContext(4696, 2, true);
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ChartViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
