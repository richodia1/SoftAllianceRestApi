using AutoMapper;

namespace SoftAllianceRestApi.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Models.Movie, Models.modelDto.MovieDto>();
            CreateMap<Models.Movie, Models.modelDtos.MovieForCreateUpdateDto>();
            
        }
    }
}
