
namespace FinPort.Core
{
    public interface IEntity : IStatus
    {
        //int Id { get; set; }
        bool Deleted { get; set; }
    }

}