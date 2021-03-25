using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Cabinet
{
    [Serializable]
    class Program
    {
        static void Main(string[] args)
        {
            /*try
            {
                CardFile card = new CardFile();
                Author Shevchenko = new Author("Тарас", "Шевченко", "Григорьевич", new DateTime(1814, 3, 09));
                card.AddAuthor(Shevchenko);

                Book Kobzar = new Book("Кобзарь", "Сборка поэзий", Genre.Poems, new DateTime(1860, 1, 1), Publisher.Unknown);
                Kobzar.Authors.Add(Shevchenko);

                Book DepecheMode = new Book("Депеш Мод", "Про молодёжь 90-х", Genre.Lifestyle, new DateTime(2004, 1, 1), Publisher.BookClub);
                DepecheMode.Authors.Add(new Author("Сергей", "Жадан", "Викторович", new DateTime(1974, 8, 23)));
                Book Voroshylovgrad = new Book("Ворошиловград", "Как луганчанин путешествовал", Genre.Lifestyle, new DateTime(2010, 1, 1), Publisher.BookClub);
                Voroshylovgrad.Authors.Add(new Author("Сергей", "Жадан", "Викторович", new DateTime(1974, 8, 23)));

                card.AddBook(Kobzar);
                card.AddBook(DepecheMode);
                card.AddBook(Voroshylovgrad);

                Book book = card.getBook(Shevchenko, Kobzar.Title);
                Console.WriteLine(book);

                Console.WriteLine();

                foreach (Book oneBook in card.getBooks("Атлант расслабил булки"))
                {
                    Console.WriteLine(oneBook);
                }

                Console.WriteLine();

                Console.WriteLine("От Жадана");
                foreach (Book oneBook in card.getBooks(new Author("Сергей", "Жадан", "Викторович", new DateTime(1974, 8, 23))))
                {
                    Console.WriteLine(oneBook);
                    Console.WriteLine();
                }

                Console.WriteLine("This is America");
                KeyValuePair<Author, List<Book>> ? data = card.getAuthorData("Сергей", "Жадан", "Викторович", new DateTime(1974, 8, 23));
                Console.WriteLine(data.Value.Key);
                Console.WriteLine(data.Value.Value.Count);

                Console.ForegroundColor = ConsoleColor.Green;
                //конструктора FileReader'a нет, поэтому путь к файлу записываем таким образом
                Console.WriteLine(FileReader.ReadTextFile("C:\\Users\\dmini\\Desktop\\My repo.txt"));
                Console.WriteLine();
                Console.ResetColor();
            }
            catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                //Console.WriteLine(ex.StackTrace);
                Console.ResetColor();
            }*/

            BinaryFormatter formatter = new BinaryFormatter();
            //serialization
            Stream stream = File.Create("Book.bin");
            formatter.Serialize(stream, new Book("Just a book", "Content.net", Genre.Analitics, DateTime.Now, Publisher.Unknown));
            stream.Close();
            //deserialization
            Book book = (Book)formatter.Deserialize(File.OpenRead("Book.bin"));
            Console.WriteLine(book);

            XmlSerializer XMLS = new XmlSerializer(typeof(Book));
            Stream XMLStream = File.Create("Book.xml");
            Book zBook = new Book("Just a book", "Content.net", Genre.Analitics, DateTime.Now, Publisher.Unknown);
            zBook.Authors.Add(new Author("Andy", "Walker", "Paul", DateTime.Now));
            zBook.Authors.Add(new Author("Erik", "Mobster", "Dusan", DateTime.Now));
            XMLS.Serialize(XMLStream, zBook);
            XMLStream.Close();

            Book Nbook = (Book)XMLS.Deserialize(File.OpenRead("Book.xml"));
            Console.WriteLine(Nbook);
        }
    }
}
