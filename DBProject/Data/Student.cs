using System.ComponentModel.DataAnnotations;

namespace DBProject.Data
{
    public class Student//Table
    {
        [Key]
        public Guid Id { get; set; }//Column1
        public string Name { get; set; }//Col2
        public string Address { get; set; }//Col3
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
