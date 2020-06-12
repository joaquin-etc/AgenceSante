using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace tp1 
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        //constante pour le mot de passe pour le login
        const string motDePasse = "AgenceSanté";
        
        public MainWindow()
        {
            InitializeComponent();
            username.Focus();
        }

        private void btnContinuer(object sender, RoutedEventArgs e)
        {
            //L'utilisateur ne peut rentrer sans marquer son nom d'utilisateur
            if (username.Text != string.Empty)
            {
                //si le mot de passe est valide, il ouvre l'autre fenêtre et ferme celle-ci
                if (password.Password.ToString() == motDePasse)
                {
                    var Window = new Enregistrement(username.Text);
                    Window.Show();
                    Window.Title = "Enregistrement par " + username.Text;
                    Close();
                }
                else//si le mot de passe est invalide, un message est montré
                {
                    MessageBoxResult messageBoite = MessageBox.Show("Mot de passe érroné, voulez vous réessayer?", "Login invalide", MessageBoxButton.YesNo);
                    if (messageBoite == MessageBoxResult.Yes)
                    {
                        //s'il veut réessayer, le mot de passe est effacé et le focus mis sur la boîte
                        password.Clear();
                        password.Focus();
                    }
                    if (messageBoite == MessageBoxResult.No)
                    {
                        //s'il ne veut pas réessayer le programme est fermé
                        this.Close();
                    }
                }
            }
            //s'il laisse le username vide un message est montré
            else
            {
                MessageBox.Show("Vous ne pouvez pas laisser un username vide");
                password.Clear();
                username.Focus();
            }
        }
        //si la boite username perd le focus, la première lettre sera mise en majuscule
        private void username_LostFocus(object sender, RoutedEventArgs e)
        {
            if(username.Text!=string.Empty)
             username.Text = username.Text.ElementAt(0).ToString().ToUpper() + username.Text.Substring(1);
        }
    }
}
