#pragma checksum "C:\Development\SourceCode\Demo\DT2\DecisionTech\RM.Basket.Library\RM.Supermarket\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1e8ce7711be44bf4f1404856a50972ead029d346"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "C:\Development\SourceCode\Demo\DT2\DecisionTech\RM.Basket.Library\RM.Supermarket\Views\_ViewImports.cshtml"
using RM.Supermarket.Models;

#line default
#line hidden
#line 2 "C:\Development\SourceCode\Demo\DT2\DecisionTech\RM.Basket.Library\RM.Supermarket\Views\_ViewImports.cshtml"
using RM.Supermarket.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1e8ce7711be44bf4f1404856a50972ead029d346", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9969b844a1edb5601adcefaf4250a05396e9d6c4", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RM.Supermarket.ViewModels.HomeViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Basket", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddToBasket", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(48, 101, true);
            WriteLiteral("\r\n<div class=\"col-sm-12 col-md-12 col-lg-12\">\r\n  <div class=\"bottom-padding-small float-right\">\r\n    ");
            EndContext();
            BeginContext(149, 145, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "407fd7994f174ac9bf1dd15b9fc7b22f", async() => {
                BeginContext(253, 13, true);
                WriteLiteral("View Basket (");
                EndContext();
                BeginContext(267, 22, false);
#line 5 "C:\Development\SourceCode\Demo\DT2\DecisionTech\RM.Basket.Library\RM.Supermarket\Views\Home\Index.cshtml"
                                                                                                                    Write(Model.BasketItemsCount);

#line default
#line hidden
                EndContext();
                BeginContext(289, 1, true);
                WriteLiteral(")");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-basketId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 5 "C:\Development\SourceCode\Demo\DT2\DecisionTech\RM.Basket.Library\RM.Supermarket\Views\Home\Index.cshtml"
                                                                               WriteLiteral(Model.BasketId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["basketId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-basketId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["basketId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(294, 20, true);
            WriteLiteral("\r\n  </div>\r\n</div>\r\n");
            EndContext();
#line 8 "C:\Development\SourceCode\Demo\DT2\DecisionTech\RM.Basket.Library\RM.Supermarket\Views\Home\Index.cshtml"
   foreach (var product in Model.Products)
  {

#line default
#line hidden
            BeginContext(363, 109, true);
            WriteLiteral("  <div class=\"col-sm-4 col-md-4 col-lg-4\">\r\n    <div class=\"productdisplay\">\r\n      <img class=\"imgthumbnail\"");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 472, "\"", 504, 1);
#line 12 "C:\Development\SourceCode\Demo\DT2\DecisionTech\RM.Basket.Library\RM.Supermarket\Views\Home\Index.cshtml"
WriteAttributeValue("", 478, product.ImageThumbnailUrl, 478, 26, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(505, 136, true);
            WriteLiteral(" alt=\"\" />\r\n      <div class=\"caption\">\r\n        <div class=\"row\">\r\n          <div class=\"col-sm-6 col-md-6 col-lg-6\">\r\n            <h4>");
            EndContext();
            BeginContext(642, 12, false);
#line 16 "C:\Development\SourceCode\Demo\DT2\DecisionTech\RM.Basket.Library\RM.Supermarket\Views\Home\Index.cshtml"
           Write(product.Name);

#line default
#line hidden
            EndContext();
            BeginContext(654, 93, true);
            WriteLiteral("</h4>\r\n          </div>\r\n          <div class=\"col-sm-6 col-md-6 col-lg-6\">\r\n            <h4>");
            EndContext();
            BeginContext(748, 27, false);
#line 19 "C:\Development\SourceCode\Demo\DT2\DecisionTech\RM.Basket.Library\RM.Supermarket\Views\Home\Index.cshtml"
           Write(product.Price.ToString("c"));

#line default
#line hidden
            EndContext();
            BeginContext(775, 108, true);
            WriteLiteral("</h4>\r\n          </div>\r\n        </div>\r\n      </div>\r\n      <div>\r\n        <div class=\"button\">\r\n          ");
            EndContext();
            BeginContext(883, 124, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9d032012c3514395ba3eb0c40ae946ac", async() => {
                BeginContext(990, 13, true);
                WriteLiteral("Add to Basket");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-productId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 25 "C:\Development\SourceCode\Demo\DT2\DecisionTech\RM.Basket.Library\RM.Supermarket\Views\Home\Index.cshtml"
                                                                                            WriteLiteral(product.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-productId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1007, 77, true);
            WriteLiteral("\r\n        </div>\r\n      </div>\r\n    </div>\r\n  </div>\r\n    <div>\r\n    </div>\r\n");
            EndContext();
#line 32 "C:\Development\SourceCode\Demo\DT2\DecisionTech\RM.Basket.Library\RM.Supermarket\Views\Home\Index.cshtml"
  }

#line default
#line hidden
            BeginContext(1089, 2, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RM.Supermarket.ViewModels.HomeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591