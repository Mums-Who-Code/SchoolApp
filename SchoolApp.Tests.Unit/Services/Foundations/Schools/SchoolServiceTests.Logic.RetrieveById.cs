// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using FluentAssertions;
using Force.DeepCloner;
using Moq;
using SchoolApp.ConsoleApp.Models.Schools;
using Xunit;

namespace SchoolApp.Tests.Unit.Services.Foundations.Schools
{
    public partial class SchoolServiceTests
    {
        [Fact]
        public void ShouldRetrieveSchoolById()
        {
            //given
            School randomSchool = CreateRandomSchool();
            School inputSchool = randomSchool;
            School storageSchool = inputSchool;
            School expectedSchool = storageSchool.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.SelectSchoolById(inputSchool.SchoolId))
                    .Returns(storageSchool);

            //when
            School actualSchool =
                this.schoolService.RetrieveSchoolById(inputSchool.SchoolId);

            //then
            actualSchool.Should().BeEquivalentTo(expectedSchool);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectSchoolById(inputSchool.SchoolId),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}