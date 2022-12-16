using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class BasicEnemy : MonoBehaviour, IEnemy
{
    [SerializeField] private int _attackValue;
    [SerializeField] private int _startHP;
    private int _healthPoint;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private GameObject _damageTakenText;
    [SerializeField] private Image _hpBar;
    [SerializeField] private GameObject _coinToCollect;
    private Vector3 _destination;
    private Transform _playerTransform;
    private PlayerController _playerController;
    private bool _startAttacking = false;

    public void FindDestination()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _playerController = _playerTransform.gameObject.GetComponent<PlayerController>();
        _destination = new Vector3(_playerTransform.position.x + 0.7f, transform.position.y, transform.position.z);
    }
    public void GetDamage(int damageTaken)
    {
        _healthPoint -= damageTaken;
        var _damageVisual = Instantiate(_damageTakenText, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1f), Quaternion.identity);
        _damageVisual.GetComponentInChildren<TextMeshProUGUI>().text = "-" + damageTaken.ToString();
        Destroy(_damageVisual, 1f);
        _hpBar.fillAmount -= (float)damageTaken / _startHP;
        if(_healthPoint <= 0)
        {
            Die();
        }
    }
    public void Attack(int attackValue)
    {
        _playerController.GetDamage(attackValue);
    }

    public void Die()
    {
        Instantiate(_coinToCollect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    private void Start()
    {
        _healthPoint = _startHP;
        _hpBar.fillAmount = 1f;
        FindDestination();
    }
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _destination, 0.01f);
        if(transform.position == _destination && !_startAttacking)
        {
            _startAttacking = true;
            StartCoroutine(EnemyAttack());
        }
    }
    IEnumerator EnemyAttack()
    {
        while (true)
        {
            Attack(_attackValue);
            yield return new WaitForSeconds(_attackSpeed);
        }
    }
}
