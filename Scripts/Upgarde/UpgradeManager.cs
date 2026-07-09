using Godot;
using System;


namespace KeroKeep
{  

    public partial class UpgradeManager : Node
    {
        [Signal]
        public delegate void UpgradePurchasedEventHandler(int index, int newLevel);

        private GameManager _gameManager;
        private UpgradeData[] _upgrades;

        public override void _Ready()
        {
            _gameManager = GetNode<GameManager>("/root/GameManager");
            BuildUpgrades();

        }

        private void BuildUpgrades()
        {
            _upgrades = new UpgradeData[]
            {
                new UpgradeData { ID = "pocket_search",  UpgradeName = "Pocket Search",   BaseGoldCost = 10,  Effect = new PocketSearchEffect() },
                new UpgradeData { ID = "strength",       UpgradeName = "Strength Training", BaseGoldCost = 50, Effect = new StrengthEffect() },
                new UpgradeData { ID = "storeroom",      UpgradeName = "Unlock Storeroom", BaseGoldCost = 50,  Effect = new StoreroomEffect() },
                new UpgradeData { ID = "scavengers",     UpgradeName = "Scavengers",       BaseGoldCost = 75,  BaseScrapCost = 10,  Effect = new ScavengerEffect() },
                new UpgradeData { ID = "farm",           UpgradeName = "Unlock Farm",      BaseGoldCost = 150, BaseScrapCost = 50,  Effect = new FarmUnlockedEffect() },
                new UpgradeData { ID = "farmers",        UpgradeName = "Farmers",          BaseGoldCost = 200, BaseFoodCost = 20,   Effect = new FarmersEffect() },
                new UpgradeData { ID = "archers",        UpgradeName = "Archer Militia",   BaseGoldCost = 200, BaseScrapCost = 100, BaseFoodCost = 50, Effect = new MageEffect() },
                new UpgradeData { ID = "gear",           UpgradeName = "Archery Gear",     BaseGoldCost = 300, BaseScrapCost = 175, Effect = new GearEffect() },
                new UpgradeData { ID = "arrow_count",    UpgradeName = "Quiver Capacity",  BaseGoldCost = 500, BaseScrapCost = 250, BaseFoodCost = 150, Effect = new ArrowCountEffect() },
                          
            };
        }

        public bool BuyUpgrade(int index)
{
    // 1. Guard: index in range
    if (index < 0 || index >= _upgrades.Length) return false;
    
    UpgradeData data = _upgrades[index];
    
    // 2. Calculate current costs
    int goldCost = Mathf.CeilToInt(data.BaseGoldCost * Mathf.Pow(data.CostGrowth, data.CurrentLevel));
    int scrapCost = Mathf.CeilToInt(data.BaseScrapCost * Mathf.Pow(data.CostGrowth, data.CurrentLevel));
    int foodCost = Mathf.CeilToInt(data.BaseFoodCost * Mathf.Pow(data.CostGrowth, data.CurrentLevel));
    
    // 3. Guard: can afford
    if (_gameManager.Gold < goldCost || _gameManager.Scrap < scrapCost || _gameManager.Food < foodCost)
        return false;
    
    // 4. Deduct
    _gameManager.Gold -= goldCost;
    _gameManager.Scrap -= scrapCost;
    _gameManager.Food -= foodCost;
    
    // 5. Apply effect (passes current level BEFORE increment)
    data.Effect.ApplyEffect(_gameManager, data.CurrentLevel);
    
    // 6. Increment level
    data.CurrentLevel++;
    
    // 7. Emit signal
    EmitSignal(nameof(UpgradePurchased), index, data.CurrentLevel);
    
    return true;
}
    }
}


