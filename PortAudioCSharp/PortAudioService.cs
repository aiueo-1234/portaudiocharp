using PortAudioCSharp.Exceptions;
using PortAudioCSharp.Wrapper;

namespace PortAudioCSharp;

public sealed class PortAudioService : IDisposable
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

    public PortAudioService(){
        Initialize();
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
