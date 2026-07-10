# Dev-Log #002 — Systems That Last

*2026-07-08*

## What I Built

I spent two sessions tearing the design apart and putting it back together. The kind of work that produces zero commits but changes everything.

First pass: repo hygiene. Three `.tmp` files had snuck into git. The project files still said `lastbastioncs`. The food system had a death spiral — zero production when you ran out, which meant no recovery. Now it's Famine Mode: 25% efficiency. You can claw your way back. That's the third pillar — Fair Forever.

Second pass: an 8-part design review against the idle game genre's best. Cookie Clicker, Leaf Blower Revolution, Realm Grinder, Antimatter Dimensions — I read how they solve progression, automation, and prestige. Then I rebuilt Kero Keep's systems from those lessons.

## What Changed

The economy got an identity. Gold is progression. Scrap is combat. Food is sustainability. They're not interchangeable — each gates a different part of the keep, and you feel the difference.

The prestige formula went from `sqrt(gold)` to something that respects all three currencies plus milestones. Oil and Bones merged into Essence — one rare resource is cleaner than two. Energy replaced cooldowns — burst and pause, not endless waiting.

Archers became a ceremony. You don't buy them from a menu. You unlock a gate, pay a cost that hurts, and a named frog takes the wall. The first archer appears around 30 seconds in. A new system every 5-10 minutes after that. First prestige at 2-3 hours.

Welcome back screen, daily login bonus, and sound effects moved from "maybe someday" to MVP. If the game respects your time, it respects it from minute zero.

## What Fought Back

Scope. The original GDD had 12 systems and no sense of what to build first. The solution: split the whole project into Phase A (port the prototype, 6 sprints) and Phase B (add new features after). No deadlines — build order by dependency. Sprint 5 (Economy) can't work before Sprint 4 (Upgrades). Sprint 6 (UI) can't work before Sprint 5. The chain is clear.

## What's Coming

The upgrade system. Nine flat upgrades, one interface, a code array. Once that's done, the economy timers close the loop — resources flowing without clicking.

---

*No screenshots yet — placeholder art during development.*
