namespace CaspianTeam.Framework.NetCore.Models.DataAccess
{
    public class BaseEntites
    {
        public long Id { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
    }
}
