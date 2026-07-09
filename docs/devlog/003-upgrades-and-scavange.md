# Dev-Log #003 — Upgrades & A Typo Called Scavange

*2026-07-09*

## What I Built

The upgrade system shipped. Twelve files, one hundred thirty-seven lines, zero warnings. Nine flat upgrades built on an `IUpgradeEffect` interface — each effect class is five to nine lines. Click damage, gold multiplier, arrow damage, arrow count, archer count, and the three resource unlocks. An `UpgradeManager` autoload builds the array, handles cost scaling, and fires a signal when anything changes.

Before that: Sprint 3 got a code review. Three issues across BaseMob, GameManager, and SaveLoad. A dead `Damage` property sat in BaseMob since the prototype. The gold multiplier was truncating before multiplying — `(int)(gold * 1.5)` instead of `CeilToInt(gold * 1.5)`, so Pocket Search level 1 did nothing visible. And `Scavange` — a typo that had crawled through five properties, save keys, and the entire load state. All fixed.

The mages decision landed too. Kero Keep's ranged units will be frog mages instead of archers. Same mechanics — projectile system, unlock gates, food upkeep — but swamp-green magic bolts instead of arrows. Visual change, no new code. The GDD gets updated after the port.

## What Fought Back

The upgrade system's architecture went through sixteen research calls and six design dimensions before a single line was written. A switch block would have been simpler but dead-ended at 5-skill migration. An interface with nine effect classes is more files but cleanly extensible — each skill in Phase B gets its own effect class with no refactor.

Also: Godot 4.7 Mono changed the `_InputEvent` signature. The parameter that was `Node` in 4.6 became `Viewport` in 4.7. Took a build failure and a cache delete to surface that one.

## What's Coming

Economy timers — the loop that makes resources flow without clicking. Food harvest ticks, scrap scavenge ticks, auto-collect upgrades. Once that's running, Sprint 6 connects everything to a UI.
