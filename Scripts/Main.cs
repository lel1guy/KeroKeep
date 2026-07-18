using Godot;

namespace KeroKeep
{

    
    public partial class Main : Node
    {
        private Game _game;
        private UpgradeMenu _upgradeMenu;

        public override void _Ready()
        {
            _game = GetNode<Game>("Game");
            _upgradeMenu = GetNode<UpgradeMenu>("UI_Layer/UpgradeMenu");

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