namespace ACE.Mods.Metrics;

public class Mod : BasicMod
{
    public Mod() : base() => Setup("ACE.Mods.Metrics", new PatchClass(this));

    internal static void Log(string message, ModManager.LogLevel level = ModManager.LogLevel.Info)
    {
        ModManager.Log($"[ACE.Mods.Metrics] {message}", level);
    }
}
