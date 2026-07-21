using Godot;
using System;

namespace KeroKeep
{
public partial class GameManager : Node
{

      private SaveLoad _saveLoad;


    // Resources Signals
    [Signal]
    public delegate void GoldChangedEventHandler(int amount);

    [Signal]
    public delegate void FoodChangedEventHandler(int amount);

    [Signal]
    public delegate void ScrapChangedEventHandler(int amount);

    [Signal]
    public delegate void MageCountChangedEventHandler(int count);
    
    // Resources
    public int Gold { get; set; } = 0;
    public int Food { get; set; } = 0;

    public int Scrap { get; set; } = 0;


    // Unlocks
    public bool StoreroomUnlocked { get; set; } = false;
    public bool FarmUnlocked { get; set; } = false;

    //Upgrades
    public int ClickDamage { get; set; } = 1;
    public float BoltDamage { get; set; } = 0.25f;
    public int BoltCount { get; set; } = 1;
    public float GoldDropMultiplier { get; set; } = 1.0f;
    public int MageCount { get; set; } = 0;
    public int MaxMageCount { get; set; } = 4;
    public int UnlockedStage { get; set; } = 0;
    public int UpgradeLevel { get; set; } = 1;

    //Food Management
    public float FarmTime { get; set; } = 4f;
    public int FoodPerFarm { get; set; } = 5;
    public bool AutoFarm { get; set; } = false;
    public float AutoFarmTimer { get; set; } = 2f;
    public int AutoFarmAmount { get; set; } = 1;
    
    // Scrap Management
    public float ScavengeTime { get; set; } = 15f;
    public int ScrapPerScavenge { get; set; } = 10;
    public bool AutoScavenge { get; set; } = false;
    public float AutoScavengeTimer { get; set; } = 2f;
    public int AutoScavengeAmount { get; set; } = 1;

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

        _saveLoad = GetNode<SaveLoad>("/root/SaveLoad");

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

        if (AutoScavenge)
        {
            AddScrap(AutoScavengeAmount);
        }
    }

    public override void _Notification(int what)
    {
        if (what == NotificationWMCloseRequest)
        {
            _saveLoad.SaveGame();
            GetTree().Quit();
        }

        else if (what == NotificationWMGoBackRequest)
        {
            _saveLoad.SaveGame();
            GetTree().Quit();
        }

        else if (what == NotificationApplicationPaused || what == NotificationApplicationFocusOut)
        {
            _saveLoad.SaveGame();
        }
    }

    public void AddMage()
        {
            if (MageCount < MaxMageCount)
            {
                MageCount += 1;
                EmitSignal(SignalName.MageCountChanged, MageCount);
            }

            else
            {
                MageCount = MaxMageCount;
            }
        }

    public void LoadState(Godot.Collections.Dictionary data)
        {
            Gold = data.ContainsKey("gold")
                ? data["gold"].AsInt32()
                : 0;

            Food = data.ContainsKey("food")
                ? data["food"].AsInt32()
                : 0;

            Scrap = data.ContainsKey("scrap")
                ? data["scrap"].AsInt32()
                : 0;

            StoreroomUnlocked = data.ContainsKey("storeroomUnlocked")
                ? data["storeroomUnlocked"].AsBool()
                : false;
            
            FarmUnlocked = data.ContainsKey("farmUnlocked")
                ? data["farmUnlocked"].AsBool()
                : false;

            ClickDamage = data.ContainsKey("clickDamage")
                ? data["clickDamage"].AsInt32()
                : 1;
            
            BoltDamage = data.ContainsKey("BoltDamage")
                ? data["BoltDamage"].AsSingle()
                : 0.25f;

            BoltCount = data.ContainsKey("BoltCount")
                ? data["BoltCount"].AsInt32()
                : 1;
            
            GoldDropMultiplier = data.ContainsKey("goldDropMultiplier")
                ? data["goldDropMultiplier"].AsSingle()
                : 1.0f;
            
            MageCount = data.ContainsKey("MageCount")
                ? data["MageCount"].AsInt32()
                : 0;

            MaxMageCount = data.ContainsKey("maxMageCount")
                ? data["maxMageCount"].AsInt32()
                : 4;

            UnlockedStage = data.ContainsKey("unlockedStage")
                ? data["unlockedStage"].AsInt32()
                : 0;

            UpgradeLevel = data.ContainsKey("upgradeLevel")
                ? data["upgradeLevel"].AsInt32()
                : 1;

            FarmTime = data.ContainsKey("farmTime")
                ? data["farmTime"].AsSingle()
                : 4f;
            
            FoodPerFarm = data.ContainsKey("foodPerFarm")
                ? data["foodPerFarm"].AsInt32()
                : 5;

            AutoFarm = data.ContainsKey("autoFarm")
                ? data["autoFarm"].AsBool()
                : false;
            
            AutoFarmTimer = data.ContainsKey("autoFarmTimer")
                ? data["autoFarmTimer"].AsSingle()
                : 2f;
            
            AutoFarmAmount = data.ContainsKey("autoFarmAmount")
                ? data["autoFarmAmount"].AsInt32()
                : 1;
            
            ScavengeTime = data.ContainsKey("ScavengeTime")
                ? data["ScavengeTime"].AsSingle()
                : 15f;

            ScrapPerScavenge = data.ContainsKey("scrapPerScavenge")
                ? data["scrapPerScavenge"].AsInt32()
                : 10;

            AutoScavenge = data.ContainsKey("autoScavenge")
                ? data["autoScavenge"].AsBool()
                : false;

            AutoScavengeTimer = data.ContainsKey("autoScavengeTimer")
                ? data["autoScavengeTimer"].AsSingle()
                : 2f;

            AutoScavengeAmount = data.ContainsKey("autoScavengeAmount")
                ? data["autoScavengeAmount"].AsInt32()
                : 1;

            AutoResourceTimer = data.ContainsKey("autoResourceTimer")
                ? data["autoResourceTimer"].AsSingle()
                : 1f;

            LastSaveTime = data.ContainsKey("lastSaveTime")
                ? data["lastSaveTime"].AsSingle()
                : 0f;

            
        }
}
}