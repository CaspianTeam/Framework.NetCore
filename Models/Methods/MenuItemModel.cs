namespace CaspianTeam.Framework.NetCore.Models.Methods
{
    public class MenuItemModel
    {
        public long? Id { get; set; }
        public long? BaseId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string IconClass { get; set; }
        public int? Order { get; set; }
    }
}
