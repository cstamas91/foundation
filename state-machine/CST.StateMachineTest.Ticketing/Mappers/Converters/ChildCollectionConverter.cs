using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoMapper;
using CST.Common.Utils.ViewModel;

namespace CST.StateMachineTest.Ticketing.Mappers.Converters
{
    public class ChildCollectionConverter<TItem, TDto> : IValueConverter<ICollection<TItem>, ChildCollection<TDto>>
    {
        public ChildCollection<TDto> Convert(ICollection<TItem> sourceMember, ResolutionContext context) =>
            ChildCollection<TDto>
                .Unchanged(sourceMember.Select(item => context.Mapper.Map<TItem, TDto>(item)));

        public static void Define<TS, TD>(IMemberConfigurationExpression<TS, TD, ChildCollection<TDto>> memberOptions)
        {
            memberOptions.ConvertUsing<ChildCollectionConverter<TItem, TDto>, ICollection<TItem>>();
        }
    }
}