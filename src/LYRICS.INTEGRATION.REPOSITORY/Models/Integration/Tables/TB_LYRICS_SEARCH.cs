using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LYRICS.INTEGRATION.REPOSITORY.Models.Integration.Tables
{
    public partial class TB_LYRICS_SEARCH
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal LYRIC_SEARCH { get; set; }

        public DateTime INSERTION_DATE { get; set; }

        public string AUTHOR { get; set; } = null!;

        public string TITLE { get; set; } = null!;

        public bool VALID { get; set; }
    }
}
