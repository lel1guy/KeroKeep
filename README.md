# Kero Keep

**The last fortress of Batrachia is mine to defend.**

![Status](https://img.shields.io/badge/status-active-brightgreen) ![Godot](https://img.shields.io/badge/Godot-4-478cbf?logo=godot-engine) ![C#](https://img.shields.io/badge/C%23-12-239120?logo=csharp) ![License](https://img.shields.io/badge/license-MIT-blue)

---

## What Is This?

An incremental siege defense game where armored frog warriors hold the wall against an endless horde. Click to kill, earn resources, build defenses, survive waves. No victory screen — the siege never ends.

I built the original prototype in GDScript (Godot). Now I'm porting it to C# to learn the language properly — same game, better foundation. Formerly called **LastBastion**.

> You command Kero Keep — the last fortress standing between the kingdom of Batrachia and an endless siege. Build. Fight. Grow. Everything you earn, you earned.

- **Genre:** Incremental idle + tower defense + RPG elements
- **Setting:** Batrachia — a medieval kingdom of humanoid frogs (not comedic, think *Redwall* with frog armor)
- **Platform:** Windows, Linux
- **Design:** Earned Growth · Persistent Siege · Fair Forever

📖 **[Full Game Design Document →](docs/GDD.md)**

---

## Where I'm At

| System | Status |
|--------|:------:|
| GameManager (autoload) | ✅ Complete |
| Save & Load | ✅ Complete |
| Combat (arrows) | 🟡 BaseMob.cs done, Arrow.cs next |
| Enemies | 🟡 BaseMob.cs done |
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