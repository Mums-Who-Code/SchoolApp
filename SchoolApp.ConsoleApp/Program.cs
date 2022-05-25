// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

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
        }
    }
}