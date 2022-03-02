namespace KARYA.CORE.Entities.Abstarct
{
    public interface IEditEntity
    {   
        bool Inserted { get; set; }
        bool Updated { get; set; }
        bool Deleted { get; set; }
    }
}
