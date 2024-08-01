using System;
using Xamarin.Forms;

namespace App1
{
    public partial class PlantuleDetailsPage : ContentPage
    {
        private Plantule selectedPlantule;

        public PlantuleDetailsPage(Plantule plantule)
        {
            InitializeComponent();
            selectedPlantule = plantule; // Initialiser selectedPlantule
            BindingContext = selectedPlantule;
        }

        private async void OnEditButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditPlantPage(selectedPlantule));
        }
        private async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            bool confirm = await DisplayAlert("Confirmation", "Êtes-vous sûr de vouloir supprimer cette plantule ?", "Oui", "Non");
            if (confirm)
            {
                MessagingCenter.Send(this, "DeletePlantule", selectedPlantule);
                await Navigation.PopAsync();
            }
        }
    }
}

