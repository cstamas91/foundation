using AutoMapper;
using CST.Demo.Data.Models.Ticketing;
using CST.Demo.Ticketing.Dtos;

namespace CST.Demo.Ticketing.Mappers
{
    public class CommitProfile : Profile
    {
        public CommitProfile()
        {
            CreateMap<Commit, CommitDto>()
                .ReverseMap();
        }
    }
}