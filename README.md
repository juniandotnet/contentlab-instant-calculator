# Cross-Platform Instant Calculator Desktop App

**This project is modified for tutorial with topic .NET Desktop App CI/CD using Azure Pipelines and GitHub. The original code can be obtained [here](https://github.com/junian/instant-calculator).**

This software is created as proof of concept on how to write Cross-platform desktop app using .NET Framework.
This project is intended to be used as tutorial material, not for general use.
It may contains bug in here and there, but it should be acceptable to work on any machine.

## About

![Instant Calculator Windows Preview](https://raw.githubusercontent.com/junian/instant-calculator/gh-pages/img/instant-calculator-preview-01.png)

This software function is intended to replace conventional calculator, where user can directly enter mathematical expression freely in a text box.
The math evaluation is produced by using a Javascript interpreter called [Jint](https://github.com/sebastienros/jint).

This source code contains 1 Solution with 4 projects.

- **InstantCalculator**: This is library project, contains logic and shared UI code.
- **InstantCalculator.Tests**: This is unit testing project. The purpose is to create tests for written functions in **InstantCalculator** library project.
- **InstantCalculator.Wpf**: This is Windows executable project. This project references the library and display the UI.
- **InstantCalculator.Setup**: This project produces msi installer for Windows.
