namespace MVCProject.Models
{
    public class HTMLTagsViewModel
    {
        public string PaymentMode { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public List<string> ElectronicItems { get; set; }
        public IFormFile? File { get; set; }
        public List<IFormFile>? Files { get; set; }
        public bool IsEligible { get; set; }
        public string Address { get; set; }
    }
}
