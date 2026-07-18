using Godot;

namespace KeroKeep
{

    
    public partial class Main : Node
    {
        private Node2D _game;
        private Control _upgradeMenu;

        public override void _Ready()
        {
            _game = GetNode<Node2D>("Game");
            _upgradeMenu = GetNode<Control>("UI_Layer/UpgradeMenu");

            _game.UpgradeMenuOpen += OnOpenUpgradeMenu;
            _upgradeMenu.UpgradeMenuClose += OnCloseUpgradeMenu;

            OnCloseUpgradeMenu();

        }

        private void OnOpenUpgradeMenu()
        {
            _upgradeMenu.Visible = true;
            _game.Visible = false;

        }

        private void OnCloseUpgradeMenu()
        {
            _upgradeMenu.Visible = false;
            _game.Visible = true;
        }


    }

}