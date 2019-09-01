using FluentValidation.TestHelper;
using QNet.Web.Models.Boards;
using QNet.Web.Validators.Boards;
using NUnit.Framework;

namespace QNet.Web.MVC.Tests.Public.Validators.Boards
{
    [TestFixture]
    public class EditForumTopicValidatorTests : BaseValidatorTests
    {
        private EditForumTopicValidator _validator;
        
        [SetUp]
        public new void Setup()
        {
            _validator = new EditForumTopicValidator(_localizationService);
        }

        [Test]
        public void Should_have_error_when_subject_is_null_or_empty()
        {
            var model = new EditForumTopicModel
            {
                Subject = null
            };
            _validator.ShouldHaveValidationErrorFor(x => x.Subject, model);
            model.Subject = "";
            _validator.ShouldHaveValidationErrorFor(x => x.Subject, model);
        }

        [Test]
        public void Should_not_have_error_when_subject_is_specified()
        {
            var model = new EditForumTopicModel
            {
                Subject = "some comment"
            };
            _validator.ShouldNotHaveValidationErrorFor(x => x.Subject, model);
        }

        [Test]
        public void Should_have_error_when_text_is_null_or_empty()
        {
            var model = new EditForumTopicModel
            {
                Text = null
            };
            _validator.ShouldHaveValidationErrorFor(x => x.Text, model);
            model.Text = "";
            _validator.ShouldHaveValidationErrorFor(x => x.Text, model);
        }

        [Test]
        public void Should_not_have_error_when_text_is_specified()
        {
            var model = new EditForumTopicModel
            {
                Text = "some comment"
            };
            _validator.ShouldNotHaveValidationErrorFor(x => x.Text, model);
        }
    }
}
