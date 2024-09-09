using Onion.CleanArchitecture.Net.Application.Interfaces;
using System;

namespace Onion.CleanArchitecture.Net.Infrastructure.Shared.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;

        public DateTime Now => DateTime.Now;
    }
}
