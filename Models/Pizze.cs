using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore_01.Models
{
    public class Pizze
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Il campo URL dell'immagine è obbligatorio")]
        [Url(ErrorMessage = "Mi dispiace, l'Url inserito non è valido")]
        [MoreThanOneWordValidationAttribute]
        public string Immagine { get; set; }

        [Required(ErrorMessage = "Il campo Nome è obbligatorio")]
        [StringLength(20, ErrorMessage = "Il nome non può avere più di 20 caratteri")]
      
        public string Nome { get; set; }

        [Required(ErrorMessage = "Il campo descrizione  è obbligatorio")]
        
        [Column(TypeName="text")]
        public string Descrizione { get; set; }
        public string Prezzo { get; set; }

        public Pizze()
        {

        }

        public Pizze( string immagine, string nome, string descrizione, string prezzo)
        {
            this.Immagine = immagine;
            this.Nome = nome;
            this.Descrizione = descrizione;
            this.Prezzo = prezzo;
        }
    }
}