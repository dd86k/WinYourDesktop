# WinYourDesktop, Desktop file interpreter

![Screenshot](http://dd86k.github.io/imgs/wyd2.png)

**WinYourDesktop** is a small and fast Desktop file interpreter for Windows.

## What is a Desktop file?

A Desktop file is an menu entry file for a vast majority of desktop environments for Linux distros.

This [article](http://www.linuxtopia.org/online_books/linux_desktop_guides/gnome_2.14_admin_guide/menustructure-desktopentry.html) explains it further.

## Features

- Can start Terminal Type sessions
- Support for Windows and UNIX-like variables
  - Supports most Windows auto-generated variables
  - Supports most UNIX-like variables
    - e.g. `$HOME` _will_ return `C:\Users\DD`
- Support for ~ (UNIX-like user profile path)
- Simple debugger
- Available in French and English

## Installing (executable)

1. Place the executable file at a permanent spot where you will remember.
2. Then make WinYourDesktop the default application to open Desktop Entry files.
3. (Optional) Add WinYourDesktop in your anti-virus trusted list.
4. (Optional) Run it once so the .NET platform caches the app.

No installers are available for the moment.

## Installing (source)

Everything has been written in C# 6.0 for the .NET 4.6.1 platform with Visual Studio 2015.

The solution consists of three projects (build order respectively):

- wyd-lib (WinYourDesktopLibrary)
  - Library
- WinYourDesktop
  - UI app
- wydcon (WinYourDesktopConsole)
  - Console app

I am using these packages:
- Costura.Fody v1.3.3
- SharpShell (Future use)