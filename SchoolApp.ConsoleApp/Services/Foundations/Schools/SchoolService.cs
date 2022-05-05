// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;
using SchoolApp.ConsoleApp.Brokers.Storages;
using SchoolApp.ConsoleApp.Models.Schools;

namespace SchoolApp.ConsoleApp.Services.Foundations.Schools
{
    public class SchoolService : ISchoolService
    {
        private readonly IStorageBroker storageBroker;

        public SchoolService(IStorageBroker storageBroker) =>
            this.storageBroker = storageBroker;

        public School AddSchool(School school) =>
            this.storageBroker.InsertSchool(school);
     }
}