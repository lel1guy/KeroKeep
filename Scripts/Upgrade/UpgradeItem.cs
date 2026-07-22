using Godot;
using System;

namespace KeroKeep
{
    public partial class UpgradeItem : PanelContainer
    {
        [Export] public string UpgradeName { get; set; } = "Upgrade";
        [Export] public string Description { get; set; } = "description";
        [Export] public int BaseGoldCost { get; set; } = 0;
        [Export] public int BaseFoodCost { get; set; } = 0;
        [Export] public int BaseScrapCost { get; set; } = 0;
        [Export] public float CostGrowth { get; set; } = 1.5f;
        [Export] public int UpgradeIndex { get; set; } = 0;

        private GameManager _gameManager;
        private UpgradeManager _upgradeManager;

        private Label _titleLabel;
        private Label _descriptionLabel;
        private Label _costLabel;
        private Button _buyButton;

        private int _currentLevel = 0;

        public override void _Ready()
        {
           _gameManager = GetNode<GameManager>("/root/GameManager");
           _upgradeManager = GetNode<UpgradeManager>("/root/UpgradeManager");

            _titleLabel       = GetNode<Label>("TextureRect/VBoxContainer/TitleLabel");
            _descriptionLabel = GetNode<Label>("TextureRect/VBoxContainer/DescriptionLabel");
            _costLabel        = GetNode<Label>("TextureRect/VBoxContainer/CostLabel");
            _buyButton        = GetNode<Button>("TextureRect/VBoxContainer/BuyButton");

            _buyButton.Pressed += OnBuyButtonPressed;
            _gameManager.GoldChanged += OnResourceChanged;
            _gameManager.FoodChanged += OnResourceChanged;
            _gameManager.ScrapChanged += OnResourceChanged;
            _upgradeManager.UpgradePurchased += OnUpgradePurchased;

            _currentLevel = _upgradeManager.GetUpgrades()[UpgradeIndex].CurrentLevel;
            
            UpdateUi();
        }

        public void OnBuyButtonPressed()
        {
            _upgradeManager.BuyUpgrade(UpgradeIndex);

        }

        private void OnResourceChanged(int _)
        {
            int goldCost = Mathf.CeilToInt(BaseGoldCost * Mathf.Pow(CostGrowth, _currentLevel));
            int scrapCost = Mathf.CeilToInt(BaseScrapCost * Mathf.Pow(CostGrowth, _currentLevel));
            int foodCost = Mathf.CeilToInt(BaseFoodCost * Mathf.Pow(CostGrowth, _currentLevel));

            _buyButton.Disabled = !_gameManager.CanAfford(goldCost, foodCost, scrapCost);

        }

        private void OnUpgradePurchased(int index, int newLevel)
        {
            if (index == UpgradeIndex)
            {
                _currentLevel = newLevel;
                UpdateUi();
            }
        
        }

        private void UpdateUi()
        {
            _titleLabel.Text = $"{UpgradeName} (Lvl {_currentLevel})";
            _descriptionLabel.Text = $"{Description}";

            int goldCost = Mathf.CeilToInt(BaseGoldCost * Mathf.Pow(CostGrowth, _currentLevel));
            int scrapCost = Mathf.CeilToInt(BaseScrapCost * Mathf.Pow(CostGrowth, _currentLevel));
            int foodCost = Mathf.CeilToInt(BaseFoodCost * Mathf.Pow(CostGrowth, _currentLevel));

            string costText = "";
            if (goldCost > 0) costText += $"Gold: {goldCost}" ;
            if (scrapCost > 0) costText += $"Scrap: {scrapCost}";
            if (foodCost > 0) costText += $"Food: {foodCost}";
            if (costText == "") costText = "Maxed";

            _costLabel.Text = costText;
        }


    }

}