using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UPHSD_OnlineVotingSystem.DTO
{
    public class ModelDTO
    {
        public int UserId { get; set; }
        public string VotersId { get; set; }
        public string Fullname { get; set; }
        public int PositionId { get; set; }
    }
}