﻿// -----------------------------------------------------------------------
// Copyright (c) Signature Chess Club & MumsWhoCode. All rights reserved.
// -----------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Moq;
using SCMS.Services.Api.Models.Foundations.Guardians;
using SCMS.Services.Api.Models.Foundations.Guardians.Exceptions;
using Xunit;

namespace SCMS.Services.Tests.Unit.Services.Foundations.Guardians
{
    public partial class GuardianServiceTests
    {
        [Fact]
        public async Task ShouldThrowCriticalDependencyExceptionOnRetreiveByIdIfSqlErrorOccursAndLogItAsync()
        {
            // given
            Guid someGuardianId = Guid.NewGuid();
            SqlException sqlException = GetSqlException();

            var failedGuardianStorageException =
                new FailedGuardianStorageException(sqlException);

            var expectedGuardianDependencyException =
                new GuardianDependencyException(failedGuardianStorageException);

            this.storageBrokerMock.Setup(broker =>
                broker.SelectGuardianByIdAsync(It.IsAny<Guid>()))
                    .Throws(sqlException);

            // when
            ValueTask<Guardian> retrieveGuardianByIdTask =
                this.guardianService.RetrieveGuardianByIdAsync(someGuardianId);

            // then
            await Assert.ThrowsAsync<GuardianDependencyException>(() =>
                retrieveGuardianByIdTask.AsTask());

            this.storageBrokerMock.Verify(broker =>
                broker.SelectGuardianByIdAsync(It.IsAny<Guid>()),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogCritical(It.Is(SameExceptionAs(
                    expectedGuardianDependencyException))),
                        Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnRetreiveByIdIfDependenctErrorOccursAndLogItAsync()
        {
            // given
            Guid someGuardianId = Guid.NewGuid();
            var invalidOperationException = new InvalidOperationException();

            var failedGuardianStorageException =
                new FailedGuardianStorageException(invalidOperationException);

            var expectedGuardianDependencyException =
                new GuardianDependencyException(failedGuardianStorageException);

            this.storageBrokerMock.Setup(broker =>
                broker.SelectGuardianByIdAsync(It.IsAny<Guid>()))
                    .Throws(invalidOperationException);

            // when
            ValueTask<Guardian> retrieveGuardianByIdTask =
                this.guardianService.RetrieveGuardianByIdAsync(someGuardianId);

            // then
            await Assert.ThrowsAsync<GuardianDependencyException>(() =>
                retrieveGuardianByIdTask.AsTask());

            this.storageBrokerMock.Verify(broker =>
                broker.SelectGuardianByIdAsync(It.IsAny<Guid>()),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedGuardianDependencyException))),
                        Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
