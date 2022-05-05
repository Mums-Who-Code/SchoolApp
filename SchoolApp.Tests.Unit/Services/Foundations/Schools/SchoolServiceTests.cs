// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using Moq;
using SchoolApp.ConsoleApp.Brokers.Storages;
using SchoolApp.ConsoleApp.Models.Schools;
using SchoolApp.ConsoleApp.Services.Foundations.Schools;
using Tynamix.ObjectFiller;

namespace SchoolApp.Tests.Unit.Services.Foundations.Schools
{
    public partial class SchoolServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly ISchoolService schoolService;

        public SchoolServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.schoolService = new SchoolService(storageBroker: this.storageBrokerMock.Object);
        }

        private static School CreateRandomSchool() =>
            CreateSchoolFiller().Create();

        private static Filler<School> CreateSchoolFiller() =>
            new Filler<School>();
    }
}