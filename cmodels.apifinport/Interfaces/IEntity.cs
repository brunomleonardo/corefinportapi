
namespace cmodels.apifinport.Interfaces
{
    public interface IEntity : IStatus
    {
        int Id { get; set; }
        bool Deleted { get; set; }
    }

}