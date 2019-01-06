using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JensenEngineers.Data
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name {
            get { return FirstName + " " + LastName; }

        }
        public string Designation { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public bool HasReviewAuthorization { get; set; }
        public bool IsInManagement { get; set; }
        public bool IsInDirectorPanel { get; set; }


    }
}