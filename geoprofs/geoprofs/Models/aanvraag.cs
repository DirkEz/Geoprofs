using System;
using System.ComponentModel.DataAnnotations;

public class Aanvraag
{
    public int Id { get; set; }

    [Display(Name = "Werknemer ID")]
    public int WerknemersId { get; set; }

    [Display(Name = "Vanaf datum")]
    [DataType(DataType.Date)]
    public DateTime VanafDatum { get; set; }

    [Display(Name = "Tot datum")]
    [DataType(DataType.Date)]
    public DateTime TotDatum { get; set; }

    public int Vakantie { get; set; }

    public int Persoonlijk { get; set; }

    public int Ziek { get; set; }

    public int Goedkeuring { get; set; }

    [Display(Name = "Ondersteund door")]
    public int OndersteundDoor { get; set; }

    public Werknemer Werknemer { get; set; }
    public Werknemer OndersteundDoorWerknemer { get; set; }
}
