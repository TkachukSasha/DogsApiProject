using Dogs.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogs.Test.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly DogsDbContext Context;

        public TestCommandBase()
        {
            Context = DogsDbContextFactory.Create();
        }

        public void Dispose()
        {
            NotesContextFactory.Destroy(Context);
        }
    }
}
