using Q6;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class NotificationService
{
    private readonly NotificationConfig _config;

    // Injecting NotificationConfig through Dependency Injection
    public NotificationService(NotificationConfig config)
    {
        _config = config;
    }

    public async Task<List<string>> GetNotificationsAsync(int? numberOfNotifications = null)
    {
        // Agar user input nahi deta, toh default config se value uthayega
        int count = numberOfNotifications ?? _config.DefaultNumberOfNotifications;

        var list = new List<string>();
        for (int i = 1; i <= count; i++)
        {
            list.Add($"System Alert #{i}: Server handshake established successfully.");
        }

        // Simulating async fetch
        await Task.Delay(50);
        return list;
    }

    public string GetCurrentStyle()
    {
        return _config.NotificationStyle;
    }
}