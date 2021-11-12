using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Prueb_GitHub.Views
{
    /// <summary>
    /// Lógica de interacción para afegirTasca.xaml
    /// </summary>
    public partial class afegirTasca : Window
    {
        public afegirTasca()
        {
            InitializeComponent();
        }
        //quan l'usuari clica sobre el button afegir
        private void btn_agregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //afageix un nou item al listview
                lvTasca.Items.Add(new Tasca()
                {
                    //Id = temp.ToString()
                    Id = int.Parse(txt_id.Text),
                    Name = txt_nomTasca.Text,
                    Descripcio = txt_descripcio.Text,
                    ata_Inici = datepicker_data_inici.Text,
                    Data_final = datepicker_data_final.Text,
                    Prioritat = (cmb_prioritat.SelectedItem as ComboBoxItem).Content.ToString(), //transforma el valor del item seleccionat
                    Responsable = (cmb_responsable.SelectedItem as ComboBoxItem).Content.ToString(), //transforma el valor del item seleccionat
                    Estat = (cmb_estat.SelectedItem as ComboBoxItem).Content.ToString() //transforma el valor del item seleccionat
                });
            }
            catch (Exception)
            {
                MessageBox.Show("Has d'omplir tots els camps");
            }
        }

        private void btn_modificar_Click(object sender, RoutedEventArgs e)
        {

        }

        // quan l'usuari clica sobre el button eliminar
        private void btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            try //faig un trycatch per asegurarme que l'usuari ha seleccionat un item previament
            {
                //elimina el item seleccionat
                lvTasca.Items.RemoveAt(lvTasca.SelectedIndex);
            }
            catch (Exception)
            {
                MessageBox.Show("Has de seleccionar una tasca", "Informacio", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public class Tasca
        {
            public string Name { get; set; } //accesors
            public string Responsable { get; set; }
            public string Descripcio { get; set; }
            public string Data_final { get; set; }
            public string Prioritat { get; set; }
            public string ata_Inici { get; set; } //si poso data_inici em dona errors per iaxo he possat ata inici
            public int Id { get; set; }
            public string Estat { get; set; }
        }

        //metode per netejar els camps
        public void netejaCamps()
        {
            /*txt_nomTasca.Text = "";
            txt_responsable.Text = "";
            txt_descripcio.Text = "";
            txt_prioritat.Text = "";
            txt_data_final.Text = "";
            txt_data_inici.Text = "";*/
        }

        //Aques event s'aplica sobre el textbox id  
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            //si la tecla es un nuemero
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                //permet introduir valors
                e.Handled = false;
            else
                //si no no permet introduir valors
                e.Handled = true;
        }

    }
}
