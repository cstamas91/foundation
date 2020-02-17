using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CST.Common.Utils.ViewModel;
using CST.StateMachineTest.Data;
using CST.StateMachineTest.Ticketing.Dtos;

namespace CST.StateMachineTest.Ticketing.Mappers.Converters
{
    public class RelatedCommitsConverter : IValueConverter<ICollection<Commit>, UpdateableItem<CommitDto>[]>
    {
        public UpdateableItem<CommitDto>[] Convert(ICollection<Commit> sourceMember, ResolutionContext context)
        {
            return sourceMember.Select(context.Mapper.Map<Commit, UpdateableItem<CommitDto>>)
                .ToArray();
        }
    }
}