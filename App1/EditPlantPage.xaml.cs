using System;
using Xamarin.Forms;

namespace App1
{
    public partial class EditPlantPage : ContentPage
    {
        private Plantule selectedPlantule;

        public EditPlantPage(Plantule plantule)
        {
            InitializeComponent();

            selectedPlantule = plantule;

            // Remplir les champs avec les données de la plantule sélectionnée
            txtIdentification.Text = plantule.Identification;
            cmbEtatSante.SelectedItem = plantule.EtatSante;
            dpDateArrivee.Date = plantule.DateArrivee;
            txtProvenance.Text = plantule.Provenance;
            txtDescription.Text = plantule.Description;
            cmbStade.SelectedItem = plantule.Stade;
            cmbEntreposage.SelectedItem = plantule.Entreposage;
            dpDateRetrait.Date = plantule.DateRetrait ?? DateTime.Now; // Utiliser DateTime.Now si DateRetrait est null
            cmbRaisonRetrait.SelectedItem = plantule.RaisonRetrait;
            cmbResponsable.SelectedItem = plantule.Responsable;
            txtNote.Text = plantule.Note;
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            // Mise à jour des données de la plantule
            selectedPlantule.EtatSante = cmbEtatSante.SelectedItem?.ToString();
            selectedPlantule.DateArrivee = dpDateArrivee.Date;
            selectedPlantule.Provenance = txtProvenance.Text;
            selectedPlantule.Description = txtDescription.Text;
            selectedPlantule.Stade = cmbStade.SelectedItem?.ToString();
            selectedPlantule.Entreposage = cmbEntreposage.SelectedItem?.ToString();
            selectedPlantule.Actif = dpDateRetrait.Date == DateTime.Now || dpDateRetrait.Date == default(DateTime); // Utiliser DateTime.Now pour vérifier
            selectedPlantule.DateRetrait = dpDateRetrait.Date != DateTime.Now ? dpDateRetrait.Date : (DateTime?)null;
            selectedPlantule.RaisonRetrait = cmbRaisonRetrait.SelectedItem?.ToString();
            selectedPlantule.Responsable = cmbResponsable.SelectedItem?.ToString();
            selectedPlantule.Note = txtNote.Text;

            // Rediriger vers la page précédente
            await Navigation.PopAsync();
        }
    }
}


