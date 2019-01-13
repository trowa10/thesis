using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UPHSD_OnlineVotingSystem.DTO
{
    public class PositionDTO
    {
        public string Name { get; set; }
        public int RequireWinner { get; set; }
        public string Object { get; set; }
    }
}