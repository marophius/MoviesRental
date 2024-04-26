using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Query.Domain.Models
{
    public class Dvd
    {
        [BsonId]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime Published { get; set; }
        public bool Available { get; set; }
        public int Copies { get; set; }
        public string DirectorId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
