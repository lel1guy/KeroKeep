using Godot;
using System;

namespace KeroKeep
{
    public partial class Mage : Area2D
    {
        private GameManager _gameManager;
        private Node2D _BoltSpawns;
        private AnimatedSprite2D _sprite;
        private Timer _timer;

        private PackedScene _BoltScene;

        public override void _Ready()
        {
            _gameManager = GetNode<GameManager>("/root/GameManager");

            _BoltSpawns = GetNode<Node2D>("BoltSpawns");
            _sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
            _timer = GetNode<Timer>("Timer");

            _BoltScene = GD.Load<PackedScene>("res://Scenes/Bolt/Bolt.tscn");

            _timer.Timeout += OnTimerTimeout;

        }

        public override void _PhysicsProcess(double delta)
        {
            var enemies = GetOverlappingBodies();
            _sprite.Play(enemies.Count > 0 ? "Shoot" : "Idle");
        }

        public void OnTimerTimeout()
        {
            if (GetOverlappingBodies().Count > 0)
                Fire();
        }

        public void Fire()
        {
            var spawnNodes = _BoltSpawns.GetChildren();
            for ( int i = 0; i < _gameManager.BoltCount; i++)
            {
                if (i >= spawnNodes.Count) break;

                var Bolt = _BoltScene.Instantiate<Node2D>();
                var spawnPoint = (Node2D)spawnNodes[i];
                Bolt.GlobalPosition = spawnPoint.GlobalPosition;
                Bolt.GlobalRotation = GlobalRotation;
                GetTree().Root.AddChild(Bolt);
            }
        }



    }

}