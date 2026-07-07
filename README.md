# Kero Keep

**The last fortress of Batrachia is mine to defend.**

![Status](https://img.shields.io/badge/status-active-brightgreen) ![Godot](https://img.shields.io/badge/Godot-4-478cbf?logo=godot-engine) ![C#](https://img.shields.io/badge/C%23-12-239120?logo=csharp) ![License](https://img.shields.io/badge/license-PolyForm%20Shield-orange)

> ⚠️ **Source-available, not open-source.** You can view, learn from, and contribute to the code. Commercial use, redistribution, and selling derivatives is prohibited. [Buy the game on itch.io →](#)

---

## What Is This?

An incremental siege defense game where armored frog warriors hold the wall against an endless horde. Click to kill, earn resources, build defenses, survive waves. No victory screen — the siege never ends.

I built the original prototype in GDScript (Godot). Now I'm porting it to C# to learn the language properly — same game, better foundation. Formerly called **LastBastion**.

> You command Kero Keep — the last fortress standing between the kingdom of Batrachia and an endless siege. Build. Fight. Grow. Everything you earn, you earned.

- **Genre:** Incremental idle + tower defense + RPG elements
- **Setting:** Batrachia — a medieval kingdom of humanoid frogs (not comedic, think *Redwall* with frog armor)
- **Platform:** Windows, Linux
- **Design:** Earned Growth · Persistent Siege · Fair Forever
- **License:** [PolyForm Shield 1.0.0](LICENSE.md) — free for learning, paid for playing

📖 **[Full Game Design Document →](https://github.com/lel1guy/KeroKeep/blob/main/docs/GDD.md)**

---

## License

This project is **source-available** under the [PolyForm Shield 1.0.0](LICENSE.md) license.

| You can | You cannot |
|---------|------------|
| ✅ View and study the code | ❌ Sell the game or derivatives |
| ✅ Fork for personal learning | ❌ Redistribute builds |
| ✅ Submit pull requests | ❌ Use in commercial products |
| ✅ Build and run locally | ❌ Compete with the official release |

**The game itself is paid.** The code is public so you can see how it works, learn Godot C# patterns, and contribute improvements — not so you can clone and undercut. If you want to use substantial portions of the code commercially, [contact me](https://github.com/lel1guy).

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
```

---

## Want the Game?

Builds will be available on **[itch.io](#)** when the game is playable. This repo is the **source code only** — no pre-built binaries.

---

## Run It (for learning)

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

Session-by-session breakdown of what I built, what broke, and how I fixed it: [Dev-Log.md](Dev-Log.md)

---

## The Prototype

The original GDScript version is at [lel1guy/LastBastion](https://github.com/lel1guy/LastBastion) — playable alpha with working combat, economy, archers, and 3 enemy types. I'm using it as a design reference while I rebuild in C#.

---

Built by [@lel1guy](https://github.com/lel1guy). Source-available. Pay for the game, not the code.

*Previously: [LastBastion](https://github.com/lel1guy/LastBastion) (GDScript) | [FootPong](https://github.com/lel1guy/FootPong) (first game)*
