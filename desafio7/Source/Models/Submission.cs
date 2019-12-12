using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("submission")]
    public class Submission
    {
        
        [Key, Column("user_id"), Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        [Required] 
        public User User { get; set; }
        
        [Key, Column("challenge_id"), Required]
        public int ChallengeId { get; set; }
        [ForeignKey("ChallengeId")]
        [Required]
        public Challenge Challenge { get; set; }

        [Column("score"), Required]
        public decimal Score { get; set; }

        [Column("create_at"), Required]
        public DateTime CreatedAt { get; set; }
    }
}
