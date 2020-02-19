using AutoMapper;
using CST.Common.Utils.ViewModel;
using CST.StateMachineTest.Data;
using CST.StateMachineTest.Ticketing.Dtos;
using CST.StateMachineTest.Ticketing.Mappers.Converters;

namespace CST.StateMachineTest.Ticketing.Mappers
{
    public class CommitProfile : Profile
    {
        public CommitProfile()
        {
            CreateMap<Commit, CommitDto>();
            CreateMap<Commit, UpdateableItem<CommitDto>>()
                .ConvertUsing<UpdateableItemConverter<Commit, CommitDto>>();
        }
    }
}