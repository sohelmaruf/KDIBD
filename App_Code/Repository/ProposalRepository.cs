using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;
using Dapper;
using JensenEngineers.Data;

namespace JensenEngineers.Repository
{
    public class ProposalRepository: DbContext
    {
        public Proposal Get(int id)
        {
            Proposal data = new Proposal();

            using (IDbConnection connection = Connection)
            {
                connection.Open();
                var Objparams = new DynamicParameters();

                Objparams.Add("@Id", id);

                data = connection
                    .Query<Proposal>("GET_PROPOSAL_BY_ID", Objparams, commandType: CommandType.StoredProcedure)
                    .FirstOrDefault();
            }
            return data;

        }

        public IEnumerable<Proposal> GetAll()
        {

            IEnumerable<Proposal> data;

            using (IDbConnection connection = Connection)
            {
                connection.Open();

                data = connection
                    .Query<Proposal>("GET_ALL_PROPOSAL", null, commandType: CommandType.StoredProcedure)
                    .ToList();
            }
            return data;
        }
        public Proposal Add(Proposal proposal)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();

                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@Id", proposal.Id);
                ObjParm.Add("@Name", proposal.Name);
                ObjParm.Add("@Address", proposal.Address);
                ObjParm.Add("@City", proposal.City);
                ObjParm.Add("@State", proposal.State);
                ObjParm.Add("@Zip", proposal.Zip);
                ObjParm.Add("@Details", proposal.Details);
                ObjParm.Add("@InitialContractDate", Convert.ToDateTime(proposal.InitialContractDate));
                ObjParm.Add("@SubmittalDate", proposal.SubmittalDate);
                ObjParm.Add("@RevisionDate", proposal.RevisionDate);
                ObjParm.Add("@ProposalType", proposal.ProposalType);
                ObjParm.Add("@DailyType", proposal.DailyType);
                ObjParm.Add("@ProjectType", proposal.ProjectType);
                ObjParm.Add("@ProjectOtherTypeValue", proposal.ProjectOtherTypeValue);
                ObjParm.Add("@FoundationTypeValue", proposal.FoundationTypeValue);
                ObjParm.Add("@FoundationSlabTypeValue", proposal.FoundationSlabTypeValue);
                ObjParm.Add("@FoundationPierTypeValue", proposal.FoundationPierTypeValue);
                ObjParm.Add("@FoundationPierRemiedialTypeValue", proposal.FoundationPierRemiedialTypeValue);
                ObjParm.Add("@FoundationPierRemiedialOtherTypeValue", proposal.FoundationPierRemiedialOtherTypeValue);
                ObjParm.Add("@FoundationOtherTypeValue", proposal.FoundationOtherTypeValue);
                ObjParm.Add("@FrameTypeValue", proposal.FrameTypeValue);
                ObjParm.Add("@FrameResidentialValue", proposal.FrameResidentialValue);
                ObjParm.Add("@FrameResidentialOtherValue", proposal.FrameResidentialOtherValue);
                ObjParm.Add("@FrameExteriorValue", proposal.FrameExteriorValue);
                ObjParm.Add("@FrameExteriorOtherValue", proposal.FrameExteriorOtherValue);
                ObjParm.Add("@FrameRoofTypeValue", proposal.FrameRoofTypeValue);
                ObjParm.Add("@FrameRoofTypeOtherValue", proposal.FrameRoofTypeOtherValue);
                ObjParm.Add("@RetainingWallValue", proposal.RetainingWallValue);
                ObjParm.Add("@RetainingWallTypeValue", proposal.RetainingWallTypeValue);
                ObjParm.Add("@RetainingWallTypeWallValue", proposal.RetainingWallTypeWallValue);
                ObjParm.Add("@RetainingWallTypeWallOtherValue", proposal.RetainingWallTypeWallOtherValue);
                ObjParm.Add("@PoolValue", proposal.PoolValue);
                ObjParm.Add("@PoolCompnayDesignValue", proposal.PoolCompnayDesignValue);
                ObjParm.Add("@ClientID", proposal.ClientID);
                ObjParm.Add("@GeneratedID", dbType: DbType.Int32, direction: ParameterDirection.Output);

                dbConnection.Execute("SAVE_UPDATE_PROPOSAL", ObjParm, commandType: CommandType.StoredProcedure);
                proposal.Id = ObjParm.Get<int>("@GeneratedID");
            }
            return proposal;
        }
    }
}