using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabinet
{
    [Serializable]
    public class Book
    {
        private string _title;
        private string _content;
        public Genre genre;
        private DateTime _published;
        List<Author> _authors;
        public Publisher publisher;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
        public DateTime DatePublished
        {
            get { return _published; }
        }
        public List<Author> Authors
        {
            get { return _authors; }
        }
        public Book()
        {
            _title = "Book";
            _content = "See the book";
            genre = Genre.Analitics;
            _published = DateTime.Now;
            _authors = new List<Author>();
            publisher = Publisher.Unknown;
        }
        public Book(string title, string content, Genre genre, DateTime dateofpublish, Publisher publisher)
        {
            _title = title;
            _content = content;
            this.genre = genre;
            _published = dateofpublish;
            _authors = new List<Author>();
            this.publisher = publisher;
        }
        public override string ToString()
        {
            return $"The book" + 
                $"\nTitle: {Title}" + 
                $"\nGenre: {this.genre}" + 
                $"\nContent: {Content}" +
                $"\nDate of publish: {DatePublished}" + 
                $"\nPublisher: {this.publisher}";
        }
    }
}
