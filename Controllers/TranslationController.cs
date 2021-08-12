using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace TranslationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslationController : ControllerBase
    {
        private readonly ILogger<TranslationController> _logger;

        public TranslationController(ILogger<TranslationController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<Translation> Get(Translation toTranslate)
        {
           
            if (Translate(ref toTranslate))
            {
                return toTranslate;
            }
            else
            {
                return StatusCode(500);
            }
        }

        private bool Translate(ref Translation toTranslate)
        {
            bool ret = false;

            try
            {
                //Set the url to request google api
                string uri = String.Format("https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}",
                    toTranslate.SourceLanguage, toTranslate.TargetLanguage, Uri.EscapeUriString(toTranslate.Text));

                using (var httpClient = new HttpClient())
                {
                    var response = httpClient.GetAsync(uri);
                    response.Wait();

                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        string dataResult = result.Content.ReadAsStringAsync().Result;
                        var jsonData = JsonSerializer.Deserialize<List<dynamic>>(dataResult);
                        JsonElement jsonElement = jsonData[0];
                        toTranslate.SourceLanguage = Convert.ToString(jsonData[2]);

                        foreach (var element in jsonElement.EnumerateArray())
                        {
                            toTranslate.Translated += Convert.ToString(element[0]);
                        }
                        ret = true;
                    }
                }
            }
            catch { }
            return ret;
           
        }
    }
}
