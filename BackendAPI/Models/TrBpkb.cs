namespace BackendAPI.Models
{
    public class TrBpkb
    {
        public string AgreementNumber { get; set; }
        public string BpkbNo { get; set; }
        public string BranchId { get; set; }
        public DateTime BpkbDate { get; set; }
        public string FakturNo { get; set; }
        public DateTime FakturDate { get; set; }
        public string LocationId { get; set; }
        public string PoliceNo { get; set; }
        public DateTime? BpkbDateIn { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateOn { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }

        public MsStorageLocation Location { get; set; }
    }

}
