using Common.Domain;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogModules.Domain
{
    [Index("Slug",IsUnique =true)]
    [Table("Posts",Schema = "dbo.blog")]
    public class Post : BaseEntity
    {        
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }

        [MaxLength(80)]
        public string OwnerName { get; set; }
        public string Title { get; set; }

        [MaxLength(80)]
        public string Slug { get; set; }
        public string Description { get; set; }
        [MaxLength(110)]
        public string ImageName { get; set; }
        public long Visit { get; set; }
        
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
