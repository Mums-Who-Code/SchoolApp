﻿// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using SchoolApp.ConsoleApp.Brokers.Loggings;
using SchoolApp.ConsoleApp.Brokers.Storages;
using SchoolApp.ConsoleApp.Models.Schools;

namespace SchoolApp.ConsoleApp.Services.Foundations.Schools
{
    public partial class SchoolService : ISchoolService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public SchoolService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public School AddSchool(School school) =>
        TryCatch(() =>
        {
            ValidateSchool(school);

            return this.storageBroker.InsertSchool(school);
        });
    }
}