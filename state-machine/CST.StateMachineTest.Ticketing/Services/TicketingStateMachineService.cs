using CST.Common.Utils.StateMachineFeature.BaseClasses;
using CST.StateMachineTest.Data;
using CST.StateMachineTest.Ticketing.Repositories;

namespace CST.StateMachineTest.Ticketing.Services
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