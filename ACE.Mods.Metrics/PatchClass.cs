namespace ACE.Mods.Metrics;

[HarmonyPatch]
public class PatchClass(BasicMod mod, string settingsName = "Settings.json") : BasicPatch<Settings>(mod, settingsName)
{
    public override void Init()
    {
        base.Init();
    }

    public override Task OnStartSuccess()
    {
        Settings = SettingsContainer?.Settings ?? new();
        StartServices();

        return Task.CompletedTask;
    }

    //public override Task OnWorldOpen()
    //{
    //    Settings = SettingsContainer?.Settings ?? new();
    //    StartServices();

    //    return Task.CompletedTask;
    //}

    protected override void SettingsChanged(object sender, EventArgs e)
    {
        StopServices();
        base.SettingsChanged(sender, e);
        Settings = SettingsContainer?.Settings ?? new();
        StartServices();
    }

    public override void Stop()
    {
        StopServices();
        base.Stop();
    }

    public static void StartServices()
    {
        try
        {
            PrometheusMetrics.InitMetrics();

            Mod.Log($"Metrics Exporter Online and listening to requests at http{(Settings.UseHTTPs ? "s" : "")}://{Settings.Host}:{Settings.Port}" + "/" + $"{Settings.Url}");
        }
        catch (Exception ex)
        {
            Mod.Log($"ERROR during initialization - {ex.Message}", ModManager.LogLevel.Error);
        }
    }

    public static void StopServices()
    {
        PrometheusMetrics.ShutdownMetrics();

        Mod.Log("Metrics Exporter Offline");
    }
}
