# Roadmap

> Last updated: 2026-07-21

## Phase A — Port GDScript Prototype to C# ✅ COMPLETE

| Sprint | System | Status |
|:---:|--------|:---:|
| 1 | GameManager + SaveLoad (autoloads, signals, resource methods) | ✅ |
| 2 | Combat (BaseMob, Arrow, Skeleton) | ✅ |
| 3 | Code review + fixes (dead code, cast bug, typos) | ✅ |
| 4 | Upgrades (IUpgradeEffect, 10 effect classes, UpgradeManager) | ✅ |
| 5 | Game.cs (economy buttons, room visibility, Zombie, spawners) | ✅ |
| 6 | UI + Integration (ResourcesHud, Archer, Main, UpgradeMenu, UpgradeItem) | ✅ |
| + | Orc enemy + BoltCountEffect | ✅ |

**Result:** 26 C# scripts. Zero GDScript remaining. Fully playable — click, kill, earn, upgrade loop complete.

## Phase B — New MVP Features ⬜ In Progress

| # | Feature | Est. | Depends On |
|---|---------|------|------------|
| B1 | Wave counter + record (WaveManager.cs) | 2.5d | Phase A complete |
| B2 | Mage ceremony + unlock gates | 3d | Phase A complete |
| B3 | Milestone popups | 1d | GameManager signals |
| B4 | Boss hunting (3 mini-bosses at waves 10/20/30) | 2d | B1 |
| B5 | Chronicle prestige (CP calc, 5-upgrade shop, wall-fall trigger) | 2d | B1 |
| B6 | Welcome back screen (offline summary) | 1d | B1 |
| B7 | Daily login bonus (7-day streak) | 1d | B5 |
| B8 | Sound effects (mages, monsters, UI, ambient) | 5d | Phase A complete |

**Phase B target:** ~18 days

## Post-MVP — Depth & Polish

| # | Feature | Est. | Depends On |
|---|---------|------|------------|
| S1 | Survivor system (6 named, stats, leveling) | 5d | Economy |
| S2 | 5-skill system (replacing 9 upgrades) | 5d | Survivors |
| S3 | Quest system (3 slots, 4 types) | 4d | Bosses |
| S4 | Boss system (random + quest, full) | 4d | B4 |
| S5 | Engineering tree (T1-T2) | 5d | Skills, Essence |
| S6 | Chronicle expanded (narrative, Valor Marks, survivor persistence) | 5d | B5 |
| S7 | Challenge modifiers (risk/reward) | 3d | Waves, Bosses |
| S8 | Visual base evolution (wall states, building visuals) | 4d | Core UI |

## Long-term Vision

| # | Feature | Est. |
|---|---------|------|
| C1 | Achievement system (~38 achievements) | 3d |
| C2 | Engineering T3-T4 | 4d |
| C3 | Mage tier system (Acolyte → Channeler → Oracle) | 3d |
| C4 | Music & ambient soundtrack | 5d |
| C5 | Demon monsters | 3d |
| C6 | Animated UI feedback | 4d |

## Anti-Cut List

These are non-negotiable — the game doesn't ship without them:

| Feature | Why |
|---------|-----|
| P3 — Fair Forever | Core pillar. No pay-to-win. |
| Save system | Players must not lose progress. |
| Wave/siege loop | The game IS the siege. |
