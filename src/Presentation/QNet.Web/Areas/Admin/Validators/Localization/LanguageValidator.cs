using System.Globalization;
using FluentValidation;
using QNet.Web.Areas.Admin.Models.Localization;
using QNet.Core.Domain.Localization;
using QNet.Data;
using QNet.Services.Localization;
using QNet.Web.Framework.Validators;

namespace QNet.Web.Areas.Admin.Validators.Localization
{
    public partial class LanguageValidator : BaseQNetValidator<LanguageModel>
    {
        public LanguageValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Languages.Fields.Name.Required"));
            RuleFor(x => x.LanguageCulture)
                .Must(x =>
                          {
                              try
                              {
                                  //let's try to create a CultureInfo object
                                  //if "DisplayLocale" is wrong, then exception will be thrown
                                  var unused = new CultureInfo(x);
                                  return true;
                              }
                              catch
                              {
                                  return false;
                              }
                          })
                .WithMessage(localizationService.GetResource("Admin.Configuration.Languages.Fields.LanguageCulture.Validation"));

            RuleFor(x => x.UniqueSeoCode).NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.Languages.Fields.UniqueSeoCode.Required"));
            RuleFor(x => x.UniqueSeoCode).Length(2).WithMessage(localizationService.GetResource("Admin.Configuration.Languages.Fields.UniqueSeoCode.Length"));

            SetDatabaseValidationRules<Language>(dbContext, "UniqueSeoCode");
        }
    }
}