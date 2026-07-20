using Godot;
using System;

namespace KeroKeep
{

public partial class BaseMob : CharacterBody2D
    {

        private GameManager _gameManager;

        [Export] public int Health { get; set; } = 1;
        [Export] public int Speed { get; set; } = 50;
        [Export] public int GoldDrop { get; set; } = 1;


        private AnimatedSprite2D _sprite;
        public override void _Ready()
        {
            _sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
            _sprite.Play("Walk");

            _gameManager = GetNode<GameManager>("/root/GameManager");
        }

        public override void _PhysicsProcess(double delta)
        {
            Velocity = new Vector2(-Speed, 0);
            MoveAndSlide();
        }

        public async void TakeDamage(float damage)
        {
            Health -= (int)damage;
            if (Health <= 0)
            {
                Speed = 0;
                _gameManager.AddGold(Mathf.CeilToInt(GoldDrop * _gameManager.GoldDropMultiplier));
                _sprite.Play("Death");
                await ToSignal(_sprite, AnimatedSprite2D.SignalName.AnimationFinished);
                QueueFree();
            }
        }

        public override void _InputEvent(Viewport viewport, InputEvent @event, int shapeIdx)
        {
            if (Health > 0 && @event.IsActionPressed("clickAttack"))
            {
                TakeDamage(_gameManager.ClickDamage);
            }   
        }
    }
}
