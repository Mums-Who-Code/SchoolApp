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
            //Given
            School nullSchool = null;
            var nullSchoolException = new NullSchoolException();

            var expectedSchoolValidationException =
                new SchoolValidationException(nullSchoolException);


            //When
            Action addSchoolAction = () => this.schoolService.AddSchool(nullSchool);

            //Then
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
            //Given
            School invalidSchool = new School
            {
                SchoolName = invalidText,
                SchoolLocation = invalidText
            };

            var invalidSchoolException = new InvalidSchoolException();

            invalidSchoolException.AddData(
                key: nameof(School.SchoolId),
                values: "School ID is invalid");

            invalidSchoolException.AddData(
                key: nameof(School.SchoolName),
                values: "School Name is invalid");

            invalidSchoolException.AddData(
                key: nameof(School.SchoolLocation),
                values: "School Location is invalid");

            var expectedSchoolValidationException = new SchoolValidationException(invalidSchoolException);

            //When
            Action addSchoolAction = () => this.schoolService.AddSchool(invalidSchool);

            //Then
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