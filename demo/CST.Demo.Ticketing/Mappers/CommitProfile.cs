using AutoMapper;
using CST.StateMachineTest.Data;
using CST.StateMachineTest.Ticketing.Dtos;

namespace CST.StateMachineTest.Ticketing.Mappers
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