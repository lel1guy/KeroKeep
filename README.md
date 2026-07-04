---

## What I've Built

| System | Status |
|--------|:------:|
| GameManager (autoload) | ✅ Complete |
| Save & Load | 🟡 In progress |
| Combat (arrows) | ⬜ |
| Enemies | ⬜ |
| Upgrades (9-flat) | ⬜ |
| UI | ⬜ |
| Economy (timers) | ⬜ |
| Survivors | ⬜ |
| Skills (5-skill) | ⬜ |
| Bosses | ⬜ |
| Engineering tree | ⬜ |
| Prestige | ⬜ |

**MVP target:** 7 core systems, ~3 weeks. **Full game:** all 12 systems, ~15 weeks. Solo dev, one system at a time.

---

## Tech Stack

| What | Detail |
|------|--------|
| **Engine** | Godot 4 (Mono) |
| **Language** | C# 12 (.NET 8) |
| **Architecture** | Autoloads (GameManager, Save&Load) |
| **Save format** | JSON — `user://SaveFile.json` |
| **Namespace** | `KeroKeep` |
| **Prototype** | [LastBastion](https://github.com/lel1guy/LastBastion) (GDScript, archived) |

```
Scripts/    ← C# source (GameManager.cs, ...)
Scenes/     ← Godot scenes
Assets/     ← sprites, textures, audio
docs/       ← GDD.md (full design document)
```

---

## Run It

```bash
# Clone
git clone https://github.com/lel1guy/KeroKeep.git
cd KeroKeep

# Open in Godot 4 Mono
godot --editor .

# Or run headless
godot --headless
```

You need **Godot 4 with Mono/.NET support** and **.NET 8 SDK**.

---

## Dev Log

Session-by-session breakdown of what I built, what broke, and how I fixed it: [Dev-Log.md](docs/Dev-Log.md)

---

## The Prototype

The original GDScript version is at [lel1guy/LastBastion](https://github.com/lel1guy/LastBastion) — playable alpha with working combat, economy, archers, and 3 enemy types. I'm using it as a design reference while I rebuild in C#.

---

Built by [@lel1guy](https://github.com/lel1guy). Open source, no pay-to-win, forever.

*Previously: [LastBastion](https://github.com/lel1guy/LastBastion) (GDScript) | [FootPong](https://github.com/lel1guy/FootPong) (first game)*