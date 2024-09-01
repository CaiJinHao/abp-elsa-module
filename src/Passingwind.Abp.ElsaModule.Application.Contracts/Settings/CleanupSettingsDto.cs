namespace Passingwind.Abp.ElsaModule.Settings;

public class CleanupSettingsDto
{
    public bool Enabled { get; set; }
    public int KeepDays { get; set; }
    public bool ScopeAll { get; set; }
    public int[] Scopes { get; set; }
}
