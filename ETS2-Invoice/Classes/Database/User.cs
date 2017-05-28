using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS2_Invoice.Classes.Database
{
    class User
    {
        public int id, fk_creationpassword, is_admin;
        public string username, password;
        public DateTime creationdate;
    }
}
