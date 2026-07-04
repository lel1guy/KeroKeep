# LastBastion

Post-apocalyptic medieval fantasy idle game. C# port of the GDScript prototype.

**Engine:** Godot 4 (Mono) · **Language:** C#  
**Status:** 🟢 Active — GameManager.cs in progress (6/10 chunks)

---

## The Game

> You are the last bastion standing between humanity and an endless siege. Build. Fight. Grow. Everything you earn, you earned.

- **Genre:** Incremental idle with tower defense and RPG elements
- **Design philosophy:** B/C hybrid — named survivors with stats + skill levels, engineering tree, siege waves
- **Design pillars:** Earned Growth, Persistent Siege, Fair Forever
- **Platforms:** Windows (primary), Android (partial)

📖 **[Full Game Design Document](docs/GDD.md)** — 8 sections: vision, core loop, 12 systems (B/C hybrid), MoSCoW content plan, MVP/cut list, risk assessment, tuning variables.

## Prototype

The original GDScript version is archived at [lel1guy/LastBastion](https://github.com/lel1guy/LastBastion) — playable alpha, used as reference for the C# port.

## Structure

```
Scripts/    ← C# source (GameManager.cs, ...)
Scenes/     ← Godot scenes (Game, Main, Enemies, Upgrades, ...)
Assets/     ← sprites, textures, audio
docs/       ← GDD.md (full design document)
```

## Conversion Progress

### Current Sprint

| System | Status |
|--------|:---:|
| GameManager | 🟡 6/10 chunks |
| Save & Load | ⬜ |
| Combat (arrows) | ⬜ |
| Enemies | ⬜ |
| Upgrades (9-flat) | ⬜ |
| UI | ⬜ |
| Economy (timers) | ⬜ |

### Post-MVP

| System | Status |
|--------|:---:|
| Survivors | ⬜ |
| Skills (5-skill) | ⬜ |
| Quests | ⬜ |
| Achievements | ⬜ |
| Bosses | ⬜ |
| Engineering | ⬜ |
| Prestige | ⬜ |

---

Built by [@lel1guy](https://github.com/lel1guy) from Quarteira, Algarve, Portugal.
