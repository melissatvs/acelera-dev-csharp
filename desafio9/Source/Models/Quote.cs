using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("scripts")]
    public class Quote
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        
        [Column("episode")]
        public int Episode { get; set; }

        [Column("episode_name")]
        public string EpisodeName { get; set; }

        [Column("segment")]
        public string Segment { get; set; }

        [Column("type")]
        public string Type { get; set; }

        [Column("actor")]
        public string Actor { get; set; }

        [Column("character")]
        public string Character { get; set; }

        [Column("detail")]
        [StringLength(1000)]
        public string Detail { get; set; }

        [Column("record_date")]
        public DateTime? RecordDate { get; set; }

        [Column("series")]
        public string Series { get; set; }

        [Column("transmission_date")]
        public DateTime? TransmissionDate { get; set; }
    }
}