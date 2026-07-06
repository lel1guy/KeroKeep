# Dev Log — Kero Keep

> Port `GameManager.gd` → `GameManager.cs`. Kero Keep C# conversion. Formerly "LastBastion" — renamed 2026-07-04.

---

## Session 1 — 2026-07-01

**Source:** Discord (#hermes-chat)
**Duration:** ~1.5 hours
**Status:** 🟡 In progress — 6 of 10 chunks done

### What Was Built

| Chunk | What | Status |
|-------|------|:---:|
| 1 | Skeleton (`partial class`, `using Godot`, namespace) | ✅ |
| 2 | 3 signals (`GoldChanged`, `FoodChanged`, `ScrapChanged`) | ✅ |
| 3 | Core resource properties (`Gold`, `Scrap`, `Food` with `private set`) | ✅ |
| 4 | Unlock flags + combat stats (10 properties with `get; set;`) | ✅ |
| 5 | Economy timer properties | ⬜ |
| 6 | Resource methods (`AddGold`, `AddScrap`, `AddFood`) — partial (no signals yet) | 🟡 |
| 7 | `SpendResources`, `CanAfford`, `GetUpgradeCost` | ⬜ |
| 8 | `_Ready()` with timer setup | ⬜ |
| 9 | `_Notification()` for save-on-close | ⬜ |
| 10 | Register as autoload in Godot | ⬜ |

### Concepts Learned

| Concept | Where | Absorbed? |
|---------|-------|:---:|
| `partial class` — why Godot needs it | Chunk 1 | ✅ |
| `using Godot;` — imports all Godot types | Chunk 1 | ✅ |
| `namespace` — code organization | Chunk 1 | ✅ |
| `[Signal] delegate` — signals in C# | Chunk 2 | ✅ |
| `{ get; private set; }` vs `{ get; set; }` — access control | Chunks 3, 4 | ✅ |
| `f` suffix for float literals (`0.25f`) | Chunk 4 | ✅ |
| PascalCase convention (properties, methods) | Chunks 3, 4 | ✅ |
| `void` return type — "returns nothing" | Chunk 6 (started) | 🟡 |
| `bool` return type — "returns true/false" | — | ⬜ |
| `EmitSignal(SignalName.X, value)` — signal emission | — | ⬜ |
| Early return pattern (`if (!condition) return;`) | — | ⬜ |
| `Mathf.Pow()` — Godot math in C# | — | ⬜ |
| Casting: `(int)value` vs GDScript `int(value)` | — | ⬜ |
| `override` keyword for `_Ready()` | — | ⬜ |
| Event subscription: `timer.Timeout += Method` | — | ⬜ |

### Code Written (Session 1)

```csharp
using Godot;
using System;

namespace LastBastion;

public partial class GameManager : Node
{
    // Resources Signals
    [Signal]
    public delegate void GoldChangedEventHandler(int amount);

    [Signal]
    public delegate void FoodChangedEventHandler(int amount);

    [Signal]
    public delegate void ScrapChangedEventHandler(int amount);
    
    // Resources
    public int Gold { get; private set; } = 0;
    public int Food { get; private set; } = 0;
    public int Scrap { get; private set; } = 0;

    // Unlocks
    public bool StoreroomUnlocked { get; set; } = false;
    public bool FarmUnlocked { get; set; } = false;

    // Upgrades
    public int ClickDamage { get; set; } = 1;
    public float ArrowDamage { get; set; } = 0.25f;
    public int ArrowCount { get; set; } = 1;
    public float GoldDropMultiplier { get; set; } = 1.0f;
    public int ArcherCount { get; set; } = 0;
    public int MaxArcherCount { get; set; } = 4;
    public int UnlockedStage { get; set; } = 0;
    public int UpgradeLevel { get; set; } = 1;

    // Resource Management
    public void AddGold(int amount)
    {
        Gold += amount;
    }

    public void AddFood(int amount)
    {
        Food += amount;
    }

    public void AddScrap(int amount)
    {
        Scrap += amount;
    }
}
```

### What's Missing in Current Methods

- `AddGold` — needs `EmitSignal(SignalName.GoldChanged, Gold)`
- `AddScrap` — needs storeroom unlock check + `EmitSignal`
- `AddFood` — needs farm unlock check + `EmitSignal`
- All three methods need signal emission before they're complete

### Decisions Made

- Project structure: `Scripts/`, `Scenes/`, `Assets/` under `lastbastioncs`
- Removed unused `using System.Dynamic;`
- Session paused at Chunk 6 — V wanted detailed explanation of method concepts before continuing
- **Repo pushed to GitHub** — `lel1guy/KeroKeep` (private) created 2026-07-02 with initial commit

### Pitfalls Encountered

| Pitfall | Fix |
|---------|-----|
| Hermes wrote code in Chunks 3-4 instead of describing | V called it out. Hermes corrected — description-only from Chunk 5 onward |
| `using System.Dynamic;` auto-added (unused) | Removed |
| Typo `ammount` → `amount` in signal params | Fixed |
| Missing `namespace LastBastion;` | Added |
| Hermes forgot Rule #1 (document everything) | Fixed — this log created, memory updated |

### Next Session

1. ~~Remind V to push to GitHub~~ ✅ Done — `lel1guy/KeroKeep` created 2026-07-02
2. Resume at `EmitSignal` — add signal emission to all three resource methods
3. Add unlock checks (`if (!StoreroomUnlocked) return;`)
4. Write `SpendResources`, `CanAfford`, `GetUpgradeCost`
5. Economy timer properties
6. `_Ready()` with timer setup + `override`
7. `_Notification()` for save-on-close
8. Register `GameManager` as autoload in Godot
9. **Build after every chunk** — catch errors early

### Files Modified

- `D:\Game Development\Projects\lastbastioncs\Scripts\GameManager.cs` — created, 6 of 10 chunks complete

---

## Session 2 — 2026-07-02 (GDD Rewrite)

**Source:** Discord (#hermes-chat)
**Duration:** ~2 hours
**Status:** ✅ Complete — GDD fully redesigned

### What Was Done

Complete rewrite of the Game Design Document. No code written — design only.

| Area | What Changed |
|------|-------------|
| **Vision & Pillars** | Expanded feeling table (boss encounter, prestige reset). New systems note added. |
| **Core Loop** | Three-loop model expanded. 2.4-2.7 added for quests, achievements, bosses, prestige. |
| **Systems (3.1-3.12)** | 7 new system sections: Survivor, Skill, Quest, Achievement, Boss, Engineering, Prestige. |
| **Design philosophy** | B/C hybrid — named survivors with stats (Option B) + skill levels, engineering tree, siege waves (Option C). |
| **Content Plan** | MoSCoW with dev time estimates (MVP: 3-5 weeks, Should Do: 6-10 weeks, Could Do: 6-9 weeks). |
| **C# Conversion Plan** | Core systems + new systems mapped to C# targets. Architecture decision: port upgrade system first, transition to skills later. |
| **MVP/Cut List** | New section. MVP checklist, explicit cut list, anti-cut list. |
| **Risk Assessment** | New section. 10 risks with probability/impact/mitigation. Riskiest assumption identified. |
| **Tuning Variables** | New section. 5 categories of tunable knobs with default values and ranges. |

### Key Design Decisions

| Decision | Rationale |
|----------|-----------|
| 6 survivors max (3 farm, 3 scavenge) | Enough for attachment without spreadsheet overload |
| Siege waves: percentage-based | P2 Persistent Siege — unpredictable = tense |
| Bosses: random spawn + quest bosses | Hybrid approach. Random keeps tension, quest gives structure |
| Prestige trigger: final quest boss OR wall fall | Dual path — player choice, never forced |
| 5 skills replacing 9 flat upgrades | More depth, more earned. Old system ported as-is for MVP |
| Engineering tree unlocking through skill levels | Natural progression. Recipes persist through prestige |

### Open Design Questions

- ~~What resources exist?~~ → Gold, Scrap, Food, **Oil**, **Bones** (added)
- How many archer types / tiers? *(still open)*
- Should achievements grant rewards, or purely cosmetic? *(TBD)*
- Exact values for boss HP/gold multipliers — 5× or 10×? *(tuning phase)*
- "X meets Y" formula — V hasn't found comparison yet *(pending)*
- Comparable titles table *(pending)*

---

## Session 3 — 2026-07-04 (Rename & World-Building)

**Source:** Discord (#hermes-chat)
**Type:** Design — rename & world-building

### What Happened

- **Renamed game:** LastBastion → **Kero Keep** — last fortress of the kingdom of Batrachia
- **Civilization:** Humanoid frogs — armored, bow-wielding, medieval fantasy warriors. Not comedic.
- **Kingdom:** Batrachia — the ancient realm whose last wall is Kero Keep
- **Name check:** "Kero Keep" — no conflicts on itch.io, Steam, or Google
- **GDD updated:** New header, elevator pitch, Setting & World section, all prose references

### Design Decisions

| Decision | Rationale |
|----------|-----------|
| Name: Kero Keep | Frog identity (kero = frog croak), clear genre signal (keep = fortress). Distinctive on itch.io. |
| Kingdom: Batrachia | Epic, ancient-sounding. Greek root (batrachos = frog). Gives depth behind the simple name. |
| Frog civilization | Visual distinction in crowded idle/clicker genre. Opens unique enemy types, architecture, animations. Core mechanics unchanged. |

### Open Questions

- [x] Folder rename: `Game Dev/LastBastion/` → `Game Dev/KeroKeep/` ✅ Done (2026-07-04)
- [x] GitHub repo rename: `LastBastionCS` → `KeroKeep` ✅ Done (2026-07-04)
- [x] C# namespace: `namespace LastBastion;` → `namespace KeroKeep;` ✅ Decided — rename

---

## Session 4 — 2026-07-04 (Sprint 1 Completed)

**Source:** Discord (#game-dev)
**Duration:** ~1 hour
**Status:** ✅ Complete — GameManager.cs Sprint 1 finished

### What Was Done

Resumed Sprint 1 from Chunk 6 and completed the remaining 4 chunks + autoload registration.

| Chunk | What | Status |
|-------|------|:---:|
| 5 | Economy timer properties (11 properties) | ✅ |
| 6 | Resource methods + `EmitSignal` + unlock gates | ✅ |
| 7 | `SpendResources`, `CanAfford`, `GetUpgradeCost` | ✅ |
| 8 | `_Ready()` + auto-resource timer + `override` | ✅ |
| 9 | `_Notification()` — save-on-close | ✅ |
| 10 | Register `GameManager` as Godot autoload | ✅ |

### Concepts Learned

| Concept | Where | Absorbed? |
|---------|-------|:---:|
| `EmitSignal(SignalName.X, value)` — type-safe signal emission | AddGold/Food/Scrap, SpendResources | ✅ |
| Early return / guard clause (`if (!cond) return;`) | AddScrap, AddFood | ✅ |
| `&&` (logical AND) / `||` (logical OR) | CanAfford, _Notification | ✅ |
| `Mathf.Pow(x, y)` — Godot math in C# | GetUpgradeCost | ✅ |
| `(int)(value)` cast — C-style before the value | GetUpgradeCost | ✅ |
| `override` keyword — required for lifecycle methods | _Ready, _Notification | ✅ |
| Event subscription: `timer.Timeout += Method` | _Ready | ✅ |
| `else if` (two words) — replaces GDScript `elif` | _Notification | ✅ |
| Godot notification constants (`NotificationWMCloseRequest`, etc.) | _Notification | ✅ |
| `new Timer()` — C# instantiation syntax | _Ready | ✅ |
| File-scoped namespace + `partial class` pattern | Whole file | ✅ |

### Errors Encountered & Fixed

| Error | Fix |
|-------|-----|
| Methods written outside the class (`}` too early) | Moved closing brace to end of file |
| `overide` typo | → `override` |
| `NotificationMCloseRequest` typo | → `NotificationWMCloseRequest` |
| `get_tree()` lowercase | → `GetTree()` |
| `Quit()` called on pause/focus-out branch | Removed — only save, don't quit on alt-tab |
| `SaveGame()` called (method doesn't exist) | Commented out: `// SaveLoad.SaveGame();` |
| Namespace said `LastBastion` | Renamed to `KeroKeep` |

### Final File

`Scripts/GameManager.cs` — 115 lines, 10/10 chunks complete (autoload registered in Godot editor).

### Files Modified

- `Scripts/GameManager.cs` — completed (chunks 5-9)
- `project.godot` — autoload entry added (chunk 10)

### Pitfalls Encountered

| Pitfall | Fix |
|---------|-----|
| Brace discipline — closing `}` too early orphaned methods | Repeated "is it inside the class?" check each turn |
| Notification constant naming — `WM` prefix easy to miss | Showed full GDScript→C# constant table |
| `Quit()` on pause — would kill app on alt-tab | Caught during review, corrected to save-only |

---

## Session 5 — 2026-07-04 (GDD Excalidraw Diagram)

**Source:** Discord (#hermes-chat)
**Duration:** ~20 min
**Status:** ✅ Complete — visual GDD diagram created

### What Was Done

Created a comprehensive Excalidraw diagram (`GDD.excalidraw`) from the canonical GDD — a single-page visual overview suitable for Obsidian.

| Section | Contents |
|---------|----------|
| **Title** | KeroKeep — Game Design Document, subtitle with engine/language/design approach |
| **Design Pillars** | P1 Earned Growth, P2 Persistent Siege, P3 Fair Forever — colored boxes with descriptions |
| **Core Loop** | 5-node flow: Click→Kill → Earn Resources → Unlock+Upgrade → Monsters→Stronger → Quests→Bosses→Prestige |
| **Resource Economy** | 5 resources: Gold, Scrap, Food, Oil, Bones — with earn/spend descriptions |
| **Systems Overview** | 12-system grid (4×3): Archers, Monsters, Economy, Save, Survivors, Skills, Bosses, Engineering, Quests, Achievements, Prestige, Offline Sim |
| **Architecture** | GameManager.cs + SaveLoad.cs autoloads, signal list, save details, C# patterns, scene tree |
| **Content Plan** | MoSCoW timeline: MUST (3-5 wks), SHOULD (6-10 wks), COULD (6-9 wks), anti-cut section |
| **Key Numbers** | 6 survivors, 5 skills, 5 resources, 4 archers, 3 pillars, 2 autoloads |

### Diagram Stats

- **96 elements**: 32 rectangles, 59 text, 5 arrows
- **Colors:** Green (Earned), Blue (Systems), Red (Monsters/Bosses), Purple (Skills/Upgrades), Teal (Save/Engineering), Yellow (Quests/Achievements/Plan), Orange (Survivors/Prestige/Oil)
- **File:** `Game Dev/KeroKeep/GDD.excalidraw` (39 KB)
- **Canvas:** ~1700×1150px

### How to Open

1. In Obsidian: drag `GDD.excalidraw` into a note, or open directly with the Excalidraw plugin
2. Online: visit excalidraw.com → Open → select the file

### Files Modified

- `Game Dev/KeroKeep/GDD.excalidraw` — created

---

## Session 6 — 2026-07-04 (Sprint 2 Started)

**Source:** Discord (#game-dev)
**Duration:** ~30 min
**Status:** 🟡 In progress — Chunk 1 complete, Chunk 2 explained

### What Was Done

| Chunk | What | Status |
|-------|------|:---:|
| 1 | Skeleton (`using Godot`, namespace, `partial class SaveLoad : Node`) | ✅ |
| 2 | `SaveGame()` — detailed explanation given, not yet written | 🟡 |

### Concepts Explained

| Concept | Where | Absorbed? |
|---------|-------|:---:|
| `Godot.Collections.Dictionary` vs C# Dictionary — holds mixed types | SaveGame dict | ⬜ |
| `Json.Stringify()` — static method, no `new` needed | SaveGame serialize | ⬜ |
| `FileAccess.Open(path, ModeFlags)` — replaces GDScript `FileAccess.open()` | SaveGame write | ⬜ |
| `using var` — auto-dispose pattern for file handles | SaveGame write | ⬜ |
| `Time.GetUnixTimeFromSystem()` — returns `double`, needs `(float)` cast | SaveGame timestamp | ⬜ |
| 18 properties to save from GameManager | SaveGame dict | ⬜ |

### Files Modified

- `Scripts/SaveLoad.cs` — created (skeleton + empty `SaveGame()` body)

### Next Session

1. Resume Chunk 2 — V writes `SaveGame()` body with 25-property dictionary

---

## Session 7 — 2026-07-06 (Sprint 2 Completed)

**Source:** Discord (#game-dev)
**Duration:** ~2 hours
**Status:** ✅ Complete — SaveLoad.cs Sprint 2 finished

### What Was Done

| Chunk | What | Where | Status |
|-------|------|-------|:---:|
| 1 | Skeleton (`using Godot`, namespace, `partial class SaveLoad : Node`) | SaveLoad.cs | ✅ |
| 2 | `SaveGame()` — 25 properties → Dictionary → `Json.Stringify()` → `FileAccess` | SaveLoad.cs | ✅ |
| 3 | `LoadGame()` — `FileAccess.FileExists()` guard, `GetAsText()`, `Json.ParseString()`, `.AsGodotDictionary()` | SaveLoad.cs | ✅ |
| 4 | `_Ready()` with `LoadGame()` on startup + auto-save Timer (60s) | SaveLoad.cs | ✅ |
| 5 | `LoadState(Dictionary)` — 25 extractions with `ContainsKey()` + fallback defaults | **GameManager.cs** | ✅ |
| 6 | Register `SaveLoad` as autoload | `project.godot` | ✅ |
| 7 | Uncomment `SaveLoad.SaveGame()` calls — `_saveLoad.SaveGame()` in `_Notification()` | GameManager.cs | ✅ |

### Concepts Learned

| Concept | Where | Absorbed? |
|---------|-------|:---:|
| `Godot.Collections.Dictionary` — variant dictionary, mixed types, no type parameters | SaveGame + LoadState | ✅ |
| `Json.Stringify()` vs GDScript `JSON.stringify()` — static, no `new` | SaveGame | ✅ |
| `Json.ParseString()` returns `Variant` — must call `.AsGodotDictionary()` to extract | LoadGame | ✅ |
| `.AsInt32()`, `.AsBool()`, `.AsSingle()` — extracting typed values from Variant | LoadState | ✅ |
| `ContainsKey("x") ? data["x"].AsType() : default` — GDScript `data.get()` equivalent | LoadState | ✅ |
| `GetNode<T>("/root/Name")` — C# has no autoload magic; must fetch from scene tree | `_Ready` (both files) | ✅ |
| Scene tree vs static access — classes are blueprints, instances are houses | Architecture | ✅ |
| Cross-autoload references: both `SaveLoad` and `GameManager` need `GetNode<>()` to each other | `_Ready` (both files) | ✅ |
| `FileAccess.Open(path, ModeFlags.Write)` — C# enum syntax vs GDScript constant | SaveGame | ✅ |
| `FileAccess.FileExists(path)` — guard before reading | LoadGame | ✅ |
| `file.GetAsText()` — reads entire file to string | LoadGame | ✅ |
| `using var` — auto-dispose pattern for file handles | SaveGame, LoadGame | ✅ |
| `(float)Time.GetUnixTimeFromSystem()` — double → float cast required | SaveGame | ✅ |
| `saveTimer.Timeout += SaveGame` — direct method as callback (no wrapper needed) | `_Ready` | ✅ |
| C# code must be inside methods — not at class level | Lesson from error CS1519 | ✅ |

### Architecture

```
SaveLoad.cs (autoload)              GameManager.cs (autoload)
┌──────────────────────┐            ┌──────────────────────┐
│ _Ready()             │            │ _Ready()             │
│  → GetNode<GM>()     │◄──────────►│  → GetNode<SL>()     │
│  → LoadGame()        │            │  → resource timer    │
│  → auto-save timer   │            │                      │
│                      │            │ _Notification()      │
│ SaveGame()           │───────────►│  → _saveLoad.Save()  │
│  → 25 props → JSON   │            │                      │
│                      │            │ LoadState(dict)      │
│ LoadGame()           │───────────►│  → 25 extrações      │
│  → JSON → dict → GM  │            │                      │
└──────────────────────┘            └──────────────────────┘
```

### Flow

| Trigger | What Happens |
|---------|-------------|
| Game starts | `SaveLoad._Ready()` → `LoadGame()` → `GameManager.LoadState(data)` |
| Every 60 seconds | `SaveLoad._Ready()` timer → `SaveGame()` |
| Window close / go-back | `GameManager._Notification()` → `_saveLoad.SaveGame()` → `GetTree().Quit()` |
| Pause / focus-out | `GameManager._Notification()` → `_saveLoad.SaveGame()` |

### Key C# vs GDScript Differences (This Sprint)

| GDScript | C# |
|----------|-----|
| `var data = {}` | `var data = new Godot.Collections.Dictionary();` |
| `data["gold"] = GameManager.gold` | `data["gold"] = _gameManager.Gold;` |
| `JSON.stringify(data)` | `Json.Stringify(data)` |
| `JSON.new()` + `.parse(json)` | `Json.ParseString(jsonText)` → `Variant` |
| `json.data` | `result.AsGodotDictionary()` |
| `data.get("gold", 0)` | `data.ContainsKey("gold") ? data["gold"].AsInt32() : 0` |
| `FileAccess.open(path, FileAccess.WRITE)` | `FileAccess.Open(path, FileAccess.ModeFlags.Write)` |
| `file.store_string(json)` | `file.StoreString(jsonData)` |
| `file.close()` | `using var` auto-disposes |
| `GameManager.gold = value` | `LoadState()` method (private set blocks external access) |

### Errors Encountered & Fixed

| Error | Cause | Fix |
|-------|-------|-----|
| `CS1519 — Invalid token '=' in a member declaration` | Wrote `GameManager.LastSaveTime = ...` outside any method | Moved into `SaveGame()` body |
| `CS0120 — An object reference is required` (×25) | Used `GameManager.Gold` as if it were static | Added `GetNode<GameManager>("/root/GameManager")` in `_Ready()` |
| `JSON.Stringify` → typo | GDScript muscle memory (`JSON` not `Json`) | Changed to `Json.Stringify()` |
| `key="Gold"` vs `key="gold"` | Inconsistent casing in dictionary keys | Standardised to camelCase for all 25 keys |
| `Json.ParseString(Json)` — passing the class, not the string | Used `Json` (class name) instead of `jsonText` (variable) | `file.GetAsText()` → `string jsonText` → `Json.ParseString(jsonText)` |

### Files Modified

- `Scripts/SaveLoad.cs` — created (60 lines): `_Ready`, `SaveGame`, `LoadGame`
- `Scripts/GameManager.cs` — modified (added `_saveLoad` field, `GetNode<>()`, `LoadState()`, uncommented `SaveGame()` calls)
- `project.godot` — autoload entry added for `SaveLoad`

---

## Session 8 — 2026-07-06 (Sprint 3 Started)

**Source:** Discord (#game-dev)
**Duration:** ~1.5 hours
**Status:** 🟡 In progress — Chunk 1 complete (BaseMob.cs)

### What Was Done

| Chunk | What | Status |
|-------|------|:---:|
| 1 | `BaseMob.cs` — skeleton, properties, `_Ready`, `_PhysicsProcess`, `TakeDamage`, `_InputEvent` | ✅ |
| 2 | `Skeleton.cs` — derived class with specific stats | ⬜ |
| 3 | Spawn — Game/Main scene mob spawning | ⬜ |
| 4 | `Arrow.cs` — projectile with travel + damage | ⬜ |
| 5 | Click→Dano — integrated click attack via `_InputEvent` | ✅ (built into BaseMob) |
| 6 | Loot — gold drop on death | ✅ (built into BaseMob) |
| 7 | ArrowPool — reusable arrow pool | ⬜ |

### BaseMob.cs Structure

```
BaseMob : CharacterBody2D
├── [Export] Health (int, default 1)
├── [Export] Speed (int, default 50)
├── [Export] GoldDrop (int, default 1)
├── Damage (int, public)
├── _Ready() — cache _sprite + _gameManager via GetNode<>()
├── _PhysicsProcess(double) — Velocity = new Vector2(0, Speed)
├── TakeDamage(float) — async void, death animation + loot + queue_free
└── _InputEvent() — @event.IsActionPressed("clickAttack") → TakeDamage
```

### Concepts Learned

| Concept | Where | Absorbed? |
|---------|-------|:---:|
| `[Export] public int Health { get; set; } = 1;` — C# exported property | Properties | ✅ |
| `new Vector2(0, Speed)` — Vector2 struct, immutable X/Y fields | _PhysicsProcess | ✅ |
| `async void` + `await ToSignal()` — async death animation pattern | TakeDamage | ✅ |
| `(int)damage` — float → int cast for Health | TakeDamage | ✅ |
| `@event` prefix — `event` is C# reserved keyword | _InputEvent | ✅ |
| `long shapeIdx` — Godot C# uses long, not int | _InputEvent | ✅ |
| `GetNode<GameManager>("/root/GameManager")` — autoload access in C# | _Ready | ✅ |
| `&&` combining conditions in one if | _InputEvent | ✅ |
| Brace discipline — don't close class before methods are inside | Class structure | ✅ |

### C# vs GDScript Differences (This Sprint)

| GDScript | C# |
|----------|-----|
| `@export var health = 1` | `[Export] public int Health { get; set; } = 1;` |
| `velocity.y = speed` | `Velocity = new Vector2(0, Speed)` |
| `$AnimatedSprite2D` | `GetNode<AnimatedSprite2D>("AnimatedSprite2D")` cached in field |
| `GameManager.add_gold(...)` | `_gameManager.AddGold(...)` via cached reference |
| `await $AnimatedSprite2D.animation_finished` | `await ToSignal(_sprite, AnimatedSprite2D.SignalName.AnimationFinished)` |
| `event.is_action_pressed(...)` | `@event.IsActionPressed(...)` |
| `shape_idx: int` | `long shapeIdx` |
| `queue_free()` | `QueueFree()` |

### Errors Encountered & Fixed

| Error | Cause | Fix |
|-------|-------|-----|
| CS0115 — no suitable method found to override | `int shapeIdx` instead of `long shapeIdx` | Changed to `long shapeIdx` |
| Missing `_sprite.Play("Death")` before await | Jumped straight to `await ToSignal()` without triggering animation | Added `.Play("Death")` line |
| TakeDamage(int) — truncates float arrows to 0 | ArrowDamage is float (0.25f) | Changed to `TakeDamage(float damage)` with `(int)damage` cast |

### Decisions Made

- Sprint 3 scope: Enemies + Combat combined (BaseMob.cs + Arrow.cs + Skeleton.cs)
- Click→Dano and Loot built directly into BaseMob — not separate chunks
- ArrowPool deferred to post-Arrow implementation
- `GoldDrop` property name chosen over prototype's `gold_amout` (typo fix)
- `clickAttack` action name used (camelCase, not `click_attack` with underscore)

### Files Modified

- `Scripts/BaseMob.cs` — created (52 lines): `BaseMob : CharacterBody2D` with 4 properties, 4 methods

### Next Session

1. Build test — verify BaseMob.cs parses with `godot --headless`
2. **Chunk 2: Skeleton.cs** — derive from BaseMob with specific stats (health, speed, sprite)
3. Chunk 3: Spawn — Game/Main scene mob spawning logic
4. Chunk 4: Arrow.cs — projectile system
