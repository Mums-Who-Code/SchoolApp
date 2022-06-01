// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System.Collections.Generic;
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
        public void ShouldRetrieveAllSchools()
        {
            //given
            List<School> randomSchools = CreateRandomSchools();
            List<School> persistedSchools = randomSchools;
            List<School> expectedSchools = persistedSchools.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllSchools())
                    .Returns(persistedSchools);

            //when
            List<School> actualSchools =
                this.schoolService.RetrieveAllSchools();

            //then
            actualSchools.Should().BeEquivalentTo(expectedSchools);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllSchools(),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}