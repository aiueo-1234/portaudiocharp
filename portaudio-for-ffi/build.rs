fn main() {
    // portaudio.hのrust用ffiコード生成
    bindgen::Builder::default()
        .header("portaudio/include/portaudio.h")
        .blocklist_item("PaHostApiTypeId|PaErrorCode|PaStreamCallbackResult")
        .generate()
        .unwrap()
        .write_to_file("src/portaudio.rs")
        .unwrap();
    // csbindgen側で一部オブジェクトのアクセシビリティ変更ができないためpublicにしたいものを分割
    bindgen::Builder::default()
        .header("portaudio/include/portaudio.h")
        .default_enum_style(bindgen::EnumVariation::Rust {
            non_exhaustive: false,
        })
        .allowlist_item("PaHostApiTypeId|PaErrorCode|PaStreamCallbackResult|paFramesPerBufferUnspecified")
        .generate()
        .unwrap()
        .write_to_file("src/portaudio_enum.rs")
        .unwrap();

    // alsa部分のrust用ffiコード生成
    bindgen::Builder::default()
        .header("portaudio/include/pa_linux_alsa.h")
        .rustified_enum("PaHostApiTypeId")
        .allowlist_function("PaAlsa_.*")
        .blocklist_item("PaHostApiTypeId")
        .generate()
        .unwrap()
        .write_to_file("src/pa_linux_alsa.rs")
        .unwrap();

    // pulseaudio部分のrust用ffiコード生成
    bindgen::Builder::default()
        .header("portaudio/include/pa_linux_pulseaudio.h")
        .allowlist_function("PaPulseAudio_.*")
        .generate()
        .unwrap()
        .write_to_file("src/pa_linux_pulseaudio.rs")
        .unwrap();

    // portaudio.hのC#用ffiコード生成
    csbindgen::Builder::default()
        .input_bindgen_file("src/portaudio.rs")
        .rust_file_header("use super::portaudio::*;")
        .csharp_entry_point_prefix("")
        .csharp_namespace("PortAudioCSharp.AutoGenerated")
        .csharp_class_name("NativeMethods")
        .csharp_dll_name("portaudio")
        .csharp_class_accessibility("internal")
        .generate_to_file(
            "src/portaudio_ffi.rs",
            "dotnet/autogen/NativeMethods.portaudio.g.cs",
        )
        .unwrap();
    // アクセシビリティを個別に設定できないのでファイルを分割
    csbindgen::Builder::default()
        .input_bindgen_file("src/portaudio_enum.rs")
        .rust_file_header("use super::portaudio::*;")
        .always_included_types(["PaErrorCode", "PaHostApiTypeId", "PaStreamCallbackResult"])
        .csharp_entry_point_prefix("")
        .csharp_namespace("PortAudioCSharp.AutoGenerated")
        .csharp_class_name("NativeConsts")
        .csharp_dll_name("portaudio")
        .csharp_class_accessibility("public")
        .csharp_generate_const_filter(|x| x.starts_with("pa"))
        .csharp_disable_emit_dll_name(true)
        .generate_to_file(
            "src/portaudio_enum_ffi.rs",
            "dotnet/autogen/NativeConsts.portaudio_enum.g.cs",
        )
        .unwrap();

    // alsa部分のC#用ffiコード生成
    csbindgen::Builder::default()
        .input_bindgen_file("src/pa_linux_alsa.rs")
        .rust_file_header("use super::pa_linux_alsa::*;")
        .csharp_entry_point_prefix("")
        .csharp_namespace("PortAudioCSharp.AutoGenerated.Linux")
        .csharp_class_name("NativeMethodsAlsa")
        .csharp_import_namespace("PortAudioCSharp.AutoGenerated")
        .csharp_dll_name("portaudio")
        .csharp_class_accessibility("internal")
        .generate_to_file(
            "src/pa_linux_alsa_ffi.rs",
            "dotnet/autogen/NativeMethods.pa_linux_alsa.g.cs",
        )
        .unwrap();

    // pulseaudioのC#用ffiコード生成
    csbindgen::Builder::default()
        .input_bindgen_file("src/pa_linux_pulseaudio.rs")
        .rust_file_header("use super::pa_linux_pulseaudio::*;")
        .csharp_entry_point_prefix("")
        .csharp_namespace("PortAudioCSharp.AutoGenerated.Linux")
        .csharp_class_name("NativeMethodsPulsAudio")
        .csharp_import_namespace("PortAudioCSharp.AutoGenerated")
        .csharp_dll_name("portaudio")
        .csharp_class_accessibility("internal")
        .generate_to_file(
            "src/pa_linux_pulseaudio_ffi.rs",
            "dotnet/autogen/NativeMethods.pa_linux_pulseaudio.g.cs",
        )
        .unwrap();
}
