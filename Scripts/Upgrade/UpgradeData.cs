using Godot;
using System;

namespace KeroKeep
{
    public class UpgradeData
    {
        public string ID { get; set; } = "";
        public string UpgradeName { get; set; } = "";
        public string Description { get; set; } = "";

        public int BaseGoldCost { get; set; } = 0;
        public int BaseFoodCost { get; set; } = 0;
        public int BaseScrapCost { get; set; } = 0;

        public float CostGrowth { get; set; } = 1.5f;

        public int CurrentLevel { get; set; } = 0;

        public IUpgradeEffect Effect { get; set; } = null;


    }

}