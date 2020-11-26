namespace Indkøbsapp.Interfaces
{
    public enum VareKategori
    {Mælkeprodukter, Kød, Grønsager, Kiks, Kage, IS}
    public interface IButikItems
    { 
        public int ID { get; set; }
        public string Navn { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Billede { get; set; }
    }
}
