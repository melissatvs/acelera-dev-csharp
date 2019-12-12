using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("user")]
    public class User
    {
        [Key, Column("id"), Required]
        public int Id { get; set; }

        [Column("full_name"), MaxLength(100), Required]
        public string FullName { get; set; }

        [Column("email"), MaxLength(100), Required]
        public string Email { get; set; }

        [Column("nickname"), MaxLength(50), Required]
        public string Nickname { get; set; }

        [Column("password"), MaxLength(255), Required]
        public string Password { get; set; }

        [Column("create_at"), Required]
        public DateTime CreatedAt { get; set; }

        /*referencias só pra ver se funciona as navegações*/
        public ICollection<Candidate> Candidates { get; set; }
        public ICollection<Submission> Submissions { get; set; }

    }
}
