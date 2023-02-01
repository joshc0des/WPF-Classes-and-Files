namespace WPF_Classes_and_Files
{
    internal class Toy
    {
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        private string Aisle { get; set; }

        public Toy()
        {
            Manufacturer = string.Empty;
            Name = string.Empty;
            Price = 0;
            Image = string.Empty;
            Aisle = string.Empty;
        }

        public string GetAisle()
        {
            string manuf = Manufacturer.Substring(0, 1).ToUpper();
            string pri = Price.ToString().Replace(".", "");
            string outstr = manuf + pri;

            return outstr;
        }

        public override string ToString()
        {
            string output = $"{Manufacturer} - {Name}";
            return output;
        }
    }
}