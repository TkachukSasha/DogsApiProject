using AutoMapper;
using Dogs.Application.Common.Contracts;
using Dogs.Application.Common.Mapping;
using Dogs.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Dogs.Test.Common.Helpers
{
    public class QueryTestFixture : IDisposable
    {
        public DogsDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = DogsContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(IDogsDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            DogsContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
