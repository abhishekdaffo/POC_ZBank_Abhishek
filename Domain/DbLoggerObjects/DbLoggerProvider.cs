﻿using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Domain.DbLoggerObjects
{
    /// <summary>
    /// Provider for Log
    /// </summary>
    [ProviderAlias("Database")]
    public class DbLoggerProvider : ILoggerProvider
    {
        public readonly DbLoggerOptions Options;

        public DbLoggerProvider(IOptions<DbLoggerOptions> _options)
        {
            Options = _options.Value; // Stores all the options.
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new DbLogger(this);
        }

        public void Dispose()
        {
        }
    }
}
