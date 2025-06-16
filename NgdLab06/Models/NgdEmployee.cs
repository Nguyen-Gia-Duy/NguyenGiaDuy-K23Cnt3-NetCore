namespace NgdLab06.Models
{
    public class NgdEmployee
    {
        public int NgdId { get; set; }
        public string NgdName { get; set; }
        public DateTime NgdBirthDay { get; set; }
        public string NgdEmail { get; set; }
        public string NgdPhone { get; set; }
        public decimal NgdSalary { get; set; }
        public bool NgdStatus { get; set; } // true = đang làm việc, false = nghỉ việc
    }
}
