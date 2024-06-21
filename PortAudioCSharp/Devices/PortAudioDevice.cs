using PortAudioCSharp.Wrapper;
using System.Text;

namespace PortAudioCSharp.Devices;

public class PortAudioDevice
{
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
        HostApi = hostApi;
        if (deviceIndex < 0 || deviceIndex > PortAudioWrapper.GetDeviceCount())
        {
            throw new ArgumentOutOfRangeException(nameof(deviceIndex));
        }
        var deviceInfo = PortAudioWrapper.GetDeviceInfo(deviceIndex);
        Name = UnicodeEncoding.Default.GetString(deviceInfo.Name);
        MaxInputChannels=deviceInfo.MaxInputChannels;
        MaxOutputChannels=deviceInfo.MaxOutputChannels;
        DefaultLowInputLatency=deviceInfo.DefaultLowInputLatency;
        DefaultLowOutputLatency=deviceInfo.DefaultLowOutputLatency;
        DefaultHighInputLatency=deviceInfo.DefaultHighInputLatency;
        DefaultHighOutputLatency=deviceInfo.DefaultHighOutputLatency;
        DefaultSampleRate = deviceInfo.DefaultSampleRate;
    }

    public static IEnumerable<PortAudioDevice> GetAllDevice(HostApi hostApi){
        return Enumerable.Range(0,hostApi.DeviceCount).Select(i=>new PortAudioDevice(i,hostApi));
    }
}