#pragma checksum "C:\Users\ravan\Documents\Learnings\Dot Net Core\Code\RepositoryPatternDemo\RepositoryPatternDemo.Web\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1dcd3808344707c916ffb9508376acf82c777b51"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\ravan\Documents\Learnings\Dot Net Core\Code\RepositoryPatternDemo\RepositoryPatternDemo.Web\Views\_ViewImports.cshtml"
using RepositoryPatternDemo.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ravan\Documents\Learnings\Dot Net Core\Code\RepositoryPatternDemo\RepositoryPatternDemo.Web\Views\_ViewImports.cshtml"
using RepositoryPatternDemo.Web.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\ravan\Documents\Learnings\Dot Net Core\Code\RepositoryPatternDemo\RepositoryPatternDemo.Web\Views\Home\Index.cshtml"
using RepositoryPatternDemo.Common.Resources;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1dcd3808344707c916ffb9508376acf82c777b51", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0a746e069aa8c8fdc124c5a81291da61611cea32", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RepositoryPatternDemo.Web.ViewModels.ProductCategoryRelationViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\ravan\Documents\Learnings\Dot Net Core\Code\RepositoryPatternDemo\RepositoryPatternDemo.Web\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n");
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 10 "C:\Users\ravan\Documents\Learnings\Dot Net Core\Code\RepositoryPatternDemo\RepositoryPatternDemo.Web\Views\Home\Index.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\ravan\Documents\Learnings\Dot Net Core\Code\RepositoryPatternDemo\RepositoryPatternDemo.Web\Views\Home\Index.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\ravan\Documents\Learnings\Dot Net Core\Code\RepositoryPatternDemo\RepositoryPatternDemo.Web\Views\Home\Index.cshtml"
                            

    if (Model != null &&
        Model.ProductCategoryRelations.Count() > 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"form-group row\">\r\n            <div class=\"col-md-3\">\r\n                <label>");
#nullable restore
#line 19 "C:\Users\ravan\Documents\Learnings\Dot Net Core\Code\RepositoryPatternDemo\RepositoryPatternDemo.Web\Views\Home\Index.cshtml"
                  Write(Resource.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n            </div>\r\n            <div class=\"col-md-3\">\r\n                <label>");
#nullable restore
#line 22 "C:\Users\ravan\Documents\Learnings\Dot Net Core\Code\RepositoryPatternDemo\RepositoryPatternDemo.Web\Views\Home\Index.cshtml"
                  Write(Resource.ProductCategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 26 "C:\Users\ravan\Documents\Learnings\Dot Net Core\Code\RepositoryPatternDemo\RepositoryPatternDemo.Web\Views\Home\Index.cshtml"
         foreach (var productCategoryRelation in Model.ProductCategoryRelations)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"form-group row\">\r\n                <div class=\"col-md-3\">\r\n                    <label>");
#nullable restore
#line 30 "C:\Users\ravan\Documents\Learnings\Dot Net Core\Code\RepositoryPatternDemo\RepositoryPatternDemo.Web\Views\Home\Index.cshtml"
                      Write(productCategoryRelation.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                </div>\r\n                <div class=\"col-md-3\">\r\n                    <label>");
#nullable restore
#line 33 "C:\Users\ravan\Documents\Learnings\Dot Net Core\Code\RepositoryPatternDemo\RepositoryPatternDemo.Web\Views\Home\Index.cshtml"
                      Write(productCategoryRelation.ProductCategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 36 "C:\Users\ravan\Documents\Learnings\Dot Net Core\Code\RepositoryPatternDemo\RepositoryPatternDemo.Web\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "C:\Users\ravan\Documents\Learnings\Dot Net Core\Code\RepositoryPatternDemo\RepositoryPatternDemo.Web\Views\Home\Index.cshtml"
         
    }
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RepositoryPatternDemo.Web.ViewModels.ProductCategoryRelationViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
