#pragma checksum "C:\Users\vasil\source\repos\Endava.iAcademy\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "87a94a37ffde5edc696d5bfe219b54cf928c368c"
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
#line 1 "C:\Users\vasil\source\repos\Endava.iAcademy\Views\_ViewImports.cshtml"
using Endava.iAcademy;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\vasil\source\repos\Endava.iAcademy\Views\_ViewImports.cshtml"
using Endava.iAcademy.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87a94a37ffde5edc696d5bfe219b54cf928c368c", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ee8d3dd45def5d8f90c00f6099c50804b07f570e", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Endava.iAcademy.ViewModels.CoursesViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\vasil\source\repos\Endava.iAcademy\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1 class=\"display-3\">iAcademy</h1>\r\n<br>\r\n<h1 class=\"font-weight-light\">Courses:</h1>\r\n<br />\r\n<p>Sort by:\r\n<p />\r\n");
#nullable restore
#line 12 "C:\Users\vasil\source\repos\Endava.iAcademy\Views\Home\Index.cshtml"
  
    List<SelectListItem> listItems = new List<SelectListItem>();
    listItems.Add(new SelectListItem
    {
        Text = "Title",
        Value = "Title"
    });
    listItems.Add(new SelectListItem
    {
        Text = "Date",
        Value = "Date",
        Selected = true
    });

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 27 "C:\Users\vasil\source\repos\Endava.iAcademy\Views\Home\Index.cshtml"
Write(Html.DropDownListFor(model => model.Courses, listItems, "-- Select Status --"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 28 "C:\Users\vasil\source\repos\Endava.iAcademy\Views\Home\Index.cshtml"
 foreach (var course in Model.Courses)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <ul>\r\n        <li><a style=\"font-size: 30px\"");
            BeginWriteAttribute("href", " href=\"", 694, "\"", 755, 1);
#nullable restore
#line 31 "C:\Users\vasil\source\repos\Endava.iAcademy\Views\Home\Index.cshtml"
WriteAttributeValue("", 701, Url.Action("Index", "Course", new { id = course.Id }), 701, 54, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 31 "C:\Users\vasil\source\repos\Endava.iAcademy\Views\Home\Index.cshtml"
                                                                                                Write(course.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n    </ul>\r\n");
#nullable restore
#line 33 "C:\Users\vasil\source\repos\Endava.iAcademy\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Endava.iAcademy.ViewModels.CoursesViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
