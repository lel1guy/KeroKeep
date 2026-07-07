# Kero Keep — Game Design Document

> **Status:** 🟡 Phase A — porting GDScript prototype to C# (Sprint 3/6). Phase B (new MVP features) after port complete.
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
| 2026-07-06 | 3-pillar design review: progression visibility, automation arc, prestige MVP | Deep research vs idle game genre standards |
| 2026-07-06 | Progression: milestone popups + visual base evolution | A+C hybrid — feedback + immersion |
| 2026-07-06 | Archers: recruitment ceremony + unlock gates (cost that hurts) | A+B — personality + earned automation |
| 2026-07-06 | Prestige: hybrid MVP (Chronicle minimal → expand post-MVP) | Don't sacrifice scope, keep code extensible |
| 2026-07-06 | Combat scaling switched to exponential (×1.5/×1.4/×1.3) | Idle game genre expectation — numbers must multiply |
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
| **Reward** | Gold, occasionally Essence (rare drops) |
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
| **Milestone** | "Kill 100 skeletons" | Gold, Essence |
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
| **Random spawn** | Percentage chance per wave | Tougher stats, unique attack patterns, drops rare loot (Gold, Essence) |
| **Quest boss** | Summoned when quest conditions met | Named, unique mechanics, gate to next progression tier |

**My approach:** Random spawns keep tension high during normal play. Quest bosses give structure and clear goals.

### 2.8 Progression Visibility

Progress must be *felt*, not just calculated. Two systems ensure the player always sees growth.

#### Milestone Popups

Threshold-based notifications that fire on key moments. Brief, celebratory, non-spammy.

| Category | Examples | Frequency |
|----------|----------|-----------|
| **Combat** | "⚔️ 100 kills!", "💀 First boss slain!" | Every 50-100 kills |
| **Economy** | "💰 500 Gold!", "🏗️ Storeroom built!" | First-time unlocks |
| **Archers** | "🏹 Kael joins the wall!" | One per archer |
| **Waves** | "🌊 Wave 10 survived!", "🛡️ Wall held!" | Every 5-10 waves |

**Design rules:** Never show more than one popup per 30 seconds. Use the player's archer names. Tie popups to GameManager signals for easy hookup.

#### Visual Base Evolution

The keep changes visually as the player progresses. Not cosmetic purchases — the world *reacts* to progress.

| Threshold | Visual Change | Feels Like |
|-----------|--------------|------------|
| First archer | Wall gets a banner | "This is mine now" |
| 4 archers | Wall reinforced (stone texture upgrade) | "We're holding" |
| Storeroom unlocked | Storeroom appears, fills with scrap sprites | "Resources are real" |
| Farm unlocked | Crops appear, grow over time | "Life persists" |
| After prestige | Wall gains scars/markings from past cycles | "I've been here before" |

**Implementation:** Each building/wall has 2-3 visual states. States are triggered by GameManager flags and archer count. Can be implemented incrementally — start with wall states and archer banners (cheapest, highest impact).

### 2.9 Post-4-Archers Loop — Economy → Waves → Bosses (A+B+C)

Once all 4 archers are acquired, the game shifts from "unlock" to "optimize and push." Three systems work together to create an infinite loop.

#### Economy Focus (A)

The player's attention shifts from combat to resource management. Food must sustain all 4 archers. Scrap funds upgrades. The UI highlights production rates ("+12 Food/min, -8 Food/min upkeep = +4 net"). The question becomes: "Can I sustain this?"

#### Wave Pushing (B)

A visible wave counter with a personal record. Every 5 waves, a milestone popup. The goal is infinite: "How far can I go?"

| Feature | Detail |
|---------|--------|
| **Wave counter** | Always visible in HUD |
| **Record** | "Best: Wave 34" next to counter. Saved in GameManager. |
| **Wall-fall screen** | "The wall fell at Wave 34. Record: 34." |
| **Milestones** | Popups at waves 5, 10, 15, 20, 30, 40, 50... |

#### Boss Hunting (C)

Every 10 waves, a mini-boss appears. Not the full boss system from post-MVP — a simple elite enemy that breaks the rhythm.

| Wave | Boss | HP | Drops | Unlocks |
|------|------|----|-------|---------|
| 10 | Siege Captain | 5× normal | 200 Gold, 50 Scrap | First boss kill milestone |
| 20 | Gate Crasher | 7× normal | 500 Gold, 100 Scrap | Prestige prompt appears |
| 30 | Wall Breaker | 10× normal | 1000 Gold, 200 Scrap, 3 Essence | Elite challenges teaser |
| 40+ | Scaled | +2× per 10 waves | Proportional | — |

