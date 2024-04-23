using DIASP.Model;

namespace DIASP.Abstract
{
    public interface IPersonOutputService
    {

        public void SaveToFile(Person person, string filePath);

        public List<Person> LoadPerson(string filePath);
    }
}
