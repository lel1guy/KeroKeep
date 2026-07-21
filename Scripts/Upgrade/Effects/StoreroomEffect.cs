using Godot;
using System;

namespace KeroKeep
{

    public class StoreroomEffect : IUpgradeEffect
    {

        public void ApplyEffect(GameManager gm, int level)
        {
            if (level == 0)
            {
                gm.StoreroomUnlocked = true;
            }
            else
            {
                gm.ScrapPerScavenge += 5;
            }
        }

    }
}