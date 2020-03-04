namespace CST.Demo.Ticketing.Dtos
{
    public class CreateTicketDto
    {
        public string Description { get; set; }
        public string Title { get; set; }
        public const string TitlePlaceholder = "Give your ticket a descriptive title";
        public const string DescriptionPlaceholder = "Describe your issue";
    }
}