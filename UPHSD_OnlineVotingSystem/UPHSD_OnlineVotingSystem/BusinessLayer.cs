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

        public ICollection<Model.PositionModel> GetPositions()
        {
            List<Model.PositionModel> list = new List<Model.PositionModel>();

            using (IDataReader reader = this._engine.ExecDataReaderProc("GetPositions", new string[] { }))
            {
                while (reader.Read())
                {

                    Model.PositionModel obj = new Model.PositionModel()
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString(),
                        Object = reader["Object"].ToString(),
                        RequireWinner = (int)reader["RequireWinner"]
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

        public int Login(LogDTO logDto)
        {
            int res = 0;
            using (IDataReader reader = this._engine.ExecDataReaderProc("GetAuth", new string[] {
                "username", logDto.VoterId,
                "password", logDto.Password
            }))
            {
                while (reader.Read())
                {

                    res = (int)reader["result"];                 
                }
            }
            this._engine.Dispose();
            return res;
        }

        public ICollection<CandidateModel> GetCandidatesByPosition(int id)
        {
            List<Model.CandidateModel> list = new List<Model.CandidateModel>();

            using (IDataReader reader = this._engine.ExecDataReaderProc("GetCandidateByPosition", new object[] { "positionId", id }))
            {
                while (reader.Read())
                {

                    Model.CandidateModel obj = new Model.CandidateModel()
                    {
                  
                        Fullname = reader["fullname"].ToString(),
                        VoterId = reader["voterid"].ToString()
                                  
                    };
                    list.Add(obj);
                }
            }

            return list;
        }

        public ICollection<VoteModel> GetVotes()
        {
            List<Model.VoteModel> list = new List<Model.VoteModel>();

            using (IDataReader reader = this._engine.ExecDataReaderProc("GetVotes", new object[] { }))
            {
                while (reader.Read())
                {

                    Model.VoteModel obj = new Model.VoteModel()
                    {
                        Id = (int)reader["id"],
                        UserId = (int)reader["userId"],
                        Fullname = reader["fullname"].ToString(),
                        PositionId = (int)reader["PositionId"],
                        VotersId = reader["voterid"].ToString()

                    };
                    list.Add(obj);
                }
            }

            return list;
        }

        public bool SubmitVotes(VoteDTO voteDTO)
        {

            int result = _engine.ExecNonQueryProc("InsertVote",

                                new object[]

                                    {

                                        "userId", voteDTO.UserId,
                                        "votersId", voteDTO.VotersId,
                                        "fullname", voteDTO.Fullname,
                                        "position", voteDTO.PositionId
                                    });


            return (result > 0) ? true : false;
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

        public bool RegisterPosition(PositionDTO positionDTO)
        {

            int result = _engine.ExecNonQueryProc("InsertPosition",
                                new object[]
                                    {

                                        "name", positionDTO.Name,
                                        "winner", positionDTO.RequireWinner,
                                        "object_name", positionDTO.Object
                                    });

            return (result > 0) ? true : false;
        }

        public bool UpdatePosition(UPositionDTO positionDTO)
        {

            int result = _engine.ExecNonQueryProc("UpdatePosition",
                                new object[]
                                    {
                                        "id", positionDTO.Id,
                                        "name", positionDTO.Name,
                                        "winner", positionDTO.RequireWinner,
                                        "object_name", positionDTO.Object
                                    });

            return (result > 0) ? true : false;
        }

        public bool DeletePosition(int Id)
        {

            int result = _engine.ExecNonQueryProc("DeletePosition",
                                new object[]
                                    {
                                        "id", Id
                                    });

            return (result > 0) ? true : false;
        }
    }
}