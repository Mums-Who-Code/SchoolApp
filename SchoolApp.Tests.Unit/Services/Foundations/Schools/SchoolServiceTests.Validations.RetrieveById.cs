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
        public void ShouldThrowValidationExceptionOnRetrieveByIdIfIdIsInvalidAndLogIt()
        {
            //given
            var invalidSchool = new School();
            var invalidSchoolException = new InvalidSchoolException();

            invalidSchoolException.AddData(
                key: nameof(School.SchoolId),
                values: "ID is required.");

            var expectedSchoolValidationException =
                new SchoolValidationException(invalidSchoolException);

            //when
            Action retrieveSchoolByIdAction = () =>
                this.schoolService.RetrieveSchoolById(invalidSchool.SchoolId);

            //then
            Assert.Throws<SchoolValidationException>(retrieveSchoolByIdAction);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedSchoolValidationException))),
                        Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectSchoolById(It.IsAny<int>()),
                    Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}