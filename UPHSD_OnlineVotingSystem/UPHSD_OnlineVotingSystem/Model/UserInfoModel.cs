using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UPHSD_OnlineVotingSystem.Model
{
    public class UserInfoModel
    {
        //int _id;
        //string _voterId;
        //string _firstName;
        //string _midName;
        //string _lastName;
        //string _role;
        //string _address;
        //string _contactNum;

        public UserInfoModel()
        {

        }
        //public UserInfoModel(int id, string voterId, string fname, string mname, string lname)
        //{
        //    this._id = id;
        //    this._voterId = voterId;
        //    this._firstName = fname;
        //    this._midName = mname;
        //    this._lastName = lname;
        //}

        //public UserInfoModel(int id, string voterId, string fname, string mname, string lname, string role, string address, string contactNum)
        //{
        //    this._id = id;
        //    this._voterId = voterId;
        //    this._firstName = fname;
        //    this._midName = mname;
        //    this._lastName = lname;
        //    this._role = role;
        //    this._address = address;
        //    this._contactNum = contactNum;
        //}

        public int Id { get; set; }
        public string VoterId { get; set; }
        public string FirstName { get; set; }
        public string MidName { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
        public string Role { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Password { get; set; }
    }
}