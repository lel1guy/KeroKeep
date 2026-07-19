# Kero Keep

**The last fortress of Batrachia. Defend it.**

![Status](https://img.shields.io/badge/status-playable-success) ![Godot](https://img.shields.io/badge/Godot-4-478cbf?logo=godot-engine) ![C#](https://img.shields.io/badge/C%23-12-239120?logo=csharp) ![Phase](https://img.shields.io/badge/Phase-A%20Complete-blue) ![License](https://img.shields.io/badge/license-PolyForm%20Shield-orange)

> ⚠️ **Source-available, not open-source.** You can view, learn from, and contribute to the code. Commercial use, redistribution, and selling derivatives is prohibited.

---

## What Is This?

An incremental siege defense game where armored frog warriors hold the wall against an endless horde. Click to kill, earn resources, build defenses, survive waves. No victory screen — the siege never ends.

Built the prototype in GDScript. Ported it to C# — 24 scripts across 6 sprints, zero GDScript remaining. Fully playable. Phase B (new MVP features) up next.

> You command Kero Keep — the last fortress standing between the kingdom of Batrachia and an endless siege. Build. Fight. Grow. Everything you earn, you earned.

- **Genre:** Incremental idle + tower defense + RPG elements
- **Setting:** Batrachia — a medieval kingdom of humanoid frogs (not comedic, think *Redwall* with frog armor)
- **Platform:** Windows, Linux
- **Engine:** Godot 4 (Mono) · 24 C# scripts
- **Design:** Earned Growth · Persistent Siege · Fair Forever
- **License:** [PolyForm Shield 1.0.0](LICENSE.md) — free for learning, paid for playing

📖 **[Game Design Document →](docs/gdd/index.md)**
📝 **[Development Log →](docs/devlog/index.md)**

---

## Design Pillars

**P1 — EARNED GROWTH**
Progress traces back to player action — mobs killed, mages commanded, resources chosen and spent. Clicking and timers are pacing mechanisms, not idle automation. The game doesn't grow without you.

**P2 — PERSISTENT SIEGE**
There is no pause. No victory screen. The siege is eternal. Once all mages are unlocked, the simulation runs even while you're offline — random hordes and bosses appear, the world keeps burning.

**P3 — FAIR FOREVER**
No pay-to-win. No premium currency. The game respects your time and your wallet equally. Non-negotiable.

---

## What's Playable Right Now

- ✅ Click combat — damage numbers, gold drops, death animations
- ✅ Resource economy — manual scavenge/farm + auto-production timers
- ✅ 9 upgrades — click damage, magic bolt damage, bolt count, gold multiplier, and more
- ✅ 3 monster types — Skeletons, Zombies (7 variants), and spawner infrastructure
- ✅ Save/Load — JSON autoload, auto-save every 60s, load on startup
- ✅ UI — resource HUD, upgrade workshop cards, scene switching
- ✅ Full C# port — 24 scripts, zero GDScript

## What's Next (Phase B)

- [ ] Wave counter + personal record
- [ ] Mage recruitment ceremony + unlock gates
- [ ] Milestone popups
- [ ] Boss hunting (every 10 waves)
- [ ] Chronicle prestige loop
- [ ] Welcome back screen
- [ ] Daily login bonus
- [ ] Sound effects

---

## Architecture

| Layer | Technology |
|-------|-----------|
| **Engine** | Godot 4 (Mono) |
| **Language** | C# 12 |
| **Autoloads** | `GameManager`, `SaveLoad`, `UpgradeManager` (registered in project.godot) |
| **Patterns** | Signal-driven UI updates, `IUpgradeEffect` interface for upgrades, `partial class` for Godot source generators |
| **Save format** | JSON → `user://SaveGame.json` |
| **Project structure** | `Scripts/` (all C#), `Scenes/` (`.tscn`), `Assets/` (sprites, sounds) |
