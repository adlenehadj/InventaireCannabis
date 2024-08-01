using System;
using Xamarin.Forms;

namespace App1
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string email = emailEntry.Text;
            string password = passwordEntry.Text;

            if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(password))
            {
                // Vérifiez les informations de connexion ici
                if (email == "test@example.com" && password == "password")
                {
                    // Connexion réussie
                    await DisplayAlert("Success", "Connexion réussie", "OK");
                    await Navigation.PushAsync(new RegisterPlantPage()); // Naviguer vers la page RegisterPlantPage
                }
                else
                {
                    // Échec de la connexion
                    await DisplayAlert("Error", "Email ou mot de passe incorrect", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "Veuillez remplir tous les champs", "OK");
            }
        }
    }
}
