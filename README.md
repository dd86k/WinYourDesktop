# WinYourDesktop
## A Desktop Entry file interpreter

You know what I don't like on Windows?

__Windows File Shortcut (.lnk) files.__

You know what I loved when I stayed on Linux Mint?

__Desktop Entry (.desktop) files.__

_WinYourDesktop_ is a loose (not strict by standard) and simple Desktop Entry file interpreter for Windows.

# What is going on?

| Handler | Progress |
| --- | --- |
| IconHandler (hard) | Working - Paused |
| FilenameHandler (hard) | Not started |
| TooltipHandler (hard) | Not started |
| LogHandler | Working - Paused |

# Installing (binaries)

Note:

- You need at least the .NET 4.0 Framework.

---

1. Simply put the executable file somewhere on your computer that you will remember.

2. Then make WinYourDesktop the default application to open Desktop Entry files.

# Installing (source)

You will need at least Visual Studio 2015 or a recent version of Xamarin Studio (you will need to do some tweaks in the project file).

Please note that I'm writing C# 6.0 for .NET 4.0.

# Debugging

Generate the wyd-lib project first, since WinYourDesktop and WinYourDesktopConsole depends on the library in order to run.

Fody takes care of embedding these DLLs.

# Ideas?

Just toss them in the ticket system ("Issues")!

# FAQ

- What is a Desktop Entry file?
  - Please see this [article](http://www.linuxtopia.org/online_books/linux_desktop_guides/gnome_2.14_admin_guide/menustructure-desktopentry.html).

# Notes

- I am using
  - Costura.Fody.1.3.5.0
  - SharpShell


I'm looking forward to finish this!