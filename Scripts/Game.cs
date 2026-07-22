using Godot;
using System;
using System.Runtime.Serialization.Formatters;


namespace KeroKeep
{

     public partial class Game : Node2D
    {
        private GameManager _gameManager;

        [Signal] public delegate void UpgradeMenuOpenEventHandler();

        [Export] public Godot.Collections.Array<PackedScene> Mobs {get; set; } = new();
        [Export] public Godot.Collections.Array<PackedScene> MageScenes {get; set; } = new();

        private Button _scavengeButton;
        private Timer _scavengeTimer;
        private Button _farmButton;
        private Timer _farmTimer;

        private ColorRect _autoScrap;
        private ColorRect _autoFood;
        private AnimatedSprite2D _autoScrapLoad;
        private AnimatedSprite2D _autoFarmLoad;

        private CanvasItem _storeroomNode;
        private CanvasItem _farmNode;

        private Node2D _mobSpawnPoints;
        private Node2D _mageSpawnPoints;

        private Timer _mobSpawnTimer;

        private Button _upgradeMenuButton;

        public override void _Ready()
        {
            _gameManager = GetNode<GameManager>("/root/GameManager");

            _scavengeButton = GetNode<Button>("BaseUserInterface/ScavangeButton");
            _scavengeTimer  = GetNode<Timer>("BaseUserInterface/ScavangeButton/ScavangeTimer");
            _farmButton     = GetNode<Button>("BaseUserInterface/FarmButton");
            _farmTimer      = GetNode<Timer>("BaseUserInterface/FarmButton/FarmTimer");
            
            _storeroomNode = GetNode<Sprite2D>("BaseUserInterface/ScavangeButton/StoreRoom");
            _farmNode      = GetNode<Sprite2D>("BaseUserInterface/FarmButton/Farm");

            _mobSpawnPoints    = GetNode<Node2D>("MobSpawnPoints");
            _mageSpawnPoints = GetNode<Node2D>("MageSpawnPoints");

            _mobSpawnTimer = GetNode<Timer>("MobSpawnTimer");

            _scavengeButton.Pressed +=  _OnScavengeButtonPressed;
            _scavengeTimer.Timeout += _OnScavengeTimerTimeout;

            _farmButton.Pressed += _OnFarmButtonPressed;
            _farmTimer.Timeout += _OnFarmTimerTimeout;

            _mobSpawnTimer.Timeout += SpawnMob;

            _upgradeMenuButton = GetNode<Button>("BaseUserInterface/UpgradeMenuButton");
            _upgradeMenuButton.Pressed += OnUpgradeMenuButtonPressed;

            _gameManager.MageCountChanged += OnMageCountChanged;
            SpawnExistingMages();

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
            
        }

        private void _OnScavengeTimerTimeout()
        {
            _scavengeButton.Disabled = false;
            _gameManager.AddScrap(_gameManager.ScrapPerScavenge);

        }

        private void _OnFarmButtonPressed()
        {
            if (!_gameManager.FarmUnlocked) return;

            _farmButton.Disabled = true;
            _farmTimer.Start(_gameManager.FarmTime);
            
            
        }

        private void _OnFarmTimerTimeout()
        {
            _farmButton.Disabled = false;
            _gameManager.AddFood(_gameManager.FoodPerFarm);

        }

        private void SpawnMob()
        {
            if (Mobs.Count == 0) return;
            var randomScene = Mobs.PickRandom();
            var mob = randomScene.Instantiate<BaseMob>();

            var spawnPoints = _mobSpawnPoints.GetChildren();
            var randomSpawn = (Node2D)spawnPoints.PickRandom();

            mob.GlobalPosition = randomSpawn.GlobalPosition;
            AddChild(mob);
        }

        private void SpawnMage()
        {
            if (MageScenes.Count == 0) return;
            var points = _mageSpawnPoints.GetChildren();
            if (_gameManager.MageCount > points.Count) return;

            var randomScene = MageScenes.PickRandom();
            var Mage = randomScene.Instantiate<Node2D>();

            var spawnPoint = (Node2D)points[_gameManager.MageCount - 1];
            Mage.GlobalPosition = spawnPoint.GlobalPosition;
            AddChild(Mage);
        }

        private void OnUpgradeMenuButtonPressed()
        {
            EmitSignal(SignalName.UpgradeMenuOpen);
        }

        private void OnMageCountChanged(int count)
        {
            SpawnMage();
        }

        private void SpawnExistingMages()
        {
            if (MageScenes.Count == 0)
            {
                GD.PrintErr("SpawnExistingMages: MagesScenes are not set!!");
                return;
            }

            var points = _mageSpawnPoints.GetChildren();

            for (int i = 0; i < _gameManager.MageCount && i < points.Count; i++)
            {
                var randomScene = MageScenes.PickRandom();
                var mage = randomScene.Instantiate<Node2D>();
                mage.GlobalPosition = ((Node2D)points[i]).GlobalPosition;
                AddChild(mage);
            }
        }

        
    }


}
