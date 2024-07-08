namespace Metrics;

public class Settings
{
    public string Host { get; set; } = "127.0.0.1";
    public int Port { get; set; } = 9200;
    public string Url { get; set; } = "metrics/";
    public bool UseHTTPs { get; set; } = false;
}
