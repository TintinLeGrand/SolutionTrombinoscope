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

        public List<Personnel> GetAllPersonnel()
        {
            try
            {
                return bdd.Personnels.ToList();
            }
            catch
            {
                throw;
            }
        }

        public void NewFonction(Service service)
        {
            throw new NotImplementedException();
        }

        public List<Service> GetAllService()
        {
            try
            {
                return bdd.Services.ToList();
            }
            catch
            {
                throw;
            }
        }

        public List<Fonction> GetAllFonction()
        {
            try
            {
                return bdd.Fonctions.ToList();
            }
            catch
            {
                throw;
            }
        }

        public void NewFonction(Fonction fn)
        {
            try
            {
                bdd.Fonctions.InsertOnSubmit(fn);
                bdd.SubmitChanges();
            }
            catch
            {
                throw;
            }
        }
        public void NewService(Service sv)
        {
            try
            {
                bdd.Services.InsertOnSubmit(sv);
                bdd.SubmitChanges();
            }
            catch
            {
                throw;
            }
        }

        public void NewPersonnel(Personnel ps)
        {
            try
            {
                bdd.Personnels.InsertOnSubmit(ps);
                bdd.SubmitChanges();
            }
            catch
            {
                throw;
            }
        }


    }
}
