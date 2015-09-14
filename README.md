# WinYourDesktop
## A Desktop Entry file interpreter

You know what I don't like on Windows?

Windows File Shortcut (.lnk) files.

You know what I loved when I stayed on Linux Mint?

Desktop Entry (.desktop) files.

__WinYourDesktop__ is a loose (not strict by standard) and simple Desktop Entry file interpreter for Windows.

# What is going on?

| General | Progress |
| --- | --- |
| Absolute paths | Done |
| Relative paths | Testing |
| System paths | Assumed done |
| UI App | Working |

---

| Application type | Progress |
| --- | --- |
| Exec | Working |
| TryExec | Working |

- Executable
- Executable + arguments
- Terminal applications (CLI)
- Terminal applications (CLI) + arguments
- Batch (Hopefully soon!)
- Batch scripts (Untested)

---

| Directory type | Progress |
| --- | --- |
| Path | Done |

---

| Link type | Progress |
| --- | --- |
| URL | Done |

---

| Handler | Progress |
| --- | --- |
| IconHandler (hard) | Working - Paused |
| FilenameHandler (hard) | Not started |
| TooltipHandler (hard) | Not started |
| LogHandler | Working |

# Installing

Note:

- You need at least the .NET 4.0 Framework.

---

1. Simply put the executable file somewhere on your computer that you will remember.

2. Then make WinYourDesktop the default application to open Desktop Entry files.

# Installing (source)

You will need at least Visual Studio 2015 or a recent version of Xamarin Studio (you will likely need to do some tweaks in the project file).

Please note that I'm writing C# 6.0 for .NET 4.0.

---

Also you _might_ want to turn off the signed assembly option. To do that, you need to:

1. Double click on the __Properties__ item in the Solution Explorer (or right click WinYourDesktop, Properties). 

2. Go down to __Signature__.

3. Uncheck __Sign ClickOnce manifests__ and __Sign Assembly__ items.

# Ideas?

Just toss them in the ticket system ("Issues")!

# FAQ

- What is a Desktop Entry file?
  - Please see this [article](http://www.linuxtopia.org/online_books/linux_desktop_guides/gnome_2.14_admin_guide/menustructure-desktopentry.html).

I'm looking forward to finish it!