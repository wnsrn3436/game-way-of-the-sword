# Way of the Sword

An action game where you slash apples, bananas, ghosts, and rocks coming from both sides to collect points. The swordsman standing in the middle swings toward the side you click, and the game ends as soon as anything touches him. It runs on a small engine that carries the object and event structure of GameMaker over to VB.NET classes. It was made as a school assignment.

<p>
  <img src="docs/screenshots/screenshot-1.png" width="480" alt="Game screen">
</p>


## How to play

The Releases download contains the executable and the background music `BGM.mp3`. Keep the two in the same folder and run the executable. .NET Framework 4.5 and Windows Media Player are required.

Pick a difficulty and press "시작하기" (start). Enemies appear at the left or right edge of the screen at a random speed and pass through to the other side. Clicking the game screen with the left mouse button makes the swordsman face the clicked side and swing his sword, and during the swing one enemy touched by the blade disappears and the Score goes up by 1. When an enemy touches the swordsman's body, the game ends and the music stops, and a difficulty can be picked again to start over.

| Difficulty | Enemy spawn interval |
|---|---|
| 쉬움 (easy) | 2 seconds |
| 보통 (normal) | 1 second |
| 어려움 (hard) | 0.5 seconds |


## How it works

**A GameMaker style object structure is built from classes.** `GmObject` keeps the instances in an array of `ArrayList`s, one per depth, and provides `InstanceCreate` and `InstanceDestroy`. Every game object inherits `InstanceBase`, and the base class runs two timers per instance: one moves the position by speed and direction every 17 ms and then calls `StepEvent`, and the other advances the animation frame at an interval set by `ImageSpeed` and calls `AnimationEndEvent` at the last frame. The swordsman `ObjCharacter` and the enemy `ObjMonster` override the events below to define their own behavior.

```vb
Public Overridable Sub StepEvent()
End Sub

Public Overridable Sub AnimationEndEvent()
End Sub

Public Overridable Sub MouseGlobalPressedEvent(e As MouseEventArgs)
End Sub
```

**Drawing is collected in one buffer and put on screen at once.** Every 17 ms, the same background picture is drawn twice side by side, the Score is written, and all instances are drawn onto a buffer bitmap in depth order, after which the finished buffer is copied to the screen. When the swordsman faces left, his picture is cloned and mirrored with `RotateFlip` before drawing.


## Files

| Path | Content |
|---|---|
| `source/WayOfTheSword.sln` | Visual Studio 2013 solution |
| `source/WayOfTheSword/GmObject.vb` | Instance management, drawing, swordsman and enemy classes |
| `source/WayOfTheSword/frmMain.vb` | Start, difficulty, enemy spawning, background music |
| `source/WayOfTheSword/frmMain.Designer.vb`, `frmMain.resx` | Form design and sprite image lists |
| `source/WayOfTheSword/Resources/bgr.png` | Background |
| `docs/screenshots/` | Screenshots |
| Releases | Executable and background music |


## License

CC BY-NC-ND 4.0. Unmodified copies may be shared for noncommercial purposes with attribution. Modified versions and commercial use are not allowed. Bundled libraries, graphics, sounds, and maps made by other people keep their own rights. See [LICENSE](LICENSE).
