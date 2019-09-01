using FluentValidation.TestHelper;
using QNet.Web.Models.Customer;
using QNet.Web.Validators.Customer;
using NUnit.Framework;

namespace QNet.Web.MVC.Tests.Public.Validators.Customer
{
    [TestFixture]
    public class PasswordRecoveryValidatorTests : BaseValidatorTests
    {
        private PasswordRecoveryValidator _validator;
        
        [SetUp]
        public new void Setup()
        {
            _validator = new PasswordRecoveryValidator(_localizationService);
        }
        
        [Test]
        public void Should_have_error_when_email_is_null_or_empty()
        {
            var model = new PasswordRecoveryModel
            {
                Email = null
            };
            _validator.ShouldHaveValidationErrorFor(x => x.Email, model);
            model.Email = "";
            _validator.ShouldHaveValidationErrorFor(x => x.Email, model);
        }

        [Test]
        public void Should_have_error_when_email_is_wrong_format()
        {
            var model = new PasswordRecoveryModel
            {
                Email = "adminexample.com"
            };
            _validator.ShouldHaveValidationErrorFor(x => x.Email, model);
        }

        [Test]
        public void Should_not_have_error_when_email_is_correct_format()
        {
            var model = new PasswordRecoveryModel
            {
                Email = "admin@example.com"
            };
            _validator.ShouldNotHaveValidationErrorFor(x => x.Email, model);
        }
    }
}
