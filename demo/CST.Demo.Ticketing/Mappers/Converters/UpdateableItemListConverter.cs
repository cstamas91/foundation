using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using CST.Common.Utils.Common;
using CST.Common.Utils.ViewModel;

namespace CST.Demo.Ticketing.Mappers.Converters
{
    public class UpdateableItemListConverter<TItem, TDto, TKey> : 
        IValueConverter<ICollection<TItem>, List<UpdateableItem<TDto>>>
        where TItem: IIdentifiable<TKey> 
        where TKey : struct, IEquatable<TKey>
        where TDto: IIdentifiable<TKey>
    {
        public List<UpdateableItem<TDto>> Convert(ICollection<TItem> sourceMember, ResolutionContext context) =>
            sourceMember
                .Select(item => UpdateableItem<TDto>.Unchanged(context.Mapper.Map<TItem, TDto>(item)))
                .ToList();

        public static void Define<TS, TD>(
            IMemberConfigurationExpression<TS, TD, List<UpdateableItem<TDto>>> memberOptions,
            Expression<Func<TS, ICollection<TItem>>> sourceMember)
        {
            memberOptions.ConvertUsing<UpdateableItemListConverter<TItem, TDto, TKey>, ICollection<TItem>>(sourceMember);
        }
    }
}