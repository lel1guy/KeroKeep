# Concept

> "You command Kero Keep — the last fortress standing between the kingdom of Batrachia and an endless siege. Build. Fight. Grow. Everything you earn, you earned."

## What Is This?

Kero Keep is an incremental siege defense game where armored frog warriors hold the wall against an endless horde. There is no victory screen — only the next wave, the next upgrade, the next wall that needs to hold.

The game blends idle mechanics with tower defense and RPG elements. You click to kill monsters, earn resources, recruit frog mages to fire from the wall, upgrade your keep, and survive. When the wall falls, you prestige — coming back stronger with permanent bonuses.

Built in Godot 4 (Mono) with C#. 24 scripts across 6 sprints. Fully playable.

## Why This Game

Most incremental games feel like spreadsheets — numbers go up, but the world doesn't react. Kero Keep makes progress *visible*. Mages you see on the wall. Waves you feel bearing down. Every upgrade traces back to something you did, not a timer.

The frog identity gives the game visual distinction in a crowded genre — armored warriors of a dying kingdom, not generic humans. The stakes are real: your survivors can starve, your walls can fall, and the siege never ends.

## The Feeling

| Moment | Feeling |
|--------|---------|
| **Growth beat** | Watching your base harden, numbers climb, survivors grow stronger — knowing *you* earned every increment through action |
| **Siege tension** | The dread before a wave. "Will we make it?" Relief when the last enemy falls. Pressure of knowing it *never* ends |
| **Boss encounter** | A named threat appears. Music shifts. The screen darkens. This one matters — beating it means real progression, losing it means real setback |
| **Prestige reset** | The wall has held through everything. Time to begin again — stronger, wiser, with scars that show. A bittersweet goodbye to the survivors who got you here |

## Design Pillars

**P1 — EARNED GROWTH**
Progress traces back to player action — mobs killed, mages commanded, resources chosen and spent. Clicking and timers are pacing mechanisms, not idle automation. The game doesn't grow without you.

**P2 — PERSISTENT SIEGE**
There is no pause. No victory screen. The siege is eternal. Once all mages are unlocked, the simulation runs even while you're offline — random hordes and bosses appear, the world keeps burning. Offline persistence is a reward, not a given.

**P3 — FAIR FOREVER**
No pay-to-win. No premium currency. Money never touches game balance. If monetization ever happens, it's optional — ads for a temporary assist. The game respects your time and your wallet equally. Non-negotiable.

## B/C Hybrid Design

Kero Keep uses a hybrid design approach:

| Aspect | Approach | What It Means |
|--------|----------|---------------|
| **Survivors** | Option B | Named individuals with stats, personality, and attachment. 6 max (3 farmers, 3 scavengers). |
| **Skills** | Option C | 5 skills replace 9 flat upgrades. Depth over breadth. Skill levels gate new mechanics. |
| **Engineering** | Option C | Tech tree unlocked through skill levels. Recipes persist through prestige. |
| **Siege waves** | Option C | Percentage-based difficulty. Unpredictable = tense. No fixed wave schedules. |

## Genre & Audience

- **Primary:** Incremental/idle game players who want more than a spreadsheet
- **Secondary:** Tower defense fans who enjoy persistent, endless modes
- **Tone:** Grounded fantasy with charm — *Redwall* grit with an amphibian skin

## Comparable Titles

The game draws mechanical inspiration from Cookie Clicker (exponential scaling), Realm Grinder (prestige depth), and Leaf Blower Revolution (visible automation). The frog identity and siege loop distinguish it from anything else in the genre.
