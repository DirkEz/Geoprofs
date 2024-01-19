using System;
using System.ComponentModel.DataAnnotations;


namespace geoprofs.Models
{
    

    public class Werknemer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Voornaam is verplicht.")]
        [StringLength(50, ErrorMessage = "Voornaam mag niet langer zijn dan 50 karakters.")]
        public string Voornaam { get; set; }

        [Required(ErrorMessage = "Achternaam is verplicht.")]
        [StringLength(50, ErrorMessage = "Achternaam mag niet langer zijn dan 50 karakters.")]
        public string Achternaam { get; set; }

        [Required(ErrorMessage = "E-mail is verplicht.")]
        [EmailAddress(ErrorMessage = "Ongeldig e-mailadres.")]
        [StringLength(60, ErrorMessage = "E-mail mag niet langer zijn dan 60 karakters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Wachtwoord is verplicht.")]
        [StringLength(64, ErrorMessage = "Wachtwoord mag niet langer zijn dan 64 karakters.")]
        public string Wachtwoord { get; set; }

        [Display(Name = "Datum in dienst")]
        [DataType(DataType.Date)]
        public DateTime DatumIndienst { get; set; }

        public string BSN { get; set; } = "Vul hier uw bsn in";

        [Display(Name = "Saldo verlof")]
        public int SaldoVerlof { get; set; } = 25;

        public int Vakantie { get; set; } = 0;

        public int Persoonlijk { get; set; } = 0;

        public int Ziek { get; set; } = 0;

        [Display(Name = "Positie ID")]
        public int PositieId { get; set; }

        [Display(Name = "Supervisor ID")]
        public int SupervisorId { get; set; }

        public Positie Positie { get; set; }
    }

}

