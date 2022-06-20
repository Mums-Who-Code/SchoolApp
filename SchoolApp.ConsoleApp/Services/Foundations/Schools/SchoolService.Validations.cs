// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;
using SchoolApp.ConsoleApp.Models.Schools;
using SchoolApp.ConsoleApp.Models.Schools.Exceptions;

namespace SchoolApp.ConsoleApp.Services.Foundations.Schools
{
    public partial class SchoolService
    {
        private static void ValidateSchool(School school)
        {
            ValidateSchoolIsNotNull(school);

            Validate(
                (Rule: IsInvalid(school.SchoolId), Parameter: nameof(School.SchoolId)),
                (Rule: IsInvalid(text: school.SchoolName), Parameter: nameof(School.SchoolName)),
                (Rule: IsInvalid(text: school.SchoolLocation), Parameter: nameof(School.SchoolLocation)));
        }

        private static void ValidateInput(int SchoolId) =>
            Validate((Rule: IsInvalid(SchoolId), Parameter: nameof(School.SchoolId)));

        private static dynamic IsInvalid(int SchoolId) => new
        {
            Condition = SchoolId == default,
            Message = "ID is required."
        };

        private static dynamic IsInvalid(string text) => new
        {
            Condition = String.IsNullOrWhiteSpace(text),
            Message = "Text is required."
        };

        private static void ValidateSchoolIsNotNull(School school)
        {
            if (school == null)
            {
                throw new NullSchoolException();
            }
        }

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidSchoolException = new InvalidSchoolException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidSchoolException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }
            
            invalidSchoolException.ThrowIfContainsErrors();
        }
    }
}