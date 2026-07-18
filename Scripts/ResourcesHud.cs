using Godot;
using System;

namespace KeroKeep
{

    public partial class ResourcesHud : CanvasLayer
    {
        private GameManager _gameManager;

        private Label _goldLabel;
        private Label _foodLabel;
        private Label _scrapLabel;

        public override void _Ready()
        {
            _gameManager = GetNode<GameManager>("/root/GameManager");

            _goldLabel = GetNode<Label>("GoldLabel");
            _foodLabel = GetNode<Label>("FoodLabel");
            _scrapLabel = GetNode<Label>("ScrapLabel");

            _gameManager.GoldChanged += OnGoldChanged;
            _gameManager.FoodChanged += OnFoodChanged;
            _gameManager.ScrapChanged += OnScrapChanged;

            OnGoldChanged(_gameManager.Gold);
            OnScrapChanged(_gameManager.Scrap);
            OnFoodChanged(_gameManager.Food);

        }

        public void OnGoldChanged(int amount)
        {
            _goldLabel.Text = $"Gold: {amount}";
        }

        public void OnFoodChanged(int amount)
        {
            _foodLabel.Text = $"Food: {amount}";
        }

        public void OnScrapChanged(int amount)
        {
            _scrapLabel.Text = $"Scrap: {amount}";
        }

    }

}