# WinYourDesktop
## A Desktop Entry file interpreter

You know what I don't like on Windows?

__Windows File Shortcut (.lnk) files.__

You know what I loved when I stayed on Linux Mint?

__Desktop Entry (.desktop) files.__

_WinYourDesktop_ is a loose (not strict by standard) and simple Desktop Entry file interpreter for Windows.

# Installing (binaries)

Note:
- You need at least the .NET 4.0 Framework.

---

1. Simply put the executable file somewhere on your computer that you will remember.

2. Then make WinYourDesktop the default application to open Desktop Entry files.

# Installing (source)

You will need at least Visual Studio 2015 or the latest version of Xamarin Studio (you will need to do some tweaks in the project file, also I'm not sure if it's entirely compatible).

Please note that I'm writing C# 6.0 on .NET 4.0.

# Debugging

This solution consists of three projects

- WinYourDesktop
  - UI front-end
- WinYourDesktopConsole
  - Console front-end
- wyd-lib
  - .NET Library, Interpreter

Make sure Costura.Fody and SharpShell are installed and referenced.

Generate the wyd-lib project first, since WinYourDesktop and WinYourDesktopConsole depends on the library in order to run.

Then you can just debug right away.

Fody takes care of embedding the DLLs.

# Ideas?

Just toss them in the ticket system ("Issues")!

# FAQ

## General

- What is a Desktop Entry file?
  - Please see this [article](http://www.linuxtopia.org/online_books/linux_desktop_guides/gnome_2.14_admin_guide/menustructure-desktopentry.html).
  
## Source code

- Why does FormHandler shows up with a form icon?
  - Since FormHandler is a partial class of FormMain, it automatically detects it as being form code.

# Notes

I am using these packages:
- Costura.Fody.1.3.5.0
- SharpShell


I'm looking forward to finish this!