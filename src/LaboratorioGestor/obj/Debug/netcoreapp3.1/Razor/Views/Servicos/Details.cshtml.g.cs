#pragma checksum "C:\GitHub\LaboratorioGestor\src\LaboratorioGestor\Views\Servicos\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "418dbd9744a820a9df8273212baa48fff4dfcef6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Servicos_Details), @"mvc.1.0.view", @"/Views/Servicos/Details.cshtml")]
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
#line 1 "C:\GitHub\LaboratorioGestor\src\LaboratorioGestor\Views\_ViewImports.cshtml"
using LaboratorioGestor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\GitHub\LaboratorioGestor\src\LaboratorioGestor\Views\_ViewImports.cshtml"
using LaboratorioGestor.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\GitHub\LaboratorioGestor\src\LaboratorioGestor\Views\_ViewImports.cshtml"
using LaboratorioGestor.App.ViewModels.Identity.AccountViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\GitHub\LaboratorioGestor\src\LaboratorioGestor\Views\_ViewImports.cshtml"
using LaboratorioGestor.App.ViewModels.Identity.ManageViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\GitHub\LaboratorioGestor\src\LaboratorioGestor\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\GitHub\LaboratorioGestor\src\LaboratorioGestor\Views\_ViewImports.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\GitHub\LaboratorioGestor\src\LaboratorioGestor\Views\_ViewImports.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"418dbd9744a820a9df8273212baa48fff4dfcef6", @"/Views/Servicos/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f2c49a2f0d63734e23e2081615e7175d13123bbd", @"/Views/_ViewImports.cshtml")]
    public class Views_Servicos_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LaboratorioGestor.App.ViewModels.ServicoViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\GitHub\LaboratorioGestor\src\LaboratorioGestor\Views\Servicos\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>ServicoViewModel</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 14 "C:\GitHub\LaboratorioGestor\src\LaboratorioGestor\Views\Servicos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DataCadastro));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "C:\GitHub\LaboratorioGestor\src\LaboratorioGestor\Views\Servicos\Details.cshtml"
       Write(Html.DisplayFor(model => model.DataCadastro));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 20 "C:\GitHub\LaboratorioGestor\src\LaboratorioGestor\Views\Servicos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Idade));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 23 "C:\GitHub\LaboratorioGestor\src\LaboratorioGestor\Views\Servicos\Details.cshtml"
       Write(Html.DisplayFor(model => model.Idade));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 26 "C:\GitHub\LaboratorioGestor\src\LaboratorioGestor\Views\Servicos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.NomePaciente));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 29 "C:\GitHub\LaboratorioGestor\src\LaboratorioGestor\Views\Servicos\Details.cshtml"
       Write(Html.DisplayFor(model => model.NomePaciente));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 32 "C:\GitHub\LaboratorioGestor\src\LaboratorioGestor\Views\Servicos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Cor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 35 "C:\GitHub\LaboratorioGestor\src\LaboratorioGestor\Views\Servicos\Details.cshtml"
       Write(Html.DisplayFor(model => model.Cor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 38 "C:\GitHub\LaboratorioGestor\src\LaboratorioGestor\Views\Servicos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DataEntrada));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 41 "C:\GitHub\LaboratorioGestor\src\LaboratorioGestor\Views\Servicos\Details.cshtml"
       Write(Html.DisplayFor(model => model.DataEntrada));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 44 "C:\GitHub\LaboratorioGestor\src\LaboratorioGestor\Views\Servicos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DataEntrega));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 47 "C:\GitHub\LaboratorioGestor\src\LaboratorioGestor\Views\Servicos\Details.cshtml"
       Write(Html.DisplayFor(model => model.DataEntrega));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 50 "C:\GitHub\LaboratorioGestor\src\LaboratorioGestor\Views\Servicos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ReferenciaOS));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 53 "C:\GitHub\LaboratorioGestor\src\LaboratorioGestor\Views\Servicos\Details.cshtml"
       Write(Html.DisplayFor(model => model.ReferenciaOS));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 56 "C:\GitHub\LaboratorioGestor\src\LaboratorioGestor\Views\Servicos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Quantidade));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 59 "C:\GitHub\LaboratorioGestor\src\LaboratorioGestor\Views\Servicos\Details.cshtml"
       Write(Html.DisplayFor(model => model.Quantidade));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 62 "C:\GitHub\LaboratorioGestor\src\LaboratorioGestor\Views\Servicos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Valor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 65 "C:\GitHub\LaboratorioGestor\src\LaboratorioGestor\Views\Servicos\Details.cshtml"
       Write(Html.DisplayFor(model => model.Valor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 68 "C:\GitHub\LaboratorioGestor\src\LaboratorioGestor\Views\Servicos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Observcao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 71 "C:\GitHub\LaboratorioGestor\src\LaboratorioGestor\Views\Servicos\Details.cshtml"
       Write(Html.DisplayFor(model => model.Observcao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 74 "C:\GitHub\LaboratorioGestor\src\LaboratorioGestor\Views\Servicos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.IDProduto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 77 "C:\GitHub\LaboratorioGestor\src\LaboratorioGestor\Views\Servicos\Details.cshtml"
       Write(Html.DisplayFor(model => model.IDProduto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 80 "C:\GitHub\LaboratorioGestor\src\LaboratorioGestor\Views\Servicos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.IDProtetico));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 83 "C:\GitHub\LaboratorioGestor\src\LaboratorioGestor\Views\Servicos\Details.cshtml"
       Write(Html.DisplayFor(model => model.IDProtetico));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 86 "C:\GitHub\LaboratorioGestor\src\LaboratorioGestor\Views\Servicos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.IDDentista));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 89 "C:\GitHub\LaboratorioGestor\src\LaboratorioGestor\Views\Servicos\Details.cshtml"
       Write(Html.DisplayFor(model => model.IDDentista));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "418dbd9744a820a9df8273212baa48fff4dfcef613504", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 94 "C:\GitHub\LaboratorioGestor\src\LaboratorioGestor\Views\Servicos\Details.cshtml"
                           WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "418dbd9744a820a9df8273212baa48fff4dfcef615647", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LaboratorioGestor.App.ViewModels.ServicoViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
