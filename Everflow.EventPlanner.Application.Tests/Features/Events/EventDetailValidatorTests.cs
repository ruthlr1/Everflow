using Everflow.EventPlanner.Application.Features.Events.Upsert;
using FluentValidation.TestHelper;

namespace Everflow.EventPlanner.Application.Tests.Features.Events
{
    public class EventDetailValidatorTests
    {

        private UpsertEventDetailCommandValidator _validator;
        private UpsertEventDetailCommand _model;
        [SetUp]
        public void SetupValidator()
        {
            _model = new UpsertEventDetailCommand();
            _validator = new UpsertEventDetailCommandValidator();
        }


        [Test]
        public void EmptyModel_ShouldHaveValidation()
        {
            // act
            TestValidationResult<UpsertEventDetailCommand> result = _validator.TestValidate(_model);

            // assert
            result.ShouldHaveValidationErrorFor(x => x.EventDetailDescription);
            result.ShouldHaveValidationErrorFor(x => x.EventDetailDate);
            result.ShouldHaveValidationErrorFor(x => x.EventDetailStartTime);
            result.ShouldHaveValidationErrorFor(x => x.EventDetailEndTime);
        }

        [Test]
        public void InvalidModel_EndTimeMustBeGreaterThanStartTime_ShouldHaveValidation()
        {
            // arrange
            _model.EventDetailStartTime = new DateTime(2000, 1, 1, 9, 0, 0).TimeOfDay;
            _model.EventDetailEndTime = new DateTime(2000, 1, 1, 7, 0, 0).TimeOfDay;

            // act
            TestValidationResult<UpsertEventDetailCommand> result = _validator.TestValidate(_model);

            // assert
            result.ShouldHaveValidationErrorFor(x => x.EventDetailEndTime);
        }

        [Test]
        public void ValidModel_ShouldNotHaveValidation()
        {
            // arrange
            _model.EventDetailDescription = "Test description";
            _model.EventDetailDate = new DateTime(2000, 1, 1);
            _model.EventDetailStartTime = new DateTime(2000, 1, 1, 9, 0, 0).TimeOfDay;
            _model.EventDetailEndTime = new DateTime(2000, 1, 1, 11, 0, 0).TimeOfDay;

            // act
            TestValidationResult<UpsertEventDetailCommand> result = _validator.TestValidate(_model);

            // assert
            result.ShouldNotHaveValidationErrorFor(x => x.EventDetailDescription);
            result.ShouldNotHaveValidationErrorFor(x => x.EventDetailDate);
            result.ShouldNotHaveValidationErrorFor(x => x.EventDetailStartTime);
            result.ShouldNotHaveValidationErrorFor(x => x.EventDetailEndTime);
        }

        [Test]
        public void InValidModel_DescriptionExceedsMaxLength_ShouldNotHaveValidation()
        {
            // arrange
            _model.EventDetailDescription = "sadjhsdanjsdmaoasdmosdansdaosdaosadnadsasn_sadjhsdanjsdmaoasdmosdansdaosdaosadnadsasn_sadjhsdanjsdmaoasdmosdansdaosdaosadnadsasn_sadjhsdanjsdmaoasdmosdansdaosdaosadnadsasn_";

            // act
            TestValidationResult<UpsertEventDetailCommand> result = _validator.TestValidate(_model);

            // assert
            result.ShouldHaveValidationErrorFor(x => x.EventDetailDescription);
        }

    }
}
