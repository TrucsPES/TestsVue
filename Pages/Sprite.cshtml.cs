﻿using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Net.Http.Headers;

namespace ECS.PR.Extra.Areas.Anonyme
{
    public class SpriteModel : PageModel
    {
        public IActionResult OnGet()
        {
            var headers = Response.GetTypedHeaders();
            headers.CacheControl = new CacheControlHeaderValue
            {
                Public = true,
                MaxAge = TimeSpan.FromDays(365)
            };
            return Page();
        }
    }
}
