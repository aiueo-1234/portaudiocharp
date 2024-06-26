using PortAudioCSharp.AutoGenerated;
using PortAudioCSharp.Utils;

namespace PortAudioCSharp.Wrapper;

public class VersionInfo
{
    public int VersionMajor { get; }
    public int VersionMinor { get; }
    public int VersionSubMinor { get; }
    public string VersionControlRevision { get; }
    public string VersionText { get; }

    internal unsafe VersionInfo(PaVersionInfo* paVersionInfo)
    {
        VersionMajor = paVersionInfo->versionMajor;
        VersionMinor = paVersionInfo->versionMinor;
        VersionSubMinor = paVersionInfo->versionSubMinor;
        VersionControlRevision = Helper.ConvertText(paVersionInfo->versionControlRevision);
        VersionText = Helper.ConvertText(paVersionInfo->versionText);
    }
}
