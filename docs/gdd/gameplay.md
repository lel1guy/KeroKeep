# Gameplay

## Core Loop

Kero Keep operates on three nested timescales:

### Moment-to-Moment (~10 seconds)

| Element | Description |
|---------|-------------|
| **Player input** | Click on monster → deal damage |
| **System response** | HP decreases, damage number pops, death animation at 0 HP |
| **Reward** | Gold, occasionally Essence (rare drops) |
| **Feel** | Snappy, responsive, impact. Every click matters. |

### Session (~10-20 minutes)

| Element | Description |
|---------|-------------|
| **Unlocking** | Spend resources to recruit mages / build defenses |
| **Upgrading** | Level up skills, upgrade survivors, progress engineering tree |
| **Monster scaling** | Over time, monsters grow stronger. New types appear. Bosses can spawn. |
| **Tension** | Resources are finite. Every choice delays another. |

### Meta (hours / days)

| Element | Description |
|---------|-------------|
| **Offline simulation** | Available from the start at 25% rate. Upgrades to 50-75% when all mages acquired. World runs while you're away. |
| **Random events** | Hordes and bosses can appear unpredictably. |
| **Progression check** | Has the wall held? Are new upgrades available? |

### Loop Diagram

```
[Click to kill] ──→ [Earn resources] ──→ [Unlock/Upgrade/Skill]
       ↑                                          │
       │                                          ↓
       └──────── [Monsters get stronger] ←───────┘
        ┌─────────────────────────────────────────┘
        ↓
[Quests] ──→ [Bosses] ──→ [Prestige] ──→ [Stronger restart]
```

## Systems Overview

### Mage System

The keep's ranged defenders. One type with tier progression. Max 4 mages, each firing up to 3 magic bolts. Each mage has an unlock cost and ongoing food upkeep.

Recruitment is a ceremony — each mage gets a name from a pool of Batrachian names and a short intro line. The moment you unlock your fourth mage should feel earned.

### Monster System

Three enemy types implemented (Skeleton, Zombie, Orc) with a fourth (Demon) planned for post-MVP. Each has different HP, speed, and mechanical behaviors — not just bigger numbers.

| Monster | Stage | HP | Speed | Role |
|---------|-------|----|-------|------|
| **Skeleton** | 0 | Low | Fast | Basic — no special mechanics |
| **Zombie** | 1 | Medium | Slow | Tanky — 7 variants, takes more clicks |
| **Orc** | 2 | High | Medium | Armored — base class ready, full armor mechanic planned for Phase B |
| **Demon** | 3 | — | — | Planned — teleports, fire AoE |

Wave layout: 4 lanes running top-to-bottom. At the bottom: the wall and mage positions. Below the wall: storeroom, farm, dormitory, and upgrade buildings.

### Economy

Three primary resources visible in the HUD at all times:

| Resource | Source | Spent On |
|----------|--------|----------|
| **Gold** | Combat kills | Unlocks, general upgrades, prestige |
| **Scrap** | Manual scavenging + auto-scrap | Mage recruitment, combat upgrades, wall repairs |
| **Food** | Manual farming + auto-food | Upkeep for mages, survivors, workers |

Essence is a rare fourth resource (boss kills, quest rewards) that appears in its own UI context — the engineering menu and crafting system.

Manual actions (scavenge, farm) use an Energy pool instead of cooldowns. Burst 5 actions, let it recharge. Upgrades increase max energy and regen rate.

Combat income scales exponentially — ×1.5 per level for click damage, ×1.4 for magic bolt damage, ×1.3 for gold multiplier. Numbers multiply, not add.

### Upgrade System

Ten flat upgrades currently implemented, covering click damage, magic bolt damage, bolt capacity, gold multiplier, scavenging rate, farming rate, and mage count. Exponential cost growth via the `IUpgradeEffect` interface — adding a new effect is a 6-line class with no existing code to touch.

Post-MVP, these transition to a 5-skill system (Combat, Scavenging, Farming, Engineering, Leadership) where skills level up through use rather than purchase.

### Progression Visibility

Progress must be *felt*, not just calculated. Two systems ensure the player sees growth:

**Milestone Popups** fire on key thresholds — combat milestones, economy unlocks, mage recruitment, wave survival. Brief, celebratory, never spammy.

**Visual Base Evolution** changes the keep as you progress. The wall gets banners when your first mage joins. Stone texture upgrades when you have four. Crops appear when the farm unlocks. Scars mark the wall after prestige — proof you've been here before.

### Post-4-Mages Loop

Once all four mages are acquired, the game shifts from "unlock" to "optimize and push":

- **Economy Focus:** sustain all four mages' food upkeep. UI highlights production rates.
- **Wave Pushing:** visible counter with personal record. "How far can I go?"
- **Boss Hunting:** every 10 waves, a mini-boss appears. Reward checkpoints to prepare for.

### Welcome Back Screen

When returning after more than 5 minutes away, a summary screen shows time away, resources earned, waves survived, and mage status. The emotional payoff of idle games — connects "I was away" to "my keep endured."
