// <auto-generated>
// This code is generated by csbindgen.
// DON'T CHANGE THIS DIRECTLY.
// </auto-generated>
#pragma warning disable CS8500
#pragma warning disable CS8981
using System;
using System.Runtime.InteropServices;
using PortAudio.Unsafe;


namespace PortAudio.Unsafe.Linux
{
    public static unsafe partial class NativeMethodsPulsAudio
    {
        const string __DllName = "portaudio";



        /// <summary>Renames the PulseAudio description for the source that is opened by PortAudio. @param s The PortAudio stream to operate on. @param streamName The new name/description of the source. @return paNoError on success or the error encountered otherwise.</summary>
        [DllImport(__DllName, EntryPoint = "PaPulseAudio_RenameSource", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PaPulseAudio_RenameSource(void* s, byte* streamName);

        /// <summary>Renames the PulseAudio description for the sink that is opened by PortAudio. @param s The PortAudio stream to operate on. @param streamName The new name/description of the sink. @return paNoError on success or the error encountered otherwise.</summary>
        [DllImport(__DllName, EntryPoint = "PaPulseAudio_RenameSink", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int PaPulseAudio_RenameSink(void* s, byte* streamName);


    }



}