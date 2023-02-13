using BookStore.API.Models;

namespace BookStore.API.Interfaces
{
    public interface ITranslatorRepository
    {
        Task<Translator> GetByIdAsync(int id);
        Task<IList<Translator>> GetAll();
        Task<Translator> Add(Translator entity);
        Task<Translator> Update(Translator entity);
        Task<bool> Delete(int id);
    }
}
