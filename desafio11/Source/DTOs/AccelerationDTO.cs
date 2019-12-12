using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.DTOs
{
    public class AccelerationDTO
    {        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Slug { get; set; }
        [Required]
        public int ChallengeId { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
    }
}