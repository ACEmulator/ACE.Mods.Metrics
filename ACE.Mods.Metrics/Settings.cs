namespace ACE.Mods.Metrics;

public class Settings
{
    /// <summary>
    /// Host, default: 127.0.0.1
    /// Probably best to leave this as is, and use reverse proxy which can be secured better.
    /// </summary>
    public string Host { get; set; } = "127.0.0.1";

    /// <summary>
    /// Port, default: 9200
    /// Probably best to leave this as is, and use reverse proxy which can be secured better.
    /// </summary>
    public int Port { get; set; } = 9200;

    /// <summary>
    /// Url, default: metrics/
    /// Probably best to leave this as is, and use reverse proxy which can be secured better.
    /// If above is default, the full url becomes http://127.0.0.1:9200/metrics/ to access
    /// </summary>
    public string Url { get; set; } = "metrics/";

    /// <summary>
    /// UseHTTPs, default: false
    /// Probably best to leave this as is, and use reverse proxy which can be secured better.
    /// If above is default, the full url becomes https://127.0.0.1:9200/metrics/ to access
    /// </summary>
    public bool UseHTTPs { get; set; } = false;
}
