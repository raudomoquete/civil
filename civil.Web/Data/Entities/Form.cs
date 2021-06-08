using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace civil.Web.Data.Entities
{
    public class Form
    {
        public int Id { get; set; }

        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Tipo de Incidente")]
        [MaxLength(200, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string Incident { get; set; }

        [Display(Name = "Provincia")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string Province { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(500, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string Description { get; set; }

        [Display(Name = "Longitud")]
        public string Longitude { get; set; }

        [Display(Name = "Latitud")]
        public string Latitude { get; set; }

        [Display(Name = "Imagen")]
        public string ImageUrl { get; set; }

        [Display(Name = "Personas afectadas")]
        public int AffectedPeople { get; set; }

        [Display(Name = "Viviendas afectadas")]
        public int AffectedHomes { get; set; }

        [Display(Name = "Fallecidos")]
        public int Deceased { get; set; }

        [Display(Name = "Observación")]
        [MaxLength(500, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string Observation { get; set; }

        [Display(Name = "Informante")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string Informant { get; set; }

        [Display(Name = "Operador")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Operator { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedAt { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime UpdatedAt { get; set; }

    }
}
