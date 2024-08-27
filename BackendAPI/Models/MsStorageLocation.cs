namespace BackendAPI.Models
{
    public class MsStorageLocation
    {
        public string LocationId { get; set; }
        public string LocationName { get; set; }

        public ICollection<TrBpkb> TrBpkbs { get; set; }
    }

}
