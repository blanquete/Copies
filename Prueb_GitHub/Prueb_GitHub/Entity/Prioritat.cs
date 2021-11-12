using System;
using System.Collections.Generic;
using System.Text;

namespace To_do_List_ARI.Entity
{
    public class Prioritat
    {
        private int id;
        private string nom;
        private int urgencia;
        private string color;

        public Prioritat()
        {
            id = 0;
            nom = "";
            urgencia = 0;
            color = "";
        }
        public Prioritat(int id_, string nom_, int urgencia_, string color_)
        {
            id = id_;
            nom = nom_;
            urgencia = urgencia_;
            color = color_;
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
        public int Urgencia
        {
            get { return urgencia; }
            set { urgencia = value; }
        }
        public string Color
        {
            get { return color; }
            set { color = value; }
        }
    }
}
