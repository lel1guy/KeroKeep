using Godot;
using System;

namespace KeroKeep
{
    public class MageEffect : IUpgradeEffect
    {
        public void ApplyEffect(GameManager gm, int level)
        {
            if (gm.MageCount < gm.MaxMageCount)
            {
                gm.MageCount += 1;
            }

            else
            {
                gm.MageCount = gm.MaxMageCount;
            }

        }
    }
}
