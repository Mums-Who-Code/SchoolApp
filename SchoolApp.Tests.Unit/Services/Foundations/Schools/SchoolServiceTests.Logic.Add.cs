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
            //Given
            School randomSchool = CreateRandomSchool();
            School inputSchool = randomSchool;
            School persistedSchool = inputSchool; 
            School expectedSchool = persistedSchool.DeepClone();

            this.storageBrokerMock.Setup(broker =>
            broker.InsertSchool(inputSchool))
                .Returns(persistedSchool);

            //When
            School actualSchool = this.schoolService.AddSchool(inputSchool);

            //Then
            actualSchool.Should().BeEquivalentTo(expectedSchool);

            this.storageBrokerMock.Verify(broker =>
            broker.InsertSchool(inputSchool), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}