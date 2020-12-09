namespace Indkøbsapp.Interfaces
{
    public enum VareKategori
    {Mælkeprodukter, Kød, Grøntsager, Kiks, Kage, IS}
    public interface IButikItems
    {
        public VareKategori TypeVare { get; set; }
        public int ID { get; set; }
        public string Navn { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Billede { get; set; }
        public string Butik { get; set; }
    }
}
