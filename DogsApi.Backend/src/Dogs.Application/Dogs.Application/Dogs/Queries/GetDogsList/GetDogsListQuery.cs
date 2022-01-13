using Dogs.Core.Entities;
using MediatR;

namespace Dogs.Application.Dogs.Queries.GetDogsList
{
    public class GetDogsListQuery : IRequest<Dog[]>
    {
    }
}
