using System;
using System.Text;
using System.Text.Unicode;

namespace PortAudioCSharp.Utils;

internal static class Helper
{
    internal static unsafe string ConvertText(byte* cText)
    {
        int count = 0;
        while (*(cText + count) != '\0') { count++; }
        var text = string.Create(count, (nint)cText, (Span<char> chars, nint state) =>
        {
            Utf8.ToUtf16(new ReadOnlySpan<byte>((byte*)state, count), chars, out _, out _);
        });
        return text;
    }

    internal static string ConvertText(ReadOnlySpan<byte> cText)
    {
        return Encoding.Unicode.GetString(cText);
    }

    internal static unsafe ReadOnlySpan<byte> ConvertROS(byte* cText)
    {
        if ((nint)cText == nint.Zero)
        {
            return default;
        }
        int count = 0;
        while (*(cText + count) != '\0') { count++; }
        return new ReadOnlySpan<byte>(cText, count);
    }
}
