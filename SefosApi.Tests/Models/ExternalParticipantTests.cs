using SefosApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SefosApi.Tests.Models
{
    public class ExternalParticipantTests
    {
        [Fact]
        public void ModelValidation_Validdata_ReturnsErrors()
        {
            var model = new ExternalParticipant
            {
                Email = "valid@example.com",
                Language = "en",
                AuthenticationMethod = "sms"
            };

            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model);
            var isValid = Validator.TryValidateObject(model, context, validationResults, true);

            Assert.True(isValid);
            Assert.Empty(validationResults);

        }

        [Fact]
        public void ModelValidation_MissingEmail_ReturnsValidatationError()
        {
            var model = new ExternalParticipant
            {
                Language = "en",
                AuthenticationMethod = "sms"
            };
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model);
            var isValid = Validator.TryValidateObject(model, context, validationResults, true);

            Assert.Contains("Email field is required", validationResults.Select(x => x.ErrorMessage));

        }
    }
}
