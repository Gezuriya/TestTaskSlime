using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _damageTakenText;
    [SerializeField] private Image _hpBar;
    public int AttackValue;
    public float AttackSpeed;
    public int HealthPoints;
    public int StartHP;
    [SerializeField] private PlayerShoot _playerShoot;
    [SerializeField] private Animator _anim;


    public void GetDamage(int damageTaken)
    {
        HealthPoints -= damageTaken;
        var _damageVisual = Instantiate(_damageTakenText, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1f), Quaternion.identity);
        _damageVisual.GetComponentInChildren<TextMeshProUGUI>().text = "-" + damageTaken.ToString();
        Destroy(_damageVisual, 1f);
        print((float)damageTaken / StartHP);
        _hpBar.fillAmount -= (float)damageTaken / StartHP;

      /*  if (_healthPoint <= 0)
        {
            Die();
        }*/
    }
    private void Start()
    {
        StartEverything();
    }

    public void StartEverything()
    {
        GetParameters();
        HealthPoints = StartHP;
        StartCoroutine(Attack());
    }
    public void GetParameters()
    {
        if (PlayerPrefs.HasKey("ATK"))
        {
            AttackValue = PlayerPrefs.GetInt("ATK");
        }
        else
            AttackValue = 30;

        if (PlayerPrefs.HasKey("ASPD"))
        {
            AttackSpeed = PlayerPrefs.GetFloat("ASPD");
        }
        else
            AttackSpeed = 2f;

        if (PlayerPrefs.HasKey("HP"))
        {
            StartHP = PlayerPrefs.GetInt("HP");
        }
        else
            StartHP = 100;
    }

    IEnumerator Attack()
    {
        while (true)
        {
            StartCoroutine(ShootAnim());
            _playerShoot.Shoot(AttackValue);
            yield return new WaitForSeconds(AttackSpeed); 
        }
    }
    IEnumerator ShootAnim()
    {
        _anim.SetBool("Attack", true);
        yield return new WaitForSeconds(1f);
        _anim.SetBool("Attack", false);
    }
}
