using Godot;
using System;


namespace KeroKeep
{

     public partial class Game : Node2D
    {
        private GameManager _gameManager;

        [Signal] public delegate void UpgradeMenuOpenEventHandler();

        [Export] public Godot.Collections.Array<PackedScene> Mobs {get; set; } = new();
        [Export] public Godot.Collections.Array<PackedScene> ArcherScenes {get; set; } = new();

        private Button _scavengeButton;
        private Timer _scavengeTimer;
        private Button _farmButton;
        private Timer _farmTimer;

        private ColorRect _autoScrap;
        private ColorRect _autoFood;
        private AnimatedSprite2D _autoScrapLoad;
        private AnimatedSprite2D _autoFarmLoad;

        private ColorRect _storeroomNode;
        private ColorRect _farmNode;

        private Node2D _mobSpawnPoints;
        private Node2D _archerSpawnPoints;

        private Timer _mobSpawnTimer;

        public override void _Ready()
        {
            _gameManager = GetNode<GameManager>("/root/GameManager");

            _scavengeButton = GetNode<Button>("BaseUserInterface/RoomsButtons/ScavangeButton");
            _scavengeTimer  = GetNode<Timer>("BaseUserInterface/RoomsButtons/ScavangeButton/ScavangeTimer");
            _farmButton     = GetNode<Button>("BaseUserInterface/RoomsButtons/FarmButton");
            _farmTimer      = GetNode<Timer>("BaseUserInterface/RoomsButtons/FarmButton/FarmTimer");
            
            _autoScrap     = GetNode<ColorRect>("BaseUserInterface/Rooms/StoreRoom/AutoScrap");
            _autoScrapLoad = GetNode<AnimatedSprite2D>("BaseUserInterface/Rooms/StoreRoom/AutoScrap/Auto_Scrap_Load");
            _autoFood      = GetNode<ColorRect>("BaseUserInterface/Rooms/Farm/AutoFood");
            _autoFarmLoad  = GetNode<AnimatedSprite2D>("BaseUserInterface/Rooms/Farm/AutoFood/Auto_Food_Load");

            _storeroomNode = GetNode<ColorRect>("BaseUserInterface/Rooms/StoreRoom");
            _farmNode      = GetNode<ColorRect>("BaseUserInterface/Rooms/Farm");

            _mobSpawnPoints    = GetNode<Node2D>("MobSpawnPoints");
            _archerSpawnPoints = GetNode<Node2D>("ArcherSpawnPoints");

            _mobSpawnTimer = GetNode<Timer>("MobSpawnTimer");

            _scavengeButton.Pressed +=  _OnScavengeButtonPressed;
            _scavengeTimer.Timeout += _OnScavengeTimerTimeout;

            _farmButton.Pressed += _OnFarmButtonPressed;
            _farmTimer.Timeout += _OnFarmTimerTimeout;

            _mobSpawnTimer.Timeout += SpawnMob;

        }

        public override void _Process(double delta)
        {
            _storeroomNode.Visible = _gameManager.StoreroomUnlocked;
            _farmNode.Visible = _gameManager.FarmUnlocked;
        }

        private void _OnScavengeButtonPressed()
        {
            if (!_gameManager.StoreroomUnlocked) return;

            _scavengeButton.Disabled = true;
            _scavengeTimer.Start(_gameManager.ScavengeTime);
            _autoScrap.Visible = true;
        }

        private void _OnScavengeTimerTimeout()
        {
            _scavengeButton.Disabled = false;
            _gameManager.AddScrap(_gameManager.ScrapPerScavenge);
            _autoScrap.Visible = false;
            _autoScrapLoad.Play("default");
        }

        private void _OnFarmButtonPressed()
        {
            if (!_gameManager.FarmUnlocked) return;

            _farmButton.Disabled = true;
            _farmTimer.Start(_gameManager.FarmTime);
            _autoFood.Visible = true;
            
        }

        private void _OnFarmTimerTimeout()
        {
            _farmButton.Disabled = false;
            _gameManager.AddFood(_gameManager.FoodPerFarm);
            _autoFood.Visible = false;
            _autoFarmLoad.Play("default");
        }

        private void SpawnMob()
        {
            var randomScene = Mobs.PickRandom();
            var mob = randomScene.Instantiate<BaseMob>();

            var spawnPoints = _mobSpawnPoints.GetChildren();
            var randomSpawn = spawnPoints.PickRandom();

            mob.GlobalPosition = randomSpawn.GlobalPosition;
            AddChild(mob);
        }

        private void SpawnArcher()
        {
            var points = _archerSpawnPoints.GetChildren();
            if (_gameManager.ArcherCount > points.Count) return;

            var randomScene = ArcherScenes.PickRandom();
            var archer = randomScene.Instantiate<Node2D>();

            var spawnPoint = points[_gameManager.ArcherCount - 1];
            archer.GlobalPosition = spawnPoint.GlobalPosition;
            AddChild(archer);
        }

        
    }


}