**Design:** Bosses use the same BaseMob class with a `IsBoss = true` flag. Larger sprite, visible HP bar, unique death animation. Boss drops are a reward checkpoint — the player prepares for them.

### 2.10 Welcome Back Screen

When the player returns to the game (after being away > 5 minutes), a summary screen appears before the main game:

| Element | Detail |
|---------|--------|
| **Time away** | "You were gone for 3 hours." |
| **Resources earned** | "+1,240 Gold · +320 Scrap · +180 Food" |
| **Waves survived** | "Your keep held through 8 waves." |
| **Any deaths?** | "All archers survived." or "Kael fell at wave 12." |
| **Dismiss** | Click to close → back to the keep |

**Why:** This is the emotional payoff of idle games. The player sees their offline progress in one satisfying burst. It connects "I was away" to "my keep endured" — aligning with P2 (Persistent Siege).

**Implementation:** `WelcomeBackPopup` scene, triggered on `_Ready()` if `Time.GetUnixTimeFromSystem() - LastSaveTime > 300`. Reads from GameManager and WaveManager. ~1 day.

### 2.11 Daily Login Bonus

Free, equal for all players. No premium tier. No pay-to-win.

| Day | Reward | Type |
|-----|--------|------|
| 1 | +50 starting Gold for next run | Economy |
| 2 | +25 starting Scrap for next run | Economy |
| 3 | +10 starting Food for next run | Economy |
| 4 | +25% Gold for 10 minutes (active buff) | Boost |
| 5 | +1 permanent click damage (rest of day) | Combat |
| 6 | 2× Energy regen for 10 minutes | Boost |
| 7 | **Streak bonus:** +2 CP on next prestige | Prestige |
| 8+ | Cycle repeats (day 1 reward again) | — |

**Rules:**
- One reward per calendar day. Miss a day → streak resets to day 1.
- Rewards apply to the *next run* or activate as *timed buffs* — they don't stack infinitely.
- No reward requires watching an ad or spending money. P3 non-negotiable.
- Streak day counter saved in GameManager. Visible on main menu.

**Why:** Daily login is the #1 retention mechanic in idle games. Free for all = fair. Small rewards = never mandatory, always appreciated. The day 7 CP bonus gives prestige players a reason to maintain streaks.

**Implementation:** `DailyBonusManager` autoload checks date on startup, awards if new day. ~1 day.

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
- All resources (Gold, Scrap, Food, Essence)
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
| **Scrap** | Manual scavenge + auto-scrap (upgrade) | Archer unlocks, damage upgrades |
| **Food** | Manual farm + auto-food (upgrade) | Upkeep for archers, survivors, workers |
| **Essence** | Rare drops, boss kills, quest rewards | Engineering tree, advanced buildings, rituals |

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

#### Unlock Design — Earned, Not Bought

Archers are the player's primary automation — each one is a milestone, not a purchase.

| Archer | Unlock Cost | Additional Gate |
|--------|------------|-----------------|
| **1st** | 50 Gold | Tutorial — free after first 10 kills |
| **2nd** | 150 Gold + 30 Scrap | Kill 50 monsters |
| **3rd** | 400 Gold + 100 Scrap + 20 Food | Survive 5 waves |
| **4th** | 1000 Gold + 300 Scrap + 50 Food | Defeat first boss OR reach wave 15 |

**Why gates:** The 4th archer should *hurt* to earn. The player remembers the moment they unlocked it. This transforms automation from "I bought a thing" to "I earned my wall."

#### Recruitment Ceremony

Each archer has a name (from a pool of Batrachian names), a short one-line intro, and a visual effect on unlock. Examples:
- "Kael takes position on the wall." (archer 1 — steady, reliable)
- "Lyra's arrows will darken the sky." (archer 3 — earned, powerful)

**Names pool:** 8+ Batrachian names (Kael, Lyra, Torvin, Sera, Brann, Vexa, Oric, Myra). Randomly assigned on unlock. Names persist through saves.

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

#### Resources

