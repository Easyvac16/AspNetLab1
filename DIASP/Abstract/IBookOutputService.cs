using DIASP.Model;

namespace DIASP.Abstract
{
    public interface IBookOutputService
    {

        public void SaveToFile(Book book, string filePath);

        public List<Book> LoadBooks(string filePath);
    }
}
