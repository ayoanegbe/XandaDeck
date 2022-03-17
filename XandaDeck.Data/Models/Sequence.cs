using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace XandaDeck.Data.Models
{
    public class Sequence
    {
        [Key]
        public int SequenceId { get; set; }
        [Required]
        public string SequenceName { get; set; }
        public SequenceType SequenceType { get; set; }
        public int LastNumber { get; set; }

    }
}
