# Cross-Platform Instant Calculator Desktop App

This software is created as proof of concept on how to write Cross-platform desktop app using .NET Framework.
This project is intended to be used as tutorial material, not for general use.
It may contains bug in here and there, but it should be acceptable to work on any machine.

## Overview

This software function is intended to replace conventional calculator, where user can directly enter mathematical expression freely in a text box.
The math evaluation is produced by using a Javascript interpreter called [Jint](https://github.com/sebastienros/jint).

![Instant Calculator Windows Preview](https://raw.githubusercontent.com/junian/instant-calculator/gh-pages/img/instant-calculator-preview-01.png)

The source code is tagged and grouped by functionality where `v0.0.0` is the first commit of the project.

## v0.0.1 - Create Multi-platform UI using Eto.Forms

The first part of this project displays how to create UI with single codebase that can target multiple platforms: Windows, macOS, and GTK-based Linux Desktop.
It also displays how to work with MVVM pattern.

## v0.0.2. Add Unit Testing

This part of project shows on how to create unit testing projects to assure every changes made by contributors doesn't break the software.

## v0.0.3. Merge Windows App Binaries

When developing software targeting to Windows, some dependencies might produce a lot of System.*.dll, especially when you're using .NET Standard library.
This might be problematic to some people, for example when creating an installer file.
In this part of the code, it's shown on how to merge some binaries into one exe file using [Costura.Fody](https://github.com/Fody/Costura).

## v0.0.4. Create Windows Installer

This part shows on how to create msi installer for Windows.
