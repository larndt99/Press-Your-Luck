#pragma checksum "C:\Users\Lucas\Desktop\PROG2230\Assignment3_ArndtLucas\PressYourLuck_Starter\PressYourLuck\Views\Game\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "63f8f1be121b03eeef06ad3d926ade3b69ecbc4a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Game_Index), @"mvc.1.0.view", @"/Views/Game/Index.cshtml")]
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
#line 1 "C:\Users\Lucas\Desktop\PROG2230\Assignment3_ArndtLucas\PressYourLuck_Starter\PressYourLuck\Views\_ViewImports.cshtml"
using PressYourLuck;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Lucas\Desktop\PROG2230\Assignment3_ArndtLucas\PressYourLuck_Starter\PressYourLuck\Views\_ViewImports.cshtml"
using PressYourLuck.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"63f8f1be121b03eeef06ad3d926ade3b69ecbc4a", @"/Views/Game/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"842051d68800ad210ef9b3389f15811b05c4578d", @"/Views/_ViewImports.cshtml")]
    public class Views_Game_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Card>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-6\">\r\n        Current Bet: ");
#nullable restore
#line 5 "C:\Users\Lucas\Desktop\PROG2230\Assignment3_ArndtLucas\PressYourLuck_Starter\PressYourLuck\Views\Game\Index.cshtml"
                Write(ViewData[""]);

#line default
#line hidden
#nullable disable
            WriteLiteral("]\r\n    </div>\r\n    <div class=\"col-6\">\r\n        <a>Take the Coins!</a>\r\n    </div>\r\n</div>\r\n<div class=\"row\">\r\n");
#nullable restore
#line 12 "C:\Users\Lucas\Desktop\PROG2230\Assignment3_ArndtLucas\PressYourLuck_Starter\PressYourLuck\Views\Game\Index.cshtml"
     foreach (var tile in Model)
    {   

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"col-3 col-md-2\" style=\"margin: 4px 0px 4px 0px\">\r\n        <div class=\"card\">\r\n            <img class=\"card-img-top\"");
            BeginWriteAttribute("src", " src=\"", 385, "\"", 411, 1);
#nullable restore
#line 16 "C:\Users\Lucas\Desktop\PROG2230\Assignment3_ArndtLucas\PressYourLuck_Starter\PressYourLuck\Views\Game\Index.cshtml"
WriteAttributeValue("", 391, tile.GetImagePath(), 391, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" >\r\n            <div class=\"card-body\">\r\n");
#nullable restore
#line 18 "C:\Users\Lucas\Desktop\PROG2230\Assignment3_ArndtLucas\PressYourLuck_Starter\PressYourLuck\Views\Game\Index.cshtml"
                 if (tile.Visible)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div>");
#nullable restore
#line 20 "C:\Users\Lucas\Desktop\PROG2230\Assignment3_ArndtLucas\PressYourLuck_Starter\PressYourLuck\Views\Game\Index.cshtml"
                    Write(tile.Value.ToString("N2"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 21 "C:\Users\Lucas\Desktop\PROG2230\Assignment3_ArndtLucas\PressYourLuck_Starter\PressYourLuck\Views\Game\Index.cshtml"

                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <a class=\"btn btn-primary\"");
            BeginWriteAttribute("href", " href=\"", 675, "\"", 724, 2);
            WriteAttributeValue("", 682, "/Game/CardPicked?indexCard=", 682, 27, true);
#nullable restore
#line 25 "C:\Users\Lucas\Desktop\PROG2230\Assignment3_ArndtLucas\PressYourLuck_Starter\PressYourLuck\Views\Game\Index.cshtml"
WriteAttributeValue("", 709, tile.TileIndex, 709, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Select</a>\r\n");
#nullable restore
#line 26 "C:\Users\Lucas\Desktop\PROG2230\Assignment3_ArndtLucas\PressYourLuck_Starter\PressYourLuck\Views\Game\Index.cshtml"
                                                                                                                                      

                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>    \r\n");
#nullable restore
#line 32 "C:\Users\Lucas\Desktop\PROG2230\Assignment3_ArndtLucas\PressYourLuck_Starter\PressYourLuck\Views\Game\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Card>> Html { get; private set; }
    }
}
#pragma warning restore 1591
