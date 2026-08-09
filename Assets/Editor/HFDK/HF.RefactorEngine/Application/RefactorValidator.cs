using System;
using System.Collections.Generic;
using System.Linq;

using HF.Refactor.Models;

namespace HF.Refactor.Engine
{
    /// <summary>
    /// Validates a refactor job before execution.
    /// Every rule that could prevent a safe refactor
    /// belongs here.
    /// </summary>
    public sealed class RefactorValidator
    {
        private readonly Logger _logger;

        public RefactorValidator(Logger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Validates the supplied refactor job.
        /// Throws an exception if validation fails.
        /// </summary>
        public void Validate(RefactorJob job)
        {
            if (job == null)
                throw new ArgumentNullException(nameof(job));

            _logger.Info("Validating refactor job...");

            ValidateSearchTerms(job);

            ValidateOperations(job);

            ValidateDuplicateTargets(job);

            ValidateReservedIdentifiers(job);

            _logger.Info("Validation completed successfully.");
        }

        //----------------------------------------------------
        // Validation Rules
        //----------------------------------------------------

        private static void ValidateSearchTerms(
            RefactorJob job)
        {
            if (string.IsNullOrWhiteSpace(job.Find))
                throw new InvalidOperationException(
                    "Find value cannot be empty.");

            if (string.IsNullOrWhiteSpace(job.Replace))
                throw new InvalidOperationException(
                    "Replace value cannot be empty.");

            if (job.Find == job.Replace)
                throw new InvalidOperationException(
                    "Find and Replace cannot be identical.");
        }

        private static void ValidateOperations(
            RefactorJob job)
        {
            if (job.Operations == null)
                throw new InvalidOperationException(
                    "Operations collection is null.");

            if (job.Operations.Count == 0)
                throw new InvalidOperationException(
                    "No refactor operations were generated.");
        }

        private static void ValidateDuplicateTargets(
            RefactorJob job)
        {
            IEnumerable<string> duplicates =
                job.Operations
                   .Where(x => !string.IsNullOrWhiteSpace(x.After))
                   .GroupBy(x => x.After)
                   .Where(g => g.Count() > 1)
                   .Select(g => g.Key);

            if (duplicates.Any())
            {
                throw new InvalidOperationException(
                    $"Duplicate target detected: {duplicates.First()}");
            }
        }

        private static void ValidateReservedIdentifiers(
            RefactorJob job)
        {
            string[] reserved =
            {
                "class",
                "namespace",
                "public",
                "private",
                "protected",
                "internal",
                "void",
                "string",
                "int",
                "float",
                "bool",
                "object",
                "null"
            };

            if (reserved.Contains(job.Replace))
            {
                throw new InvalidOperationException(
                    $"'{job.Replace}' is a reserved C# keyword.");
            }
        }
    }
}