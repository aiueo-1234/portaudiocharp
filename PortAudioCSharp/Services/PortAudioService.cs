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

    public PortAudioService()
    {
        Initialize();
        DefaultHostApi = new HostApi();
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
}
