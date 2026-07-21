using Godot;
using System;

namespace KeroKeep
{
    public class ScavengerEffect : IUpgradeEffect
    {
        public void ApplyEffect(GameManager gm, int level)
        {
            if (level == 0)
            {
                gm.AutoScavenge = true;
            }
            else
            {
                gm.ScrapPerScavenge += 5;
            }
        }
    }
}
