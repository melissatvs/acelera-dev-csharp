using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("company")]
    public class Company
    {
        [Key, Column("id"), Required]
        public int Id { get; set; }

        [Column("name"), MaxLength(100), Required]
        public string Name { get; set; }
        
        [Column("slug"), MaxLength(50), Required]
        public string Slug { get; set; }

        [Column("create_at"), Required]
        public DateTime CreatedAt { get; set; }

        /*referencias só pra ver se funciona as navegações*/
        public ICollection<Candidate> Candidates { get; set; }
    }
}