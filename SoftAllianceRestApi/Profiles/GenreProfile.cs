using AutoMapper;

namespace SoftAllianceRestApi.Profiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Models.Genre, Models.modelDto.GenreDto>();
            CreateMap<Models.modelDtos.GenreForCreateUpdateDto, Models.Genre>();
          
        }
    }
}
