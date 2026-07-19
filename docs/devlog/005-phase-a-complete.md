# Dev-Log #005 — Phase A Complete

*2026-07-15*

## What Got Built

Phase A is done. Twenty-four C# scripts across six sprints. The entire GDScript prototype — GameManager, SaveLoad, combat, upgrades, economy, UI — now runs in Godot 4 Mono with zero GDScript remaining.

The final sprint was a push to wire everything together. Five new scripts landed in one session: `ResourcesHud.cs` to show Gold, Scrap, and Food on screen; `Archer.cs` to get mages detecting enemies and firing magic bolts on a timer; `Main.cs` to handle scene switching between the game and upgrade workshop; `UpgradeMenu.cs` as the workshop container; and `UpgradeItem.cs` as the individual upgrade cards that talk to the upgrade system.

The architecture clicked into place through signal flow. `Game.cs` emits `UpgradeMenuOpen`. `Main.cs` subscribes and toggles visibility. `UpgradeItem.cs` delegates buy logic to `UpgradeManager`. Resources update through `GoldChanged`/`ScrapChanged`/`FoodChanged` signals wired to the HUD. Clean separation of concerns — each script knows about its own job and nothing else.

## What Fought Back

Nine bugs in the final wiring session. The type that comes from connecting real scenes to code for the first time.

A `Node2D` can't be cast to `ColorRect` — the room visibility code assumed the wrong node type. Renamed `MobSpwanTimer` to `MobSpawnTimer` (a typo that survived from the GDScript prototype). Array-guided `PickRandom()` calls crashed because the export arrays were empty in the Inspector. The workshop button did nothing because nobody wired up its handler. A whole upgrade card was missing from the scene. And stale GDScript connection metadata in `.tscn` files had to be ripped out — C# subscribes programmatically, not through editor signals.

The pattern was consistent: code written correctly, scenes not yet configured to match. Once every export array was populated, every button subscribed, and every stale connection scrubbed, the game ran.

## What's Coming

Phase B starts now. Eight new systems that weren't in the prototype: wave counter with personal records, mage recruitment ceremonies, milestone popups, boss hunting at every 10th wave, the Chronicle prestige loop, welcome back screen, daily login bonuses, and sound throughout. Build order by dependency, not deadlines. The siege never ends.
