using System;
using Xamarin.Forms;

namespace App1
{
    public class Plantule
    {
        public string Identification { get; set; }
        public string EtatSante { get; set; }
        public DateTime DateArrivee { get; set; }
        public string Provenance { get; set; }
        public string Description { get; set; }
        public string Stade { get; set; }
        public string Entreposage { get; set; }
        public bool Actif { get; set; }
        public DateTime? DateRetrait { get; set; }
        public string RaisonRetrait { get; set; }
        public string Responsable { get; set; }
        public string Note { get; set; }
        public ImageSource QRCode { get; set; }
    }
}

