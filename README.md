# Accessiano

Accessiano is a Unity prototype for an accessible piano experience driven by eye tracking. The project combines a simple one-octave piano layout, note samples, and Tobii eye-tracking assets so a player can focus a key with their gaze and trigger the note with the keyboard.

## Project status

This repository contains an early prototype:

- Unity project name: `Accessiano`
- Unity editor version: `2018.3.0f2`
- Main playable scene: `Accessiano/Assets/_Scenes/Piano.unity`
- Custom gameplay script: `Accessiano/Assets/Scripts/PianoKeyController.cs`

The prototype currently plays a key's audio when the `Eye` object is inside that key's trigger and the player presses `Space`.

## Requirements

- Unity `2018.3.0f2`
- A Windows setup if you want to use the bundled Tobii native DLLs
- A Tobii-compatible eye-tracking setup if you want to drive the experience with gaze input

## Getting started

1. Clone the repository.
2. Open the Unity project located in `Accessiano/`.
3. Open the scene `Assets/_Scenes/Piano.unity`.
4. Press Play in the Unity Editor.

## Controls

- **Gaze / Eye object overlap**: select a piano key
- **Space**: play the selected key

## Project structure

```text
Accessiano/
├── README.md
└── Accessiano/
    ├── Assets/
    │   ├── _Scenes/Piano.unity
    │   ├── Scripts/PianoKeyController.cs
    │   ├── Material/            # note audio clips and materials
    │   └── Tobii/               # Tobii SDK assets and plugins
    ├── Packages/
    └── ProjectSettings/
```

## Notes

- The scene uses note samples from `C1` through `C2`, including sharps, to create the piano range.
- A demo video is included at `Accessiano/VID-20190430-WA0028.mp4`.
- `ProjectSettings/EditorBuildSettings.asset` currently points to `Assets/Scenes/SampleScene.unity`; if you plan to build the prototype, add `Assets/_Scenes/Piano.unity` to Build Settings first.

## Development

The repository includes generated Unity and Visual Studio artifacts, so opening the project in Unity may update tracked files. If you only want to explore the prototype, using the Unity Editor is the expected workflow.

The generated C# solution targets `.NET Framework 4.7.1`, which is normally handled by the Unity/Visual Studio toolchain on Windows.
