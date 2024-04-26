using MoviesRental.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoviesRental.Domain.Entities
{
    public class Director : Entity
    {
        protected Director() { }
        public Director(
            string name,
            string surname)
        {
            UpdateName(name);
            UpdateSurname(surname);

        }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        private List<Dvd> _dvds = new List<Dvd>();
        public IReadOnlyCollection<Dvd> Dvds => _dvds;
        public const int MIN_LENGTH = 3;
        public const int MAX_LENGTH = 30;
        public string FullName()
        {
            return $"{Name} {Surname}";
        }

        public void UpdateName(string name)
        {
            if (!ValidateName(name))
                throw new DomainException($"Invalid name for director");

            Name = name;
            UpdatedAt = DateTime.Now;
        }

        public void UpdateSurname(string surname)
        {
            if (!ValidateName(surname))
                throw new DomainException($"Invalid surname for director");

            Surname = surname;
            UpdatedAt = DateTime.Now;
        }

        public bool ValidateName(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length < MIN_LENGTH || value.Length > MAX_LENGTH) return false;

            return Regex.IsMatch(value, "^(?=.*[A-ZÀ-ÿ~])(?=.*[a-zà-ÿ~])[A-Za-zÀ-ÿ~]+$");
        }
    }
}
