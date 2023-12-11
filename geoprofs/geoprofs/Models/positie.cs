using System.ComponentModel.DataAnnotations;

public class Positie
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Positie naam is verplicht.")]
    [StringLength(60, ErrorMessage = "Positie naam mag niet langer zijn dan 60 karakters.")]
    public string PositieNaam { get; set; }
}

