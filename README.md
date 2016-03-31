# WinYourDesktop
## A Desktop Entry file interpreter

![Screenshot](http://didi.wcantin.ca/p/wyd1.png)

_WinYourDesktop_ is a simple Desktop Entry file interpreter for Windows.

# Installing (file)

1. Place the executable file where you will remember.

2. Then make WinYourDesktop the default application to open Desktop Entry files.

No installers are available for the moment.

# Installing (source)

You will need at least Visual Studio 2015. I'm not sure Xamarin Studio supports VS's plugins.

Written in C# 6.0 for .NET 4.5.2.

This solution consists of three projects (also, build order):

- wyd-lib
  - Interpreter library
- WinYourDesktop
  - UI front-end
- WinYourDesktopConsole
  - Console front-end

I am using these packages:
- Costura.Fody v1.3.3
- SharpShell (Unused for now)

# FAQ

## General

- What is a Desktop Entry file?
  - Please see this [article](http://www.linuxtopia.org/online_books/linux_desktop_guides/gnome_2.14_admin_guide/menustructure-desktopentry.html).
  
## Visual Studio

- Why does FormHandler shows up with a form icon?
  - `FormHandler` is a partial class of `FormMain`, which is a form, thus VS thinks that it's UI code.
  
## Source code

Nothing here yet.

# Notes

Nothing here yet.

I'm looking forward to finish this!