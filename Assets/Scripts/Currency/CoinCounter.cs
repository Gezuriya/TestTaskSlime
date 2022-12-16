using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinCounterText;
    public int CoinAmount;

    private void Awake()
    {
        UpdateCoinAmount();
    }
    private void UpdateCoinAmount()
    {
        if (PlayerPrefs.HasKey("Coins"))
        {
            CoinAmount = PlayerPrefs.GetInt("Coins");
        }
        else
            CoinAmount = 0;

        _coinCounterText.text = CoinAmount.ToString();
    }

    public void AddCoins(int value)
    {
        CoinAmount += value;
        PlayerPrefs.SetInt("Coins", CoinAmount);
        UpdateCoinAmount();
    }
}
