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
    public class AttachmentTests
    {
        [Fact]
        public void ModelValidation_ValidData_ReturnsNoErrors()
        {
            var model = new Attachment
            {
                Content = "base64string==",
                Name = "file.pdf",
                Type = "application/pdf"
            };

            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model);
            var isValid = Validator.TryValidateObject(model, context, validationResults, true);

            Assert.True(isValid);
            Assert.Empty(validationResults);
        }

        
    }

}
