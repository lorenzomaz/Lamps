
using System.ComponentModel.DataAnnotations;

namespace Lamps.Infrastructure.Entities
{
    public class Lamp
    {
        public int Id { get; set; }

        [StringLengthAttribute(100)]
        public string Name { get; set; }
        public string Img { get; set; }
        public string Info { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Price { get; set; }

    }
}
