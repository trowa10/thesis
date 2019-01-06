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
            this._engine.Dispose();
            return list;
        }

        public ICollection<PositionModel> GetPositions()
        {
            List<PositionModel> list = new List<PositionModel>();

            using (IDataReader reader = this._engine.ExecDataReaderProc("GetPositions", new string[] { }))
            {
                while (reader.Read())
                {

                    PositionModel obj = new PositionModel()
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString()
                    };
                    list.Add(obj);
                }
            }
           
            return list;
        }

        public UserInfoModel GetUserInfo(string voterId)
        {

            var res = new UserInfoModel();
            using (IDataReader reader = this._engine.ExecDataReaderProc("GetUserInfoById", new string[] { "voterId", voterId }))
            {
                while (reader.Read())
                {

                    res.Id = (int)reader["id"];
                    res.VoterId = reader["voterId"].ToString();
                    res.FirstName = reader["fname"].ToString();
                    res.MidName = reader["midname"].ToString();
                    res.LastName = reader["lastname"].ToString();
                }
            }
            
            return res;
        }

        public bool Login(LogDTO logDto)
        {
            bool res = false;
            using (IDataReader reader = this._engine.ExecDataReaderProc("GetAuth", new string[] {
                "username", logDto.VoterId,
                "password", logDto.Password
            }))
            {
                while (reader.Read())
                {

                    res = (bool)reader["result"];                 
                }
            }
            this._engine.Dispose();
            return res;
        }
        public bool RegisterUser(UserDto userDto)
        {

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


            this._engine.Dispose();
            return (result > 0) ? true : false;
        }

        public bool RegisterCandidate(CandidateDTO candidateDTO)
        {

            int result = _engine.ExecNonQueryProc("InsertCandidateSP",
                                new object[]
                                    {

                                        "voterId", candidateDTO.VoterId,
                                        "positionId", candidateDTO.PositionId   
                                    });

            return (result > 0) ? true : false;
        }
    }
}