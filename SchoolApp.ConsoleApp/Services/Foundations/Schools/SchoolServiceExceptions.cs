// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using SchoolApp.ConsoleApp.Models.Schools;
using SchoolApp.ConsoleApp.Models.Schools.Exceptions;
using Xeptions;

namespace SchoolApp.ConsoleApp.Services.Foundations.Schools
{
    public partial class SchoolService
    {
        private delegate School ReturningSchoolFunction();

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
        }

        private SchoolValidationException CreateAndLogValidationException(Xeption exception)
        {
            var schoolValidationException = new SchoolValidationException(exception);
            this.loggingBroker.LogError(schoolValidationException);

            throw schoolValidationException;
        }
    }
}