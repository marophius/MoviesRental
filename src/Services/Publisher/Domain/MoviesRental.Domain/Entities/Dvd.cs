using MoviesRental.Core.DomainObjects;
using MoviesRental.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Domain.Entities
{
    public class Dvd : Entity
    {
        protected Dvd() { }
        public Dvd(
            string title,
            int genre,
            DateTime published,
            int copies,
            Guid directorId)
        {
            Available = true;
            UpdateTitle(title);
            UpdateGenre(genre);
            UpdatePublishedDate(published);
            UpdateCopies(copies);
            UpdateDirector(directorId);
        }
        public string Title { get; private set; }
        public EGenre Genre { get; private set; }
        public DateTime Published { get; private set; }
        public bool Available { get; private set; }
        public int Copies { get; private set; }
        public Guid DirectorId { get; private set; }
        public Director Director { get; set; }

        public const int MIN_TITLE_LENGTH = 2;
        public const int MAX_TITLE_LENGTH = 50;

        public void RentCopy()
        {
            if (Copies == 0 || !Available)
                throw new DomainException($"DVD {Title} is not available to rent");

            var copies = Copies - 1;
            UpdateCopies(copies);
        }

        public void ReturnCopy()
        {
            if (!Available)
                throw new DomainException($"DVD {Title} is not available");
            var copies = Copies + 1;
            UpdateCopies(copies);
        }

        public void UpdateTitle(string title)
        {
            if (!Available)
                throw new DomainException($"DVD {Title} is not available");

            if (string.IsNullOrWhiteSpace(title) || title.Length < MIN_TITLE_LENGTH || title.Length > MAX_TITLE_LENGTH)
                throw new DomainException($"Invalid name {title} to a DVD");

            Title = title;
            UpdatedAt = DateTime.Now;
        }

        public void UpdateGenre(int genre)
        {
            if (!Available)
                throw new DomainException($"DVD {Title} is not available");

            Genre = genre switch
            {
                0 => EGenre.Action,
                1 => EGenre.Adventure,
                2 => EGenre.Animation,
                3 => EGenre.Comedy,
                4 => EGenre.Crime,
                5 => EGenre.Documentary,
                6 => EGenre.Drama,
                7 => EGenre.Fantasy,
                8 => EGenre.Horror,
                9 => EGenre.Musical,
                10 => EGenre.Mistery,
                11 => EGenre.Romance,
                12 => EGenre.SciFi,
                13 => EGenre.Thriller,
                14 => EGenre.Western,
                15 => EGenre.Biography,
                16 => EGenre.Historic,
                17 => EGenre.War,
                18 => EGenre.Family,
                _ => throw new DomainException("Invalid genre option!")
            };

            UpdatedAt = DateTime.Now;
        }

        public void UpdatePublishedDate(DateTime date)
        {
            if (!Available)
                throw new DomainException($"DVD {Title} is not available");
            var todayDate = DateTime.Now;

            if (todayDate < date)
                throw new DomainException("Invalid published date");

            Published = date;
            UpdatedAt = todayDate;
        }

        public void UpdateDirector(Guid directorId)
        {
            if (!Available)
                throw new DomainException($"DVD {Title} is not available");

            if (directorId == Guid.Empty)
                throw new DomainException("Invalid director's Id");

            DirectorId = directorId;
            UpdatedAt = DateTime.Now;
        }

        public void UpdateCopies(int copies)
        {
            if (!Available)
                throw new DomainException($"DVD {Title} is not available");

            if (copies < 0)
                throw new DomainException("Number of copies must be greater than zero.");

            Copies = copies;
            UpdatedAt = DateTime.Now;
        }

        public void DeleteDvd()
        {
            if (!Available)
                throw new DomainException("DVD is already deleted.");
            Available = false;
            Copies = 0;
            DeletedAt = DateTime.Now;
        }
    }
}
