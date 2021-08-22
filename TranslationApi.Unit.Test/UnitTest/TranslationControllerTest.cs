using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;
using TranslationApi.Controllers;
using System.Net;

namespace TranslationApi.Unit.Test
{
    [TestClass]
    public class TranslationControllerTest
    {
        [TestMethod]
        public void InvokeGet_WithAllParams_ReturnTranslation()
        {
            //Arrange
            ILogger<TranslationController> logger = Mock.Of<ILogger<TranslationController>>();
            string textParam = "Hello";
            string targetParam = "de";
            string sourceParam = "en";


            //Act
            TranslationController translationController = new TranslationController(logger);
            ActionResult<Translation> actionResult = translationController.Get(textParam, targetParam, sourceParam);

            //Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(OkObjectResult));
            OkObjectResult okObjectResult = (OkObjectResult)actionResult.Result;
            Assert.IsInstanceOfType(okObjectResult.Value, typeof(Translation));
            Translation translation = (Translation)okObjectResult.Value;
            Assert.AreEqual("Hallo", translation.Translated);
            Assert.AreEqual("en", translation.DetectedLanguage);

        }

        [TestMethod]
        public void InvokeGet_WithTextAndTarget_ReturnTranslation()
        {
            //Arrange
            ILogger<TranslationController> logger = Mock.Of<ILogger<TranslationController>>();
            string textParam = "Hello";
            string targetParam = "de";


            //Act
            TranslationController translationController = new TranslationController(logger);
            ActionResult<Translation> actionResult = translationController.Get(textParam, targetParam);

            //Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(OkObjectResult));
            OkObjectResult okObjectResult = (OkObjectResult)actionResult.Result;
            Assert.IsInstanceOfType(okObjectResult.Value, typeof(Translation));
            Translation translation = (Translation)okObjectResult.Value;
            Assert.AreEqual("Hallo", translation.Translated);
            Assert.AreEqual("en", translation.DetectedLanguage);

        }

        [TestMethod]
        public void InvokeGet_WithoutParams_ReturnInternalServerError()
        {
            //Arrange
            ILogger<TranslationController> logger = Mock.Of<ILogger<TranslationController>>();
            string textParam = null;
            string targetParam = null;


            //Act
            TranslationController translationController = new TranslationController(logger);
            ActionResult<Translation> actionResult = translationController.Get(textParam, targetParam);

            //Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(StatusCodeResult));
            StatusCodeResult statusCodeResult = (StatusCodeResult)actionResult.Result;
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, statusCodeResult.StatusCode);

        }


        [TestMethod]
        public void InvokeGet_WithBlankParams_ReturnInternalServerError()
        {
            //Arrange
            ILogger<TranslationController> logger = Mock.Of<ILogger<TranslationController>>();
            string textParam = "";
            string targetParam = "";

            //Act
            TranslationController translationController = new TranslationController(logger);
            ActionResult<Translation> actionResult = translationController.Get(textParam, targetParam);

            //Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(StatusCodeResult));
            StatusCodeResult statusCodeResult = (StatusCodeResult)actionResult.Result;
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, statusCodeResult.StatusCode);

        }


    }
}
