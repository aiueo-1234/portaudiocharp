using System.Text;
using PortAudioCSharp.AutoGenerated;
using PortAudioCSharp.Exceptions;
using PortAudioCSharp.Wrapper;

namespace PortAudioCSharp;

public class HostApi
{
    public PaHostApiTypeId Type { get; }
    public string Name { get; }
    public int DeviceCount { get; }

    public HostApi() : this(PortAudioWrapper.GetDefaultHostApi(), true) { }

    public HostApi(PaHostApiTypeId paHostApiTypeId) : this(PortAudioWrapper.HostApiTypeIdToHostApiIndex(paHostApiTypeId), true) { }

    public HostApi(int apiIndex) : this(apiIndex, true) { }

    private HostApi(int apiIndex, bool chakeError)
    {
        if (chakeError)
        {
            var avaliableApiCount = PortAudioWrapper.GetHostApiCount();
            if (avaliableApiCount < 0)
            {
                PortAudioException.Throw((PaErrorCode)avaliableApiCount);
            }
            ArgumentOutOfRangeException.ThrowIfGreaterThan(apiIndex, avaliableApiCount);
            if (apiIndex < 0)
            {
                PortAudioException.ThrowIfError(avaliableApiCount);
                throw new ArgumentOutOfRangeException(nameof(apiIndex));
            }
        }

        var apiInfo = PortAudioWrapper.GetHostApiInfo(apiIndex);
        Type=apiInfo.Type;
        Name=UnicodeEncoding.Default.GetString(apiInfo.Name);

        //デバイス部分を実装する
    }

    public static IEnumerable<HostApi> GetAll()
    {
        var avaliableApiCount = PortAudioWrapper.GetHostApiCount();
        if (avaliableApiCount < 0)
        {
            PortAudioException.Throw((PaErrorCode)avaliableApiCount);
        }
        return Enumerable.Range(0, avaliableApiCount).Select(x => new HostApi(x, false));
    }
}