#pragma checksum "C:\Codigo Teste\LaboratorioGestor\src\LaboratorioGestor\Views\Recebimentos\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5bee36bd4734c6ea3481e0592cb1827ab40ca933"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Recebimentos_Index), @"mvc.1.0.view", @"/Views/Recebimentos/Index.cshtml")]
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
#line 1 "C:\Codigo Teste\LaboratorioGestor\src\LaboratorioGestor\Views\_ViewImports.cshtml"
using LaboratorioGestor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Codigo Teste\LaboratorioGestor\src\LaboratorioGestor\Views\_ViewImports.cshtml"
using LaboratorioGestor.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Codigo Teste\LaboratorioGestor\src\LaboratorioGestor\Views\_ViewImports.cshtml"
using LaboratorioGestor.App.ViewModels.Identity.AccountViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Codigo Teste\LaboratorioGestor\src\LaboratorioGestor\Views\_ViewImports.cshtml"
using LaboratorioGestor.App.ViewModels.Identity.ManageViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Codigo Teste\LaboratorioGestor\src\LaboratorioGestor\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Codigo Teste\LaboratorioGestor\src\LaboratorioGestor\Views\_ViewImports.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Codigo Teste\LaboratorioGestor\src\LaboratorioGestor\Views\_ViewImports.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5bee36bd4734c6ea3481e0592cb1827ab40ca933", @"/Views/Recebimentos/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f2c49a2f0d63734e23e2081615e7175d13123bbd", @"/Views/_ViewImports.cshtml")]
    public class Views_Recebimentos_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<LaboratorioGestor.App.ViewModels.RecebimentosViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Codigo Teste\LaboratorioGestor\src\LaboratorioGestor\Views\Recebimentos\Index.cshtml"
  
    ViewData["Title"] = "Recebimentos";
    var pesquisa = Context.Request.Query["NomeDentista"];
    var pesquisaID = Context.Request.Query["IDPesquisa"];

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 9 "C:\Codigo Teste\LaboratorioGestor\src\LaboratorioGestor\Views\Recebimentos\Index.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5bee36bd4734c6ea3481e0592cb1827ab40ca9336010", async() => {
                WriteLiteral("Novo Recebimento");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5bee36bd4734c6ea3481e0592cb1827ab40ca9337187", async() => {
                WriteLiteral("\r\n    <input type=\"hidden\" id=\"IDPesquisa\" name=\"IDPesquisa\"");
                BeginWriteAttribute("value", " value=\"", 437, "\"", 456, 1);
#nullable restore
#line 16 "C:\Codigo Teste\LaboratorioGestor\src\LaboratorioGestor\Views\Recebimentos\Index.cshtml"
WriteAttributeValue("", 445, pesquisaID, 445, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control\">\r\n    <div class=\"form-row\">\r\n        <input type=\"text\" id=\"NomeDentista\" name=\"NomeDentista\" class=\"form-control col-md-10\"");
                BeginWriteAttribute("value", " value=\"", 604, "\"", 621, 1);
#nullable restore
#line 18 "C:\Codigo Teste\LaboratorioGestor\src\LaboratorioGestor\Views\Recebimentos\Index.cshtml"
WriteAttributeValue("", 612, pesquisa, 612, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" placeholder=\"Digite nome do dentista...\">\r\n        <button type=\"submit\" class=\"btn btn-primary col-md-1\">Pesquisa</button>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 27 "C:\Codigo Teste\LaboratorioGestor\src\LaboratorioGestor\Views\Recebimentos\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DataCadastro));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 30 "C:\Codigo Teste\LaboratorioGestor\src\LaboratorioGestor\Views\Recebimentos\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Valor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 36 "C:\Codigo Teste\LaboratorioGestor\src\LaboratorioGestor\Views\Recebimentos\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 40 "C:\Codigo Teste\LaboratorioGestor\src\LaboratorioGestor\Views\Recebimentos\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.DataCadastro));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 43 "C:\Codigo Teste\LaboratorioGestor\src\LaboratorioGestor\Views\Recebimentos\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Valor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n");
            WriteLiteral("            </tr>\r\n");
#nullable restore
#line 51 "C:\Codigo Teste\LaboratorioGestor\src\LaboratorioGestor\Views\Recebimentos\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
#nullable restore
#line 55 "C:\Codigo Teste\LaboratorioGestor\src\LaboratorioGestor\Views\Recebimentos\Index.cshtml"
 if (Model != null)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 57 "C:\Codigo Teste\LaboratorioGestor\src\LaboratorioGestor\Views\Recebimentos\Index.cshtml"
Write(Html.PagedListPager((IPagedList)Model, pagina => Url.Action("Index", new { pagina = pagina })));

#line default
#line hidden
#nullable disable
#nullable restore
#line 57 "C:\Codigo Teste\LaboratorioGestor\src\LaboratorioGestor\Views\Recebimentos\Index.cshtml"
                                                                                                   
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n    <script>\r\n        $(document).ready(function () {\r\n            ObterDentistaPorDescricao();\r\n        });\r\n    </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<LaboratorioGestor.App.ViewModels.RecebimentosViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591