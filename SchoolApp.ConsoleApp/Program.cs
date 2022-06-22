// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using SchoolApp.ConsoleApp.Brokers.Loggings;
using SchoolApp.ConsoleApp.Brokers.Storages;
using SchoolApp.ConsoleApp.Models.Schools;
using SchoolApp.ConsoleApp.Services.Foundations.Schools;

namespace SchoolApp.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var storageBroker = new StorageBroker();
            var loggerFactory = new LoggerFactory();
            var logger = new Logger<LoggingBroker>(loggerFactory);
            var loggingBroker = new LoggingBroker(logger);
            var schoolService = new SchoolService(storageBroker, loggingBroker);

            var inputSchool = new School
            {
                SchoolId = 123,
                SchoolName = "Vidya Chaitanya School",
                SchoolLocation = "India"
            };

            schoolService.AddSchool(inputSchool);

            inputSchool = new School
            {
                SchoolId = 1236,
                SchoolName = "Elementary School",
                SchoolLocation = "US"
            };

            schoolService.AddSchool(inputSchool);
            List<School> storedSchools = schoolService.RetrieveAllSchools();
            School returningSchool = schoolService.RetrieveSchoolById(123);
        }
    }
}