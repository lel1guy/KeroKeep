using Godot;
using System;

 namespace KeroKeep
{

    public class StrengthEffect : IUpgradeEffect
    {
        public void ApplyEffect(GameManager gm, int level)
        {
            gm.ClickDamage += 1;
        }
    }
    
}
