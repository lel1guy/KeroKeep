# Dev-Log #007 — The Bugs That Waited Until Reload

*2026-07-22*

## What Got Fixed

Two bugs that survived every playtest session — because they only surfaced after saving, closing, and reloading the game.

**Upgrade levels reset to zero on reload.** The SaveLoad system faithfully saved every property from `GameManager.cs` — gold, scrap, food, mage count — but never touched `UpgradeManager._upgrades[i].CurrentLevel`. On reload, `BuildUpgrades()` created fresh instances with `CurrentLevel = 0`. The effects persisted because modified GameManager properties were saved and restored, but the level counters were gone. Even worse, rebuying level-0 upgrades triggered first-purchase bonuses again — double-dipping.

The fix touched four files. `SaveLoad.cs` now saves a `upgradeLevels` array and calls `_upgradeManager.LoadState()`. `UpgradeManager.cs` gained a `GetUpgrades()` accessor and a `LoadState(Dictionary)` method. `UpgradeItem.cs` reads `CurrentLevel` from the manager in `_Ready()` instead of assuming zero. And the autoload registration order in `project.godot` was reordered to guarantee `UpgradeManager` initializes before `SaveLoad` runs its load.

**Mages vanished from the wall after reload.** `GameManager.LoadState()` set `MageCount` directly — no signal emission. Meanwhile `Game._Ready()` subscribed to the `MageCountChanged` signal after the autoload had already finished loading. The signal fired with nobody listening, and the wall stayed empty.

## What Fought Back

The real insight wasn't either bug individually — it was the Load State / Signal Timing Problem they shared. Godot runs autoload `_Ready()` methods before any scene `_Ready()`. If an autoload emits signals during load, the scene nodes haven't subscribed yet. State that needs to spawn scene objects cannot rely on signals during initialization.

The pattern that works: combine both approaches. Signal-driven for runtime events (buying a mage mid-game), direct state read for initialization (spawning existing mages on load). `SpawnExistingMages()` iterates `MageCount` directly in `Game._Ready()`, while the existing `MageCountChanged` handler covers everything that happens after.

## Architecture Pattern: Signal + Direct Read

| Pattern | Works for | Fails for |
|---------|-----------|-----------|
| Signal-driven | Runtime purchases | Load/reload |
| Direct read | Load/reload | Runtime (would duplicate) |
| Both combined | All cases | Nothing |

This isn't a Godot quirk — it's the same pattern as loading a web page: the server sends HTML, then JavaScript hydrates it. The initial state comes from the payload, not from the event system.

## What's Coming

Phase A is truly complete now — save/load works, mages persist, upgrades remember their levels. Phase B starts with the wave counter and record system. The build order stays by dependency, not deadline.
