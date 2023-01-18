namespace Artnotiser.Common.Model.Mobile
{
    public class Notification
    {
        public DateTime Timestamp { get; set; }
        public List<ObservationGroup> ObservationGroups { get; set; }
    }

    public class ObservationGroup
    {
        public string Title { get; set; }

        public List<Observation> Observations { get; set; }

        public ObservationGroup(string title, List<Observation> observations) 
        {
            Title = title;
            Observations = observations;
        }
    }
}
