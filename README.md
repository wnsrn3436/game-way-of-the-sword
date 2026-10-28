# Way of the Sword

[한국어](README.ko.md)

An action game where you slash apples, bananas, ghosts, and rocks coming from both sides to collect points. The swordsman standing in the middle swings toward the side you click, and the game ends as soon as anything touches him. It runs on a small engine that ports GameMaker's object and event structure to VB.NET classes. I made it for a school assignment.

<p>
  <img src="docs/screenshots/screenshot-1.png" width="480" alt="Game screen">
</p>


## How to play

The archive downloaded from Releases contains the executable and the background music `BGM.mp3`. Keep the two in the same folder and run the executable. It needs .NET Framework 4.5 and Windows Media Player.

Pick a difficulty and press "시작하기" (start). Enemies appear at the left or right edge of the screen at a random speed and pass through to the other side. Left-clicking the game screen turns the swordsman toward the clicked side and he swings his sword. During the swing, one enemy touched by the blade disappears and the Score goes up by 1. When an enemy touches the swordsman's body, the game ends and the music stops. You can then pick a difficulty again to start over.

| Difficulty | Enemy spawn interval |
|---|---|
| 쉬움 (easy) | 2 seconds |
| 보통 (normal) | 1 second |
| 어려움 (hard) | 0.5 seconds |


## How it works

**A GameMaker-style object structure is built from classes.** `GmObject` keeps the instances in an array of `ArrayList`s, one per depth, and provides `InstanceCreate` and `InstanceDestroy`. Every game object inherits `InstanceBase`, and this base class runs two timers per instance. One updates the position from speed and direction every 17 ms and then calls `StepEvent`. The other advances the animation frame at an interval set by `ImageSpeed` and calls `AnimationEndEvent` on the last frame. The swordsman `ObjCharacter` and the enemy `ObjMonster` override the events below to define their own behavior.

```vb
Public Overridable Sub StepEvent()
End Sub

Public Overridable Sub AnimationEndEvent()
End Sub

Public Overridable Sub MouseGlobalPressedEvent(e As MouseEventArgs)
End Sub
```

**Everything is drawn to one buffer and put on screen at once.** Every 17 ms, the game draws the same background image twice side by side, writes the Score, and draws all instances onto a buffer bitmap in depth order. The finished buffer is then copied to the screen. When the swordsman faces left, his image is cloned and flipped horizontally with `RotateFlip` before it is drawn.


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

CC BY-NC-ND 4.0. Unmodified copies may be shared for noncommercial purposes with attribution. Distributing modified versions and commercial use are not allowed. Bundled libraries, graphics, sounds, and maps made by other people keep their own rights. See [LICENSE](LICENSE).
