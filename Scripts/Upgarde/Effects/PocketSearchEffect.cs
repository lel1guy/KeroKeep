using Godot;
using System;

namespace KeroKeep
{
    public class PocketSearchEffect : IUpgradeEffect
    {
        public void ApplyEffect(GameManager gm, int level)
        {
            gm.GoldDropMultiplier += level == 0 ? 1f : 0.5f;
        }
    }

}
