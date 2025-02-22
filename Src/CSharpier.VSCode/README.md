# CSharpier Formatter for Visual Studio Code

[CSharpier](https://github.com/belav/csharpier) is an opinionated code formatter for c#.
It uses Roslyn to parse your code and re-prints it using its own rules.
The printing process was ported from [prettier](https://prettier.io) but has evolved over time.

## Installation

Install through VS Code extensions. Search for `CSharpier`

Can also be installed in VS Code: Launch VS Code Quick Open (Ctrl+P), paste the following command, and press enter.

```
ext install csharpier.csharpier-vscode
```

## Default Formatter
To ensure that CSharpier is used to format c# files, be sure to set it as the default formatter.

```json
  "[csharp]": {
    "editor.defaultFormatter": "csharpier.csharpier-vscode"
  }
```

## Usage

### Keyboard Shortcuts

Visual Studio Code provides [default keyboard shortcuts](https://code.visualstudio.com/docs/getstarted/keybindings#_keyboard-shortcuts-reference) for code formatting. You can learn about these for each platform in the [VS Code documentation](https://code.visualstudio.com/docs/getstarted/keybindings#_keyboard-shortcuts-reference).

If you don't like the defaults, you can rebind `editor.action.formatDocument` and `editor.action.formatSelection` in the keyboard shortcuts menu of vscode.

### Format On Save

Respects `editor.formatOnSave` setting.

Found in the settings at Text Editor | Formatting | Format on Save

You can turn on format-on-save on a per-language basis by scoping the setting:

```json
// Set the default
"editor.formatOnSave": false,
// Enable per-language
"[csharp]": {
    "editor.formatOnSave": true
}
```

### Devcontainers

CSharpier supports DevContainers if it is installed as a local dotnet tool.
```bash
# if no .config/dotnet-tools.json file exists
dotnet new tool-manifest

# add csharpier to manifest
dotnet tool install csharpier

# rebuild container image
```

## Limitations

Format Selection is not supported.

Only `"editor.formatOnSaveMode" : "file"` is supported. If using other modes, you can set `file` by scoping the setting:
```json
"editor.formatOnSave": true,
"editor.formatOnSaveMode": "modifications"
"[csharp]": {
    "editor.formatOnSaveMode": "file"
}
```
