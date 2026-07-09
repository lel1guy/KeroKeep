using Godot;
using System;
namespace KeroKeep
{
    public class FarmUnlockedEffect : IUpgradeEffect
    {
        public void ApplyEffect(GameManager gm, int level)
        {
            if (level == 0)
            {
                gm.FarmUnlocked = true;
            }
            else
            {
                gm.FoodPerFarm += 5;
            }
        }
    }
}