using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace albumes.models.Entities
{
    [Table("Artist")]
    public class Artist
    {
        [Key]
        public int ArtistID { get; set; }
        public string Name { get; set; }
    }
}
