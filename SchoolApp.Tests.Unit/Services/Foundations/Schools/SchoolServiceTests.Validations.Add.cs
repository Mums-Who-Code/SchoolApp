// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;
using Moq;
using SchoolApp.ConsoleApp.Models.Schools;
using SchoolApp.ConsoleApp.Models.Schools.Exceptions;
using Xunit;

namespace SchoolApp.Tests.Unit.Services.Foundations.Schools
{
    public partial class SchoolServiceTests
    {
        [Fact]
        public void ShouldThrowValidationExceptionOnAddIfSchoolIsNullAndLogIt()
        {
            //given
            School nullSchool = null;
            var nullSchoolException = new NullSchoolException();

            var expectedSchoolValidationException =
                new SchoolValidationException(nullSchoolException);

            //when
            Action addSchoolAction = () => this.schoolService.AddSchool(nullSchool);

            //then
            Assert.Throws<SchoolValidationException>(addSchoolAction);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedSchoolValidationException))),
                    Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertSchool(It.IsAny<School>()),
                    Times.Never);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public void ShouldThrowValidationExceptionOnAddIfSchoolIsInvalidAndLogIt(
            string invalidText)
        {
            //given
            var invalidSchool = new School
            {
                SchoolName = invalidText,
                SchoolLocation = invalidText
            };

            var invalidSchoolException = new InvalidSchoolException();

            invalidSchoolException.AddData(
                key: nameof(School.SchoolId),
                values: "ID is required.");

            invalidSchoolException.AddData(
                key: nameof(School.SchoolName),
                values: "Text is required.");

            invalidSchoolException.AddData(
                key: nameof(School.SchoolLocation),
                values: "Text is required.");

            var expectedSchoolValidationException =
                new SchoolValidationException(invalidSchoolException);

            //when
            Action addSchoolAction = () => this.schoolService.AddSchool(invalidSchool);

            //then
            Assert.Throws<SchoolValidationException>(addSchoolAction);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedSchoolValidationException))),
                         Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertSchool(It.IsAny<School>()),
                    Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}