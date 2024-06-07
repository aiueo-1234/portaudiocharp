using System;
using System.Text.Unicode;

namespace PortAudio.Utils;

internal static class Helper{
    internal static unsafe string ConvertText(byte* cText){
        int count = 0;
        while (*(cText + count) != '\0') { count++; }
        var text = string.Create(count, (nint)cText, (Span<char> chars, nint state) =>
        {
            Utf8.ToUtf16(new ReadOnlySpan<byte>((byte*)state, count), chars, out _, out _);
        });
        return text;
    }
}