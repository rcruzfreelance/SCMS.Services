﻿// -----------------------------------------------------------------------
// Copyright (c) Signature Chess Club & MumsWhoCode. All rights reserved.
// -----------------------------------------------------------------------

using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using SMCS.Services.Api.Models.Foundations.Guardians;
using SMCS.Services.Api.Models.Foundations.Guardians.Exceptions;
using Xeptions;

namespace SMCS.Services.Api.Services.Foundations.Guardians
{
    public partial class GuardianService
    {
        private delegate ValueTask<Guardian> ReturningGuardianFunction();

        private async ValueTask<Guardian> TryCatch(ReturningGuardianFunction returningGuardianFunction)
        {
            try
            {
                return await returningGuardianFunction();
            }
            catch (NullGuardianException nullGuardianException)
            {
                throw CreateAndLogValidationException(nullGuardianException);
            }
            catch (InvalidGuardianException invalidGuardianException)
            {
                throw CreateAndLogValidationException(invalidGuardianException);
            }
            catch (SqlException sqlException)
            {
                var failedGuardianStorageException =
                    new FailedGuardianStorageException(sqlException);

                throw CreateAndLogCriticalDependencyException(
                    failedGuardianStorageException);
            }
        }

        private GuardianValidationException CreateAndLogValidationException(Xeption exception)
        {
            var guardianValidationException = new GuardianValidationException(exception);
            this.loggingBroker.LogError(guardianValidationException);

            return guardianValidationException;
        }

        private GuardianDependencyException CreateAndLogCriticalDependencyException(Xeption exception)
        {
            var guardianDependencyException = new GuardianDependencyException(exception);
            this.loggingBroker.LogCritical(guardianDependencyException);

            return guardianDependencyException;
        }
    }
}
