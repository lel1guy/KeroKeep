# LastBastion

Post-apocalyptic medieval fantasy idle game. Manage a crumbling stronghold, recruit archers, scavenge resources, and hold back endless hordes.

**Engine:** Godot 4 (Mono) · **Language:** C#  
**Status:** 🟢 Active — C# port in progress

---

## The Game

> You are the last bastion standing between humanity and an endless siege. Build. Fight. Grow. Everything you earn, you earned.

- **Genre:** Incremental idle with tower defense and RPG elements
- **Platforms:** Windows (primary), Android (partial)
- **Design pillars:** Earned Growth, Persistent Siege, Fair Forever

📖 **[Full Game Design Document](docs/GDD.md)** — vision, pillars, core loop, all 5 systems, content plan, and C# conversion tracking.

## Screenshots

> ⚠️ TODO: Add gameplay GIFs or screenshots once the C# port is playable.

## Prototype

The original GDScript version is archived at [lel1guy/LastBastion](https://github.com/lel1guy/LastBastion) — playable alpha, used as reference for the C# port. All systems documented in the GDD were extracted from its live code.

## Structure

```
Scripts/    ← C# source (GameManager.cs, ...)
Scenes/     ← Godot scenes (Game, Main, Enemies, Upgrades, ...)
Assets/     ← sprites, textures, audio
docs/       ← GDD.md
```

## Conversion Progress

| System | Status |
|--------|:---:|
| GameManager | 🟡 6/10 chunks |
| Save & Load | ⬜ |
| Combat (arrows) | ⬜ |
| Enemies | ⬜ |
| Survivors | ⬜ |
| Upgrades | ⬜ |
| UI | ⬜ |
| Economy (timers) | ⬜ |

---

Built by [@lel1guy](https://github.com/lel1guy) from Quarteira, Algarve, Portugal.
