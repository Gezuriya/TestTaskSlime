using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttackSpeedShop : MonoBehaviour, IShop
{
    [SerializeField] private int _level;
    [SerializeField] private int _cost;
    [SerializeField] private float _parameterValue;
    [SerializeField] private TextMeshProUGUI _levelTxt;
    [SerializeField] private TextMeshProUGUI _costTxt;
    [SerializeField] private PlayerController _playerCont;
    [SerializeField] private CoinCounter _coinCounter;
    public void LoadValue()
    {
        if (PlayerPrefs.HasKey("LevelASPD"))
        {
            _level = PlayerPrefs.GetInt("LevelASPD");
        }
        else
            _level = 1;

        _levelTxt.text = "Lv " + _level.ToString();
        _cost = _level * 10;
        _costTxt.text = _cost.ToString();
        _parameterValue = 2 - (_level * 0.1f);
    }
    public void Upgrade()
    {
        if (_coinCounter.CoinAmount >= _cost)
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
        PlayerPrefs.SetInt("LevelASPD", _level);
        PlayerPrefs.SetFloat("ASPD", _parameterValue);
    }
    private void Start()
    {
        LoadValue();
    }

}
