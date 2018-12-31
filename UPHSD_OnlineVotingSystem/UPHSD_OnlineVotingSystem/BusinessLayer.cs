using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UPHSD_OnlineVotingSystem.DTO;
using UPHSD_OnlineVotingSystem.Model;

namespace UPHSD_OnlineVotingSystem
{

    public class BusinessLayer
    {
        private string _con;
        private AdoEngine _engine = null;
        public BusinessLayer()
        {
            this._con = WebConfigurationManager.ConnectionStrings["My_Connection"].ConnectionString;
            this._engine = new AdoEngine(this._con);
        }

        public ICollection<RoleModel> GetRole()
        {
            List<RoleModel> list = new List<RoleModel>();

            using (IDataReader reader = this._engine.ExecDataReaderProc("GetRole", new string[] { }))
            {
                while (reader.Read())
                {

                    RoleModel obj = new RoleModel()
                    {
                        Id = (int)reader["id"],
                        Name = reader["name"].ToString()
                    };
                    list.Add(obj);
                }
            }

            return list;
        }

        public bool RegisterUser(UserDto userDto) {

            int result = _engine.ExecNonQueryProc("InsertUserSP",

                                new object[]

                                    {

                                        "voterId", userDto.VoterId,
                                        "fname", userDto.Fname,
                                        "midname", userDto.Mname,
                                        "lastname" ,userDto.Lname,
                                        "contactnum" ,userDto.ContactNum,
                                        "address", userDto.Address,
                                        "role", userDto.RoleId,
                                        "password", userDto.Password

                                    });



            return (result > 0) ? true : false;
        }
    }
}