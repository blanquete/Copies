using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using Prueb_GitHub.Persistence;

namespace Prueb_GitHub.Entity
{
    public class Tasca
    {
        private int id;
        private string nom;
        private string descripcio;
        private DateTime dInici;
        private DateTime dFinal;
        private int prioritat_id;
        private int responsable_id;
        private int estat_id;
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
            dInici = new DateTime();
            dFinal = new DateTime();
            prioritat_id = 0;
            responsable_id = 0;
            estat_id = 0;
        }
        public Tasca(int id_, string nom_, string descripcio_, DateTime dInici_, DateTime dFinal_, int prioritat_id_, int responsable_id_, int estat_id_)
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
        public int Prioritat_id
        {
            get { return prioritat_id; }
            set { prioritat_id = value; }
        }
        public int Responsable_id
        {
            get { return responsable_id; }
            set { responsable_id = value; }
        }
        public int Estat_id
        {
            get { return estat_id; }
            set { estat_id = value; }
        }


       
    }
}
