using BddpersonnelContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllbddPersonnels
{
    public class bddpersonnels
    {
        private BddpersonnelDataContext bdd;
        public bddpersonnels(String user, String mdp, String serveurIp, String port)
        {
            this.bdd = new BddpersonnelDataContext("User Id=" + user + ";Password=" + mdp + ";Host=" + serveurIp + ";Port=" + port + ";Database=bddpersonnels;Persist Security Info=True");
        }
        public List<Personnel> GetallPersonnel()
        {
            try
            {
                return bdd.Personnels.ToList();
            }
            catch { throw; }
        }
        public List<Service> GetallService()
        {
            try
            {
                return bdd.Services.ToList();
            }
            catch { throw; }
        }
        public List<Fonction> GetallFonction()
        {
            try
            {
                return bdd.Fonctions.ToList();
            }
            catch { throw; }
        }
    }
}
