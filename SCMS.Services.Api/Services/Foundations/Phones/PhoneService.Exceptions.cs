﻿// -----------------------------------------------------------------------
// Copyright (c) Signature Chess Club & MumsWhoCode. All rights reserved.
// -----------------------------------------------------------------------

using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using SCMS.Services.Api.Models.Foundations.Phones;
using SCMS.Services.Api.Models.Foundations.Phones.Exceptions;
using Xeptions;

namespace SCMS.Services.Api.Services.Foundations.Phones
{
    public partial class PhoneService
    {
        private delegate ValueTask<Phone> ReturningPhoneFunction();

        private async ValueTask<Phone> TryCatch(ReturningPhoneFunction returningPhoneFunction)
        {
            try
            {
                return await returningPhoneFunction();
            }
            catch (NullPhoneException nullPhoneException)
            {
                throw CreateAndLogValidationException(nullPhoneException);
            }
            catch (InvalidPhoneException invalidPhoneException)
            {
                throw CreateAndLogValidationException(invalidPhoneException);
            }
            catch (SqlException sqlException)
            {
                var failedPhoneStorageException =
                    new FailedPhoneStorageException(sqlException);

                throw CreateAndLogDependencyException(failedPhoneStorageException);
            }
        }

        private Xeption CreateAndLogValidationException(Xeption exception)
        {
            var phoneValidationException = new PhoneValidationException(exception);
            this.loggingBroker.LogError(phoneValidationException);

            return phoneValidationException;
        }

        private Xeption CreateAndLogDependencyException(Xeption exception)
        {
            var phoneDependencyException = new PhoneDependencyException(exception);
            this.loggingBroker.LogCritical(phoneDependencyException);

            return phoneDependencyException;
        }
    }
}
