using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace geoprofs.Models
{
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

        [Display(Name = "Werknemer ID")]
        public int WerknemerId { get; set; }

        [Display(Name = "Ondersteund door Werknemer ID")]
        public int OndersteundDoorWerknemerId { get; set; }

        public Werknemer Werknemer { get; set; }

        [ForeignKey("OndersteundDoorWerknemerId")]
        public Werknemer OndersteundDoorWerknemer { get; set; }
    }
}