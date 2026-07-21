using Godot;
using System;

namespace KeroKeep
{
    public class MageEffect : IUpgradeEffect
    {
        public void ApplyEffect(GameManager gm, int level)
        {
            gm.AddMage();

        }
    }
}
