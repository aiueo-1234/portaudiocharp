using System.Text;
using PortAudioCSharp.Wrapper;

namespace PortAudioCSharp.Devices;

public class PortAudioDevice
{
    private int _deviceIndex = (int)PaDeviceIndex.paNoDevice;
    public string Name { get; }
    public HostApi HostApi { get; }

    public int MaxInputChannels { get; }
    public int MaxOutputChannels { get; }
    public double DefaultLowInputLatency { get; }
    public double DefaultLowOutputLatency { get; }
    public double DefaultHighInputLatency { get; }
    public double DefaultHighOutputLatency { get; }
    public double DefaultSampleRate { get; }

    public PortAudioDevice(int deviceIndex, HostApi hostApi)
    {
        if (deviceIndex < 0 || deviceIndex >= PortAudioWrapper.GetDeviceCount())
        {
            throw new ArgumentOutOfRangeException(nameof(deviceIndex));
        }
        _deviceIndex = deviceIndex;
        HostApi = hostApi;
        var deviceInfo = PortAudioWrapper.GetDeviceInfo(deviceIndex);
        Name = UnicodeEncoding.Default.GetString(deviceInfo.Name);
        MaxInputChannels = deviceInfo.MaxInputChannels;
        MaxOutputChannels = deviceInfo.MaxOutputChannels;
        DefaultLowInputLatency = deviceInfo.DefaultLowInputLatency;
        DefaultLowOutputLatency = deviceInfo.DefaultLowOutputLatency;
        DefaultHighInputLatency = deviceInfo.DefaultHighInputLatency;
        DefaultHighOutputLatency = deviceInfo.DefaultHighOutputLatency;
        DefaultSampleRate = deviceInfo.DefaultSampleRate;
    }

    public PortAudioDevice(int deviceIndex)
    {
        if (deviceIndex < 0 || deviceIndex >= PortAudioWrapper.GetDeviceCount())
        {
            throw new ArgumentOutOfRangeException(nameof(deviceIndex));
        }
        _deviceIndex = deviceIndex;
        var deviceInfo = PortAudioWrapper.GetDeviceInfo(deviceIndex);
        Name = UnicodeEncoding.Default.GetString(deviceInfo.Name);
        MaxInputChannels = deviceInfo.MaxInputChannels;
        MaxOutputChannels = deviceInfo.MaxOutputChannels;
        DefaultLowInputLatency = deviceInfo.DefaultLowInputLatency;
        DefaultLowOutputLatency = deviceInfo.DefaultLowOutputLatency;
        DefaultHighInputLatency = deviceInfo.DefaultHighInputLatency;
        DefaultHighOutputLatency = deviceInfo.DefaultHighOutputLatency;
        DefaultSampleRate = deviceInfo.DefaultSampleRate;
        HostApi = new HostApi(deviceInfo.HostApi, false);
    }
}
