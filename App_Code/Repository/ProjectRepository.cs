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
    public class ProjectRepository : DbContext
    {
        public Project Get(int id)
        {
            Project data = new Project();

            using (IDbConnection connection = Connection)
            {
                connection.Open();
                var Objparams = new DynamicParameters();

                Objparams.Add("@Id", id);

                data = connection
                    .Query<Project>("GET_PROJECT_BY_ID", Objparams, commandType: CommandType.StoredProcedure)
                    .FirstOrDefault();
            }
            return data;

        }

        public IEnumerable<Project> GetAll()
        {

            IEnumerable<Project> data;

            using (IDbConnection connection = Connection)
            {
                connection.Open();

                data = connection
                    .Query<Project>("GET_ALL_PROJECTS", null, commandType: CommandType.StoredProcedure)
                    .ToList();
            }
            return data;
        }

        public IEnumerable<ProjectStatus> GetProjectStatusList()
        {
            List<ProjectStatus> data;

            using (IDbConnection connection = Connection)
            {
                connection.Open();

                data = connection
                    .Query<ProjectStatus>("GET_ALL_PROJECT_STATUS", null, commandType: CommandType.StoredProcedure)
                    .ToList();
            }
            return data;
        }
        public IEnumerable<ProjectPriority> GetProjectPriorityList()
        {
            List<ProjectPriority> data;

            using (IDbConnection connection = Connection)
            {
                connection.Open();
                data = connection
                    .Query<ProjectPriority>("GET_ALL_PROJECT_PRIORITY", null, commandType: CommandType.StoredProcedure)
                    .ToList();
            }

            return data;
        }

        public IEnumerable<ProjectType> GetProjectType()
        {
            List<ProjectType> data;

            using (IDbConnection connection = Connection)
            {
                connection.Open();
                data = connection
                    .Query<ProjectType>("GET_ALL_PROJECT_TYPE", null, commandType: CommandType.StoredProcedure)
                    .ToList();
            }

            return data;
        }


        public Project Add(Project project)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();

                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@Id", project.Id);
                ObjParm.Add("@Title", project.Title);
                ObjParm.Add("@ProjectNumber", project.ProjectNumber);
                ObjParm.Add("@ProjectStatusID", project.ProjectStatusID);
                ObjParm.Add("@ProjectPriorityID", project.ProjectPriorityID);
                ObjParm.Add("@PlanName", project.PlanName);
                ObjParm.Add("@plannumber", project.PlanNumber);
                ObjParm.Add("@StartDate", project.StartDate);
                ObjParm.Add("@DueDate", project.DueDate);
                ObjParm.Add("@JobAddress", project.JobAddress);
                ObjParm.Add("@JobCity", project.JobCity);
                ObjParm.Add("@JobState", project.JobState);
                ObjParm.Add("@JobZipAddress", project.JobZipAddress);
                ObjParm.Add("@DWGFIleLocation", project.DWGFIleLocation);
                ObjParm.Add("@ProjectTypeNotes", project.ProjectTypeNotes);
                ObjParm.Add("@CustomerID", project.CustomerID);
                ObjParm.Add("@ReviewedByID", project.ReviewedByID);
                ObjParm.Add("@ProjectTypeID", project.ProjectTypeID);
                ObjParm.Add("@IsFoundation", project.IsFoundation);
                ObjParm.Add("@FoundationTypeID", project.FoundationTypeID);
                ObjParm.Add("@CrawlSpaceJoist", project.CrawlSpaceJoist);
                ObjParm.Add("@IsHaveSoilsReport", project.IsHaveSoilsReport);
                ObjParm.Add("@How_WhenSending", project.How_WhenSending);
                ObjParm.Add("@IsFraming", project.IsFraming);
                ObjParm.Add("@TypeOfFloorJoist", project.TypeOfFloorJoist);
                ObjParm.Add("@MaxFloorJoistSpacing", project.MaxFloorJoistSpacing);
                ObjParm.Add("@TypeOfCeilingJoist", project.TypeOfCeilingJoist);
                ObjParm.Add("@RoofingMaterials", project.RoofingMaterials);
                ObjParm.Add("@WeightOfRoofingMaterials", project.WeightOfRoofingMaterials);
                ObjParm.Add("@ProjectMaterialNotes", project.ProjectMaterialNotes);
                ObjParm.Add("@CouriertoWhom", project.CouriertoWhom);
                ObjParm.Add("@CouriertoAddress", project.CouriertoAddress);
                ObjParm.Add("@IsHaveCourierPlans", project.IsHaveCourierPlans);
                ObjParm.Add("@IsHaveEmail", project.IsHaveEmail);

                ObjParm.Add("@EmailAddress", project.EmailAddress);
                ObjParm.Add("@IsCustomerWillPickup", project.IsCustomerWillPickup);
                ObjParm.Add("@PickupByPersonName", project.PickupByPersonName);
                ObjParm.Add("@PickupByPersonPhoneNumber", project.PickupByPersonPhoneNumber);
                ObjParm.Add("@NumberOfCopies", project.NumberOfCopies);
                ObjParm.Add("@ProjectHoldNotes", project.ProjectHoldNotes);
                ObjParm.Add("@CustomerData", project.CustomerData);
                ObjParm.Add("@Invoice", project.Invoice);
                ObjParm.Add("@GeneratedID", dbType: DbType.Int32, direction: ParameterDirection.Output);

                dbConnection.Execute("SAVE_UPDATE_PROJECT", ObjParm, commandType: CommandType.StoredProcedure);
                project.Id = ObjParm.Get<int>("@GeneratedID");
            }
            return project;
        }
    }
}