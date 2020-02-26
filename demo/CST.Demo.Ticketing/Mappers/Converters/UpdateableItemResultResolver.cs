using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CST.Common.Utils.Common;
using CST.Common.Utils.ViewModel;

namespace CST.Demo.Ticketing.Mappers.Converters
{
    public class UpdateableItemResultResolver<TMemberSource, TMemberDestination, TItem, TDto, TKey> :
        IMappingAction<TMemberSource, TMemberDestination>
        where TItem : IIdentifiable<TKey>
        where TDto : IIdentifiable<TKey>
        where TKey : struct, IEquatable<TKey>
        where TMemberSource : IUpdateableItemCollectionSource<TDto>
        where TMemberDestination : IUpdateableItemCollectionDestination<TItem>
    {
        public void Process(
            TMemberSource source, 
            TMemberDestination destination, 
            ResolutionContext context)
        {
            var sourceCollection = source.GetSourceCollection().ToList();
            var destinationCollection = destination.GetDestinationCollection();
            ResolveAdded(sourceCollection, destinationCollection, context);
            ResolveModified(sourceCollection, destinationCollection, context);
            ResolveDeleted(sourceCollection, destinationCollection);
        }

        private static void ResolveAdded(
            IEnumerable<UpdateableItem<TDto>> items,
            ICollection<TItem> destMember,
            ResolutionContext context)
        {
            var added = items
                .Where(i => i.UpdateableItemState == UpdateableItemState.Added);

            foreach (var addedItem in added)
            {
                destMember.Add(context.Mapper.Map<TItem>(addedItem.Item));
            }
        }

        private static void ResolveModified(
            IEnumerable<UpdateableItem<TDto>> items,
            ICollection<TItem> destMember,
            ResolutionContext context)
        {
            var modified = items
                .Where(i => i.UpdateableItemState == UpdateableItemState.Modified);

            foreach (var modifiedItem in modified)
            {
                var item = destMember.FirstOrDefault(i => i.Id.Equals(modifiedItem.Item.Id));
                context.Mapper.Map(modifiedItem.Item, item);
                destMember.Add(item);
            }
        }

        private static void ResolveDeleted(
            IEnumerable<UpdateableItem<TDto>> items,
            ICollection<TItem> destMember)
        {
            var modified = items
                .Where(i => i.UpdateableItemState == UpdateableItemState.Deleted);

            foreach (var modifiedItem in modified)
            {
                var item = destMember.FirstOrDefault(i => i.Id.Equals(modifiedItem.Item.Id));
                destMember.Remove(item);
            }
        }
    }
}