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
        public void ShouldAddSchool()
        {
            //given
            School randomSchool = CreateRandomSchool();
            School inputSchool = randomSchool;
            School persistedSchool = inputSchool;
            School expectedSchool = persistedSchool.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.InsertSchool(inputSchool))
                    .Returns(persistedSchool);

            //when
            School actualSchool = this.schoolService.AddSchool(inputSchool);

            //then
            actualSchool.Should().BeEquivalentTo(expectedSchool);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertSchool(inputSchool),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}