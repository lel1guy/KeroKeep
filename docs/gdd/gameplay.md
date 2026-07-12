# Gameplay

## Core Loop

Kero Keep operates on three nested timescales.

### Moment-to-Moment (~10 seconds)

Click on monsters to deal damage. HP decreases, damage numbers pop, death animations play at 0 HP. Gold drops — occasionally rare Essence from special enemies. Every click matters.

### Session (~10-20 minutes)

Spend resources to unlock new mages and defenses. Level up skills, upgrade survivors, progress the engineering tree. Over time, monsters grow stronger, new types appear, and bosses can spawn. Resources are finite — every choice delays another.

### Meta (hours / days)

Offline simulation runs while you're away. Random hordes and bosses appear unpredictably. Return to check: has the wall held? Are new upgrades available?

```
[Click to kill] ──→ [Earn resources] ──→ [Unlock/Upgrade/Skill]
       ↑                                          │
       │                                          ↓
       └──────── [Monsters get stronger] ←───────┘
        ┌─────────────────────────────────────────┘
        ↓
[Quests] ──→ [Bosses] ──→ [Prestige] ──→ [Stronger restart]
```

## Progression Visibility

Progress is *felt*, not just calculated.

**Milestone Popups** fire on key moments — combat milestones (100 kills, first boss slain), economy unlocks (storeroom built), mage recruitment (named ceremony with one-line intro), and wave survival (every 5-10 waves). Never more than one popup per 30 seconds.

**Visual Base Evolution** — the keep changes physically. Wall banners appear with the first mage. Stone textures upgrade at four mages. Buildings fill with sprites as they're built. After prestige, wall scars tell the story of past cycles.

## Resources

| Resource | Earned How | Spent On |
|----------|-----------|----------|
| **Gold** | Kills, waves, base income | Unlocks, general upgrades |
| **Scrap** | Manual scavenge + auto-scrap (upgrade) | Mage unlocks, damage upgrades |
| **Food** | Manual farm + auto-food (upgrade) | Upkeep for mages, survivors, workers |
| **Essence** | Rare drops, boss kills, quest rewards | Engineering tree, advanced buildings |

The player learns to produce before they spend. Gold comes first (clicking kills skeletons). Then the storeroom unlocks manual scavenging. Then the farm unlocks manual food production. Only after understanding the economy does the first mage appear — costing Scrap and ongoing Food upkeep.

### Famine Mode

If food hits zero, all production drops to 25% efficiency. Mages fire slower, farmers produce less, scavengers find less. Recovery is always possible through farming — famine is a setback, not a game over.

## Systems Overview

### Mages

Up to 4 mages defend the wall. Each costs resources to unlock and food to maintain. Mage unlocks are gated by achievements — the 4th requires defeating a boss or surviving 15 waves. A recruitment ceremony names each mage with a one-line introduction, turning automation into a milestone.

### Monsters

Four monster types across four stages, each with mechanical differences beyond bigger numbers. Skeleton (basic), Zombie (tanky), Orc (armored — reduces click damage, magic bolts pierce), Demon (teleports, fire AoE, unique patterns).

### Bosses

Two types: random spawns during waves (tougher stats, rare loot) and quest bosses (named, multi-phase, gated to progression tiers). Bosses at waves 10, 20, and 30 provide early-game checkpoint challenges.

### Economy

Manual and automated resource collection. An energy pool (max 10, regenerates over time) replaces cooldowns — burst several actions then let it recharge while mages fire. Auto-production is a separate upgrade from unlocking, preserving the manual-to-automation arc.

### Prestige — The Chronicle

Reset the world, keep permanent bonuses. Dual trigger: defeat the final quest boss (voluntary) or the wall falls (forced, reduced bonus). Three resources contribute to Chronicle Points, with milestone bonuses for waves survived, bosses killed, and flawless defense. A 5-upgrade shop offers permanent improvements across cycles.

### Engineering (Post-MVP)

A tech tree unlocked through skill levels. T1: reinforced walls, basic traps. T2: Essence refinery, ballista tower. T3: auto-repair walls, signal fire. T4: foundry (permanent damage bonus through prestige), thunder dome (farmable boss arena). Engineering recipes persist through prestige — once learned, never forgotten.

### Skills (Post-MVP)

Five skills replace nine flat upgrades: Combat, Scavenging, Farming, Engineering, Leadership. Skills level up through use — deeper, more earned. Skill levels gate new mechanics (Engineering 3 unlocks Essence refinery, Leadership 4 unlocks 5th mage).

### Survivors (Post-MVP)

Six named NPCs (3 farmers, 3 scavengers) with stats, personality, and attachment. Recruited with resources, gain XP from working, level up to improve stats. Small enough to remember names — losing one to a siege hurts.

---

*From the Kero Keep Game Design Document · Updated 2026-07-12*
