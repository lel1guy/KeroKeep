using Godot;
using System;

namespace KeroKeep
{

    public interface IUpgradeEffect
    {
        void ApplyEffect(GameManager gm, int level);
    }

}