using MediatR;
using System;

namespace Dogs.Application.Dogs.Commands.CreateDog
{
    public partial class CreateDogCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public float TailLenght { get; set; }
        public float Weight { get; set; }
    }
}
