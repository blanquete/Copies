using Prueb_GitHub.Service;
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
using Prueb_GitHub.Entity;

namespace Prueb_GitHub.Views
{
    /// <summary>
    /// Lógica de interacción para AfegirResponsable.xaml
    /// </summary>
    public partial class AfegirResponsable : Window
    {
        public Responsable responsable = new Responsable();
       
        public AfegirResponsable()
        {
            InitializeComponent();
        }

        private void btnAfegirReponsable_Click(object sender, RoutedEventArgs e)
        {
                if (txtBoxNomResponsable.Text != null)
                {
                    responsable.Nom = txtBoxNomResponsable.Text;
                    UserService.afegirResponsable(responsable);
                    MessageBox.Show("Has introduït un usuari", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Has de escriure un usuari", "Information", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            

        }
    }
}
