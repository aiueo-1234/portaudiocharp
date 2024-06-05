fn main() {
    // using bindgen, generate binding code
    bindgen::Builder::default()
        .header("portaudio/include/portaudio.h")
        .rustified_enum("PaErrorCode")
        .rustified_enum("PaHostApiTypeId")
        .generate()
        .unwrap()
        .write_to_file("src/portaudio.rs")
        .unwrap();

    bindgen::Builder::default()
        .header("portaudio/include/pa_linux_alsa.h")
        .rustified_enum("PaHostApiTypeId")
        .allowlist_function("PaAlsa_.*")
        .blocklist_item("PaHostApiTypeId")
        .generate()
        .unwrap()
        .write_to_file("src/pa_linux_alsa.rs")
        .unwrap();

    bindgen::Builder::default()
        .header("portaudio/include/pa_linux_pulseaudio.h")
        .allowlist_function("PaPulseAudio_.*")
        .generate()
        .unwrap()
        .write_to_file("src/pa_linux_pulseaudio.rs")
        .unwrap();

    // csbindgen code, generate both rust ffi and C# dll import
    csbindgen::Builder::default()
        .input_bindgen_file("src/portaudio.rs") // read from bindgen generated code
        .rust_file_header("use super::portaudio::*;") // import bindgen generated modules(struct/method)
        //.rust_method_prefix("")
        .always_included_types(["PaErrorCode"])
        .csharp_entry_point_prefix("") // adjust same signature of rust method and C# EntryPoint
        .csharp_namespace("PortAudio.Unsafe")
        .csharp_class_name("NativeMethods")
        .csharp_dll_name("libportaudio")
        .generate_to_file("src/portaudio_ffi.rs", "dotnet/NativeMethods.portaudio.g.cs")
        .unwrap();

    csbindgen::Builder::default()
        .input_bindgen_file("src/pa_linux_alsa.rs") // read from bindgen generated code
        .rust_file_header("use super::pa_linux_alsa::*;") // import bindgen generated modules(struct/method)
        //.rust_method_prefix("")
        .csharp_entry_point_prefix("") // adjust same signature of rust method and C# EntryPoint
        .csharp_namespace("PortAudio.Unsafe.Linux")
        .csharp_class_name("NativeMethodsAlsa")
        .csharp_import_namespace("PortAudio.Unsafe")
        .csharp_dll_name("libportaudio")
        .generate_to_file("src/pa_linux_alsa_ffi.rs", "dotnet/NativeMethods.pa_linux_alsa.g.cs")
        .unwrap();

    csbindgen::Builder::default()
        .input_bindgen_file("src/pa_linux_pulseaudio.rs") // read from bindgen generated code
        .rust_file_header("use super::pa_linux_pulseaudio::*;") // import bindgen generated modules(struct/method)
        //.rust_method_prefix("")
        .csharp_entry_point_prefix("") // adjust same signature of rust method and C# EntryPoint
        .csharp_namespace("PortAudio.Unsafe.Linux")
        .csharp_class_name("NativeMethodsPulsAudio")
        .csharp_import_namespace("PortAudio.Unsafe")
        .csharp_dll_name("libportaudio")
        .generate_to_file("src/pa_linux_pulseaudio_ffi.rs", "dotnet/NativeMethods.pa_linux_pulseaudio.g.cs")
        .unwrap();
}
