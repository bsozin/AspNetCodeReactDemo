using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCodeReact.Data.Models
{
    public sealed class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        [Column("BrandId")]
        public int BrandId { get; set; }

        [ForeignKey(nameof(BrandId))]
        public Brand Brand { get; set; } = null!;

        [Column("BodyTypeId")]
        public int BodyTypeId { get; set; }

        [ForeignKey(nameof(BodyTypeId))]
        public BodyType BodyType { get; set; } = null!;

        [Column("Name")]
        [StringLength(1000)]
        public string Name { get; set; } = null!;

        [Column("SeatsCount")]
        [Range(1, 12)]
        public int SeatsCount { get; set; }

        [Column("DealerUrl")]
        [StringLength(1000)]
        [Url]
        public string? DealerUrl { get; set; }

        [Column("CreationDate")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTimeOffset CreationDate { get; private set; }
    }
}