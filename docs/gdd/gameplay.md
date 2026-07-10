# Gameplay

## Core Loop

```
[Click to kill] → [Earn resources] → [Unlock/Upgrade]
       ↑                                    │
       │                                    ↓
       └──── [Monsters get stronger] ←──────┘
        ┌────────────────────────────────────┘
        ↓
  [Quests] → [Bosses] → [Prestige] → [Stronger restart]
```

Kero Keep operates on three nested timescales:

### Moment-to-Moment (~10 seconds)

- Click on monsters → deal damage
- HP decreases, damage numbers pop, death animations play
- Reward: Gold, occasionally rare Essence
- Feel target: snappy, responsive, every click matters

### Session (~10-20 minutes)

- Spend resources to unlock archers and defenses
- Level up skills, upgrade survivors
- Survive waves, push your record higher
- Tension: resources are finite, every choice delays another

### Meta (hours/days)

- Offline simulation runs while you're away
- Random hordes and bosses can appear unpredictably
- Return to a welcome-back screen: "You were gone 3 hours. Your keep held through 8 waves. +1,240 Gold."
- The emotional payoff of idle games — seeing progress you earned while away

## Systems Overview

### Combat

Click to deal damage. Every click matters — this is not a pure idle game. Archers fire automatically from the wall, but their effectiveness depends on your upgrades, their levels, and the enemy type they face. Combat income scales exponentially — click damage ×1.5 per level, gold multiplier ×1.3 — so numbers multiply, not add.

### Energy System

Manual actions (scavenging, farming) use an Energy pool instead of cooldowns. 10 Energy max (upgradable), regenerates 1 per 5 seconds. Scavenge costs 2 Energy → 5 Scrap. Farm costs 2 Energy → 3 Food. The rhythm is burst → pause → burst — energy recharges while archers fire.

### Archer System

Up to 4 archers on the wall. Each one is a milestone — unlocked through resources AND gates (kill counts, wave survival, boss defeats). The 4th archer should *hurt* to earn. Each has a name from a Batrachian pool, a recruitment ceremony, and can be upgraded.

### Monster System

4 enemy stages with mechanical differences — not just bigger numbers. Skeletons swarm fast. Zombies tank hits. Orcs resist clicks but fear arrows. Demons teleport and force repositioning. Every 10 waves, a boss appears — named, dangerous, rewarding.

### Economy

Three visible resources: Gold (combat), Scrap (scavenging), Food (farming). A fourth rare resource (Essence) appears in advanced menus. **Famine Mode:** if food hits zero, production drops to 25% — you can claw back, but you'll feel it. No death spiral. Food upkeep per archer/survivor creates constant tension.

### Survivors

6 named NPCs (3 farmers, 3 scavengers). They gain XP, level up, and grow attached to. Losing one to famine or siege is a real setback. Stats: Efficiency, Loyalty, Resilience.

### Skills

5 skills replace flat upgrades: Combat, Scavenging, Farming, Engineering, Leadership. Skills level through use, not purchase. Skill levels gate new mechanics — Engineering 3 unlocks Essence refinery, Leadership 4 unlocks 5th archer.

### Quests & Achievements

**Quests:** 3 active slots on a quest board. Four types — milestone (kill X), survivor (level up), boss (defeat named), prestige (complete all). Optional — they guide but don't gate.

**Achievements:** Permanent one-time unlocks across 3 tiers (Bronze ~20, Silver ~12, Gold ~6). Persist through prestige. Cosmetic titles and base visuals.

### Welcome Back Screen

When returning after >5 minutes away, a summary screen: time away, resources earned, waves survived, archer status. The emotional payoff of idle games — connecting "I was away" to "my keep endured."

### Daily Login Bonus

7-day streak with free rewards. Day 1: +50 starting Gold. Day 7: +2 Chronicle Points on next prestige. Miss a day → reset to day 1. Free for all, no premium tier. P3 non-negotiable.

### Prestige

The endgame loop. Reset the world, keep permanent bonuses, start stronger. Two paths: win (defeat the final boss, choose to transcend) or lose (the wall falls, forced reset with reduced bonus). Either way, you come back stronger. **Chronicle Points** granted via `sqrt(gold) + sqrt(scrap) + sqrt(food)` plus milestone bonuses — every resource matters.

## Progression Visibility

Progress must be *felt*, not just calculated:

- **Milestone popups** fire on key moments — every 50 kills, first boss slain, wave 10 survived. One per 30 seconds max.
- **Visual base evolution** — the keep changes as you progress: banners on first archer, stone walls at 4 archers, crops growing, prestige scars.

## Economy Unlock Order

```
Start: Gold only (clicks kill skeletons)
    ↓ ~30 seconds
Storeroom → Scrap (manual scavenge unlocked)
    ↓ ~1-2 minutes
Farm → Food (manual farming unlocked)
    ↓ "The keep is producing. Now I need defenses."
1st Archer → costs Scrap + Food upkeep
    ↓ Player already understands the economy
```

*Auto-production is a separate upgrade chain — manual first, automation earned.*

## Progression

| Phase | What Unlocks |
|-------|-------------|
| **Early** | First archer, storeroom (scrap), farm (food). Learn the economy. |
| **Mid** | All 4 archers, skill system, bosses every 10 waves. Push your record. |
| **Late** | Prestige cycle, engineering tree, Essence crafting. Optimize forever. |

---

*See the full [Roadmap](roadmap.md) for current development status.*
