# WinYourDesktop
## A Desktop Entry file interpreter

![Screenshot](http://guitarxhero.github.io/imgs/wyd2.png)

_WinYourDesktop_ is a simple Desktop Entry file interpreter for Windows.

# Features

- Can start Terminal (cmd) sessions
- Translate support for Windows and Linux-like variables
- Translate support for ~ (User profile)
- Simple debugger
- Available in French and English

# Installing (executable)

1. Place the executable file at a permanent spot where you will remember.
2. Then make WinYourDesktop the default application to open Desktop Entry files.
3. (Optional) Add WinYourDesktop in your anti-virus trusted list.
4. (Optional) Run it once so the .NET platform caches the app.

No installers are available for the moment.

# Installing (source)

Everything has been written in C# 6.0 for the .NET 4.5.2 platform with Visual Studio 2015.

The solution consists of three projects (build order respectively):

- wyd-lib (WinYourDesktopLibrary)
  - Library
- WinYourDesktop
  - UI app
- wydcon (WinYourDesktopConsole)
  - Console app

I am using these packages:
- Costura.Fody v1.3.3
- SharpShell (Unused for now)

# FAQ
## General

- What is a Desktop Entry file?
  - Please see this [article](http://www.linuxtopia.org/online_books/linux_desktop_guides/gnome_2.14_admin_guide/menustructure-desktopentry.html).
  
## Visual Studio / Source code

- Why does MainFormHandler.cs shows up with a form icon?
  - `MainFormHandler.cs` is a partial class of `FormMain`, which is a form, thus Visual Studio thinks that it's form code.