using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("candidate")]
    public class Candidate
    {
        
        [Key, Column("user_id"), Required]
        public int UserId { get; set; }
        [ForeignKey("UserId"), Required]
        public User User { get; set; }

        
        [Key, Column("acceleration_id"), Required]
        public int AccelerationId { get; set; }
        [ForeignKey("AccelerationId"), Required]
        public Acceleration Acceleration { get; set; }

        
        [Key, Column("company_id"), Required]
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId"), Required]
        public Company Company { get; set; }

        [Column("status"), Required]
        public int Status { get; set; }

        [Column("create_at"), Required]
        public DateTime CreatedAt { get; set; }
            
    }
}
