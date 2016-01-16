# WinYourDesktop
## A Desktop Entry file interpreter

You know what I don't like on Windows?

__Windows File Shortcut (.lnk) files.__

You know what I loved when I stayed on Linux Mint?

__Desktop Entry (.desktop) files.__

_WinYourDesktop_ is a simple Desktop Entry file interpreter for Windows.

# Installing (file)

1. Place the executable file where you will remember.

2. Then make WinYourDesktop the default application to open Desktop Entry files.

No installers are available for the moment.

# Installing (source)

You will need at least Visual Studio 2015 or the latest version of Xamarin Studio (you will need to do some tweaks in the project file, also I'm not sure if it's entirely compatible with the extensions).

Please note that I'm writing C# 6.0 for .NET 4.5.2, although this is .NET 4.5 compatible.

This solution consists of three projects (also, build order):

- wyd-lib
  - .NET Library, Interpreter
- WinYourDesktop
  - UI front-end
- WinYourDesktopConsole
  - Console front-end

Costura.Fody takes care of embedding the library into the UI and console executables.

# FAQ

## General

- What is a Desktop Entry file?
  - Please see this [article](http://www.linuxtopia.org/online_books/linux_desktop_guides/gnome_2.14_admin_guide/menustructure-desktopentry.html).
  
## Visual Studio

- Why does FormHandler shows up with a form icon?
  - `FormHandler` is a partial class of `FormMain`, which is a form.
  
## Source code

# Notes

I am using these packages:
- Costura.Fody.1.3.5.0
- SharpShell

I'm looking forward to finish this!