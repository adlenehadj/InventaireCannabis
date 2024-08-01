using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace App1
{
    public partial class ScanQrCodePage : ContentPage
    {
        public ScanQrCodePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            scannerView.IsScanning = true;
        }

        protected override void OnDisappearing()
        {
            scannerView.IsScanning = false;
            base.OnDisappearing();
        }

        private async void Handle_OnScanResult(ZXing.Result result)
        {
            scannerView.IsScanning = false;
            Device.BeginInvokeOnMainThread(async () =>
            {
                // Chercher la plantule par identification
                var plantule = await FindPlantuleByIdentification(result.Text);
                if (plantule != null)
                {
                    await Navigation.PushAsync(new PlantuleDetailsPage(plantule));
                }
                else
                {
                    await DisplayAlert("Erreur", "Plantule non trouvée", "OK");
                }
                await Navigation.PopAsync();
            });
        }

        private async void OnStopScanClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private Task<Plantule> FindPlantuleByIdentification(string identification)
        {
            // Chercher dans la collection de plantules enregistrées
            foreach (var plantule in App.Plantules)
            {
                if (plantule.Identification == identification)
                {
                    return Task.FromResult(plantule);
                }
            }
            return Task.FromResult<Plantule>(null);
        }
    }
}


