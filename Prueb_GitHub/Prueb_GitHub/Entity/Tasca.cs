using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using Prueb_GitHub.Persistence;

namespace Prueb_GitHub.Entity
{
    public enum Estat
    {
        ToDo,
        Doing,
        Done
    }
    public class Tasca
    {
        private int id;
        private string nom;
        private string descripcio;
        private DateTime dInici;
        private DateTime dFinal;
        private string prioritat_id;
        private string responsable_id;
        private string estat_id;
        private Estat estat;
        
        

        public Tasca()
        {
            id = 0;
            nom = "";
            descripcio = "";
            dInici = new DateTime();
            dFinal = new DateTime();
            prioritat_id = "";
            responsable_id = "";
            estat_id = "";
            estat = (Estat)0;
        }
        public Tasca(int id_, string nom_, string descripcio_, DateTime dInici_, DateTime dFinal_, string prioritat_id_, string responsable_id_, string estat_id_, Estat estat_)
        {
            id = id_;
            nom = nom_;
            descripcio = descripcio_;
            dInici = dInici_;
            dFinal = dFinal_;
            prioritat_id = prioritat_id_;
            responsable_id = responsable_id_;
            estat_id = estat_id_;
            estat = estat_;
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
        public DateTime DInici
        {
            get { return dInici; }
            set { dInici = value; }
        }
        public DateTime DFinal
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
        public Estat Estat
        {
            get { return estat; }
            set { estat = value; }
        }
    }
}
