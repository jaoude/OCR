using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OCR.Core.Model
{
    public class Page
    {
        [Key]
        public int Id { get; set; }

        public int PageNumber { get; set; }

        public string FullText { get; set; }

        public DateTime IssuDate { get; set; }

        public int IssueNumber { get; set; }

        [Column(TypeName = "varbinary(max)")]
        public byte[] Image { get; set; }
    }
}
