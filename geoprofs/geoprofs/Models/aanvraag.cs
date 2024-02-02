using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace geoprofs.Models
{
    public class Aanvraag
    {
        public int Id { get; set; }

        [Display(Name = "Werknemer ID")]
        public int WerknemersId { get; set; } = 1000;

        [Display(Name = "Vanaf datum")]
        [DataType(DataType.Date)]
        public DateTime VanafDatum { get; set; }

        [Display(Name = "Tot datum")]
        [DataType(DataType.Date)]
        public DateTime TotDatum { get; set; }

        public string SelectionType { get; set; } = "Niks Geselecteerd";

        public int Goedkeuring { get; set; } = 0;

        [Display(Name = "Ondersteund door")]
        public int OndersteundDoor { get; set; } = 0;

        [Display(Name = "Werknemer ID")]
        public int WerknemerId { get; set; } = 0;

        [Display(Name = "Ondersteund door Werknemer ID")]
        public int OndersteundDoorWerknemerId { get; set; } = 0;

        public Werknemer Werknemer { get; set; } 

        [ForeignKey("OndersteundDoorWerknemerId")]
        public Werknemer OndersteundDoorWerknemer { get; set; }
    }
}