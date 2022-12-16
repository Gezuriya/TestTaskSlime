using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HPShop : MonoBehaviour, IShop
{
    [SerializeField] private int _level;
    [SerializeField] private int _cost;
    [SerializeField] private int _parameterValue;
    [SerializeField] private TextMeshProUGUI _levelTxt;
    [SerializeField] private TextMeshProUGUI _costTxt;
    [SerializeField] private PlayerController _playerCont;
    [SerializeField] private CoinCounter _coinCounter;
    public void LoadValue()
    {
        if (PlayerPrefs.HasKey("LevelHP"))
        {
            _level = PlayerPrefs.GetInt("LevelHP");
        }
        else
            _level = 1;

        _levelTxt.text = "Lv " + _level.ToString();
        _cost = _level * 10;
        _costTxt.text = _cost.ToString();
        _parameterValue = 100 + (_level * 50);
    }
    public void Upgrade()
    {
        if(_coinCounter.CoinAmount >= _cost)
        {
            _level += 1;
            _coinCounter.CoinAmount -= _cost;
            _coinCounter.AddCoins(0);
            SaveValue();
            LoadValue();
            _playerCont.GetParameters();
        }
    }
    public void SaveValue()
    {
        PlayerPrefs.SetInt("LevelHP", _level);
        PlayerPrefs.SetInt("HP", _parameterValue);
    }
    private void Start()
    {
        LoadValue();
    }    
}
