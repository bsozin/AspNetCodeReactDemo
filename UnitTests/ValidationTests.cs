using System.Collections.Generic;
using AspNetCodeReact.Services.DTO;
using AspNetCodeReact.Services.Validators;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestPlatform.Common.ExtensionFramework.Utilities;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AspNetCodeReact.UnitTests
{
    [TestClass]
    public class ValidationTests
    {
        [TestMethod]
        [DynamicData(nameof(UpdateCarValidationSuccessData))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Для описания смысла тест-кейса")]
        public void TestUpdateCarValidation_Success(string description, UpdateCarRequest request)
        {
            var validator = new UpdateCarRequestValidator();
            var result = validator.TestValidate(request);
            result.ShouldNotHaveAnyValidationErrors();
        }

        private static IEnumerable<object[]> UpdateCarValidationSuccessData
            => new[]{
                new object[] { "C идентификатором", new UpdateCarRequest(1,2,3,"name",1,"www.mail.ru") },
                new object[] { "Без идентификатора", new UpdateCarRequest(null,2,3,"name",1,"www.mail.ru") },
                new object[] { "Максимально длинное наименование", new UpdateCarRequest(1,2,3,new string('?',1000),1,"www.mail.ru") },
                new object[] { "Минимум сидений", new UpdateCarRequest(1,2,3,"name",1,"www.mail.ru") },
                new object[] { "Максимум сидений", new UpdateCarRequest(1,2,3,"name",12,"www.mail.ru") },
                new object[] { "Отсутствие Url", new UpdateCarRequest(1,2,3,"name",12,null) },
                new object[] { "Пустой Url", new UpdateCarRequest(1,2,3,"name",12,"") },
            };


        [TestMethod]
        [DynamicData(nameof(UpdateCarValidationFailureData))]
        public void TestUpdateCarValidation_Failure(string invalidPropertyName, UpdateCarRequest request)
        {
            var validator = new UpdateCarRequestValidator();
            var result = validator.TestValidate(request);
            result.ShouldHaveValidationErrorFor(invalidPropertyName);
        }

        private static IEnumerable<object[]> UpdateCarValidationFailureData
            => new[]{
                new object[] { nameof(UpdateCarRequest.BrandId), new UpdateCarRequest(1,default,3,"name",1,"www.mail.ru") },
                new object[] { nameof(UpdateCarRequest.BodyTypeId), new UpdateCarRequest(1,2, default, "name", 1,"www.mail.ru") },
                new object[] { nameof(UpdateCarRequest.Name), new UpdateCarRequest(1,2,3,null!,1,"www.mail.ru") },
                new object[] { nameof(UpdateCarRequest.Name), new UpdateCarRequest(1,2,3,"",1,"www.mail.ru") },
                new object[] { nameof(UpdateCarRequest.Name), new UpdateCarRequest(1,2,3,new string('?',1001),1,"www.mail.ru") },
                new object[] { nameof(UpdateCarRequest.SeatsCount), new UpdateCarRequest(1,2,3,"name",0,"www.mail.ru") },
                new object[] { nameof(UpdateCarRequest.SeatsCount), new UpdateCarRequest(1,2,3,"name",13,"www.mail.ru") },
                new object[] { nameof(UpdateCarRequest.DealerUrl), new UpdateCarRequest(1,2,3,"name",5,"www.some.net") },
                new object[] { nameof(UpdateCarRequest.DealerUrl), new UpdateCarRequest(1,2,3,"name",5,"not a url") },
            };
    }
}