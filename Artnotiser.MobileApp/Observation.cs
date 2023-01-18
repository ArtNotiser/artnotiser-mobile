namespace Artnotiser.Common.Model
{
    public class Observation
    {
        public string? id { get; set; }
        public int Id { get; set; }
        public string SpeciesName { get; set; }
        public int TaxonId { get; set; }
        public string Owner { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? Quantity { get; set; }
        public string Url { get; set; }

        public string Location { get; set; }
        public string Municipality { get; set; }
        public string County { get; set; }
        public string Province { get; set; }

        // If the Location is more than 2 parts, e.g. "Kalmarhagarna, Fysingen, Upl"
        // then Location_Main will contain the 2nd to last part, which hopefully
        // is the main location (sv. huvudlokal).
        public string Location_Main { get; set; }


        public Observation() 
        { 
        }


        public Observation(Observation observation)
        {
            Id = observation.Id;
            SpeciesName = observation.SpeciesName;
            TaxonId = observation.TaxonId;
            Owner = observation.Owner;    
            StartDate = observation.StartDate;
            EndDate = observation.EndDate;
            Quantity = observation.Quantity;
            Url = observation.Url;

            Location = observation.Location;
            Municipality= observation.Municipality;
            County = observation.County;
            Province = observation.Province;
            Location_Main= observation.Location_Main;
        }
    }
}
