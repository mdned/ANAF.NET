namespace ANAF.API
{
    public class SearchCompanyResponseDto
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Cui { get; set; }
        public string Country { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Building { get; set; }
        public string Entry { get; set; }
        public string Floor { get; set; }
        public string Appartment { get; set; }

        internal SearchCompanyResponseDto() { }

        internal SearchCompanyResponseDto(string name, string phone, string cui, string county, string city, string street, 
            string number, string building, string entry, string floor, string appartment)
        {
            Name = name;
            Phone = phone;
            Cui = cui;
            Country = "Romania";
            County = county;
            City = city;
            Street = street;
            Number = number;
            Building = building;
            Entry = entry;
            Floor = floor;
            Appartment = appartment;
        }
    }
}