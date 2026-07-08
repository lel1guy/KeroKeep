# Dev-Log #001 — Foundations

*2026-07-07*

## What I Built

The first week of Kero Keep was a full-port sprint. The original prototype (`LastBastion`) was built in GDScript. This version is C# — same game, better foundation, and my first real project in the language.

**Done so far:**
- GameManager autoload ported from `.gd` → `.cs` — signals, resources, unlock flags, combat stats
- Save & Load system — JSON to `user://SaveFile.json`, auto-save every 60 seconds, save on close
- BaseMob.cs — the enemy base class with HP, speed, damage, and death handling
- Project renamed from LastBastion → Kero Keep (and with it, the world of Batrachia was born)

**What clicked:** C# properties with `{ get; private set; }` are genuinely cleaner than GDScript's `var` + manual setter pattern. The language feels right for game architecture.

## What Fought Back

The Godot C# ecosystem assumes you already know C#. It doesn't teach you. I had to learn: `partial class` (Godot's code generation requirement), `[Signal] delegate` syntax, `EmitSignal(SignalName.X, value)`, float literal suffixes (`0.25f`), PascalCase conventions. Every line was a lookup. Every lookup was a lesson.

Also: the original GDScript prototype had 9 flat upgrades. After a deep design review, I decided to port them as-is for MVP, then transition to a 5-skill system post-MVP — skills that level through use, not purchase. Better alignment with the "Earned Growth" pillar. But it means I'm building a system I already plan to replace. The tension between "ship fast" and "build right" is real.

## What's Coming

Arrow projectiles. Economy timers. The first archer on the wall. Once you can click, earn, spend, and see an archer fire — the core loop is alive.

---

*No screenshots yet — art is placeholder during development. Media coming once the keep is visible.*
