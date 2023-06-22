using Projekat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.services
{
    public interface IKlijentService
    {
        void SaveUsers(string filename);
        void ReadUsers(string filename);
        List<Korisnik> FindallClients(String email);
        Klijent NadjiKlijentaPrekoEmaila(string email);
    }
}
