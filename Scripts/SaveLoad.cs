using Godot;
using System;

namespace KeroKeep
{
    public partial class SaveLoad : Node
    {
        public void SaveGame()
        {
            GameManager.LastSaveTime = Time.GetUnixTimeFromSystem();
        }
    }
}
