# WinYourDesktop
## A Desktop Entry file interpreter

You know what I don't like on Windows?

Shortcut (.lnk) files.

You know what I loved when I stayed on Linux Mint?

Desktop Entry (.desktop) files.

_WinYourDesktop_ is a loose and simple Desktop Entry file interpreter for Windows.

# What is working so far?

- Absolute paths
- Relative paths (Soon!)

- Type
  - Application
    - Executable
    - Executable with arguments
    - Terminal (cmd) applications
    - Normal cmd commands
  - Directory
    - Path
  - Link
    - URL

# Installing

Note:

- You need at least the .NET 4.0 Framework.

---

1. Simply put the executable file somewhere on your computer that you will remember.

2. Then make WinYourDesktop the default application to open Desktop Entry files.

# Installing (source)

You will need at least Visual Studio 2015 or a recent version of Xamarin Studio (with some tweaks in the project file).

Please note that I'm writing C# 6.0 on .NET 4.0.

---

Also you might want to turn off the signed assembly option. To do that, you need to:

1. Double click on the __Properties__ item in the Solution Explorer (or right click WinYourDesktop, Properties). 

2. Go down to __Signature__.

3. Uncheck __Sign ClickOnce manifests__ and __Sign Assembly__ items.

# FAQ

- What is a Desktop Entry file?
  - Please see this [article](http://www.linuxtopia.org/online_books/linux_desktop_guides/gnome_2.14_admin_guide/menustructure-desktopentry.html).

I'm looking forward to finish it!