| Resource | Category | Source | Spent On |
|----------|----------|--------|----------|
| **Gold** | Core | Combat kills | Unlocks, general upgrades, prestige |
| **Scrap** | Core | Manual scavenge + auto-scrap (upgrade) | Archer unlocks, combat upgrades, wall repairs |
| **Food** | Core | Manual farm + auto-food (upgrade) | Upkeep for archers, survivors, workers |
| **Essence** | Rare | Boss kills, quest rewards, achievements | Engineering tree, advanced buildings, rituals |

**Design rule:** Only 3 resources visible in the HUD at any time (Gold, Scrap, Food). Essence is a rare resource that appears in its own UI context (Engineering menu, crafting) — never cluttering the main display.

#### Unlock Order — Learn Before You Spend

The player learns to *produce* resources before they learn to *spend* them.

```
Start: Gold only (clicks matam skeletons)
    ↓ ~30 segundos
Storeroom → Scrap (manual scavenge desbloqueado)
    ↓ ~1-2 minutos  
Farm → Food (manual farm desbloqueado)
    ↓ "O keep está a produzir. Agora preciso de defesas."
1st Archer → custa Scrap + Food upkeep
    ↓ O jogador já percebeu a economia
```

**Auto-production is a separate upgrade.** Unlocking Storeroom gives manual scavenge. Auto-scrap is purchased later. Same for Farm → auto-food. This preserves the automation arc: manual → earned automation.

#### Energy System (Manual Actions)

Manual scavenge and farming use an Energy pool instead of cooldowns. Burst → pause → burst rhythm.

| Property | Default | Upgrade |
|----------|---------|---------|
| Energy Max | 10 | +5 per level (upgrade) |
| Energy Regen | 1 per 5s | -0.5s per level (upgrade) |
| Scavenge Cost | 2 Energy → 5 Scrap | Yield scales with Scavenging |
| Farm Cost | 2 Energy → 3 Food | Yield scales with Farming |

**Why Energy over cooldowns:** The player can burst 5 actions (2 Energy × 5 = 10) then let it recharge. More tactical than "wait 15 seconds." The pause is natural — energy recharges while archers fire. Upgrades to EnergyMax and EnergyRegen feel meaningful because they directly increase burst capacity.

#### Combat Income (Exponential Scaling)

Monster gold × `gold_drop_multiplier`. All damage scales **exponentially** — numbers multiply, not add.

| Upgrade | Base | Formula | Level 5 | Level 10 |
|---------|------|---------|---------|----------|
| Click Damage (Strength) | 1 | ×1.5 per level | 7.6 | 57.7 |
| Arrow Damage (Gear) | 0.25 | ×1.4 per level | 1.3 | 7.2 |
| Gold Multiplier (Pocket Search) | 1.0× | ×1.3 per level | 3.7× | 13.8× |

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
| 4 | **Engineering** | — (new) | Unlocks engineering tree nodes, build speed, Essence efficiency | Building/upgrading structures |
| 5 | **Leadership** | Archers, Pocket Search | Max archers, gold multiplier, survivor morale | Recruiting survivors, surviving waves |

**Skill gating:** Skill levels unlock new mechanics. Engineering 3 → Essence refinery. Leadership 4 → 5th archer. Combat 5 → critical hits.

