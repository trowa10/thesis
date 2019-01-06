using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UPHSD_OnlineVotingSystem.Model
{
    public class PositionModel
    {
        int _id;
        string _name;
        public PositionModel(int id, string name)
        {
            _id = id;
            _name = name;
        }
        public PositionModel()
        {

        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}