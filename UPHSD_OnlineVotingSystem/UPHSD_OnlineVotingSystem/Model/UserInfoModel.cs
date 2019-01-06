using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UPHSD_OnlineVotingSystem.Model
{
    public class UserInfoModel
    {
        int _id;
        string _voterId;
        string _firstName;
        string _midName;
        string _lastName;

        public UserInfoModel()
        {

        }
        public UserInfoModel(int id, string voterId, string fname, string mname, string lname)
        {
            this._id = id;
            this._voterId = voterId;
            this._firstName = fname;
            this._midName = mname;
            this._lastName = lname;
        }

        public int Id { get; set; }
        public string VoterId { get; set; }
        public string FirstName { get; set; }
        public string MidName { get; set; }
        public string LastName { get; set; }

    }
}