using System.Collections;
using AutoMapper;
using CST.Common.Utils.ViewModel;

namespace CST.StateMachineTest.Ticketing.Mappers.Converters
{
    public class UpdateableItemConverter<TSource, TItem> : ITypeConverter<TSource, UpdateableItem<TItem>>
    {
        public UpdateableItem<TItem> Convert(
            TSource source, 
            UpdateableItem<TItem> destination, 
            ResolutionContext context)
        {
            var item = context.Mapper.Map<TSource, TItem>(source);
            return UpdateableItem<TItem>.Unchanged(item);
        }
    }
}