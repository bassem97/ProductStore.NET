using System;
using System.Collections.Generic;
using System.Text;

namespace BJ.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        PSContext Context { get; }
    }
}
