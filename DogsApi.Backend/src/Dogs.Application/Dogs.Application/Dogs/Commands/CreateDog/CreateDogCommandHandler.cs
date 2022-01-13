using Dogs.Application.Common.Contracts;
using Dogs.Core.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dogs.Application.Dogs.Commands.CreateDog
{
    public class CreateDogCommandHandler
        : IRequestHandler<CreateDogCommand, Guid>
    {
        private readonly IDogsDbContext _repository;

        public CreateDogCommandHandler(IDogsDbContext repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateDogCommand request, CancellationToken cancellationToken)
        {
            var dog = new Dog
            {
                Name = request.Name,
                Color = request.Color,
                TailLenght = request.TailLenght,
                Weight = request.Weight
            };

            await _repository.Dogs.AddAsync(dog, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return dog.Id;
        }
    }
}
