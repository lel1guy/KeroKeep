using Godot;
using System;

namespace KeroKeep
{
    public class BoltCountEffect : IUpgradeEffect
    {
        public void ApplyEffect(GameManager gm, int level)
        {
            gm.BoltCount = Mathf.Min(gm.BoltCount +1, 3);
        }
    }
}

