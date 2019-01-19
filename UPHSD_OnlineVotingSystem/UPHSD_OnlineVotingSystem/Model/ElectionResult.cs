using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UPHSD_OnlineVotingSystem.Model
{
    public class ElectionResult
    {
        public int VoteCount { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }

    }
}