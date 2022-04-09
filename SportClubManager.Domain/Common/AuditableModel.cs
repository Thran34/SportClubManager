namespace SportClubManager.Domain.Common
{
    public class AuditableModel
    {
        public int CreatedById { get; set; }
        public int? ModifiedById { get; set; }
    }
}