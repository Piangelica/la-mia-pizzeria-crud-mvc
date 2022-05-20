using NetCore_01.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NetCore_1.Models
{
    public class Category
{
        [Key]
public int Id { get; set; }
        [Required(ErrorMessage ="Il campo è obbligatorio")]
        [StringLength(75, ErrorMessage ="il titolo non può superare 75 caratteri")]
public string  Titolo { get; set; }
        [JsonIgnore]
        public List<Pizze> pizzes { get; set; }
        public Category()

        {


        }
    }
}