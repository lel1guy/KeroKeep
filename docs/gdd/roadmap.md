# Roadmap

> Phases only — no dates. Solo developer. Systems unlock in order.

## Legend

| Symbol | Meaning |
|:------:|---------|
| ✅ | Complete |
| 🟡 | In Progress |
| ⬜ | Planned |

---

## Phase A — Port Prototype to C#

*Port every system that already works in the GDScript prototype. Game plays identically to prototype when done.*

| Sprint | System | Status |
|:------:|--------|:------:|
| 1 | GameManager + SaveLoad | ✅ |
| 2 | Combat (BaseMob, Arrow, Skeleton) | ✅ |
| 3 | Code review & fixes | ✅ |
| 4 | Upgrades (9-flat, IUpgradeEffect) | ✅ |
| 5 | Economy + Game scene (scavenge/farm buttons, mob spawner, mage spawner) | 🟡 |
| 6 | UI + Integration | ⬜ |

## Phase B — New MVP Features

*Systems that make it a real game, not just a prototype.*

| System | Dependencies | Status |
|--------|-------------|:------:|
| Wave counter + record | Phase A | ⬜ |
| Mage ceremony + unlock gates | Phase A | ⬜ |
| Milestone popups | GameManager signals | ⬜ |
| Boss hunting (3 mini-bosses) | Wave system | ⬜ |
| Chronicle prestige | Wave system | ⬜ |
| Welcome back screen | GameManager, WaveManager | ⬜ |
| Daily login bonus | GameManager, SaveLoad | ⬜ |
| Sound effects | Phase A | ⬜ |

## Post-MVP

*Depth, polish, and replayability.*

| System | Status |
|--------|:------:|
| Survivors (6 named NPCs) | ⬜ |
| Skill system (5 skills) | ⬜ |
| Quest system | ⬜ |
| Achievements | ⬜ |
| Full boss system | ⬜ |
| Engineering tree | ⬜ |
| Expanded prestige + Valor Marks | ⬜ |
| Visual base evolution | ⬜ |
| Art pass (replace placeholders) | ⬜ |
| Music & soundtrack | ⬜ |
| Platform builds (Windows, Linux) | ⬜ |
| itch.io release | ⬜ |
