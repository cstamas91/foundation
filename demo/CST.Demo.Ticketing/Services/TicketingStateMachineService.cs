using CST.Common.Utils.StateMachineFeature.Abstraction;
using CST.Common.Utils.StateMachineFeature.Services;
using CST.Demo.Data.Models.Ticketing;
using CST.Demo.Ticketing.Repositories;

namespace CST.Demo.Ticketing.Services
{
    public class TicketingStateMachineService :
        BaseStateMachineService<int, GraphEnum, TicketingEnum, Ticket, TicketingRepository>
    {
        public TicketingStateMachineService(TicketingRepository repository) : base(repository)
        {
        }

        public override GraphEnum Graph { get; } = GraphEnum.Ticketing;

        protected override void PreInitializeSubject(Ticket subject)
        {
        }

        protected override void PostInitializeSubject(Ticket subject)
        {
        }

        protected override void PostInitializeSubjectState(
            StateMachineSubjectMoment<int, GraphEnum, TicketingEnum, Ticket> subjectState)
        {
        }

        protected override void PreStepSubject(Ticket subject, int edgeId)
        {
        }

        protected override void PostStepSubject(Ticket subject, int edgeId)
        {
        }

        protected override void PostStepSubjectState(
            StateMachineSubjectMoment<int, GraphEnum, TicketingEnum, Ticket> subjectState)
        {
        }
        
        
    }
}