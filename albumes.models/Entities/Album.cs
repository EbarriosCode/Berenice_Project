using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace albumes.models.Entities
{
    [Table("Album")]
    public class Album
    {
        [Key]
        public int AlbumID { get; set; }
        public int ArtistID { get; set; }
        public Artist Artist { get; set; }

        public string Title { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public bool AvailableToPurchase { get; set; }
    }
}
