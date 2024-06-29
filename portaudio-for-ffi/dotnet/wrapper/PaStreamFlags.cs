// TODO 自動生成
using System;

namespace PortAudioCSharp.Wrapper;

[Flags]
public enum PaStreamFlags : uint
{
    paNoFlag = 0,
    paClipOff = 0x00000001,
    paDitherOff = 0x00000002,
    paNeverDropInput = 0x00000004,
    paPrimeOutputBuffersUsingStreamCallback = 0x00000008,
    paPlatformSpecificFlags = 0xFFFF0000
}
