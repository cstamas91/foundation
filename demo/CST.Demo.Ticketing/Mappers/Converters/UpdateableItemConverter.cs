using AutoMapper;
using CST.Common.Utils.ViewModel;

namespace CST.Demo.Ticketing.Mappers.Converters
{
    public class UpdateableItemConverter<TItem, TDto> : 
        IValueConverter<TItem, UpdateableItem<TDto>>
    {
        public UpdateableItem<TDto> Convert(TItem sourceMember, ResolutionContext context)
        {
            return UpdateableItem<TDto>.Unchanged(context.Mapper.Map<TItem, TDto>(sourceMember));
        }
    }
}