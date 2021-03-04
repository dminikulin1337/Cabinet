using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabinet
{
    class CardFile
    {
        Dictionary<char, SortedList<Author, List<Book>>> _storage;

        public CardFile()
        {
            _storage = new Dictionary<char, SortedList<Author, List<Book>>>();
            for (int i = 1040; i < 1072; i++)
            {
                _storage.Add((char)i, new SortedList<Author, List<Book>>());
            }
        }

        public List<Book> getBooks(string name, string surname)
        {
            char Letter = surname.ToUpper()[0]; //first letter of the author's surname
            if (_storage.ContainsKey(Letter))
            {
                foreach (Author oneAuthor in _storage[Letter].Keys)
                {
                    if (oneAuthor.Name.Equals(name) && oneAuthor.Surname.Equals(surname))
                    {
                        return _storage[Letter][oneAuthor];
                    }
                }
            }
            return null;
        }
        public List<Book> getBooks(string title)
        {
            List<Book> result = new List<Book>();

            foreach (var item in _storage.Values) //dictionary rows
            {
                foreach (List<Book> books in item.Values)
                {
                    foreach (Book oneBook in books)
                    {
                        if (oneBook.Title.Equals(title))
                        {
                            result.Add(oneBook);
                        }
                    }
                }
            }

            return result;
        }
        public bool AddAuthor(Author author)
        {
            char Letter = author.Surname.ToUpper()[0]; //First author's surname letter
            if (_storage.ContainsKey(Letter))
            {
                foreach (Author item in _storage[Letter].Keys)
                {
                    if (item.Equals(author))
                    {
                        return false;
                    }
                }
                _storage[Letter].Add(author, new List<Book>());
                return true;
            }
            return false;
        }
        public void AddBook(Book book)
        {
            foreach (Author oneAuthor in book.Authors)
            {
                AddAuthor(oneAuthor);
                if (getBook(oneAuthor, book.Title) == null)
                {
                    _storage[oneAuthor.Surname.ToUpper()[0]][oneAuthor].Add(book);
                }
            }
            
        }
        public Book getBook(Author author, string title)
        {
            if (_storage.ContainsKey(author.Surname.ToUpper()[0]))
            {
                foreach (Author auth in _storage[author.Surname.ToUpper()[0]].Keys)
                {
                    if (author.Equals(auth))
                    {
                        foreach (Book book in _storage[author.Surname.ToUpper()[0]][author])
                        {
                            if (book.Title.Equals(title))
                            {
                                return book;
                            }
                        }
                    }
                }
            }
            return null;
        }
        public List<Book> getBooks(Author author)
        {
            if (_storage.ContainsKey(author.Surname.ToUpper()[0]))
            {
                foreach (Author auth in _storage[author.Surname.ToUpper()[0]].Keys)
                {
                    if (author.Equals(auth))
                    {
                        return _storage[author.Surname.ToUpper()[0]][author];
                    }
                }
            }
            return null;
        }
        public KeyValuePair<Author, List<Book>> ? getAuthorData(string name, string surname, string patronimic, DateTime birxhDate)
        {
            if (_storage.ContainsKey(surname.ToUpper()[0]))
            {
                foreach (Author auth in _storage[surname.ToUpper()[0]].Keys)
                {
                    if (auth.Name.Equals(name) && auth.Surname.Equals(surname) && auth.Patroninimic.Equals(patronimic) && auth.birthDate == birxhDate)
                    {
                        return new KeyValuePair<Author, List<Book>>(auth, _storage[surname.ToUpper()[0]][auth]);
                    }
                }
            }
            return null;
        }
    }
}
