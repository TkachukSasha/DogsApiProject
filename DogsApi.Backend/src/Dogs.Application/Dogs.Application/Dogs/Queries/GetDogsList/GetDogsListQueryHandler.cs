using Dogs.Application.Common.Contracts;
using Dogs.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dogs.Application.Dogs.Queries.GetDogsList
{
    public class GetDogsListQueryHandler
        : IRequestHandler<GetDogsListQuery, Dog[]>
    {
        private readonly IDogsDbContext _repository;

        public GetDogsListQueryHandler(IDogsDbContext repository)
        {
            _repository = repository;
        }

        public Task<Dog[]> Handle(GetDogsListQuery request, CancellationToken cancellationToken)
        {
            var result = _repository.Dogs.ToArray();

            return Task.FromResult(result);
        }
    }
}
