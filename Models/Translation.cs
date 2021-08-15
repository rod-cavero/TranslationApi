using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TranslationApi
{
    public class Translation
    {
        public string DetectedLanguage { get; set; }

        public string Translated { get; set; } //Text translated

    }
}
