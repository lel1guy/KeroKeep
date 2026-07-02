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

    //Upgrades
    public int ClickDamage { get; set; } = 1;
    public float ArrowDamage { get; set; } = 0.25f;
    public int ArrowCount { get; set; } = 1;
    public float GoldDropMultiplier { get; set; } = 1.0f;
    public int ArcherCount { get; set; } = 0;
    public int MaxArcherCount { get; set; } = 4;
    public int UnlockedStage { get; set; } = 0;
    public int UpgradeLevel { get; set; } = 1;


    //Resource Managment
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
