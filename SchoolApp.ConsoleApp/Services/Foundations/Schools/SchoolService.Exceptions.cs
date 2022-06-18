// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;
using System.Collections.Generic;
using SchoolApp.ConsoleApp.Models.Schools;
using SchoolApp.ConsoleApp.Models.Schools.Exceptions;
using Xeptions;

namespace SchoolApp.ConsoleApp.Services.Foundations.Schools
{
    public partial class SchoolService
    {
        private delegate School ReturningSchoolFunction();
        private delegate List<School> ReturningSchoolsFunction();

        private School TryCatch(ReturningSchoolFunction returningSchoolFunction)
        {
            try
            {
                return returningSchoolFunction();
            }
            catch (NullSchoolException nullSchoolException)
            {
                throw CreateAndLogValidationException(nullSchoolException);
            }
            catch (InvalidSchoolException invalidSchoolException)
            {
                throw CreateAndLogValidationException(invalidSchoolException);
            }
            catch (ArgumentNullException argumentNullException)
            {
                var nullargumentSchoolException =
                    new NullArgumentSchoolException(argumentNullException);

                throw CreateAndLogDependencyValidationException(
                    nullargumentSchoolException);
            }
            catch (Exception exception)
            {
                var failedSchoolServiceException =
                    new FailedSchoolServiceException(exception);

                throw CreateAndLogServiceException(failedSchoolServiceException);
            }
        }

        private List<School> TryCatch(ReturningSchoolsFunction returningSchoolsFunction)
        {
            try
            {
                return returningSchoolsFunction();
            }
            catch (Exception exception)
            {
                var failedSchoolServiceException =
                    new FailedSchoolServiceException(exception);

                throw CreateAndLogServiceException(
                    failedSchoolServiceException);
            }
        }

        private SchoolValidationException CreateAndLogValidationException(Xeption exception)
        {
            var schoolValidationException = new SchoolValidationException(exception);
            this.loggingBroker.LogError(schoolValidationException);

            return schoolValidationException;
        }

        private SchoolDependencyValidationException CreateAndLogDependencyValidationException(Xeption exception)
        {
            var schoolDependencyValidationException =
                new SchoolDependencyValidationException(exception);

            this.loggingBroker.LogError(schoolDependencyValidationException);

            return schoolDependencyValidationException;
        }

        private SchoolServiceException CreateAndLogServiceException(Xeption exception)
        {
            var schoolServiceException = new SchoolServiceException(exception);
            this.loggingBroker.LogError(schoolServiceException);

            return schoolServiceException;
        }
    }
}