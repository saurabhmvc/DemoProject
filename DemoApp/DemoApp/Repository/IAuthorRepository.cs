using DemoApp.Models;

namespace DemoApp.Repository
{
    public interface IAuthorRepository
    {
        public List<Author> GetAuthors();
    }
}
