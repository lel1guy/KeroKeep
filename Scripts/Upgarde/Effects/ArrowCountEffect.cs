using Godot;
using System;

namespace KeroKeep
{
    public class ArrowCountEffect : IUpgradeEffect
    {
        public void ApplyEffect(GameManager gm, int level)
        {
            gm.ArrowCount = Mathf.Min(gm.ArrowCount +1, 3);
        }
    }
}

