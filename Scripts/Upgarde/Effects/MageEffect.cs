using Godot;
using System;

namespace KeroKeep
{
    public class MageEffect : IUpgradeEffect
    {
        public void ApplyEffect(GameManager gm, int level)
        {
            if (gm.ArcherCount < gm.MaxArcherCount)
            {
                gm.ArcherCount += 1;
            }

            else
            {
                gm.ArcherCount = gm.MaxArcherCount;
            }

        }
    }
}
