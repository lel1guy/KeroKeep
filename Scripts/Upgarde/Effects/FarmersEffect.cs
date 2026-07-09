using Godot;
using System;

namespace KeroKeep
{
    public class FarmersEffect : IUpgradeEffect
    {
        public void ApplyEffect(GameManager gm, int level)
        {
            if (level == 0)
            {
                gm.AutoFarm = true;
            }
            else
            {
                gm.AutoFarmAmount += 5;
            }
        }
    }
}