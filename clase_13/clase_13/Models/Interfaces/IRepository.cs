namespace clase_13.Models.Interfaces;

// Interface Segregation Principle: Define una interfaz genérica que puede ser implementada por cualquier repositorio específico.
// Open/Closed Principle: Permite extender la funcionalidad de los repositorios sin modificar esta interfaz.
public interface IRepository<T> where T : class
{
	IEnumerable<T> GetAll();
	T? GetById(int id);
	void Add(T entity);
	void Update(T entity);
	void Delete(int id);
}