# Magick.NET-Sandbox
Sandbox for testing docker builds with Magick.NET

# Problem
Error when trying to compress images. Works locally but not when deployed to Stage / Production.
Output is the following when trying to create an image:
```
System.TypeInitializationException: The type initializer for 'NativeMagickSettings' threw an exception.
 ---> System.DllNotFoundException: Unable to load shared library 'Magick.Native-Q16-x64.dll' or one of its dependencies.
 Error loading shared library libresolv.so.2: No such file or directory (needed by /app/Magick.Native-Q16-x64.dll.so)
```
The library `libresolv.so.2` is missing.

# Solution
Adding `libc6-compat` to the Alpine system provided the missing `libresolv.so.2` library that Magick.NET needed. This package emulates the environment expected by applications developed for glibc-based systems, allowing them to run on musl libc-based Alpine without modification.

## libc6-compat
The whole packages page for [official alpine linux](https://www.alpinelinux.org/about/) seems to be offline at the date of writing (11th May 2024), but google had it indexed. The package size is **1.65kB**.
