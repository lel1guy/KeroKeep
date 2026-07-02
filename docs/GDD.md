# LastBastion — Game Design Document

> **Status:** 🟢 Active — C# port in progress
> **Engine:** Godot 4 (Mono)
> **Language:** C#
> **Repo:** [lel1guy/LastBastionCS](https://github.com/lel1guy/LastBastionCS) (private)
> **PC path:** `D:\Game Development\Projects\lastbastioncs`
> **Prototype:** [lel1guy/LastBastion](https://github.com/lel1guy/LastBastion) — GDScript, playable alpha (archived reference)
> **Dev Log:** Dev-Log — C# port session log (in vault)
> **Last updated:** 2026-07-02
> **New systems planned:** Quests, Achievements, Bosses, Prestige

---

## 1. Vision & Pillars

### Elevator Pitch

> You are the last bastion standing between humanity and an endless siege. Build. Fight. Grow. Everything you earn, you earned.

### Why This Game Exists

The incremental/idle genre is rich with games where numbers go up — but few where the numbers *feel* real. V wanted an incremental game with visible consequence: archers you see fire, waves you feel bearing down, every upgrade earned by surviving one more round. Not bars filling in menus. Not abstract numbers ticking behind a UI. A game where survival tension and RPG influence are threaded through the core idle DNA — something that didn't exist, so he started building it.

### "X meets Y"

*Pending — comparable influences to be named when inspiration strikes.*

### The Feeling

| Moment | Feeling |
|--------|---------|
| **Growth beat** | Watching your base harden, numbers climb, survivors grow stronger — knowing *you* earned every increment through action |
| **Siege tension** | The dread before a wave. "Will we make it?" Relief when the last enemy falls. Pressure of knowing it *never* ends — and the world runs even while you're away |
| **Boss encounter** | A rare, named enemy appears. Higher stakes, bigger reward. The moment the music swells and you lock in — this one matters |
| **Prestige reset** | Letting go. Trading everything you built for a permanent edge. The quiet moment before you press the button, knowing what you lose and what you gain |

### Design Pillars

**P1 — EARNED GROWTH**
Progress isn't passive. Every number that goes up traces back to player action — mobs killed, archers commanded, resources chosen and spent. Clicking and timers are pacing mechanisms, not idle automation. What matters: the game doesn't grow without the player.

**P2 — PERSISTENT SIEGE**
There is no pause. No victory screen. The siege is eternal. Once all archers are unlocked, the simulation runs even while offline — random hordes and bosses appear, the world keeps burning. Until then, you hold the line with your own hands. When you walk away, you'll wonder if it still stands when you return. Offline persistence is a reward, not a given.

**P3 — FAIR FOREVER**
No pay-to-win. No premium currency. Money never touches game balance. If monetization ever happens, it's optional — ads for a temporary assist that helps without breaking the tension. The game respects your time and your wallet equally.

The four new planned systems — Quests, Achievements, Bosses, Prestige — all serve P1 through P3. Quests give direction to earned growth. Achievements mark meaningful milestones. Bosses intensify the siege with higher-stakes moments. Prestige deepens the meta loop without touching monetization.

---

## 2. Core Loop

### 2.1 Moment-to-Moment (~10 seconds)

The player clicks monsters to attack. Each click deals damage. Monster HP ticks down until zero, at which point the monster dies and rewards are granted.

| Element | Description |
|---------|-------------|
| **Player input** | Click on monster → deal damage |
| **Reward** | Gold, possibly scrap/food from special monsters |
| **Feel target** | Snappy, responsive, impact. Every click matters. |

**Random Boss Interruption:** Each wave has a small % chance to spawn a boss. Bosses have 5-10× normal HP and drop 5-10× gold. See §3.10.

### 2.2 Session (~10-20 minutes)

| Element | Description |
|---------|-------------|
| **Daily Quests** | 3-5 tasks per day. Reset every 24h |
| **Main Quest Chain** | Story-driven quest line with multiple bosses. Final boss unlocks prestige |
| **Achievements** | Pop during play — milestones for kills, unlocks, economy, boss kills, prestige count |

### 2.3 Meta (hours / days)

| Element | Description |
|---------|-------------|
| **Offline simulation** | Unlocks when all archers acquired. World runs while away |
| **Prestige** | Defeat the final quest boss → prestige becomes available. Player chooses to reset for permanent bonuses |

---

## 3. Systems (Summary)

### Resource Web
**Gold** (kills/waves) · **Scrap** (survivor scavenging) · **Food** (survivor farming) · **Oil** (ferment crops) · **Bones** (monster drops)

### Survivors (§3.6)
6 named NPCs with stats (Farming 1-10, Scavenging 1-10) and traits. Three risk zones for scavenging (Safe/Risky/Dead Zone). Permanent death. Food upkeep creates tension.

### Skills (§3.7)
5 skills replacing flat upgrades: Combat, Archery, Scavenging, Farming, Engineering. Level through use. Focus Overdrive (manual boost).

### Quests (§3.8)
Daily (3-5/day) + Main quest chain (5 stages with bosses) + Side quests.

### Achievements (§3.9)
7 categories: Combat, Bosses, Economy, Unlocks, Engineering, Prestige, Survivors. Permanent, persist through prestige.

### Bosses (§3.10)
Hybrid: random spawns (5-12% per wave) + quest bosses. Siege Waves (8-15% per wave) with defense gap display.

### Engineering (§3.11)
Arrow tiers (Bone→Iron→Steel→Fire). Defense constructions (Spikes→Oil Trap→Auto-Turret). Oil production via crop fermentation.

### Prestige (§3.12)
Trigger: defeat final quest boss OR wall falls. Legacy Points shop. Skill baselines carry 5% forward.

---

## 4. Content Plan (MoSCoW)

- **Must Do (MVP):** C# port of GDScript prototype (~3-5 weeks)
- **Should Do:** Survivors, Skills, Bosses, Siege Waves, Daily Quests, Achievements (~6-10 weeks)
- **Could Do:** Main quest chain, Full engineering, Prestige, Offline, Polish (~6-9 weeks)
- **Won't Do:** Multiplayer, Monetization, Mobile port, Narrative system

---

## 5. C# Conversion

7 core systems being ported (GameManager 6/10 done). 7 new systems designed for post-MVP. Architecture: port upgrade system first, transition to skill system later.

---

## 6. Risks

Top risks: C# learning curve, scope creep, core loop not being fun, burnout. See full risk matrix with 10 assessed risks.

---

## 7. Tuning Variables

25+ tunable knobs across Combat, Economy, Skills, Bosses, and Prestige. Full table with defaults and ranges.

---

> **Full GDD:** 909 lines, 8 sections. Maintained in `vault/Game Dev/LastBastion/GDD.md`.
> **Last updated:** 2026-07-02 — B/C hybrid redesign with Hermes.
> **Repo:** [lel1guy/LastBastionCS](https://github.com/lel1guy/LastBastionCS)