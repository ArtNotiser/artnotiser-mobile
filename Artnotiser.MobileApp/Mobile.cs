namespace Artnotiser.Common.Model.Mobile
{
    public class NotificationMobile
    {
        public string Timestamp { get; set; }
        public List<ObservationGroupMobile> ObservationGroups { get; set; }
    }

    public class ObservationGroupMobile : List<ObservationMobile>
    {
        public string Title { get; set; }
        public string Timestamp { get; set; }

        public ObservationGroupMobile(string title, string timestamp, List<ObservationMobile> observations) : base (observations)
        {
            Timestamp= timestamp;
            Title = title;
        }
    }

    public class ObservationMobile
    {
        public string SpeciesName { get; set; }
        public string Location { get; set; }
        public string Time { get; set; }
        public string Url { get; set; }
        public int Quantity { get; set; }
    }
}
