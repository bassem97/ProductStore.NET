using System;
using System.Collections.Generic;
using System.Text;

namespace BJ.Data.Infrastructure
{
    public class DatabaseFactory : Disposable,IDatabaseFactory 
    {
        private PSContext context; 
        public DatabaseFactory()
        {
            this.context = new PSContext();
        }
        public PSContext Context { get { return context; } }

        public override void CoreDispose()
        {
            if(context != null)
            {
                context.Dispose();
            }
        }
    }
}
