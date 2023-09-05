using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCodeReact.Data.Models
{
    [Table("BodyType")]
    public sealed class BodyType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        [StringLength(32)]
        public string Name { get; set; } = null!;
    }
}
