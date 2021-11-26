using System;
using System.Collections.Generic;
using System.Text;

namespace Prueb_GitHub.Entity
{
    public class Responsable
    {
        //Declaració de variables
        private int id;
        private string nom;

        //Constructor 
        public Responsable()
        {
            id = 0;
            nom = "";
        }
        public Responsable(int id_, string nom_)
        {
            id = id_;
            nom = nom_;
        }

        //Accesors
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
    }
}
