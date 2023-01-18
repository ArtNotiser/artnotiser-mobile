using Artnotiser.Common.Model;
using Artnotiser.Common.Model.Mobile;
using System.Diagnostics;
using System.Text.Json;
using Notification = Artnotiser.Common.Model.Mobile.Notification;

namespace ArtNotiser.MobileApp;
public class ArtnotiserRepository
{
    // https://www.andreasnesheim.no/push-notifications-in-net-maui-with-firebase/

    bool includeEmptyGroups;
    public List<ObservationGroupMobile> ObservationGroups { get; private set; } = new List<ObservationGroupMobile>();

    public ArtnotiserRepository(bool emptyGroups = false)
    {
        includeEmptyGroups = emptyGroups;
    }

    public async Task GetNotificationsForUser(string userId)
    {
        Stopwatch sw = Stopwatch.StartNew();

        // 208fdd4d-35a4-4d7d-b2de-17eef6631c23
        HttpClient httpClient = new HttpClient();
        string queryUrl = $"https://dev.api.artnotiser.se/api/GetNotifications?userId={userId}";
        var response = await httpClient.GetAsync(queryUrl);
        var content = await response.Content.ReadAsStringAsync();

        long retrieveJson = sw.ElapsedMilliseconds;

        List<Notification> notifications = JsonSerializer.Deserialize<List<Notification>>(content);

        long deserializeJson = sw.ElapsedMilliseconds - retrieveJson;

        int notificationCount = notifications.Count;
        int count = 0;

        List<NotificationMobile> notificationMobiles = new List<NotificationMobile>();
        foreach (Notification notification in notifications)
        {
            NotificationMobile notificationMobile = new NotificationMobile()
            {
                Timestamp = notification.Timestamp.ToString("yyyy-MM-dd HH:mm"),
                ObservationGroups = new List<ObservationGroupMobile>()
            };

            foreach (ObservationGroup observationGroup in notification.ObservationGroups)
            {
                List<ObservationMobile> mobileObservations = new List<ObservationMobile>();
                foreach(Observation observation in observationGroup.Observations)
                {
                    mobileObservations.Add(new ObservationMobile()
                    {
                        Location= observation.Location,
                        Quantity = (int)observation.Quantity,
                        SpeciesName= observation.SpeciesName,
                        Time = observation.StartDate.ToString("dd/MM HH:mm"),
                        Url = observation.Url
                    });
                }

                notificationMobile.ObservationGroups.Add(new ObservationGroupMobile(observationGroup.Title, notification.Timestamp.ToString("yyyy-MM-dd HH:mm"), mobileObservations));
            }

            notificationMobiles.Add(notificationMobile);
            foreach (ObservationGroupMobile observationGroupMobile in notificationMobile.ObservationGroups)
            {
                ObservationGroups.Add(observationGroupMobile);
            }

            count++;
        }

        long processObjects = sw.ElapsedMilliseconds - deserializeJson - retrieveJson;
    }
}