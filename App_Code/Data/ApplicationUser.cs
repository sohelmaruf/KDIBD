using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JensenEngineers.Data
{
    public class ApplicationUser
    {
        private string _password = "";
        private string _cipher = "LOL";
        public int Id { get; set; }
        public string EmailId { get; set; }
        public string Username { get; set; }

        public string Password
        {
            get
            {

                var planText = StringCipher.Decrypt(_password);
                return planText;
            }
            set
            {
                var cipher = StringCipher.Encrypt(value);
                _password = cipher;
            }
        }

        public int UserRoleId { get; set; }

        public string GetEncryptedPasssword()
        {
            return _password;
        }
    }
}