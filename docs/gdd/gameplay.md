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

Click to deal damage. Every click matters — this is not a pure idle game. Archers fire automatically from the wall, but their effectiveness depends on your upgrades, their levels, and the enemy type they face.

### Archer System

Up to 4 archers on the wall. Each one is a milestone — unlocked through resources AND gates (kill counts, wave survival, boss defeats). The 4th archer should *hurt* to earn. Each has a name, a recruitment ceremony, and can be upgraded.

### Monster System

4 enemy stages with mechanical differences — not just bigger numbers. Skeletons swarm fast. Zombies tank hits. Orcs resist clicks but fear arrows. Demons teleport and force repositioning.

### Economy

Three visible resources: Gold, Scrap, Food. A fourth rare resource (Essence) appears in advanced menus. Manual actions use an Energy pool — burst actions followed by natural recharge while archers fire.

### Survivors

6 named NPCs (3 farmers, 3 scavengers). They gain XP, level up, and grow attached to. Losing one to famine or siege is a real setback.

### Skills

5 skills replace flat upgrades: Combat, Scavenging, Farming, Engineering, Leadership. Skills level through use, not purchase. Skill levels gate new mechanics.

### Prestige

The endgame loop. Reset the world, keep permanent bonuses, start stronger. Two paths: win (defeat the final boss, choose to transcend) or lose (the wall falls, forced reset with reduced bonus). Either way, you come back stronger.

## Progression

| Phase | What Unlocks |
|-------|-------------|
| **Early** | First archer, storeroom (scrap), farm (food). Learn the economy. |
| **Mid** | All 4 archers, skill system, bosses every 10 waves. Push your record. |
| **Late** | Prestige cycle, engineering tree, Essence crafting. Optimize forever. |

---

*See the full [Roadmap](roadmap.md) for current development status.*
