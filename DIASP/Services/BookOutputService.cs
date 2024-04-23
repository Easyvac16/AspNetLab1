using DIASP.Abstract;
using DIASP.Model;

namespace DIASP.Services
{
    public class BookOutputService : IBookOutputService
    {
        public void SaveToFile(Book book, string filePath)
        { 
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(book.ToString());
                sw.WriteLine("         ");
            }
        }

        /*public List<Book> LoadBooks(string filePath)
        {
            List<Book> books = new List<Book>();
            string[] lines = File.ReadAllLines(filePath);

            int currentIndex = -1;

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    books.Add(new Book());
                    currentIndex++;
                }
                else
                {
                    string[] parts = line.Split(':');
                    if (parts.Length >= 2)
                    {
                        string key = parts[0].Trim();
                        string value = parts[1].Trim();

                        switch (key)
                        {
                            case "Name":
                                books[currentIndex].Name = value;
                                break;

                            case "Author":
                                books[currentIndex].Author = value;
                                break;

                            case "Style":
                                books[currentIndex].Style = value;
                                break;

                            case "Age":
                                int.TryParse(value, out int age);
                                books[currentIndex].Age = age;
                                break;
                        }
                    }
                }
            }

            books.RemoveAll(b => string.IsNullOrWhiteSpace(b.Name) || string.IsNullOrWhiteSpace(b.Author) || string.IsNullOrWhiteSpace(b.Style) || b.Age <= 0);

            return books;
        }*/

        public List<Book> LoadBooks(string filePath)
        {
            List<Book> books = new List<Book>();
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    string[] parts = line.Split(' ');

                    string name = "", style = "", author = "";
                    int age = 0;

                    for (int i = 0; i < parts.Length; i++)
                    {
                        string partValue = parts[i].Trim().Split(':')[1].Trim();

                        switch (parts[i].Split(':')[0].Trim())
                        {
                            case "Name":
                                name = partValue;
                                break;

                            case "Author":
                                author = partValue;
                                break;

                            case "Age":
                                int.TryParse(partValue, out age);
                                break;
                            
                            case "Style":
                                style = partValue;
                                break;
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(author) && !string.IsNullOrWhiteSpace(style) && age > 0)
                    {
                        books.Add(new Book
                        {
                            Name = name,
                            Author = author,
                            Style = style,
                            Age = age
                        }) ;
                    }
                }
            }
            return books;
        }


    }
}
