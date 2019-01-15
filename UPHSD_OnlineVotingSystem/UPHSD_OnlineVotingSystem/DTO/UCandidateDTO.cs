using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UPHSD_OnlineVotingSystem.DTO
{
    public class UCandidateDTO
    { 
        public int Id { get; set; }
        public string VoterId { get; set; }
        public int PositionId { get; set; }
    }
}