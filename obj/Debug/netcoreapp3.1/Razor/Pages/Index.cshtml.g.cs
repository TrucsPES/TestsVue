#pragma checksum "C:\Users\Dany\Documents\Visual Studio 2012\Projects\TestsVue\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ef38cb9b1df02684369c0117c432a087f8d2d4a1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WebApplication2.Pages.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
namespace WebApplication2.Pages
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
#line 1 "C:\Users\Dany\Documents\Visual Studio 2012\Projects\TestsVue\Pages\_ViewImports.cshtml"
using WebApplication2;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ef38cb9b1df02684369c0117c432a087f8d2d4a1", @"/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"538f37ef395561d5f352aabc9fc72bce1358fc6b", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Dany\Documents\Visual Studio 2012\Projects\TestsVue\Pages\Index.cshtml"
  
    ViewData["Title"] = "Home page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<link rel=\"stylesheet\" href=\"form/snow.min.css\">\r\n<style>\r\n");
            WriteLiteral("@media (min-width: 650px) {\r\n  .order {\r\n    display: flex;\r\n  }\r\n}\r\n\r\n");
            WriteLiteral("@media\r\n    (min-width: 720px) {\r\n        .order {\r\n    display: block;\r\n  }\r\n}\r\n\r\n");
            WriteLiteral(@"@media
    (min-width: 850px) {
        .order {
    display: flex;
  }
    .order .formulate-input {
        margin-right: 1.5em;
    }
}
    .order .formulate-input {
        margin-right: 2em;
        margin-bottom: 0;
    }
    .flex-wrapper {
        max-width: 20em;
        display: flex
    }

        .flex-wrapper > .formulate-input:nth-child(odd) {
            margin-right: 1em;
        }

        .flex-wrapper > .formulate-input.flex-item-small {
            width: 5em;
            flex-basis: 5em;
            flex-shrink: 0;
        }

        .flex-wrapper > .formulate-input {
            flex-grow: 1;
        }


    .formulate-input[data-classification=text] .formulate-input-element--date input {
        padding: .60em;
    }

</style>

<div id=""form"">
");
            WriteLiteral("    <template>\r\n        ");
#nullable restore
#line 67 "C:\Users\Dany\Documents\Visual Studio 2012\Projects\TestsVue\Pages\Index.cshtml"
   Write(Html.Raw(Model.Formulaire));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    </template>
</div>

<script src=""https://unpkg.com/vue""></script>
<script src=""https://unpkg.com/axios/dist/axios.min.js""></script>
<script src=""form/formulate.min.js""></script>
<script src=""form/locales.min.js""></script>

<script>
    Vue.use(VueFormulate, {
        plugins: [this.VueFormulateI18n.fr],
        locale: 'fr', 
        validationNameStrategy: ['validationName', 'label', 'name', 'type']
    });

    const App = {
        el: '#form',


        methods: {
            failedValidation(data) {
                debugger;
            },
            submitHandler(data) {
                axios.post('/Privacy', data);
            },
            invalidMessage(fields) {
                debugger;
                const fieldNames = Object.keys(fields)
                const listOfNames = fieldNames.map(fieldName => fieldName.replace('_', ' '))
                return `Invalid fields: ${listOfNames}`
            },
            //validate() {
            //    debugger;
 ");
            WriteLiteral(@"           //    this.isValidate = !this.$refs.form.$children.some(
            //       (input) => typeof input.isValid !== 'undefined' && !input.isValid
            //    )
            //}
        },

        data: {
            contenuform: {},
            formErrors: [],
            inputErrors: {}
        },
");
            WriteLiteral("        mounted() {\r\n            console.log(\'Application mounted.\')\r\n        }\r\n    }\r\n\r\n    window.addEventListener(\'load\', () => {\r\n        new Vue(App)\r\n    })\r\n\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel>)PageContext?.ViewData;
        public IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
