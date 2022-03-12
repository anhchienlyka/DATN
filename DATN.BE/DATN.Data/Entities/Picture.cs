namespace DATN.Data.Entities
{
    public class Picture
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public byte[] Image { get; set; }
    }
}