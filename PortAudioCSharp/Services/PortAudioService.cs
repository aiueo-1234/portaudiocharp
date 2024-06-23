using PortAudioCSharp.Devices;
using PortAudioCSharp.Exceptions;
using PortAudioCSharp.Services.Contracts;
using PortAudioCSharp.Wrapper;

namespace PortAudioCSharp.Services;

public sealed class PortAudioService : IPortAudioService
{
    private bool _isInitialized = false;

    public bool IsInitialized
    {
        get
        {
            if (_isInitialized)
            {
                Initialize();
            }
            return _isInitialized;
        }
    }

    public HostApi DefaultHostApi { get; }
    public PortAudioDevice DefaultInputDevice { get; }
    public PortAudioDevice DefaultOutputDevice { get; }

    public PortAudioService()
    {
        Initialize();
        DefaultHostApi = new HostApi();
        DefaultInputDevice = new PortAudioDevice(PortAudioWrapper.GetDefaultInputDevice());
        DefaultOutputDevice = new PortAudioDevice(PortAudioWrapper.GetDefaultOutputDevice());
    }

    internal void Initialize()
    {
        PortAudioException.ThrowIfError(PortAudioWrapper.Initialize());
        _isInitialized = true;
    }

    public void Dispose()
    {
        if (_isInitialized)
        {
            PortAudioException.ThrowIfError(PortAudioWrapper.Terminate());
        }
        _isInitialized = false;
    }

    public IEnumerable<HostApi> GetAllHostApi()
    {
        var avaliableApiCount = PortAudioWrapper.GetHostApiCount();
        if (avaliableApiCount < 0)
        {
            PortAudioException.ThrowIfError(avaliableApiCount);
        }
        return Enumerable.Range(0, avaliableApiCount).Select(x => new HostApi(x, false));
    }
}
