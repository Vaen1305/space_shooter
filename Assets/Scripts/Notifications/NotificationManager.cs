using UnityEngine;
using Unity.Notifications.Android;

public class NotificationManager : MonoBehaviour
{
    private const string channelId = "game_notifications";

    void Start()
    {
        CreateNotificationChannel();
    }

    private void CreateNotificationChannel()
    {
        var channel = new AndroidNotificationChannel
        {
            Id = channelId,
            Name = "Game Notifications",
            Importance = Importance.High,
            Description = "Notifications for game events"
        };

        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    public void SendNotification(string title, string text, string smallIcon, int delayInSeconds)
    {
        var notification = new AndroidNotification
        {
            Title = title,
            Text = text,
            SmallIcon = smallIcon,
            FireTime = System.DateTime.Now.AddSeconds(delayInSeconds)
        };

        AndroidNotificationCenter.SendNotification(notification, channelId);
    }
}