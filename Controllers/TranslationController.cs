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
           //call the function to do the translation, passing by reference the class with the data
            if (Translate(ref toTranslate))
            {
                //the function returns all the information in the same class
                //which is the one the api return
                return toTranslate;
            }
            else
            {
                //if the function fail, raise a internal server error
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

                //set the client for request
                using (var httpClient = new HttpClient())
                {
                    //make the request to google api
                    var response = httpClient.GetAsync(uri);
                    response.Wait();

                    //get the result from the request
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        //if the api call was succesfull extract the data returned

                        string dataResult = result.Content.ReadAsStringAsync().Result;
                        var jsonData = JsonSerializer.Deserialize<List<dynamic>>(dataResult);
                        //take the first element of the list
                        //where the translation is
                        JsonElement jsonElement = jsonData[0];
                        //the third element has the source launge in case of request for auto detect
                        toTranslate.SourceLanguage = Convert.ToString(jsonData[2]);

                        //extract every translated sentece to join in a single string
                        foreach (var element in jsonElement.EnumerateArray())
                        {
                            toTranslate.Translated += Convert.ToString(element[0]);
                        }
                        //every was succesful return true
                        ret = true;
                    }
                }
            }
            catch { }
            return ret;
           
        }
    }
}
