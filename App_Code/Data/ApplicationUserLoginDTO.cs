using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JensenEngineers.Data
{
    public class ApplicationUserLoginDTO
    {
        public string Username { get; set; }
        private string _password;
        private string _cipher = "LOL";
        public string Password
        {
            get { return _password; }
            set
            {
                var cipher = StringCipher.Encrypt(value);
                _password = cipher.ToString();
            }
        }
    }
}