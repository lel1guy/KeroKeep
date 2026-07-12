# Dev-Log #004 — Interfaces, Upgrades, and Sprint Momentum

*2026-07-12*

## What I Built

Sprint 3 wrapped cleanly — BaseMob, Skeleton, and Arrow are all in C# and compiling. Then Sprint 4 delivered the upgrade system: all nine upgrades from the prototype, wired through an `IUpgradeEffect` interface instead of a switch block.

The architecture came from real research. Sixteen API calls across idle game codebases confirmed the industry standard: hybrid tracking with a global cost calculator and per-upgrade effect classes. For fewer than 50 upgrades in Godot C#, a code array with interface dispatch is the right call. Twelve files, ~137 lines total, and it compiles without warnings.

Sprint 5 started immediately — the Game scene script that ties economy, combat, and spawning together. Manual scavenge and farm buttons work (15s and 4s cooldowns with progress bars). The auto-resource timer was already ported in Sprint 1, so this sprint ports mob spawning and mage spawning from the prototype's Game.gd.

## What Fought Back

A typo that survived three sprints. `Scavange` instead of `Scavenge` — in properties, save keys, and LoadState. Three files across GameManager and SaveLoad. Found during the Sprint 3 code review and fixed everywhere. The kind of bug that would've been silent data corruption if left until saves were real.

Also: Godot 4.7's `_InputEvent` signature changed from `Node→Viewport, long→int` compared to earlier 4.x. And a stale `.godot/` cache kept regenerating the old `lastbastioncs.sln` even after renaming — fixed by deleting the cache and rebuilding.

## What's Coming

Sprint 5 finishes with mob spawning, mage spawning, and room visibility toggles. Then Sprint 6 — the UI and final integration — where all the ported systems connect into a playable C# build.

---

*Kero Keep — an incremental siege-defense game in Godot 4 / C#*
