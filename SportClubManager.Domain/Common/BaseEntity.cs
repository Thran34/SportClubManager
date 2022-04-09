namespace SportClubManager.Domain.Common
{
    public class BaseEntity : AuditableModel
    {
        public int Id { get; set; }

        public int Category { get; set; }
    }
}
