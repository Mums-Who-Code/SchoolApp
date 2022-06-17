// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;
using Moq;
using SchoolApp.ConsoleApp.Models.Schools.Exceptions;
using Xunit;

namespace SchoolApp.Tests.Unit.Services.Foundations.Schools
{
    public partial class SchoolServiceTests
    {
        [Fact]
        public void ShouldThrowDependencyValidationExceptionOnRetrieveByIdIfValidationErrorOccursAndLogIt()
        {
            //given
            int someSchoolId = GetRandomNumber();
            var argumentNullException = new ArgumentNullException();

            var nullArgumentSchoolException =
                new NullArgumentSchoolException(argumentNullException);

            var expectedSchoolDependencyValidationException =
                new SchoolDependencyValidationException(
                    nullArgumentSchoolException);

            this.storageBrokerMock.Setup(broker =>
                broker.SelectSchoolById(It.IsAny<int>()))
                    .Throws(argumentNullException);

            //when
            Action retrieveSchoolByIdAction = () =>
                this.schoolService.RetrieveSchoolById(someSchoolId);

            //then
            Assert.Throws<SchoolDependencyValidationException>(retrieveSchoolByIdAction);

            this.storageBrokerMock.Verify(broker =>
              broker.SelectSchoolById(It.IsAny<int>()),
                  Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedSchoolDependencyValidationException))),
                        Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}