# Kero Keep

**The last fortress of Batrachia is mine to defend.**

![Status](https://img.shields.io/badge/status-playable-success) ![Godot](https://img.shields.io/badge/Godot-4-478cbf?logo=godot-engine) ![C#](https://img.shields.io/badge/C%23-12-239120?logo=csharp) ![Phase](https://img.shields.io/badge/Phase-A%20Complete-blue) ![License](https://img.shields.io/badge/license-PolyForm%20Shield-orange)

> ⚠️ **Source-available, not open-source.** You can view, learn from, and contribute to the code. Commercial use, redistribution, and selling derivatives is prohibited.

---

## What Is This?

An incremental siege defense game where armored frog warriors hold the wall against an endless horde. Click to kill, earn resources, build defenses, survive waves. No victory screen — the siege never ends.

Built the prototype in GDScript. Ported it to C# — 24 scripts across 6 sprints, zero GDScript remaining. Fully playable.

> You command Kero Keep — the last fortress standing between the kingdom of Batrachia and an endless siege. Build. Fight. Grow. Everything you earn, you earned.

- **Genre:** Incremental idle + tower defense + RPG elements
- **Setting:** Batrachia — a medieval kingdom of humanoid frogs (not comedic, think *Redwall* with frog armor)
- **Platform:** Windows, Linux
- **Design:** Earned Growth · Persistent Siege · Fair Forever
- **License:** [PolyForm Shield 1.0.0](LICENSE.md) — free for learning, paid for playing

📖 **[Game Design Document →](docs/gdd/index.md)**
📝 **[Development Log →](docs/devlog/index.md)**

---

## Design Pillars

**P1 — EARNED GROWTH**
Progress traces back to player action — mobs killed, archers commanded, resources chosen and spent. Clicking and timers are pacing mechanisms, not idle automation. The game doesn't grow without you.

**P2 — PERSISTENT SIEGE**
There is no pause. No victory screen. The siege is eternal. The world runs even while you're away — random hordes and bosses appear, the keep keeps burning. Offline persistence is a reward, not a given.

**P3 — FAIR FOREVER**
No pay-to-win. No premium currency. Money never touches game balance. The game respects your time and your wallet equally. Non-negotiable.

---

## Where I'm At

| System | Status |
|--------|:------:|
| GameManager (autoload) | ✅ Complete |
| Save & Load | ✅ Complete |
| Combat (click-to-kill + arrows) | ✅ Complete |
| Enemies (BaseMob, Skeleton, Zombie) | ✅ Complete |
| Upgrades (9-flat, IUpgradeEffect interface) | ✅ Complete |
| Game scene (economy + spawners) | ✅ Complete |
| UI (HUD, workshop menu, archers) | ✅ Complete |
| Survivors | ⬜ |
| Skills (5-skill) | ⬜ |
| Bosses | ⬜ |
| Engineering tree | ⬜ |
| Prestige | ⬜ |

**Phase A complete.** 24 .cs files, 6 sprints, fully playable. Next: Phase B — MVP features (waves, bosses, prestige).

📋 **[Full Roadmap →](docs/gdd/roadmap.md)**

---

## Tech Stack

| What | Detail |
|------|--------|
| **Engine** | Godot 4 (Mono) |
| **Language** | C# 12 (.NET 8) |
| **Architecture** | Autoloads (GameManager, SaveLoad, UpgradeManager) |
| **Save format** | JSON — `user://SaveFile.json` |
| **Namespace** | `KeroKeep` |
| **Scripts** | 24 .cs files (zero GDScript) |
| **Prototype** | [LastBastion](https://github.com/lel1guy/LastBastion) (GDScript, archived) |

```
Scripts/           ← 24 C# files
Scripts/Upgarde/   ← Upgrade system (interface + 9 effects + manager + UI)
Scenes/            ← 15 Godot scenes (all wired to C#)
Assets/            ← sprites, textures, fonts, audio
```

---

## Want the Game?

🔜 Builds coming to itch.io when Phase B is complete. This repo is the **source code only** — no pre-built binaries.

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

## License

This project is **source-available** under the [PolyForm Shield 1.0.0](LICENSE.md) license.

| You can | You cannot |
|---------|------------|
| ✅ View and study the code | ❌ Sell the game or derivatives |
| ✅ Fork for personal learning | ❌ Redistribute builds |
| ✅ Submit pull requests | ❌ Use in commercial products |
| ✅ Build and run locally | ❌ Compete with the official release |

**The game itself is paid.** The code is public so you can see how it works, learn Godot C# patterns, and contribute improvements — not so you can clone and undercut.

---

Built by [@lel1guy](https://github.com/lel1guy). Source-available. Pay for the game, not the code.

*Previously: [LastBastion](https://github.com/lel1guy/LastBastion) (GDScript) | [FootPong](https://github.com/lel1guy/FootPong) (first game)*
