using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CST.Common.Utils.Common;
using CST.Common.Utils.ViewModel;

namespace CST.StateMachineTest.Ticketing.Mappers.Converters
{
    public class ChildCollectionConverter<TItem, TDto, TKey> : 
        IValueConverter<ICollection<TItem>, ChildCollection<TDto>>,
        ITypeConverter<ChildCollection<TDto>, ICollection<TItem>>
        where TItem: IIdentifiable<TKey> 
        where TKey : struct, IEquatable<TKey>
        where TDto: IIdentifiable<TKey>
    {
        public ChildCollection<TDto> Convert(ICollection<TItem> sourceMember, ResolutionContext context) =>
            ChildCollection<TDto>
                .Unchanged(sourceMember.Select(item => context.Mapper.Map<TItem, TDto>(item)));

        public static void Define<TS, TD>(IMemberConfigurationExpression<TS, TD, ChildCollection<TDto>> memberOptions)
        {
            memberOptions.ConvertUsing<ChildCollectionConverter<TItem, TDto, TKey>, ICollection<TItem>>();
        }

        public ICollection<TItem> Convert(ChildCollection<TDto> source, ICollection<TItem> destination, ResolutionContext context)
        {
            if (destination == null)
            {
                destination = new List<TItem>();
            }

            var added = source.GetItems(UpdateableItemState.Added);
            var removed = source.GetItems(UpdateableItemState.Deleted);
            var modified = source.GetItems(UpdateableItemState.Modified);
            foreach (var addedItem in added)
            {
                destination.Add(context.Mapper.Map<TItem>(addedItem));
            }

            foreach (var modifiedItem in modified)
            {
                var item = destination.FirstOrDefault(i => i.Id.Equals(modifiedItem.Id));
                context.Mapper.Map(modifiedItem, item);
            }

            foreach (var removedItem in removed)
            {
                var item = destination.FirstOrDefault(i => i.Id.Equals(removedItem.Id));
                destination.Remove(item);
            }

            return destination;
        }
    }
}