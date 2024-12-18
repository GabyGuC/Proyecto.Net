using System.ComponentModel.DataAnnotations;
namespace NetProyect.Models
{
	public class Contacto
	{
		[Key]
		public int Id { get; set; }

		[Required (ErrorMessage ="Nombre requerido")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Telefono requerido")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Celular requerido")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Email requerido")]
        public string Email { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}

