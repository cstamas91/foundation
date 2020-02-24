using CST.Common.Utils.Common;

namespace CST.StateMachineTest.Data
{
    public class Commit : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Hash { get; set; }    
    }
}