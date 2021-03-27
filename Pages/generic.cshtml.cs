﻿using AngleSharp;
using AngleSharp.Html.Parser;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Stubble.Core.Builders;
using Stubble.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace WebApplication2.Pages
{
    public class GenericModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        Func<HelperContext, IDictionary<string,string>?, string> jsObject = FormHelpers.JsObject;
        Func<HelperContext, IDictionary<string,string>?, string> jsArray = FormHelpers.JsArray;

        public DynamicForm Form { get; set; }
        public string FormRaw { get; set; }

        public GenericModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public void OnPost(dynamic test)
        {
            var tt = "";
        }

        public async Task OnGet(string? id)
        {
            using (var r = new StreamReader(@$"{id ?? "default"}.ecsform.yaml"))
            {
                var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)  // see height_in_inches in sample yml 
                .Build();

                var yamlObject = deserializer.Deserialize<DynamicForm>(r);

                /*var serializer = new SerializerBuilder()
                 .JsonCompatible()
                 .Build();

                Form = serializer.Serialize<>(yamlObject,);*/

                var culture = new CultureInfo("fr-CA");
                var helpers = new Helpers()
                    .Register("JsObject", jsObject)
                    .Register("JsArray", jsArray);

                var stubble = new StubbleBuilder()
                    .Configure(conf => conf.AddHelpers(helpers))
                    .Build();

                using (StreamReader streamReader = new StreamReader(@"formTemplate.vue", Encoding.UTF8))
                {
                    var content = await streamReader.ReadToEndAsync();
                    FormRaw = await stubble.RenderAsync(content, yamlObject);
                    // Do Stuff
                }
            }

            /*using (var r = new StreamReader(@"form.vue"))
            {
                Formulaire = await r.ReadToEndAsync();
            }*/

            /* var test = new { planet = "lol", test = "" };

             var context = new ValidationContext(test, serviceProvider: null, items: null);
             var validationResults = new List<ValidationResult>();

             //bool isValid = Validator..TryValidateObject(test, context, validationResults, true);


             TryValidate(test.test, context, new RequiredAttribute() { }, out var validationError);

         */

            //document = null;
            // }

            /* using (var r = new StreamReader(@"form.yml"))
             {
                 var deserializer = new DeserializerBuilder()
                 .WithNamingConvention(UnderscoredNamingConvention.Instance)  // see height_in_inches in sample yml 
                 .Build();

                 var yamlObject = deserializer.Deserialize(r);

                 var serializer = new SerializerBuilder()
                  .JsonCompatible()
                  .Build();

                 Formulaire = serializer.Serialize(yamlObject);
             }*/
        }

        private static bool TryValidate(object value, ValidationContext validationContext, ValidationAttribute attribute, out ValidationError validationError)
        {
            if (validationContext == null)
            {
                throw new ArgumentNullException("validationContext");
            }

            ValidationResult validationResult = attribute.GetValidationResult(value, validationContext);
            if (validationResult != ValidationResult.Success)
            {
                validationError = new ValidationError(attribute, value, validationResult);
                return false;
            }

            validationError = null;
            return true;
        }
        /// <summary>
        /// Private helper class to encapsulate a ValidationAttribute with the failed value and the user-visible
        /// target name against which it was validated.
        /// </summary>
        private class ValidationError
        {
            internal ValidationError(ValidationAttribute validationAttribute, object value, ValidationResult validationResult)
            {
                this.ValidationAttribute = validationAttribute;
                this.ValidationResult = validationResult;
                this.Value = value;
            }

            internal object Value { get; set; }

            internal ValidationAttribute ValidationAttribute { get; set; }

            internal ValidationResult ValidationResult { get; set; }

            internal void ThrowValidationException()
            {
                throw new ValidationException(this.ValidationResult, this.ValidationAttribute, this.Value);
            }
        }

        /*  private void ParseValidation(ref FormData validations, string name, string value, Dictionary<string, string> msg)
          {
              if (validations.Elements == null) { validations.Elements = new Dictionary<string, Validation>(); }



              validations.Elements.Add(name, new Validation());
          }*/
    }
}