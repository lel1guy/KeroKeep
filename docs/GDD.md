# Kero Keep — Game Design Document

> **Status:** 🟢 Active — C# port in progress
> **Game:** Kero Keep — defend the last keep of the kingdom of **Batrachia**
> **Engine:** Godot 4 (Mono) · **Language:** C#
> **Repo:** [lel1guy/KeroKeep](https://github.com/lel1guy/KeroKeep) (public)
> **Prototype:** [lel1guy/LastBastion](https://github.com/lel1guy/LastBastion) — GDScript (archived)
> **Dev Log:** Dev-Log
> **Design philosophy:** B/C hybrid — named survivors with stats + skill levels, engineering tree, siege waves
> **Last updated:** 2026-07-06

---

## Revision History

| Date | Change | Reason |
|------|--------|--------|
| 2026-07-06 | Food death spiral → Famine Mode (25% efficiency) | Too punishing — collided with P3 Fair Forever |
| 2026-07-06 | Offline simulation available from start at 25% | Gating idle feature behind mid-game made no sense |
| 2026-07-06 | Monster table expanded with HP/Speed/DPS/Mechanical columns | Documenting actual game design — not just numbers |
| 2026-07-06 | Wave layout documented: 4 lanes, wall layout, building positions | Missing spatial design now captured |
| 2026-07-02 | GDD fully redesigned — B/C hybrid, 12 systems, MoSCoW | Session 2 — co-design with Hermes |

## 1. Vision & Pillars

### What Is This?

> You command Kero Keep — the last fortress standing between the kingdom of Batrachia and an endless siege. Build. Fight. Grow. Everything you earn, you earned.

### Why I'm Making It

I love incremental games. Numbers go up, dopamine hits. But most of them feel like spreadsheets — you don't *see* anything happening.

I wanted an incremental game where the world actually reacts. Archers you see fire. Waves you feel bearing down on the wall. Every upgrade traces back to something *you did*, not something a timer decided. Survival tension with RPG depth, wrapped in idle DNA — and instead of generic humans, the defenders are the armored frog warriors of a dying kingdom.

### The Feeling

| Moment | Feeling |
|--------|---------|
| **Growth beat** | Watching your base harden, numbers climb, survivors grow stronger — knowing *you* earned every increment through action |
| **Siege tension** | The dread before a wave. "Will we make it?" Relief when the last enemy falls. Pressure of knowing it *never* ends |
| **Boss encounter** | A named threat appears. Music shifts. The screen darkens. This one matters — beating it means real progression, losing it means real setback |
| **Prestige reset** | The wall has held through everything. Time to begin again — stronger, wiser, with scars that show. A bittersweet goodbye to the survivors who got you here |

### My Design Pillars

**P1 — EARNED GROWTH**
Progress traces back to player action — mobs killed, archers commanded, resources chosen and spent. Clicking and timers are pacing mechanisms, not idle automation. The game doesn't grow without you.

**P2 — PERSISTENT SIEGE**
There is no pause. No victory screen. The siege is eternal. Once all archers are unlocked, the simulation runs even while you're offline — random hordes and bosses appear, the world keeps burning. Offline persistence is a reward, not a given.

**P3 — FAIR FOREVER**
No pay-to-win. No premium currency. Money never touches game balance. If monetization ever happens, it's optional — ads for a temporary assist. The game respects your time and your wallet equally. Non-negotiable.

### B/C Hybrid Design

I'm using a hybrid approach between two design philosophies:

| Aspect | Approach | What It Means |
|--------|----------|---------------|
| **Survivors** | Option B | Named individuals with stats, personality, and attachment. 6 max (3 farmers, 3 scavengers). |
| **Skills** | Option C | 5 skills replace 9 flat upgrades. Depth over breadth. Skill levels gate new mechanics. |
| **Engineering** | Option C | Tech tree unlocked through skill levels. Recipes persist through prestige. |
| **Siege waves** | Option C | Percentage-based difficulty. Unpredictable = tense. No fixed wave schedules. |

### Setting & World

**The kingdom of Batrachia** is a civilization of humanoid frogs — bipedal, armored, wielding bows and blades like any medieval realm. They are not comedic or cartoonish; they are warriors holding the last wall of a dying kingdom.

Kero Keep is the final fortress. Behind its walls: the last farmers, scavengers, and archers of Batrachia. Beyond them: nothing but the enemy.

**Tone:** Grounded fantasy with charm. The frog identity adds visual distinction and personality, but the stakes are real — your survivors can starve, your walls can fall, and the siege never ends. Think *Redwall* grit with an amphibian skin.

---

## 2. Core Loop

Kero Keep's gameplay operates on three nested timescales, plus four progression layers.

### 2.1 Moment-to-Moment (~10 seconds)

| Element | Description |
|---------|-------------|
| **Player input** | Click on monster → deal damage |
| **System response** | HP decreases, damage number pops, death animation at 0 HP |
| **Reward** | Gold, Bones (from kills), occasionally Oil |
| **Feel target** | Snappy, responsive, impact. Every click matters. |

### 2.2 Session (~10-20 minutes)

| Element | Description |
|---------|-------------|
| **Unlocking** | Spend resources to unlock new archers / defenses |
| **Upgrading** | Level up skills, upgrade survivors, progress engineering tree |
| **Monster scaling** | Over time, monsters grow stronger. New types appear. Bosses can spawn. |
| **Tension** | Resources are finite. Every choice delays another. |

### 2.3 Meta (hours / days)

| Element | Description |
|---------|-------------|
| **Offline simulation** | **Available from the start** at 25% rate. Upgrades to 50-75% rate when all archers acquired. World runs while you're away. |
| **Random events** | Hordes and bosses can appear unpredictably. |
| **Progression check** | Has the wall held? Are new upgrades available? |

### 2.4 Quests

Structured objectives that guide progression and reward meaningful choices.

| Type | Example | Reward |
|------|---------|--------|
| **Milestone** | "Kill 100 skeletons" | Gold, Oil |
| **Survivor** | "Level up Kael to level 5" | Unique survivor trait |
| **Boss** | "Defeat Gorath the Breaker" | Prestige currency, rare resources |
| **Prestige** | "Complete all quests in a cycle" | Triggers prestige option |

Quests are optional — they guide but don't gate. You can ignore quests and still progress through the siege loop.

### 2.5 Achievements

Permanent, one-time accomplishments. Cosmetic and bragging rights.

| Tier | Example | Unlock |
|------|---------|--------|
| **Bronze** | "First Blood" — kill your first monster | Title |
| **Silver** | "Wall of Flesh" — survive 50 waves | Cosmetic base upgrade |
| **Gold** | "Unbroken" — complete a prestige cycle with zero wall breaches | Rare title |

**Open question:** Should achievements grant gameplay rewards (stat boosts) or purely cosmetic? *(TBD)*

### 2.6 Bosses

Bosses break the rhythm. They're threats that demand attention and offer outsized rewards.

| Type | Trigger | Behavior |
|------|---------|----------|
| **Random spawn** | Percentage chance per wave | Tougher stats, unique attack patterns, drops rare loot (Oil, Bones) |
| **Quest boss** | Summoned when quest conditions met | Named, unique mechanics, gate to next progression tier |

**My approach:** Random spawns keep tension high during normal play. Quest bosses give structure and clear goals.

### 2.7 Prestige

The endgame loop. Reset the world, keep permanent bonuses, start stronger.

| Trigger | Description |
|---------|-------------|
| **Victory** | Defeat the final quest boss → choose to prestige |
| **Defeat** | The wall falls → forced prestige with reduced bonus |

**Dual path philosophy:** You're never forced — you can keep playing indefinitely. But eventually the wall falls, or you choose to transcend. Either way, you come back stronger.

**What sticks through prestige:**
- Skill level bonuses (permanent stat boosts)
- Engineering recipes
- Achievement titles and cosmetics
- Prestige currency (earned per cycle)

**What resets:**
- All resources (Gold, Scrap, Food, Oil, Bones)
- Survivors (new names, new stories)
- Archers and upgrades
- Monster stages

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

### Resources

| Resource | Earned How | Spent On |
|----------|-----------|----------|
| **Gold** | Kills, waves, base income | Unlocks, general upgrades |
| **Scrap** | Salvage, scavengers auto-farm | Archer unlocks, damage upgrades |
| **Food** | Farmers auto-farm | Upkeep for archers, survivors, workers |
| **Oil** | Rare drops, boss kills, quest rewards | Engineering tree — advanced buildings, automation |
| **Bones** | Monster kills, boss kills | Crafting, rituals, survivor upgrades |

#### Upkeep & Failure

Every archer and survivor has an ongoing **food upkeep cost**.

**If food hits zero — Famine Mode:**
1. All production drops to 25% efficiency — archers fire slower, farmers produce less, scavengers find less
2. Food is only produced through farming (no purchasing) — you must farm your way out
3. **Recovery path**: manual scavenging and farming still work at reduced rate. Kill monsters for gold to upgrade farm efficiency. The wall holds, but barely.
4. **No death spiral** — famine is a setback, not a game over. Tension without punishment.

---

## 3. Systems

### 3.1 Archer System

| Property | Value |
|----------|-------|
| **Archer types** | 1 type (single archer unit), tier progression |
| **Max archers** | 4 total |
| **Arrow count** | Max 3 per archer (upgraded) |

Each archer: unlock cost (Gold + Scrap + Food), upkeep cost (Food/tick), per-arrow damage (upgraded), tier progression upgrading stats and visuals.

### 3.2 Monster System

| Monster | Stage | HP | Speed | DPS | Mechanical Difference | Status |
|---------|-------|----|-------|-----|----------------------|--------|
| **Skeleton** | 0 | Low | Fast | Low | Basic — no special mechanics | Implemented (3 variants) |
| **Zombie** | 1 | Medium | Slow | Medium | Tanky — takes more clicks to kill | Implemented (7 variants) |
| **Orc** | 2 | High | Medium | High | Armored — reduces click damage, arrows pierce | Planned |
| **Demon** | 3 | Very High | Fast | Very High | Teleports, fire AoE, unique attack patterns | Planned |

Each monster type has different HP, speed, and damage output — not just bigger numbers. Mechanical differences force the player to adapt strategy per stage (e.g., Orcs need arrows, Demons need positioning).

**Wave layout:** 4 lanes running top-to-bottom. At the bottom: the wall and archer positions. Below the wall: storeroom, farm, dormitory, and upgrade buildings. The upgrade building opens a menu page with all upgrade options.

### 3.3 Upgrade System → Transitioning to Skills

Nine flat upgrades currently implemented in the GDScript prototype (Pocket Search, Scavengers, Farmers, Strength, Storeroom, Farm, Gear, Arrow Count, Archers). Exponential cost growth (×1.5 per level). Three-resource affordability check.

**My decision:** Port the 9-upgrade system as-is for MVP. Transition to the 5-skill system (3.7) post-MVP — deeper, more earned, better alignment with P1.

### 3.4 Economy

| Resource | Manual Collection | Auto Collection |
|----------|------------------|-----------------|
| **Scrap** | Scavenge (15s cd, 10 Scrap) | Auto-scrap (1s tick, upgrades scale) |
| **Food** | Farm (4s cd, 5 Food) | Auto-food (1s tick, upgrades scale) |
| **Gold** | Combat kills | — |
| **Oil** | Boss kills, quests | — |
| **Bones** | Monster kills, boss kills | — |

**Combat income:** Monster gold × `gold_drop_multiplier`. Click damage 1 base (+1/level). Arrow damage 0.25 base (+0.25/level).

### 3.5 Save System

`Save&Load` autoload → `user://SaveFile.json`. Triggers on window close, app pause, focus out, auto-save every 60s. Loads on startup.

### 3.6 Survivor System (NEW)

Named NPCs you recruit, manage, and grow attached to. They're the heart of your bastion.

| Property | Value |
|----------|-------|
| **Max survivors** | 6 total (3 farmers, 3 scavengers) |
| **Acquisition** | Recruited with Gold + Food (random name, random starting stats) |
| **Roles** | Farmers produce Food. Scavengers produce Scrap. |
| **Stats** | Efficiency (production rate), Loyalty (prestige bonus carry-over), Resilience (survives food crises longer) |
| **Leveling** | Gain XP from working. Level up → stats improve. Each level unlocks a new trait slot. |
| **Attachment** | 6 is small enough to remember names. Each has a short bio. Losing one to a siege hurts. |

**Why 6 max:** Enough for attachment and strategy without spreadsheet overload. 3+3 split keeps role decisions meaningful.

### 3.7 Skill System (NEW)

5 skills replace the 9 flat upgrades. Skills level up through use, not purchase. Deeper, more earned.

| # | Skill | Replaces | Effect | Level Up By |
|---|-------|----------|--------|-------------|
| 1 | **Combat** | Strength, Gear, Arrow Count | Click damage, arrow damage, arrow capacity | Killing monsters |
| 2 | **Scavenging** | Scavengers, Storeroom | Auto-scrap rate, manual scavenge yield, rare find chance | Collecting scrap |
| 3 | **Farming** | Farmers, Farm | Auto-food rate, manual farm yield, crop resilience | Collecting food |
| 4 | **Engineering** | — (new) | Unlocks engineering tree nodes, build speed, Oil efficiency | Building/upgrading structures |
| 5 | **Leadership** | Archers, Pocket Search | Max archers, gold multiplier, survivor morale | Recruiting survivors, surviving waves |

**Skill gating:** Skill levels unlock new mechanics. Engineering 3 → Oil refinery. Leadership 4 → 5th archer. Combat 5 → critical hits.

**My transition plan:** Port the 9 flat upgrades as-is for MVP (they work, they're tested). Add the 5-skill system post-MVP. Players keep their progress — upgrades convert to equivalent skill levels.

### 3.8 Quest System (NEW)

Structured objectives that give direction without taking away agency.

| Component | Description |
|-----------|-------------|
| **Quest board** | 3 active quest slots. Complete one, a new one appears. |
| **Types** | Milestone (kill X, collect Y), Survivor (level up, recruit), Boss (defeat named boss), Prestige (complete all in cycle) |
| **Rewards** | Gold, Oil, Bones, rare survivor traits, prestige currency |
| **Optional** | Quests guide but don't gate. Ignore them and the siege loop still works. |

### 3.9 Achievement System (NEW)

Permanent, one-time accomplishments. Tracked globally, persist through prestige.

| Tier | Count | Example |
|------|-------|---------|
| **Bronze** | ~20 | "First Blood", "Scrap Collector", "Farmer's First Harvest" |
| **Silver** | ~12 | "Wall of Flesh" (50 waves), "Boss Slayer" (5 boss kills), "Full House" (6 survivors) |
| **Gold** | ~6 | "Unbroken" (prestige with zero breaches), "Gorath's Bane" (kill Gorath 3 times) |

**Reward question (TBD):** Cosmetic only (titles, base visuals) or gameplay (small stat boosts)? I haven't decided yet.

### 3.10 Boss System (NEW)

| Type | Spawn | Stats | Reward |
|------|-------|-------|--------|
| **Random** | % chance per wave, increases with stage | 5× HP, 3× damage, unique attack pattern | Gold, Bones, rare Oil |
| **Quest** | Summoned via quest completion | Named, 10× HP, unique mechanics, phases | Prestige currency, survivor trait, engineering recipe |

**My approach:** Random bosses keep the siege tense. Quest bosses give structure and clear progression gates.

### 3.11 Engineering System (NEW)

A tech tree that unlocks through skill levels. Permanent upgrades, buildings, and automation.

| Tier | Unlocks at | Examples |
|------|-----------|----------|
| **T1** | Engineering 1 | Reinforced walls (+10% HP), basic traps (slow enemies) |
| **T2** | Engineering 3 | Oil refinery (auto-oil production), ballista tower (heavy damage) |
| **T3** | Engineering 5 | Auto-repair (walls self-heal), signal fire (survivor loyalty boost) |
| **T4** | Engineering 7 | Foundry (permanent damage bonus through prestige), thunder dome (boss arena — farmable) |

**Key rule:** Engineering recipes persist through prestige. Once you learn to build a ballista, you keep that knowledge forever. This is the primary long-term progression anchor.

**Costs:** Buildings cost Oil + Scrap. Upgrades cost Oil + Gold. Oil is the engineering bottleneck — scarce, valuable, boss-gated.

### 3.12 Prestige System (NEW)

| Aspect | Detail |
|--------|--------|
| **Trigger** | Victory (kill final quest boss) → choose to prestige. Defeat (wall falls) → forced prestige. |
| **Persists** | Skill level bonuses, engineering recipes, achievements, prestige currency |
| **Resets** | Resources (all 5), survivors, archers, upgrades, monster stages |
| **Prestige currency** | Earned per cycle based on achievements completed, bosses killed, survivors saved. Spent on permanent upgrades (starting resources, stat boosts, unique cosmetics). |
| **Philosophy** | Never forced by victory — you choose when you're ready. Forced by defeat — but you come back stronger. |

---

## 4. Content Plan (MoSCoW)

### Must Do — MVP (3-5 weeks)

| # | Feature | Est. | Depends On |
|---|---------|------|------------|
| M1 | Port 9-upgrade system to C# | 3d | GameManager.cs |
| M2 | Archer system (4 archers, 3 arrows each) | 2d | Upgrades |
| M3 | Monster system (Skeleton, Zombie, Orc) | 2d | — |
| M4 | Economy (manual + auto collection, 3 resources) | 2d | Upgrades |
| M5 | Save/Load (JSON autoload) | 1d | GameManager |
| M6 | Core UI (resources, upgrades, archer panel) | 3d | All above |
| M7 | Wave system (percentage-based scaling) | 2d | Monsters |
| **Total MVP** | | **15d (~3 weeks)** | |

### Should Do — Post-MVP (6-10 weeks)

| # | Feature | Est. | Depends On |
|---|---------|------|------------|
| S1 | Survivor system (6 named, stats, leveling) | 5d | Economy (Food upkeep) |
| S2 | 5-skill system (replacing 9 upgrades) | 5d | Survivors |
| S3 | Boss system (random + quest) | 4d | Waves, Monsters |
| S4 | Quest system (3 slots, 4 types) | 4d | Bosses |
| S5 | Oil + Bones resources | 2d | Economy |
| S6 | Engineering tree (T1-T2) | 5d | Skills, Oil |
| S7 | Offline simulation | 3d | Economy |
| **Total Should Do** | | **28d (~6 weeks)** | |

### Could Do — Polish & Depth (6-9 weeks)

| # | Feature | Est. | Depends On |
|---|---------|------|------------|
| C1 | Achievement system (38 achievements) | 3d | All Should Do |
| C2 | Engineering T3-T4 | 4d | Engineering T1-T2 |
| C3 | Prestige system (dual trigger, currency) | 5d | Bosses, Engineering |
| C4 | Archer tier system (Scout → Marksman → Ranger) | 3d | Archers |
| C5 | Sound effects & music | 5d | — |
| C6 | Animated UI feedback (damage numbers, popups) | 4d | Core UI |
| C7 | Orc + Demon monsters | 3d | Monster system |
| **Total Could Do** | | **27d (~6 weeks)** | |

---

## 5. C# Conversion Plan

### Current Sprint — Core Systems

| # | System | Source | Target | Status |
|---|--------|--------|--------|:---:|
| 1 | GameManager | `GameManager.gd` | `Scripts/GameManager.cs` | ✅ Complete |
| 2 | Save & Load | `Save&Load.gd` | `Scripts/SaveLoad.cs` | ✅ Complete |
| 3 | Combat (arrows) | `Scripts/Arrow.gd` | TBD | 🟡 |
| 4 | Enemies | `Scripts/Enemy*.gd` | TBD | 🟡 |
| 5 | Upgrades (9-flat, transitional) | `Scripts/Upgrade*.gd` | TBD | ⬜ |
| 6 | UI | Scene scripts | TBD | ⬜ |
| 7 | Economy (timers) | In GameManager | TBD | ⬜ |

### Post-MVP — New Systems

| # | System | C# Target | Status |
|---|--------|-----------|:---:|
| 8 | Survivors | TBD | ⬜ |
| 9 | Skills (5-skill) | TBD | ⬜ |
| 10 | Quests | TBD | ⬜ |
| 11 | Achievements | TBD | ⬜ |
| 12 | Bosses | TBD | ⬜ |
| 13 | Engineering | TBD | ⬜ |
| 14 | Prestige | TBD | ⬜ |

### C# Architecture Decisions

| Decision | Why |
|----------|-----|
| `namespace KeroKeep;` | File-scoped namespace (renamed from LastBastion 2026-07-04) |
| `partial class` | Required by Godot source generators |
| `[Signal] delegate` | Godot C# signal pattern |
| `{ get; private set; }` | Resource properties — read-only externally |
| `f` suffix on floats | C# explicit float literal |
| `EmitSignal(SignalName.X, value)` | Type-safe signal emission |
| `GetNode<T>("/root/Name")` in `_Ready()` | C# autoload access — no global magic, fetch instance from scene tree |
| `LoadState(Dictionary)` method | External code can't touch `private set` properties — GameManager loads its own state |

---

## 6. MVP / Cut List

### MVP Checklist

- [x] GameManager.cs complete (autoload, signals, all resource methods)
- [ ] 9 upgrades functional (buy, level, cost scaling)
- [ ] 3 monster types spawnable (Skeleton, Zombie, Orc)
- [ ] 4 archers placeable, firing arrows
- [ ] Manual + auto economy working (Scrap, Food)
- [x] Save/Load working (auto-save every 60s, JSON to user://savegame.json)
- [ ] Core UI: resource bars, upgrade panel, archer panel
- [ ] Wave system: percentage-based scaling, endless

### What I'm Cutting from MVP

| Feature | Why | When It Comes Back |
|---------|-----|-------------------|
| Survivor system | Adds complexity before the core is stable | Post-MVP |
| 5-skill system | Port 9-upgrade first, transition later | Post-MVP |
| Bosses | Needs stable monster + wave system first | Post-MVP |
| Quests | Needs bosses for boss quest type | Post-MVP |
| Oil, Bones | New resources add economy complexity | Post-MVP |
| Engineering tree | Needs skills + Oil | Post-MVP |
| Prestige | Endgame — nothing to prestige from yet | Endgame |
| Achievements | Polish layer | Polish phase |
| Offline simulation | Needs stable economy first | Post-MVP |

### Never Cutting

| Feature | Why |
|---------|-----|
| P3 — Fair Forever | Core pillar. No pay-to-win. Non-negotiable. |
| Save system | Players must not lose progress. |
| Wave/ siege loop | The game IS the siege. |

---

## 7. Risk Assessment

| # | Risk | P | I | My Plan |
|---|------|---|---|---------|
| 1 | **Scope creep** — 12 systems is too many for one person | High | High | Strict MoSCoW. MVP is 7 systems, not 12. Cut ruthlessly. |
| 2 | **Skill system over-design** — 5 skills too complex before core is fun | Med | High | Port 9-upgrade first. Add skills only when core loop is fun on its own. |
| 3 | **Burnout** — solo dev, long timeline | High | High | MVP in 3 weeks. Ship something playable. Rest is bonus. |
| 4 | **Engineering tree imbalance** — powerspike or useless | Med | Med | Tuning variables section below. Playtest each tier before adding next. |
| 5 | **Survivor attachment not landing** — players don't care about named NPCs | Low | Med | 6 survivors is small enough to test. If attachment doesn't work, I'll pivot to faceless workers. |
| 6 | **Prestige feels like punishment** — losing everything hurts | Med | High | Dual trigger (victory OR defeat). Let players choose. Strong persist bonuses. |
| 7 | **C# port technical debt** — rushing conversion breaks things | Med | Med | Port one system at a time. Build after every chunk. Tests before moving on. |
| 8 | **Resource bloat** — 5 resources is too many for an idle game | Low | Med | Start with 3 (Gold, Scrap, Food). Add Oil + Bones post-MVP only if they earn their place. |
| 9 | **Offline simulation accuracy** — too generous or too punishing | Low | Low | Percentage-based formula. Tune with real play data. Conservative defaults. |
| 10 | **"X meets Y" never found** — game lacks easy pitch | Low | Low | Play more games in the genre. Note influences. Not a blocker — game can stand on its own. |

**Riskiest assumption:** That the B/C hybrid (named survivors + engineering tree + 5 skills) is fun as a package before all pieces exist. My mitigation: MVP first, expand only when core is proven fun.

---

## 8. Tuning Variables

### Combat

| Variable | Default | Range | Notes |
|----------|---------|-------|-------|
| Click damage | 1 | 1-5 | Per Strength level |
| Arrow damage | 0.25 | 0.1-1.0 | Per Gear level |
| Boss HP multiplier | 5× | 3-10× | Random bosses |
| Quest boss HP multiplier | 10× | 8-20× | Named bosses |

### Economy

| Variable | Default | Range | Notes |
|----------|---------|-------|-------|
| Scavenge cooldown | 15s | 10-30s | Manual |
| Farm cooldown | 4s | 2-8s | Manual |
| Auto-scrap rate | 1/s | 0.5-3/s | Scales with level |
| Auto-food rate | 1/s | 0.5-3/s | Scales with level |
| Upgrade cost multiplier | 1.5× | 1.3-2.0× | Per level |
| Food upkeep per archer | 0.1/s | 0.05-0.3/s | Tension valve |
| Food upkeep per survivor | 0.2/s | 0.1-0.5/s | Higher than archers |

### Siege

| Variable | Default | Range | Notes |
|----------|---------|-------|-------|
| Wave HP scaling | +15%/wave | 10-25% | Percentage-based |
| Wave spawn rate increase | +5%/wave | 3-10% | More monsters per wave |
| Boss spawn chance | 5%/wave | 3-10% | After stage 1 |
| Offline simulation rate | 50% of live | 30-70% | Conservative default |

### Prestige

| Variable | Default | Range | Notes |
|----------|---------|-------|-------|
| Base prestige currency | 10 | 5-20 | Per cycle |
| Bonus per achievement | +2 | 1-5 | Encourages completionism |
| Bonus per boss killed | +5 | 3-10 | Bosses matter |
| Starting resource bonus | +10% | 5-25% | Per prestige level |

---

## GDScript Prototype
The original GDScript prototype lives at [lel1guy/LastBastion](https://github.com/lel1guy/LastBastion) (playable alpha, archived 2026-07-02). All original systems (3.1-3.5) were documented from its live code. The C# version (Kero Keep) inherits this design and expands it with systems 3.6-3.12.

---

## Cross-References

- Dev Log — C# port session log
- Career Plan — my C# learning path
- Godot Knowledge — engine reference
- Game Programming Patterns — Nystrom's 19 patterns

---

*Single GDD — B/C hybrid redesign, 2026-07-02. Session 2.*