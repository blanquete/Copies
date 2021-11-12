using System;
using System.Collections.Generic;
using System.Text;

namespace Prueb_GitHub.Entity
{
    public class Tasca
    {
        private int id;
        private string nom;
        private string descripcio;
        private string dInici;
        private string dFinal;
        private string prioritat_id;
        private string responsable_id;
        private string estat_id;
        private enum estat
        {
            ToDo,
            Doing,
            Done
        }


        public Tasca()
        {
            id = 0;
            nom = "";
            descripcio = "";
            dInici = "";
            dFinal = "";
            prioritat_id = "";
            responsable_id = "";
            estat_id = "";
        }
        public Tasca(int id_, string nom_, string descripcio_, string dInici_, string dFinal_, string prioritat_id_, string responsable_id_, string estat_id_)
        {
            id = id_;
            nom = nom_;
            descripcio = descripcio_;
            dInici = dInici_;
            dFinal = dFinal_;
            prioritat_id = prioritat_id_;
            responsable_id = responsable_id_;
            estat_id = estat_id_;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        public string Descripcio
        {
            get { return descripcio; }
            set { descripcio = value; }
        }
        public string DInici
        {
            get { return dInici; }
            set { dInici = value; }
        }
        public string DFinal
        {
            get { return dFinal; }
            set { dFinal = value; }
        }
        public string Prioritat_id
        {
            get { return prioritat_id; }
            set { prioritat_id = value; }
        }
        public string Responsable_id
        {
            get { return responsable_id; }
            set { responsable_id = value; }
        }
        public string Estat_id
        {
            get { return estat_id; }
            set { estat_id = value; }
        }
    }
}
