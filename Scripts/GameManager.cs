using Godot;
using System;

namespace KeroKeep
{

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

    //Food Management
    public float FarmTime { get; set; } = 4f;
    public int FoodPerFarm { get; set; } = 5;
    public bool AutoFarm { get; set; } = false;
    public float AutoFarmTimer { get; set; } = 2f;
    public int AutoFarmAmount { get; set; } = 1;
    
    // Scrap Management
    public float ScavangeTime { get; set; } = 15f;
    public int ScrapPerScavange { get; set; } = 10;
    public bool AutoScavange { get; set; } = false;
    public float AutoScavangeTimer { get; set; } = 2f;
    public int AutoScavangeAmount { get; set; } = 1;

    // Auto Resource Management
    public float AutoResourceTimer { get; set; } = 1f;

    //Last Save Time
    public float LastSaveTime { get; set; } = 0f;


    //Resource Managment
    public void AddGold(int amount)
    {
        Gold += amount;
        EmitSignal(SignalName.GoldChanged, Gold);
    }

    public void AddFood(int amount)
    {
        if (!FarmUnlocked) return;
        Food += amount;
        EmitSignal(SignalName.FoodChanged, Food);
    }

    public void AddScrap(int amount)
    {
        if(!StoreroomUnlocked) return;
        Scrap += amount;

        EmitSignal(SignalName.ScrapChanged, Scrap);
    }

    public void SpendResources(int costGold, int costFood, int costScrap)
    {
        if (costGold > 0)
        {
            Gold -= costGold;
            EmitSignal(SignalName.GoldChanged, Gold);
        }

        if (costFood > 0)
        {
            Food -= costFood;
            EmitSignal(SignalName.FoodChanged, Food);
        }

        if (costScrap > 0)
        {
            Scrap -= costScrap;
            EmitSignal(SignalName.ScrapChanged, Scrap);
        }

    }

    public bool CanAfford(int costGold, int costFood, int costScrap)
    {
        return Gold >= costGold && Food >= costFood && Scrap >= costScrap;
    }

    public int GetUpgradeCost(int baseCost, int level, float growth)
    {
        if (baseCost == 0) return 0;
        return (int)(baseCost * Mathf.Pow(growth, level));
    }

    public override void _Ready()
    {
        var timer = new Timer();
        timer.WaitTime = AutoResourceTimer;
        timer.Autostart = true;
        timer.Timeout += OnAutoResourceTimerTimeout;
        AddChild(timer);
    }

    private void OnAutoResourceTimerTimeout()
    {
        if (AutoFarm)
        {
            AddFood(AutoFarmAmount);
        }

        if (AutoScavange)
        {
            AddScrap(AutoScavangeAmount);
        }
    }

    public override void _Notification(int what)
    {
        if (what == NotificationWMCloseRequest)
        {
            //SaveLoad.SaveGame();
            GetTree().Quit();
        }

        else if (what == NotificationWMGoBackRequest)
        {
            //SaveLoad.SaveGame();
            GetTree().Quit();
        }

        else if (what == NotificationApplicationPaused || what == NotificationApplicationFocusOut)
        {
            //SaveLoad.SaveGame();
        }
    }
}
}