using Godot;
using System;
using System.Linq;


namespace KeroKeep
{

     public partial class Game : Node2D
    {
        private GameManager _gameManager;

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

        }

        public override void _Process(double delta)
        {
            
        }

        
    }


}
