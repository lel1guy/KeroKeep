# LastBastion — Game Design Document

> **Status:** 🟢 Active — C# port in progress
> **Engine:** Godot 4 (Mono)
> **Language:** C#
> **Repo:** [lel1guy/LastBastionCS](https://github.com/lel1guy/LastBastionCS)
> **Prototype:** [lel1guy/LastBastion](https://github.com/lel1guy/LastBastion) — GDScript, playable alpha (archived)
> **Last updated:** 2026-07-02

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

### Design Pillars

**P1 — EARNED GROWTH**
Progress isn't passive. Every number that goes up traces back to player action — mobs killed, archers commanded, resources chosen and spent. Clicking and timers are pacing mechanisms, not idle automation. What matters: the game doesn't grow without the player.

**P2 — PERSISTENT SIEGE**
There is no pause. No victory screen. The siege is eternal. Once all archers are unlocked, the simulation runs even while offline — random hordes and bosses appear, the world keeps burning. Until then, you hold the line with your own hands. When you walk away, you'll wonder if it still stands when you return. Offline persistence is a reward, not a given.

**P3 — FAIR FOREVER**
No pay-to-win. No premium currency. Money never touches game balance. If monetization ever happens, it's optional — ads for a temporary assist that helps without breaking the tension. The game respects your time and your wallet equally.

### Revision History

| Date | Change | Reason |
|------|--------|--------|
| 2026-06-30 | Section 1 drafted | Initial vision conversation with Hermes |
| 2026-06-30 | P2 renamed "Persistent Siege" + offline confirmed | V specified the world runs while offline |
| 2026-06-30 | Section 2 Core Loop drafted | Initial loop breakdown |
| 2026-06-30 | Section 3: Systems 3.1-3.5 documented from live code | Audited GitHub repo |
| 2026-06-30 | Section 4 Content Plan drafted | 9 prioritized features |
| 2026-07-02 | C# conversion started | LastBastionCS repo created, GameManager.cs in progress |
| 2026-07-02 | GDScript version archived as prototype | Single GDD — design lives in C# now |

### ⚠️ Code-vs-Design Gaps

These are features in the design not yet implemented:

| Feature | Design Says | Code Says |
|---------|-------------|-----------|
| Workers/Survivors | Separate entities (Farmers + Scavengers) purchased with Gold+Food | Auto collection is timer-based, unlocked by upgrades — no worker entities |
| Food Upkeep | Archers and workers cost ongoing Food | Not yet implemented |
| P2 Offline Persistence | World runs offline after all archers unlocked | Save exists but offline simulation not yet active |
| Archer Tiers | Same archer upgrades through tiers | Only 1 archer type, upgrades are flat stat increases |

---

## 2. Core Loop

LastBastion's gameplay operates on three nested timescales. Each feeds into the next.

### 2.1 Moment-to-Moment (~10 seconds)

The player clicks monsters to attack. Each click deals damage. Monster HP ticks down until it reaches zero, at which point the monster dies and rewards are granted. This is the atomic action — the heartbeat of the game.

| Element | Description |
|---------|-------------|
| **Player input** | Click on monster → deal damage |
| **System response** | HP decreases, damage number pops, monster death animation at 0 HP |
| **Reward** | Resources (to be defined), possibly XP or currency |
| **Feel target** | Snappy, responsive, impact. Every click matters. |

### 2.2 Session (~10-20 minutes)

Between waves or during lulls, the player manages resources: spending earned currency to unlock new defenses and upgrade existing ones. The deciding loop — "do I unlock the next archer tower, or upgrade the one I have?"

| Element | Description |
|---------|-------------|
| **Unlocking** | Spend resources to unlock new archers / defenses |
| **Upgrading** | Spend resources to strengthen existing archers (damage, speed, range) |
| **Monster scaling** | Over time, monsters grow stronger. New monster types appear |
| **Tension** | Resources are finite. Every choice delays another. |

### 2.3 Meta (hours / days)

The return loop. Once all archers are unlocked, the offline simulation kicks in — the siege continues while the player is away. Returning means checking: "did we survive? how much stronger are we? what did I come back to?"

| Element | Description |
|---------|-------------|
| **Offline simulation** | Unlocks when all archers acquired. World runs while away |
| **Random events** | Hordes and bosses can appear unpredictably |
| **Progression check** | Has the wall held? Are new upgrades available? |

### Loop Diagram

```
[Click to kill] ──→ [Earn resources] ──→ [Unlock/Upgrade archers]
       ↑                                          │
       │                                          ↓
       └──────── [Monsters get stronger] ←───────┘
                              │
                              ↓
                   [Offline simulation]
                   (after all archers unlocked)
```

### Open Questions

- ~~What resources exist?~~ → **Gold, Scrap, Food**
- How many archer types / tiers?
- What triggers new monster types — time, waves survived, archer count?
- What happens if the player dies / the wall falls while offline?

### Resources

| Resource | Earned How | Spent On |
|----------|-----------|----------|
| **Gold** | Kills, waves, base income | Unlocks, upgrades (general) |
| **Scrap** | Salvage, workers/survivors auto-farm | Unlock archers, damage upgrades, arrow count (max 3) |
| **Food** | Workers/survivors auto-farm | Unlock archers, **upkeep** for archers and workers |

#### Upkeep & Failure

Every archer and worker has an ongoing **food upkeep cost**. Food is consumed continuously or per tick.

**If food hits zero:**
1. Archers stop firing — defenses go silent
2. Workers stop producing — Scrap and Food income drops to zero
3. This creates a **death spiral**: no food → no workers → no food production → no recovery without manual intervention

This is the primary tension valve in the economy. Managing food isn't optional — it's survival.

#### Workers / Survivors

Workers are required for automatic resource farming. They generate Food and Scrap over time. Workers themselves cost Food to maintain (upkeep).

| Detail | Answer |
|--------|--------|
| **Acquisition** | Purchased with Gold + Food |
| **Types** | Two separate roles: **Farmers** (produce Food), **Scavengers** (produce Scrap) |
| **Recovery** | Manual clicking can produce enough Food to restart — it's not game over, but it's a punishing setback |

---

## 3. Systems

### 3.1 Archer System

| Property | Value |
|----------|-------|
| **Archer types** | 1 type (single archer unit) |
| **Max archers** | 4 total |
| **Progression** | Tiers — the same archer upgrades and grows stronger |
| **Arrow count** | Max 3 per archer (upgraded with Scrap) |

Each archer has:
- **Unlock cost** — Gold + Scrap + Food
- **Upkeep cost** — ongoing Food per tick to keep firing
- **Damage** — per-arrow damage (upgraded with Scrap)
- **Arrows** — count upgraded with Scrap, max 3 per archer
- **Tiers** — same archer upgrades through tiers, growing stronger at each level
- **Range / speed / other stats** — *to be defined*

### 3.2 Monster System

*(Documented from GDScript prototype — [GameManager.gd](https://github.com/lel1guy/LastBastion/blob/main/Scripts/GameManager.gd), [Mob.gd](https://github.com/lel1guy/LastBastion/blob/main/Scripts/Mob.gd))*

| Monster | Stage | Status |
|---------|-------|--------|
| **Skeleton** | 0 | Implemented (3 variants) |
| **Zombie** | 1 | Implemented (7 variants) |
| **Orc** | 2 | Planned |
| **Demon** | 3 | Planned |

**Behavior:** All monsters descend from `BaseMob` (CharacterBody2D). They move straight down (`velocity.y = speed`). On click, they take damage equal to `GameManager.click_damage`. At 0 HP, they play a death animation and award gold = `gold_amount × GameManager.gold_drop_multiplier`.

**Progression:** `GameManager.unlocked_stage` tracks which monster tier is active. New monster types unlock as the player advances.

### 3.3 Upgrade System

*(Documented from GDScript prototype — [upgrade_item.gd](https://github.com/lel1guy/LastBastion/blob/main/Scripts/upgrade_item.gd))*

Nine upgrades implemented. Each has base costs (Gold/Scrap/Food) and exponential cost growth (×1.5 per level).

| # | Upgrade ID | Effect |
|---|-----------|--------|
| 1 | **Pocket Search** | Gold drop multiplier +1.0 (first level), +0.5 after |
| 2 | **Scavengers** | Unlocks auto-scrap. Subsequent levels: auto_scrap_amount ×1.25 |
| 3 | **Farmers** | Unlocks auto-food. Subsequent levels: auto_food_amount ×1.25 |
| 4 | **Strength** | Click damage +1 per level |
| 5 | **Storeroom Unlocked** | Enables scrap collection. Subsequent: scrap_per_scavange ×1.25 |
| 6 | **Farm Unlocked** | Enables food collection. Subsequent: food_per_harvest ×1.25 |
| 7 | **Gear** | Arrow damage +0.25 per level |
| 8 | **Arrow Count** | Arrow count +1 (max 3) |
| 9 | **Archers** | Archer count +1 (max 4), spawns new archer |

**Cost formula:** `base_cost × 1.5^current_level` (per resource type, per upgrade — each has independent base costs).

**Affordability check:** `gold >= cost_gold AND scrap >= cost_scrap AND food >= cost_food` — all three must be met simultaneously.

### 3.4 Economy

*(Documented from GDScript prototype — [GameManager.gd](https://github.com/lel1guy/LastBastion/blob/main/Scripts/GameManager.gd))*

#### Manual Collection

| Action | Time | Yield | Unlock Requirement |
|--------|------|-------|-------------------|
| **Scavenge** | 15s cooldown | 10 Scrap | Storeroom unlocked |
| **Farm** | 4s cooldown | 5 Food | Farm unlocked |

#### Auto Collection (Upgrade-gated)

| Source | Interval | Amount | Unlocked By |
|--------|----------|--------|-------------|
| **Auto Scrap** | 1s tick | 1 Scrap (base) | "Scavengers" upgrade |
| **Auto Food** | 1s tick | 1 Food (base) | "Farmers" upgrade |

Both auto amounts scale with upgrade level (×1.25 per level after first).

#### Combat Income

| Source | Base Value | Scaling |
|--------|-----------|---------|
| **Monster gold** | Per-monster `gold_amount` | × `gold_drop_multiplier` |
| **Click damage** | 1 (base) | +1 per "Strength" level |
| **Arrow damage** | 0.25 (base) | +0.25 per "Gear" level |

#### Upkeep

*Not yet implemented.* Food upkeep for archers and workers exists in the design but is not yet active.

### 3.5 Save System

*(Documented from GDScript prototype)*

A `Save&Load.gd` autoload persists game state to `user://SaveFile.json` (17 serialized fields). Saves trigger on window close, app pause, focus out, and **auto-save every 60 seconds**. Game loads on startup.

---

## 4. Content Plan

Prioritized features still to be built, ordered by dependency and impact.

### Must Do (Core Completion)

| # | Feature | What's Missing | Depends On |
|---|---------|---------------|------------|
| 1 | **Workers/Survivors as entities** | Replace timer-based auto-collection with actual purchasable workers (Farmers + Scavengers). Purchase cost: Gold + Food. | — |
| 2 | **Food upkeep system** | Archers and workers consume Food per tick. Food at zero → everything stops → death spiral. | Workers (#1) |
| 3 | **Offline persistence** | Simulation runs while player is away (unlocked after all 4 archers). Replay time on return. | Upkeep (#2) |
| 4 | **Orc + Demon monsters** | New mob scenes for stages 2-3. Different HP/speed/gold values per type. | — |

### Should Do (Polish & Depth)

| # | Feature | What's Missing | Depends On |
|---|---------|---------------|------------|
| 5 | **Archer tier system** | Each archer progresses through named tiers (Scout → Marksman → Ranger, TBD). | — |
| 6 | **Random hordes & bosses** | Occasional "horde wave" with higher spawn rate, rare boss spawn with bonus rewards. | Orcs + Demons (#4) |
| 7 | **Sound effects & music** | Currently silent. Placeholder SFX (clicks, death, bow fire) would transform game feel. | — |
| 8 | **Animated UI feedback** | Damage numbers, resource popups, wave alerts — visual juice for actions. | — |
| 9 | **Prestige / reset system** | Classic idle mechanic. Reset with permanent bonuses. Design after core loop is complete. | All Must Do items |

### Future Note

> **Monetization (optional ad boosts):** Temporary buffs via opt-in ads — helps without breaking balance. No premium currency, no pay-to-win. Not a priority. Evaluate after core loop is complete and fun.

---

## 5. C# Conversion Plan

Porting the GDScript prototype to C#, system by system.

| # | System | GDScript Source | C# Target | Status |
|---|--------|----------------|-----------|:---:|
| 1 | GameManager | `GameManager.gd` (autoload) | `Scripts/GameManager.cs` | 🟡 6/10 chunks |
| 2 | Save & Load | `Save&Load.gd` | TBD | ⬜ |
| 3 | Combat (arrows) | `Scripts/Arrow.gd` | TBD | ⬜ |
| 4 | Enemies | `Scripts/Enemy*.gd` | TBD | ⬜ |
| 5 | Survivors | `Scripts/Survivor*.gd` | TBD | ⬜ |
| 6 | Upgrades | `Scripts/Upgrade*.gd` | TBD | ⬜ |
| 7 | UI | Scene scripts | TBD | ⬜ |
| 8 | Economy (timers) | In GameManager | TBD | ⬜ |

### C# Architecture Decisions

| Decision | Rationale |
|----------|-----------|
| `namespace LastBastion;` | File-scoped namespace |
| `partial class` | Required by Godot for source generators |
| `[Signal] delegate` | Godot C# signal pattern (replaces GDScript `signal`) |
| `{ get; private set; }` | Resource properties — read-only externally |
| `f` suffix on floats | C# requires explicit float literal (`0.25f` not `0.25`) |
| `EmitSignal(SignalName.X, value)` | Type-safe signal emission |

---

## GDScript Prototype

The original GDScript version at [lel1guy/LastBastion](https://github.com/lel1guy/LastBastion) (playable alpha) is **archived**. All systems documented above were extracted from its live code. The C# version inherits the design 1:1 — this GDD is the single source of truth for both.

---

*Single GDD — unified 2026-07-02. Game design + C# conversion in one document.*
