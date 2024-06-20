using System.Runtime.CompilerServices;
using PortAudioCSharp.AutoGenerated;
using PortAudioCSharp.Utils;

namespace PortAudioCSharp.Wrapper;

public static class PortAudioWrapper
{
    public static unsafe string GetVersionText()
    {
        return Helper.ConvertText(NativeMethods.Pa_GetVersionText());
    }

    public static unsafe VersionInfo GetVersionInfo()
    {
        return new VersionInfo(NativeMethods.Pa_GetVersionInfo());
    }

    public static PaErrorCode Initialize()
    {
        return (PaErrorCode)NativeMethods.Pa_Initialize();
    }

    public static PaErrorCode Terminate()
    {
        return (PaErrorCode)NativeMethods.Pa_Terminate();
    }

    public static unsafe string GetErrorText(PaErrorCode errorCode)
    {
        return Helper.ConvertText(NativeMethods.Pa_GetErrorText((int)errorCode));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int GetHostApiCount()
    {
        return NativeMethods.Pa_GetHostApiCount();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int GetDefaultHostApi()
    {
        return NativeMethods.Pa_GetDefaultHostApi();
    }

    public static unsafe HostApiInfo GetHostApiInfo(int hostApi)
    {
        var paHostApiInfo = NativeMethods.Pa_GetHostApiInfo(hostApi);
        if ((nint)paHostApiInfo != nint.Zero)
        {
            return new HostApiInfo(paHostApiInfo);
        }
        else
        {
            return default;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int HostApiTypeIdToHostApiIndex(PaHostApiTypeId type)
    {
        return NativeMethods.Pa_HostApiTypeIdToHostApiIndex(type);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int HostApiDeviceIndexToDeviceIndex(int hostApi, int hostApiDeviceIndex)
    {
        return NativeMethods.Pa_HostApiDeviceIndexToDeviceIndex(hostApi, hostApiDeviceIndex);
    }

    public static unsafe HostErrorInfo GetLastHostErrorInfo()
    {
        return new HostErrorInfo(NativeMethods.Pa_GetLastHostErrorInfo());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int GetDefaultInputDevice()
    {
        return NativeMethods.Pa_GetDefaultInputDevice();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int GetDefaultOutputDevice()
    {
        return NativeMethods.Pa_GetDefaultOutputDevice();
    }

    public static unsafe DeviceInfo GetDeviceInfo(int deviceIndex)
    {
        return new DeviceInfo(NativeMethods.Pa_GetDeviceInfo(deviceIndex));
    }
}
