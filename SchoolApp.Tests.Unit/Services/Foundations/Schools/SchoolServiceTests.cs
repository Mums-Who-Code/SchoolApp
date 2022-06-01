// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Moq;
using SchoolApp.ConsoleApp.Brokers.Loggings;
using SchoolApp.ConsoleApp.Brokers.Storages;
using SchoolApp.ConsoleApp.Models.Schools;
using SchoolApp.ConsoleApp.Services.Foundations.Schools;
using Tynamix.ObjectFiller;
using Xeptions;

namespace SchoolApp.Tests.Unit.Services.Foundations.Schools
{
    public partial class SchoolServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly ISchoolService schoolService;

        public SchoolServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.schoolService = new SchoolService(
                storageBroker: this.storageBrokerMock.Object,
                loggingBroker: this.loggingBrokerMock.Object);
        }

        private static Expression<Func<Xeption, bool>> SameExceptionAs(Xeption expectedException)
        {
            return actualException =>
                actualException.Message == expectedException.Message
                && actualException.InnerException.Message == expectedException.InnerException.Message
                && (actualException.InnerException as Xeption).DataEquals(expectedException.InnerException.Data);
        }

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();

        private static List<School> CreateRandomSchools() =>
            CreateSchoolFiller().Create(count: GetRandomNumber()).ToList();

        private static School CreateRandomSchool() =>
            CreateSchoolFiller().Create();

        private static Filler<School> CreateSchoolFiller() =>
            new Filler<School>();
    }
}