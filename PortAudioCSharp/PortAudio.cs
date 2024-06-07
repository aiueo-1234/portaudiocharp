using PortAudio.Wrapper;
namespace PortAudioCSharp;

public class PortAudio : IDisposable
{
    private bool _isDisposed = true;
    public void Initialize()
    {
        PortAudioWrapper.Initialize();
        _isDisposed = true;
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