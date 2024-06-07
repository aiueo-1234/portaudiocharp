using PortAudio.Wrapper;
namespace PortAudioCSharp;

public class PortAudioDevice : IDisposable
{
    private bool _isDisposed = true;
    public void Initialize()
    {
        PortAudioWrapper.Initialize();
        _isDisposed = false;
    }

    public void Dispose()
    {
        if (!_isDisposed)
        {
            PortAudioWrapper.Terminate();
        }
        _isDisposed = true;
    }
}