#pragma checksum "C:\Users\nikola\source\repos\Blog.Projekat\Blog.MVC\Views\Hashtags\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f7c5fdf7af4621628ec8293c08d3cff832574f78"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Hashtags_Index), @"mvc.1.0.view", @"/Views/Hashtags/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Hashtags/Index.cshtml", typeof(AspNetCore.Views_Hashtags_Index))]
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
#line 1 "C:\Users\nikola\source\repos\Blog.Projekat\Blog.MVC\Views\_ViewImports.cshtml"
using Blog.MVC;

#line default
#line hidden
#line 2 "C:\Users\nikola\source\repos\Blog.Projekat\Blog.MVC\Views\_ViewImports.cshtml"
using Blog.MVC.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f7c5fdf7af4621628ec8293c08d3cff832574f78", @"/Views/Hashtags/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5bcefa72b4c8ffa11a587f169e17b210e6d7746b", @"/Views/_ViewImports.cshtml")]
    public class Views_Hashtags_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Blog.Application.DTO.Hashtag.HashtagDto>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(61, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\nikola\source\repos\Blog.Projekat\Blog.MVC\Views\Hashtags\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(104, 29, true);
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(133, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f7c5fdf7af4621628ec8293c08d3cff832574f783828", async() => {
                BeginContext(156, 10, true);
                WriteLiteral("Create New");
                EndContext();
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
            EndContext();
            BeginContext(170, 92, true);
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(263, 38, false);
#line 16 "C:\Users\nikola\source\repos\Blog.Projekat\Blog.MVC\Views\Hashtags\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(301, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(357, 40, false);
#line 19 "C:\Users\nikola\source\repos\Blog.Projekat\Blog.MVC\Views\Hashtags\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(397, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(453, 45, false);
#line 22 "C:\Users\nikola\source\repos\Blog.Projekat\Blog.MVC\Views\Hashtags\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.CreatedAt));

#line default
#line hidden
            EndContext();
            BeginContext(498, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(554, 46, false);
#line 25 "C:\Users\nikola\source\repos\Blog.Projekat\Blog.MVC\Views\Hashtags\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.ModifiedAt));

#line default
#line hidden
            EndContext();
            BeginContext(600, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(656, 45, false);
#line 28 "C:\Users\nikola\source\repos\Blog.Projekat\Blog.MVC\Views\Hashtags\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.IsDeleted));

#line default
#line hidden
            EndContext();
            BeginContext(701, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 34 "C:\Users\nikola\source\repos\Blog.Projekat\Blog.MVC\Views\Hashtags\Index.cshtml"
 foreach (var dto in Model) {

#line default
#line hidden
            BeginContext(818, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(867, 36, false);
#line 37 "C:\Users\nikola\source\repos\Blog.Projekat\Blog.MVC\Views\Hashtags\Index.cshtml"
           Write(Html.DisplayFor(modelItem => dto.Id));

#line default
#line hidden
            EndContext();
            BeginContext(903, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(959, 38, false);
#line 40 "C:\Users\nikola\source\repos\Blog.Projekat\Blog.MVC\Views\Hashtags\Index.cshtml"
           Write(Html.DisplayFor(modelItem => dto.Name));

#line default
#line hidden
            EndContext();
            BeginContext(997, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1053, 43, false);
#line 43 "C:\Users\nikola\source\repos\Blog.Projekat\Blog.MVC\Views\Hashtags\Index.cshtml"
           Write(Html.DisplayFor(modelItem => dto.CreatedAt));

#line default
#line hidden
            EndContext();
            BeginContext(1096, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1152, 44, false);
#line 46 "C:\Users\nikola\source\repos\Blog.Projekat\Blog.MVC\Views\Hashtags\Index.cshtml"
           Write(Html.DisplayFor(modelItem => dto.ModifiedAt));

#line default
#line hidden
            EndContext();
            BeginContext(1196, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1252, 43, false);
#line 49 "C:\Users\nikola\source\repos\Blog.Projekat\Blog.MVC\Views\Hashtags\Index.cshtml"
           Write(Html.DisplayFor(modelItem => dto.IsDeleted));

#line default
#line hidden
            EndContext();
            BeginContext(1295, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1351, 64, false);
#line 52 "C:\Users\nikola\source\repos\Blog.Projekat\Blog.MVC\Views\Hashtags\Index.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { /* id=dto.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1415, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1436, 70, false);
#line 53 "C:\Users\nikola\source\repos\Blog.Projekat\Blog.MVC\Views\Hashtags\Index.cshtml"
           Write(Html.ActionLink("Details", "Details", new { /* id=dto.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1506, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1527, 68, false);
#line 54 "C:\Users\nikola\source\repos\Blog.Projekat\Blog.MVC\Views\Hashtags\Index.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { /* id=dto.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1595, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 57 "C:\Users\nikola\source\repos\Blog.Projekat\Blog.MVC\Views\Hashtags\Index.cshtml"
}

#line default
#line hidden
            BeginContext(1634, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Blog.Application.DTO.Hashtag.HashtagDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
