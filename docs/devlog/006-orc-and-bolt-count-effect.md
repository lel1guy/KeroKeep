# Dev-Log #006 — Orc Enemy & BoltCountEffect

*2026-07-20*

## What Got Built

Two new scripts pushed to flesh out Phase A before Phase B begins.

`Orc.cs` — a new enemy class inheriting from `BaseMob`. Tuned as the mid-game tank: 5 HP (toughest yet), Speed 40 (slower, gives player breathing room), GoldDrop 10 (bigger reward for a harder kill). The full armor mechanic — reducing click damage while magic bolts pierce through — is planned for Phase B. This is the base class that the armor system will build on.

`BoltCountEffect.cs` — a new upgrade effect implementing the `IUpgradeEffect` interface. Each purchase bumps bolt count by 1, capped at 3 via `Mathf.Min`. Named `BoltCountEffect` instead of `ArrowCountEffect` to reflect the mage thematic — the defenders fire magic bolts, not arrows.

## Architecture Note

The `IUpgradeEffect` interface continues to prove its worth. Adding a new effect is a 6-line class — implement `ApplyEffect()`, done. No switch blocks to update, no existing code to touch. The interface is the migration hook for the eventual 5-skill system in post-MVP.

## What's Coming

Phase B starts with the wave counter and record system (`WaveManager.cs`). After that: mage recruitment ceremonies, milestone popups, boss hunting at wave 10/20/30, and the Chronicle prestige loop. Build order by dependency, not deadlines.
