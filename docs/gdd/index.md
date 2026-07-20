# Kero Keep — Game Design Document

> **Status:** 🟢 Phase A Complete — 24 C# scripts across 6 sprints. Playable. Phase B (new MVP features) next.
> **Engine:** Godot 4 (Mono) · **Language:** C#
> **Last updated:** 2026-07-19

This GDD is split into focused pages. Start here or jump to what interests you.

---

## Table of Contents

| Page | What's Inside |
|------|---------------|
| [**Concept**](concept.md) | Design pillars, the feeling, genre, audience, design philosophy |
| [**World**](world.md) | Setting, tone, the keep, mages, enemies, survivors of Batrachia |
| [**Gameplay**](gameplay.md) | Core loop, systems overview, progression, prestige, economy |
| [**Art Direction**](art-direction.md) | Visual style, inspirations, palette, key moments |
| [**Roadmap**](roadmap.md) | What's built, what's next, MoSCoW priorities |

---

## Quick Summary

**Kero Keep** is an incremental siege defense game. Armored frog warriors hold the last wall of the kingdom of Batrachia against an endless horde. Click to kill. Earn resources. Build defenses. Survive waves. The siege never ends.

| Property | Value |
|----------|-------|
| **Genre** | Incremental idle + tower defense + RPG elements |
| **Platform** | Windows, Linux |
| **Monetization** | None. P3 — Fair Forever. |
| **License** | [PolyForm Shield 1.0.0](../LICENSE.md) |
| **Repo** | [github.com/lel1guy/KeroKeep](https://github.com/lel1guy/KeroKeep) |

---

## Design Pillars

**P1 — EARNED GROWTH**
Progress traces back to player action — mobs killed, mages commanded, resources chosen and spent. Clicking and timers are pacing mechanisms, not idle automation. The game doesn't grow without you.

**P2 — PERSISTENT SIEGE**
There is no pause. No victory screen. The siege is eternal. Once all mages are unlocked, the simulation runs even while you're offline — random hordes and bosses appear, the world keeps burning. Offline persistence is a reward, not a given.

**P3 — FAIR FOREVER**
No pay-to-win. No premium currency. The game respects your time and your wallet equally. Non-negotiable.
