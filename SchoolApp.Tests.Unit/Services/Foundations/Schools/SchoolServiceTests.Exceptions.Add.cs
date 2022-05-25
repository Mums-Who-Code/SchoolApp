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
        public void ShouldThrowServiceExceptionOnAddIfServiceErrorOccursAndLogIt()
        {
            //given
            School someSchool = CreateRandomSchool();
            var serviceException = new Exception();

            var failedSchoolServiceException =
                new FailedSchoolServiceException(serviceException);

            var expectedSchoolServiceException =
                new SchoolServiceException(
                    failedSchoolServiceException);

            this.storageBrokerMock.Setup(broker =>
                broker.InsertSchool(It.IsAny<School>()))
                    .Throws(serviceException);

            //when
            Action addSchoolAction = () => this.schoolService.AddSchool(someSchool);

            //then
            Assert.Throws<SchoolServiceException>(addSchoolAction);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertSchool(It.IsAny<School>()),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedSchoolServiceException))),
                        Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}