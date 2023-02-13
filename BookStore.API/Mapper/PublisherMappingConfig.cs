using BookStore.API.DTOs;
using BookStore.API.Models;
using Mapster;

namespace BookStore.API.Mapper
{
    public class PublisherMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreatePublisherDto, Publisher>()
                .Map(dest => dest.Name, src => src.Name);
        }
    }
}
