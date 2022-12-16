using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinToCollect : MonoBehaviour
{
    private CoinCounter _coinCounter;
    private int _coinAmount;
    [SerializeField] private GameObject _coinAddedText;

    private void Start()
    {
        _coinCounter = GameObject.FindGameObjectWithTag("Counter").GetComponent<CoinCounter>();
        StartCoroutine(AddCoins());
    }
    IEnumerator AddCoins()
    {
        _coinAmount = Random.Range(10, 15);
        yield return new WaitForSeconds(1);
        _coinCounter.AddCoins(_coinAmount);
        var textCoin = Instantiate(_coinAddedText, transform.position, Quaternion.identity);
        textCoin.GetComponentInChildren<TextMeshProUGUI>().text = "+" + _coinAmount.ToString();
        Destroy(textCoin, 1);
        Destroy(gameObject);
    }

}
