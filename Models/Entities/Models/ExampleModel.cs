using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities.Models
{
    public sealed class ExampleModel : IModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Name { get; set; }

        public bool Equals(IModel? other)
        {
            return other is ExampleModel model && Name == model.Name;
        }
    }
}
