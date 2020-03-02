using CST.Common.Utils.Common;

namespace CST.Demo.Data.Models.Ticketing
{
    public class Commit : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Hash { get; set; }    
    }
}