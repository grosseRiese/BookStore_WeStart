using BookStore.API.Models;

namespace BookStore.API.Interfaces
{
    public interface IContactUsRepository
    {
        Task<ContactUs> GetByIdAsync(int id);
        Task<IList<ContactUs>> GetAll();
        Task<ContactUs> Add(ContactUs entity);
        Task<ContactUs> Update(int id, ContactUs entity);
        Task<bool> Delete(int id);
    }
}
