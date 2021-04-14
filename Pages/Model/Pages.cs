﻿using Microsoft.Extensions.Primitives;
using System.Collections.Generic;

namespace ECSForm.Model
{
    public class Section
    {
        public int No { get; set; }
        public string Id { get; set; } = string.Empty;
        public string Titre { get; set; } = string.Empty;
    }
}