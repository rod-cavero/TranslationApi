using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TranslationApi
{
    public class Translation
    {
        [Required]
        public string Text { get; set; } //Text to be translated

        public string SourceLanguage { get; set; }

        [Required]
        public string TargetLanguage { get; set; }

        public string Translated { get; set; } //Text translated

        public Translation()
        {
            SourceLanguage = "auto";
            Translated = "";
        }
    }
}
