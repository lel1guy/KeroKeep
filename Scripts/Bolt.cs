using Godot;
using System;

namespace KeroKeep
{
    public partial class Arrow : Area2D
    {
        [Export] public float Speed {get; set; } = 200f;
        [Export] public float Damage {get; set; } = 0.25f;

        public override void _Process(double delta)
        {
            Position -= new Vector2(Speed * (float)delta, 0);
        }

        public override void _Ready()
        {
            BodyEntered += OnBodyEntered;

            var notifier = GetNode<VisibleOnScreenNotifier2D>("VisibleOnScreenNotifier2D");
            notifier.ScreenExited += OnScreenExited;
        }

        private void OnBodyEntered(Node2D body)
        {
            if (body is BaseMob mob)
            {
                mob.TakeDamage(Damage);
                QueueFree();
            }
        }

        private void OnScreenExited()
        {
            QueueFree();
        }
    }

}