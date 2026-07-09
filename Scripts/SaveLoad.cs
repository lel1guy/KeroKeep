using Godot;
using System;

namespace KeroKeep
{
    public partial class SaveLoad : Node
    {
         private GameManager _gameManager;

         public override void _Ready()
         {
            _gameManager = GetNode<GameManager>("/root/GameManager");

            LoadGame();

            var saveTimer = new Timer();
            saveTimer.WaitTime = 60f; // Save every 60 seconds
            saveTimer.Autostart = true;
            saveTimer.Timeout += SaveGame;
            AddChild(saveTimer);
         }
        

        public void SaveGame()
        {     

            _gameManager.LastSaveTime = (float)Time.GetUnixTimeFromSystem();

            var data = new Godot.Collections.Dictionary();
            data["gold"] = _gameManager.Gold;
            data["food"] = _gameManager.Food;
            data["scrap"] = _gameManager.Scrap;
            data["storeroomUnlocked"] = _gameManager.StoreroomUnlocked;
            data["farmUnlocked"] = _gameManager.FarmUnlocked;
            data["clickDamage"] = _gameManager.ClickDamage;
            data["arrowDamage"] = _gameManager.ArrowDamage;
            data["arrowCount"] = _gameManager.ArrowCount;
            data["goldDropMultiplier"] = _gameManager.GoldDropMultiplier;
            data["archerCount"] = _gameManager.ArcherCount;
            data["maxArcherCount"] = _gameManager.MaxArcherCount;
            data["unlockedStage"] = _gameManager.UnlockedStage;
            data["upgradeLevel"] = _gameManager.UpgradeLevel;
            data["farmTime"] = _gameManager.FarmTime;
            data["foodPerFarm"] = _gameManager.FoodPerFarm;
            data["autoFarm"] = _gameManager.AutoFarm;
            data["autoFarmTimer"] = _gameManager.AutoFarmTimer;
            data["autoFarmAmount"] = _gameManager.AutoFarmAmount;
            data["ScavengeTime"] = _gameManager.ScavengeTime;
            data["scrapPerScavenge"] = _gameManager.ScrapPerScavenge;
            data["autoScavenge"] = _gameManager.AutoScavenge;
            data["autoScavengeTimer"] = _gameManager.AutoScavengeTimer;
            data["autoScavengeAmount"] = _gameManager.AutoScavengeAmount;
            data["autoResourceTimer"] = _gameManager.AutoResourceTimer;
            data["lastSaveTime"] = _gameManager.LastSaveTime;

            string jsonData = Json.Stringify(data);
            
            using var file = FileAccess.Open("user://savegame.json", FileAccess.ModeFlags.Write);
            file.StoreString(jsonData);

        }

        public void LoadGame()
        {
            if (!FileAccess.FileExists("user://savegame.json"))
            {
                GD.Print("No save file found.");
                return;
            }

            using var file = FileAccess.Open("user://savegame.json", FileAccess.ModeFlags.Read);
            string jsonText = file.GetAsText();
           Variant result = Json.ParseString(jsonText);

           var data = result.AsGodotDictionary();

           _gameManager.LoadState(data);

        }



    }
}
