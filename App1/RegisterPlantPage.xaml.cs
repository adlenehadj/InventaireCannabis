
using QRCoder;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace App1
{
    public partial class RegisterPlantPage : ContentPage
    {
        public ObservableCollection<Plantule> Plantules { get; set; }

        public RegisterPlantPage()
        {
            InitializeComponent();
            Plantules = new ObservableCollection<Plantule>();
            listViewPlantules.ItemsSource = Plantules;
            BindingContext = this;

            Plantules.CollectionChanged += (sender, e) => UpdatePlantCount();
            UpdatePlantCount();

            MessagingCenter.Subscribe<PlantuleDetailsPage, Plantule>(this, "DeletePlantule", (sender, plantule) =>
            {
                Plantules.Remove(plantule);
                UpdatePlantCount();
            });
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdentification.Text) ||
                cmbEtatSante.SelectedItem == null ||
                dpDateArrivee.Date == null ||
                string.IsNullOrWhiteSpace(txtProvenance.Text) ||
                string.IsNullOrWhiteSpace(txtDescription.Text) ||
                cmbStade.SelectedItem == null ||
                cmbEntreposage.SelectedItem == null ||
                cmbRaisonRetrait.SelectedItem == null ||
                cmbResponsable.SelectedItem == null)
            {
                await DisplayAlert("Erreur", "Veuillez remplir tous les champs", "OK");
                return;
            }

            if (IdentificationExists(txtIdentification.Text))
            {
                await DisplayAlert("Erreur", "Une plantule avec cette identification existe déjà", "OK");
                return;
            }

            var newPlantule = new Plantule
            {
                Identification = txtIdentification.Text,
                EtatSante = cmbEtatSante.SelectedItem.ToString(),
                DateArrivee = dpDateArrivee.Date,
                Provenance = txtProvenance.Text,
                Description = txtDescription.Text,
                Stade = cmbStade.SelectedItem.ToString(),
                Entreposage = cmbEntreposage.SelectedItem.ToString(),
                Actif = dpDateRetrait.Date == default(DateTime),
                DateRetrait = dpDateRetrait.Date != default(DateTime) ? dpDateRetrait.Date : (DateTime?)null,
                RaisonRetrait = cmbRaisonRetrait.SelectedItem.ToString(),
                Responsable = cmbResponsable.SelectedItem.ToString(),
                Note = txtNote.Text
            };

            Plantules.Add(newPlantule);
            UpdatePlantCount();

            await DisplayAlert("Succès", "Plantule enregistrée avec succès", "OK");

            // Réinitialiser le formulaire
            txtIdentification.Text = string.Empty;
            cmbEtatSante.SelectedItem = null;
            dpDateArrivee.Date = DateTime.Today; // Réinitialiser à une date par défaut
            txtProvenance.Text = string.Empty;
            txtDescription.Text = string.Empty;
            cmbStade.SelectedItem = null;
            cmbEntreposage.SelectedItem = null;
            dpDateRetrait.Date = DateTime.Today; // Réinitialiser à une date par défaut
            cmbRaisonRetrait.SelectedItem = null;
            cmbResponsable.SelectedItem = null;
            txtNote.Text = string.Empty;
        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                var selectedPlantule = e.Item as Plantule;
                await Navigation.PushAsync(new PlantuleDetailsPage(selectedPlantule));
            }
        }

        private bool IdentificationExists(string identification)
        {
            foreach (var plantule in Plantules)
            {
                if (plantule.Identification == identification)
                {
                    return true;
                }
            }
            return false;
        }
        private async void OnScanQrCodeClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ScanQrCodePage());
        }

        private void UpdatePlantCount()
        {
            plantCountLabel.Text = $"Nombre de plantes : {Plantules.Count}";
        }

    }
}








