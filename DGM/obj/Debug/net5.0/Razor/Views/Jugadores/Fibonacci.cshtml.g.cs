#pragma checksum "C:\Users\carlo\source\repos\DGM\DGM\Views\Jugadores\Fibonacci.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b44bca5aeba83a83d7b95b510fc05f4b50935c1c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Jugadores_Fibonacci), @"mvc.1.0.view", @"/Views/Jugadores/Fibonacci.cshtml")]
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
#line 1 "C:\Users\carlo\source\repos\DGM\DGM\Views\_ViewImports.cshtml"
using DGM;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\carlo\source\repos\DGM\DGM\Views\_ViewImports.cshtml"
using DGM.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b44bca5aeba83a83d7b95b510fc05f4b50935c1c", @"/Views/Jugadores/Fibonacci.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8874ec0651ab4a090f5cdde8f5e99067aee89ea3", @"/Views/_ViewImports.cshtml")]
    public class Views_Jugadores_Fibonacci : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<int>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n    <h1>Fibonacci (por default, comienza con el 0 y el 4 (según el ejercicio tenía que restarle 1 al número, por eso es un 3 (4-1 = 3)), y el límite es 10. \"Revisar código para cambiar números\")</h1>\r\n\r\n");
#nullable restore
#line 6 "C:\Users\carlo\source\repos\DGM\DGM\Views\Jugadores\Fibonacci.cshtml"
 foreach (int num in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <li>");
#nullable restore
#line 8 "C:\Users\carlo\source\repos\DGM\DGM\Views\Jugadores\Fibonacci.cshtml"
   Write(num);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 9 "C:\Users\carlo\source\repos\DGM\DGM\Views\Jugadores\Fibonacci.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<int>> Html { get; private set; }
    }
}
#pragma warning restore 1591
