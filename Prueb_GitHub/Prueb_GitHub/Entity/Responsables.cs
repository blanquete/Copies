using System;
using System.Collections.Generic;
using System.Text;

namespace Prueb_GitHub.Entity
{
    public class Responsable
    {
        private int id;
        private string nom;


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
