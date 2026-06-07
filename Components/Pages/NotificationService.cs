using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Q6
{
    public class NotificationService
    {
        private readonly NotificationConfig _config;

        // Dynamic State Notify Event Trigger
        public event Action? OnStateChanged;

        public NotificationService(NotificationConfig config)
        {
            _config = config;
        }

        // Methods to change settings and trigger instant UI updates
        public void UpdateStyle(string newStyle)
        {
            _config.NotificationStyle = newStyle;
            NotifyStateChanged();
        }

        public void UpdateCount(int newCount)
        {
            _config.DefaultNumberOfNotifications = newCount;
            NotifyStateChanged();
        }

        public int GetCurrentCount() => _config.DefaultNumberOfNotifications;
        public string GetCurrentStyle() => _config.NotificationStyle;

        public async Task<List<string>> GetNotificationsAsync(int? numberOfNotifications = null)
        {
            int count = numberOfNotifications ?? _config.DefaultNumberOfNotifications;

            var list = new List<string>();
            for (int i = 1; i <= count; i++)
            {
                list.Add($"System Alert #{i}: Server handshake established successfully.");
            }

            await Task.Delay(50);
            return list;
        }

        private void NotifyStateChanged() => OnStateChanged?.Invoke();
    }
}