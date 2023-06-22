using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.services
{
    public interface IKorisnikService
    {
        void SaveUsers(string filename);
        void ReadUsers(string filename);
        void DeleteUser(string email);
    }
}
