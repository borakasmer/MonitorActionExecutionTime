#pragma checksum "/Users/borakasmer/Projects/ActionTotalTime/Views/Home/Report.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5630454039cbca1d30b4988dd1a79b4238d73f3e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Report), @"mvc.1.0.view", @"/Views/Home/Report.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Report.cshtml", typeof(AspNetCore.Views_Home_Report))]
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
#line 1 "/Users/borakasmer/Projects/ActionTotalTime/Views/_ViewImports.cshtml"
using ActionTotalTime;

#line default
#line hidden
#line 2 "/Users/borakasmer/Projects/ActionTotalTime/Views/_ViewImports.cshtml"
using ActionTotalTime.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5630454039cbca1d30b4988dd1a79b4238d73f3e", @"/Views/Home/Report.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b898485bf1ff96f040890ab96897fc291b6c02ea", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Report : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ReportModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(25, 70, true);
            WriteLiteral("\n<div id=\"visualization\" style=\"width: 800px; height: 600px;\"></div>\n\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(113, 377, true);
                WriteLiteral(@"
    <script type=""text/javascript"" src=""//www.google.com/jsapi""></script>
    <script type=""text/javascript"">
        google.load('visualization', '1', { packages: ['corechart'] });
    </script>
    <script type=""text/javascript"">
    function Report() {        
        var data = google.visualization.arrayToDataTable([
            ['Action', 'Seconds',{ role: 'style' }],
");
                EndContext();
#line 14 "/Users/borakasmer/Projects/ActionTotalTime/Views/Home/Report.cshtml"
             foreach (var item in Model)
            {
                var random = new Random();
                var color = String.Format("#{0:X6}", random.Next(0x1000000));
                

#line default
#line hidden
                BeginContext(688, 2, true);
                WriteLiteral("[\'");
                EndContext();
                BeginContext(691, 9, false);
#line 18 "/Users/borakasmer/Projects/ActionTotalTime/Views/Home/Report.cshtml"
                   Write(item.Name);

#line default
#line hidden
                EndContext();
                BeginContext(700, 3, true);
                WriteLiteral("\', ");
                EndContext();
                BeginContext(704, 17, false);
#line 18 "/Users/borakasmer/Projects/ActionTotalTime/Views/Home/Report.cshtml"
                                Write(item.TotalSeconds);

#line default
#line hidden
                EndContext();
                BeginContext(721, 2, true);
                WriteLiteral(",\'");
                EndContext();
                BeginContext(724, 5, false);
#line 18 "/Users/borakasmer/Projects/ActionTotalTime/Views/Home/Report.cshtml"
                                                    Write(color);

#line default
#line hidden
                EndContext();
                BeginContext(729, 3, true);
                WriteLiteral("\'],");
                EndContext();
#line 18 "/Users/borakasmer/Projects/ActionTotalTime/Views/Home/Report.cshtml"
                                                                         
            }

#line default
#line hidden
                BeginContext(754, 1165, true);
                WriteLiteral(@"        ]);
        
        var options = { 
            animation:{
            startup:true,
            duration: 1000,
            easing: 'out',
        },  
        curveType: 'function'
        , smoothline: 'true'
        , width: 800
        , height: 600
        , title: 'All Action Total Seconds'
        , legend: {position: 'none'}
        ,vAxis: {minValue:0,title:'Total Seconds',titleTextStyle: {color: 'red'}}       
        ,hAxis: {title:'Actions',titleTextStyle: {color: 'blue'}}                   
 };
        var chartPerformance=new google.visualization.ColumnChart(document.getElementById('visualization'));

        function selectAction() {
          var selectedBar = chartPerformance.getSelection()[0];
          if (selectedBar) {
            var selectedAction = data.getValue(selectedBar.row, 0); 
            window.location.href=""/Home/Detail/""+selectedAction.replace(/\//g,'_');            
          }
        }

        google.visualization.events.addListener(chartPerformance, 'select'");
                WriteLiteral(", selectAction);  \n        chartPerformance.draw(data, options);\n      }\n      \n      google.setOnLoadCallback(Report);       \n    </script>\n");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ReportModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
