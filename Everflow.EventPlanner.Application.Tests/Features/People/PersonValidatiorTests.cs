using Everflow.EventPlanner.Application.Features.People.Upsert;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everflow.EventPlanner.Application.Tests.Features.People
{
    public class PersonValidatiorTests
    {
        private UpsertPersonCommandValidator _validator;
        private UpsertPersonCommand _model;
        [SetUp]
        public void SetupValidator()
        {
            _model = new UpsertPersonCommand();
            _validator = new UpsertPersonCommandValidator();
        }


        [Test]
        public void EmptyModel_ShouldHaveValidation()
        {
            // act
            TestValidationResult<UpsertPersonCommand> result = _validator.TestValidate(_model);

            // assert
            result.ShouldHaveValidationErrorFor(x => x.FirstName);
            result.ShouldHaveValidationErrorFor(x => x.LastName);
            result.ShouldHaveValidationErrorFor(x => x.EmailAddress);
        }

        [Test]
        public void ModelWithInvalidEmail_ShouldHaveValidation()
        {
            // arrange
            _model.EmailAddress = "sdahikkans";

            // act
            TestValidationResult<UpsertPersonCommand> result = _validator.TestValidate(_model);

            // assert
            result.ShouldHaveValidationErrorFor(x => x.EmailAddress);
        }

        [Test]
        public void ModelWithValidEmail_ShouldNotHaveValidation()
        {
            // arrange
            _model.EmailAddress = "johndoe@gmail.com";

            // act
            TestValidationResult<UpsertPersonCommand> result = _validator.TestValidate(_model);

            // assert
            result.ShouldNotHaveValidationErrorFor(x => x.EmailAddress);
        }

        [Test]
        public void ValidModel_ShouldNotHaveValidation()
        {
            // arrange
            _model.FirstName = "John";
            _model.LastName = "Doe";
            _model.EmailAddress = "johndoe@gmail.com";

            // act
            TestValidationResult<UpsertPersonCommand> result = _validator.TestValidate(_model);

            // assert
            result.ShouldNotHaveValidationErrorFor(x => x.FirstName);
            result.ShouldNotHaveValidationErrorFor(x => x.LastName);
            result.ShouldNotHaveValidationErrorFor(x => x.EmailAddress);
        }
    }
}
