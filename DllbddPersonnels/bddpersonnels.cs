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

        public void ModifyService(Service leService, string intitule)
        {
            try
            {
                Service service = bdd.Services.SingleOrDefault(s => s.Id == leService.Id);
                if(service != null)
                {
                    service.Intitule = intitule;
                    bdd.SubmitChanges();
                }
                else
                {
                    throw new InvalidOperationException("Service not found.");
                }
            }
            catch
            {
                throw;
            }
        }

        public void DeleteService(Service leService)
        {
            try
            {
                if (leService != null)
                {
                    bdd.Services.DeleteOnSubmit(leService);
                    bdd.SubmitChanges();
                }
                else
                {
                    throw new InvalidOperationException("Service not found.");
                }
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Il y a des employés dans ce service. Il ne peut pas être supprimé.");
            }
        }

        public void DeleteFonction(Fonction laFonction)
        {
            try
            {
                Fonction fonction = bdd.Fonctions.SingleOrDefault(f => f.Id == laFonction.Id);
                if (fonction != null)
                {
                    bdd.Fonctions.DeleteOnSubmit(fonction);
                    bdd.SubmitChanges();
                }
                else
                {
                    throw new InvalidOperationException("Fonction not found.");
                }
            }
            catch
            {
                throw;
            }
        }

        public void ModifyFonction(Fonction laFonction, string intitule)
        {
            try
            {
                Fonction fonction = bdd.Fonctions.SingleOrDefault(f => f.Id == laFonction.Id);
                if (fonction != null)
                {
                    fonction.Intitule = intitule;
                    bdd.SubmitChanges();
                }
                else
                {
                    throw new InvalidOperationException("Fonction not found.");
                }
            }
            catch
            {
                throw;
            }
        }

    }
}
