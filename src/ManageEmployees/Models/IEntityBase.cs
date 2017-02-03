using ManageEmployees.Models.Enums;

namespace ManageEmployees.Models
{
    public interface IEntityBase
    {
        int Id { get; set; }
        RecordStatus RecordStatus { get; set; }
    }
}