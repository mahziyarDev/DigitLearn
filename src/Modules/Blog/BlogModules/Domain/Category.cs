using Common.Domain;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogModules.Domain
{
    [Index("Slug", IsUnique = true)]
    [Table("Categories", Schema ="do.blog")]
    public class Category : BaseEntity
    {
        public string Title { get; set; }
        [MaxLength(80)]
        public string Slug { get; set; }
    }
}