**My transition plan:** Port the 9 flat upgrades as-is for MVP (they work, they're tested). Add the 5-skill system post-MVP. Players keep their progress — upgrades convert to equivalent skill levels.

### 3.8 Quest System (NEW)

Structured objectives that give direction without taking away agency.

| Component | Description |
|-----------|-------------|
| **Quest board** | 3 active quest slots. Complete one, a new one appears. |
| **Types** | Milestone (kill X, collect Y), Survivor (level up, recruit), Boss (defeat named boss), Prestige (complete all in cycle) |
| **Rewards** | Gold, Essence, rare survivor traits, prestige currency |
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
| **Random** | % chance per wave, increases with stage | 5× HP, 3× damage, unique attack pattern | Gold, Essence |
| **Quest** | Summoned via quest completion | Named, 10× HP, unique mechanics, phases | Prestige currency, survivor trait, engineering recipe |

**My approach:** Random bosses keep the siege tense. Quest bosses give structure and clear progression gates.

### 3.11 Engineering System (NEW)

A tech tree that unlocks through skill levels. Permanent upgrades, buildings, and automation.

| Tier | Unlocks at | Examples |
|------|-----------|----------|
| **T1** | Engineering 1 | Reinforced walls (+10% HP), basic traps (slow enemies) |
| **T2** | Engineering 3 | Essence refinery (auto-essence production), ballista tower (heavy damage) |
| **T3** | Engineering 5 | Auto-repair (walls self-heal), signal fire (survivor loyalty boost) |
| **T4** | Engineering 7 | Foundry (permanent damage bonus through prestige), thunder dome (boss arena — farmable) |

**Key rule:** Engineering recipes persist through prestige. Once you learn to build a ballista, you keep that knowledge forever. This is the primary long-term progression anchor.

**Costs:** Buildings cost Essence + Scrap. Upgrades cost Essence + Gold. Essence is the engineering bottleneck — scarce, valuable, boss-gated.

### 3.12 Prestige System — The Chronicle (MVP → Expand)

**Approach:** Hybrid. MVP ships with a minimal but functional prestige loop. Post-MVP expands it with theming, narrative, and deeper upgrades. The code is architected for expansion from day one — not a throwaway implementation.

#### Phase 1 — Chronicle Minimum (MVP)

| Aspect | Detail |
|--------|--------|
| **Currency** | Chronicle Points (CP). Based on resources the player holds at prestige + milestone bonuses. |
| **Formula** | `CP = floor(sqrt(Gold/1000) + sqrt(Scrap/2000) + sqrt(Food/3000)) + milestone_bonus` |
| **Milestone bonuses** | +1 CP per 5 waves survived, +3 CP per boss killed, +2 CP if no archer died, +1 CP if never hit Famine Mode |
| **Trigger** | Wall-fall = forced prestige. Player can also choose to "Record the Chronicle" from pause menu after wave 15. |
| **Persists** | CP (currency), achievement titles, engineering recipes (post-MVP) |
| **Resets** | Resources (Gold, Scrap, Food), archers, upgrades, monster stages, wave count |
| **Shop** | 5 upgrades: +10% starting gold, +25% offline rate, start with 50 scrap, +1 permanent click damage, one cosmetic title |

**Why 3-resource formula:** Every resource matters for prestige. A player who optimized Scrap and Food gets more CP than one who only farmed Gold. The divisors (1000/2000/3000) keep Gold as the primary contributor. `sqrt()` prevents infinite grind.

#### Phase 2 — Chronicle Expanded + Valor Marks (Post-MVP)

| Addition | Detail |
|----------|--------|
| **Narrative** | Keeper speeches at waves 15/20/25. "The Chronicle awaits..." → "Your frogs have fought with honor." |
| **Two-tier currency** | CP (grind currency, always earned) + Valor Marks (merit currency, earned by excellence) |
| **Valor Marks** | +3 per boss killed, +5 per perfect wave (no wall damage), +10 per prestige cycle completed, ×2 if prestige was voluntary |
| **VM shop** | Rare upgrades: start with 1 archer unlocked, permanent +5% all damage, unique cosmetics, second prestige layer unlock |
| **Survivor persistence** | Retire survivors to village, re-hire with CP/VM discount |
| **Cosmetics** | Wall scars from past cycles, unique titles per prestige milestone |

**Why two-tier:** CP rewards *time spent* — anyone can earn it. VM rewards *skill* — only earned by playing well. Together they give both casual and hardcore players something to chase.

#### Code Architecture (Day-One Extensibility)

The prestige system is built with expansion in mind from the first line:

```csharp
// ChroniclePoints.cs — autoload
public int CalculateCP() {
    double cp = Math.Sqrt(GameManager.Gold / 1000.0) 
              + Math.Sqrt(GameManager.Scrap / 2000.0) 
              + Math.Sqrt(GameManager.Food / 3000.0);
    // Milestone bonuses
    // cp += (WaveManager.WavesSurvived / 5);
    // cp += BossTracker.BossesKilled * 3;
    // Post-MVP: Valor Marks calculated separately
    return (int)Math.Floor(cp);
}
```

**Shop as data, not hardcoded:** `ChronicleUpgrade[]` array. Adding upgrades post-MVP = adding rows to the array, not rewriting logic.

---

## 4. Content Plan (MoSCoW)

### Must Do — MVP (3-5 weeks)

| # | Feature | Est. | Depends On |
|---|---------|------|------------|
| M1 | Port 9-upgrade system to C# | 3d | GameManager.cs |
| M2 | Archer system (4 archers, recruitment ceremony, unlock gates) | 3d | Upgrades |
| M3 | Monster system (Skeleton, Zombie, Orc) | 2d | — |
| M4 | Economy (manual + auto collection, 3 resources) | 2d | Upgrades |
| M5 | Save/Load (JSON autoload) | 1d | GameManager |
| M6 | Core UI (resources, upgrades, archer panel) | 3d | All above |
| M7 | Wave system (percentage-based scaling, wave counter, record) | 2.5d | Monsters |
| M8 | Milestone popups (progression visibility) | 1d | GameManager signals |
| M9 | Boss hunting (3 mini-bosses at waves 10/20/30) | 2d | M7, M3 |
| M10 | Chronicle prestige (CP calc, 5-upgrade shop, wall-fall trigger) | 2d | GameManager, SaveLoad |
| M11 | Welcome back screen (offline summary popup) | 1d | GameManager, WaveManager |
| M12 | Daily login bonus (7-day streak, free rewards) | 1d | GameManager, SaveLoad |
| M13 | Sound effects (archers, monsters, UI, ambient) | 5d | — |
| **Total MVP** | | **30d (~6 weeks)** | |

### Should Do — Post-MVP (6-10 weeks)

| # | Feature | Est. | Depends On |
|---|---------|------|------------|
| S1 | Survivor system (6 named, stats, leveling) | 5d | Economy (Food upkeep) |
| S2 | 5-skill system (replacing 9 upgrades) | 5d | Survivors |
| S3 | Challenge modifiers (risk/reward, 6+ modifiers) | 3d | Waves, Bosses |
| S4 | Boss system (random + quest, full) | 4d | M9 boss hunting |
| S5 | Quest system (3 slots, 4 types) | 4d | Bosses |
| S6 | Essence resource (drops, engineering costs, refinery) | 2d | Economy |
| S7 | Engineering tree (T1-T2) | 5d | Skills, Essence |
| S8 | Chronicle expanded (narrative, full shop, survivor persistence) | 5d | Prestige MVP |
| S9 | Visual base evolution (wall states, building visuals) | 4d | Core UI |
| **Total Should Do** | | **28d (~6 weeks)** | |

### Could Do — Polish & Depth (6-9 weeks)

| # | Feature | Est. | Depends On |
|---|---------|------|------------|
| C1 | Achievement system (38 achievements) | 3d | All Should Do |
| C2 | Engineering T3-T4 | 4d | Engineering T1-T2 |
| C3 | Prestige system (dual trigger, currency) | 5d | Bosses, Engineering |
| C4 | Archer tier system (Scout → Marksman → Ranger) | 3d | Archers |
| C5 | Music & ambient soundtrack | 5d | — |
| C6 | Animated UI feedback (damage numbers, popups) | 4d | Core UI |
| C7 | Orc + Demon monsters | 3d | Monster system |
| **Total Could Do** | | **27d (~6 weeks)** | |

---

## 5. C# Conversion Plan

**Strategy:** Two phases. Phase A ports every system that already works in the GDScript prototype. Phase B adds new MVP features. No new features until the port is complete.

### Phase A — Port Existing Systems (prototype → C#)

| # | System | Source | Target | Status |
|---|--------|--------|--------|:---:|
| 1 | GameManager | `GameManager.gd` | `Scripts/GameManager.cs` | ✅ Complete |
| 2 | Save & Load | `Save&Load.gd` | `Scripts/SaveLoad.cs` | ✅ Complete |
| 3 | BaseMob (enemy base) | `Scripts/EnemyBase.gd` | `Scripts/BaseMob.cs` | ✅ Complete |
| 4 | Enemy variants (Skeleton, Zombie) | `Scripts/Enemy*.gd` | `Scripts/Skeleton.cs` | 🟡 |
| 5 | Arrow + combat (click + projectile) | `Scripts/Arrow.gd` | `Scripts/Arrow.cs` | ⬜ |
| 6 | Upgrades (9-flat system) | `Scripts/Upgrade*.gd` | `Scripts/UpgradeManager.cs` | ⬜ |
| 7 | Economy (timers, auto-collection) | In GameManager | Integrated in GameManager.cs | ⬜ |
| 8 | UI (resource bars, upgrade panel) | Scene scripts | Scene scripts | ⬜ |

**Done = prototype fully functional in C#.** At this point, the C# version plays exactly like the GDScript prototype.

### Phase B — New MVP Features (not in prototype)

| # | System | Target | Depends On | Status |
|---|--------|--------|------------|:---:|
| B1 | Wave counter + record | `Scripts/WaveManager.cs` | Phase A complete | ⬜ |
| B2 | Archer ceremony + unlock gates | Modified `Scripts/ArcherManager.cs` | Phase A complete | ⬜ |
| B3 | Milestone popups | `Scripts/MilestonePopup.cs` + UI | Phase A complete | ⬜ |
| B4 | Boss hunting (3 bosses) | `Scripts/BossSpawner.cs` | B1 | ⬜ |
| B5 | Chronicle prestige | `Scripts/ChroniclePoints.cs` | B1 | ⬜ |
| B6 | Welcome back screen | `Scenes/WelcomeBackPopup.tscn` | B1 | ⬜ |
| B7 | Daily login bonus | `Scripts/DailyBonusManager.cs` | B5 | ⬜ |
| B8 | Sound effects | `Assets/Sounds/` | Phase A complete | ⬜ |

**Done = Kero Keep MVP shipped.** All 13 systems from the content plan are functional.

### Post-MVP — New Systems

| # | System | C# Target | Status |
|---|--------|-----------|:---:|
| 8 | Survivors | TBD | ⬜ |
| 9 | Skills (5-skill) | TBD | ⬜ |
| 10 | Quests | TBD | ⬜ |
| 11 | Achievements | TBD | ⬜ |
| 12 | Bosses (full) | TBD | ⬜ |
| 13 | Challenge modifiers | TBD | ⬜ |
| 14 | Engineering | TBD | ⬜ |
| 15 | Prestige expanded | TBD | ⬜ |

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
- [ ] 4 archers placeable, firing arrows, with recruitment ceremony + unlock gates
- [ ] Manual + auto economy working (Scrap, Food)
- [x] Save/Load working (auto-save every 60s, JSON to user://savegame.json)
- [ ] Core UI: resource bars, upgrade panel, archer panel
- [ ] Wave system: percentage-based scaling, endless, wave counter + record
- [ ] Boss hunting: 3 mini-bosses at waves 10, 20, 30
- [ ] Milestone popups: combat, economy, archer, wave triggers
- [ ] Chronicle prestige: CP calculation, 5-upgrade shop, wall-fall trigger, pause menu option
- [ ] Welcome back screen: offline summary with resources, waves, archer status
- [ ] Daily login bonus: 7-day streak, free rewards, no pay-to-win
- [ ] Sound effects: archers firing, monsters dying, UI clicks, ambient

### What I'm Cutting from MVP

| Feature | Why | When It Comes Back |
|---------|-----|-------------------|
| Survivor system | Adds complexity before the core is stable | Post-MVP |
| 5-skill system | Port 9-upgrade first, transition later | Post-MVP |
| Bosses | Needs stable monster + wave system first | Post-MVP |
| Quests | Needs bosses for boss quest type | Post-MVP |
| Essence resource | Needs bosses + quests to be meaningful | Post-MVP |
| Engineering tree | Needs skills + Essence | Post-MVP |
| Achievements | Polish layer | Polish phase |
| Challenge modifiers | Needs wave + boss data to calibrate | Post-MVP |
| Visual base evolution | Needs core UI + assets stable first | Post-MVP |
| Chronicle expanded (narrative, full shop) | MVP ships with minimal prestige | Post-MVP |

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
| 8 | **Resource bloat** — 4 resources is too many for an idle game | Low | Low | Start with 3 (Gold, Scrap, Food). Add Essence post-MVP. 4th resource appears in own UI context, never clutters HUD. |
| 9 | **Offline simulation accuracy** — too generous or too punishing | Low | Low | Percentage-based formula. Tune with real play data. Conservative defaults. |
| 10 | **"X meets Y" never found** — game lacks easy pitch | Low | Low | Play more games in the genre. Note influences. Not a blocker — game can stand on its own. |

**Riskiest assumption:** That the B/C hybrid (named survivors + engineering tree + 5 skills) is fun as a package before all pieces exist. My mitigation: MVP first, expand only when core is proven fun.

---

## 8. Tuning Variables

### Combat

| Variable | Default | Formula | Notes |
|----------|---------|---------|-------|
| Click damage | 1 | ×1.5 per level | Exponential — level 10 = 57.7 |
| Arrow damage | 0.25 | ×1.4 per level | Exponential — level 10 = 7.2 |
| Gold multiplier | 1.0× | ×1.3 per level | Exponential — level 10 = 13.8× |
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
