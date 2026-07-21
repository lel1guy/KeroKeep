using Godot;
using System;

namespace KeroKeep
{
    public partial class UpgradeMenu : Control
    {
        [Signal]
        public delegate void UpgradeMenuCloseEventHandler();

        private Button _backButton;

        public override void _Ready()
        {
            _backButton = GetNode<Button>("BackButton");
            _backButton.Pressed += OnBackButtonPressed;

            Visible = false;
        }

        private void OnBackButtonPressed()
        {
            EmitSignal(SignalName.UpgradeMenuClose);
        }

    }

}