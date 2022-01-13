using Dogs.Infrastructure.Data;
using System;

namespace Dogs.Test.Common.Helpers
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly DogsDbContext Context;

        public TestCommandBase()
        {
            Context = DogsContextFactory.Create();
        }

        public void Dispose()
        {
            DogsContextFactory.Destroy(Context);
        }
    }
}
