using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JensenEngineers.Data
{
    public class Project
    {
        

        public int Id { get; set; }
        public string Title { get; set; }
        public string ProjectNumber { get; set; }
        public int ProjectStatusID { get; set; }
        public int ProjectPriorityID { get; set; }
        public string PlanName { get; set; }
        public string PlanNumber { get; set; }
        public string StartDate { get; set; }
        public string DueDate { get; set; }
        public string JobAddress { get; set; }
        public string JobCity { get; set; }
        public string JobState { get; set; }
        public string JobZipAddress { get; set; }
        public string DWGFIleLocation { get; set; }
        public string ProjectTypeNotes { get; set; }
        public int CustomerID { get; set; }
        public int ReviewedByID { get; set; }
        public int ProjectTypeID { get; set; }
        public bool IsFoundation { get; set; }
        public int FoundationTypeID { get; set; }
        public string CrawlSpaceJoist { get; set; }
        public bool IsHaveSoilsReport { get; set; }
        public string How_WhenSending { get; set; }
        public bool IsFraming { get; set; }
        public string TypeOfFloorJoist { get; set; }
        public string MaxFloorJoistSpacing { get; set; }
        public string TypeOfCeilingJoist { get; set; }
        public string RoofingMaterials { get; set; }
        public string WeightOfRoofingMaterials { get; set; }
        public string ProjectMaterialNotes { get; set; }
        public string CouriertoWhom { get; set; }
        public string CouriertoAddress { get; set; }
        public bool IsHaveCourierPlans { get; set; }
        public bool IsHaveEmail { get; set; }
        public string EmailAddress { get; set; }
        public bool IsCustomerWillPickup { get; set; }
        public string PickupByPersonName { get; set; }
        public string PickupByPersonPhoneNumber { get; set; }
        public string NumberOfCopies { get; set; }
        public string ProjectHoldNotes { get; set; }
        public string CustomerData { get; set; }
        public string Invoice { get; set; }
    }
}