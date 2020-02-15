using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using CST.Common.Utils.StateMachineFeature.BaseClasses;
using CST.Common.Utils.ViewModel;
using CST.StateMachineTest.Data;
using CST.StateMachineTest.Services;
using CST.StateMachineTest.Ticketing.Dtos;
using CST.StateMachineTest.Ticketing.Mappers.Converters;

namespace CST.StateMachineTest.Ticketing.Mappers
{
    public class TicketingProfile : Profile
    {
        public TicketingProfile()
        {
            CreateMap<CreateTicketDto, Ticket>()
                .ForMember(
                    ticket => ticket.RelatedCommits,
                    options => options.MapFrom(dto => new List<Commit>()));

            CreateMap<Ticket, TicketDto>()
                .ForMember(
                    dto => dto.State,
                    options => options.MapFrom(
                        ticket => ticket.CurrentSubjectState.Vertex.Name))
                .ForMember(
                    dto => dto.RelatedCommits,
                    options => options.ConvertUsing<RelatedCommitsConverter, ICollection<Commit>>())
                .ForMember(
                    dto => dto.State,
                    options => options.MapFrom(ticket => ticket.CurrentSubjectState));

            CreateMap<StateMachineSubjectMoment<int, GraphEnum, TicketingEnum, Ticket>, string>()
                .ConvertUsing<CurrentStateConverter>();

            CreateMap<Commit, CommitDto>();
            CreateMap<Commit, UpdateableItem<CommitDto>>()
                .ConvertUsing<UpdateableItemConverter<Commit, CommitDto>>();

            CreateMap<TicketFilter, Expression<Func<Ticket, bool>>>()
                .ConvertUsing<TicketFilterConverter>();
        }
    }
}