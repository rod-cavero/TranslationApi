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
        public string Text { get; set; }

        public string SourceLanguage { get; set; }

        [Required]
        public string TargetLanguage { get; set; }

        public string Translated { get; set; }

        public Translation()
        {
            SourceLanguage = "auto";
            Translated = "";
        }
    }
}
