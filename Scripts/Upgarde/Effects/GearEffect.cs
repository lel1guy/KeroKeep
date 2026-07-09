using Godot;
using System;

namespace KeroKeep
{
    public class GearEffect : IUpgradeEffect
    {
        public void ApplyEffect(GameManager gm, int level)
        {
            gm.ArrowDamage += level == 0 ? 1f : 0.5f;
        }
    }
}