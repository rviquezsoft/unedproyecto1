namespace Proyecto1.Services
{
    public interface ICRUDService<T> where T : new()
    {
        string Add(T entity);
        int CountAll();
        string Delete(string nid, int id);
        List<T> Get();
        T GetById(string nid, int id);
        string Update(T entity,string nid, int id);
    }
}