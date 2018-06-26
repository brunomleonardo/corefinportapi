namespace dal.apifinport.Interfaces
{
    public interface ICrud<E, T> where T : class
    {
        E ReadAll();
        E Create(T Entity);
        E Update(T Entity);
        E Delete(int Id);
        E Recover(int Id);
        E GetById(int Id);
        E GetByText(string input);
    }
}