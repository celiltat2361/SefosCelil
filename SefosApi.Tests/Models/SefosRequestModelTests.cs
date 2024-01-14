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
    public class SefosRequestModelTests
    {
        [Fact]
        public void ModelValidation_ValidData_ReturnsNoErrors()
        {
            var model = new SefosRequestModel
            {
                Subject = "Valid Subject",
                Body = "Valid body",
                ExternalParticipants = new List<ExternalParticipant>
            {
                new ExternalParticipant { Email = "test@example.com", Language = "en" }
            }
            };

            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model);
            var isValid = Validator.TryValidateObject(model, context, validationResults, true);

            Assert.True(isValid);
            Assert.Empty(validationResults);
        }

        [Fact]
        public void ModelValidation_MissingSubject_ReturnsValidationError()
        {
            var model = new SefosRequestModel
            {
                Body = "Valid body",
                ExternalParticipants = new List<ExternalParticipant>
            {
                new ExternalParticipant { Email = "test@example.com", Language = "en" }
            }
            };

            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model);
            var isValid = Validator.TryValidateObject(model, context, validationResults, true);

            var subjectValidationErrors = validationResults
                .Where(v => v.MemberNames.Contains("Subject"))
                .ToList();

            Assert.False(isValid);
            Assert.NotEmpty(subjectValidationErrors);
            Assert.Contains("The Subject field is required.", validationResults.Select(x => x.ErrorMessage));


            //Assert.Contains(validationResults, v => v.MemberNames.Contains("Subject"));
        }
    }

}
