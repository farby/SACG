using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACG_BLL
{
    public class Usuario
    {
        public String User { get; set; }
        public String Pass { get; set; }
        public String Role { get; set; }
        public String Estado { get; set; }

        public Usuario(String user, String pass, String role)
        {
            User = user;
            Pass = pass;
            Role = role;
        }

        public Usuario()
        {
        }
    }
}
