using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabinet
{
    [Serializable]
    public class Author: IComparable
    {
        private string _name;
        private string _surname;
        private string _patronimic;
        private DateTime _birthDate;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }
        public string Patroninimic
        {
            get { return _patronimic; }
            set { _patronimic = value; }
        }
        public DateTime birthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }
        public Author()
        {
            _name = "name";
            _surname = "surname";
            _patronimic = "patronimic";
            _birthDate = DateTime.Now;
        }
        public Author(string name, string surname, string patron, DateTime birth)
        {
            Name = name;
            Surname = surname;
            Patroninimic = patron;
            birthDate = birth;
        }
        public override bool Equals(object obj)
        {
            Author author = obj as Author;
            if (author != null)
            {
                return this.ToString().Equals(author.ToString());
            }
            else
            {
                throw new ArgumentException("Can't compare these two objects");
            }
        }
        public int CompareTo(object obj)
        {
            Author author = obj as Author;
            if (author != null)
            {
                return author.ToString().CompareTo(this.ToString());
            }
            else
            {
                throw new ArgumentException("Can't compare these two objects");
            }
        }
        public override string ToString()
        {
            return $"Author" +
                $"\nSurname: {Surname}" + 
                $"\nName: {Name}" + 
                $"\nPatronimic: {Patroninimic}" +
                $"\nBirthday: {birthDate}";
        }
    }
}
