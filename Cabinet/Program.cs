using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabinet
{
    class Program
    {
        static void Main(string[] args)
        {
            CardFile card = new CardFile();
            card.AddAuthor(new Author("Тарас", "Шевченко", "Григорьевич", new DateTime(1814, 3, 09)));
            card.AddAuthor(new Author("Николай", "Гоголь", "Васильевич", new DateTime(1809, 4, 01)));
            card.AddAuthor(new Author("Василий", "Симоненко", "Андреевич", new DateTime(1935, 1, 08)));

            Console.WriteLine(card);
        }
    }
}
