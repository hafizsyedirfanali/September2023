namespace APIProject.Models
{
    public class StudentModel
    { 
        //Id column is made nullable here because
        //we will be using same class for create and update
        //create does not require Id column and Update require Id column.
        //It would be better if we create separate class for Create without Id column
        //and separate class for update with Id column
        public Guid? Id { get; set; }//Column1
        public string Name { get; set; }//Col2
        public string Address { get; set; }//Col3
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
