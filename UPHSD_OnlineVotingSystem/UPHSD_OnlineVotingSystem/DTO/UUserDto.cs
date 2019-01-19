using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UPHSD_OnlineVotingSystem.DTO
{
    public class UUserDto
    {
        public int Id { get; set; }
        public string VoterId { get; set; }
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
        public string ContactNum { get; set; }
        public string Address { get; set; }
        public int RoleId { get; set; }
        public string Password { get; set; }
    }
}