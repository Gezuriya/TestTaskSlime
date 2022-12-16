using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _targetPoint;

    [SerializeField] private float _angleInDegrees;

    float g = Physics.gravity.y;

    [SerializeField] private GameObject _bullet;
    [SerializeField] private PlayerController _playerCont;

    public void Shoot(int damageGiven)
    {
        if (_targetPoint != null)
        {
            Vector3 fromTo = _targetPoint.position - transform.position;
            Vector3 fromToXZ = new Vector3(fromTo.x - 0.7f, 0, fromTo.z);
            float x = fromToXZ.magnitude;
            float y = fromTo.y;

            float angleInRadians = _angleInDegrees * Mathf.PI / 180;

            float v2 = (g * x * x) / (2 * (y - Mathf.Tan(angleInRadians) * x) * Mathf.Pow(Mathf.Cos(angleInRadians), 2));
            float v = Mathf.Sqrt(Mathf.Abs(v2));

            GameObject newBullet = Instantiate(_bullet, _spawnPoint.position, Quaternion.identity);
            newBullet.GetComponent<BulletController>().DamageDealed = damageGiven;
            newBullet.GetComponent<Rigidbody>().velocity = _spawnPoint.forward * v;
        }
        else
        {
            if (GameObject.FindGameObjectWithTag("Enemy") != null)
            {
                _targetPoint = GameObject.FindGameObjectWithTag("Enemy").transform;
                Vector3 fromTo = _targetPoint.position - transform.position;
                Vector3 fromToXZ = new Vector3(fromTo.x - 0.7f, 0, fromTo.z);
                float x = fromToXZ.magnitude;
                float y = fromTo.y;

                float angleInRadians = _angleInDegrees * Mathf.PI / 180;

                float v2 = (g * x * x) / (2 * (y - Mathf.Tan(angleInRadians) * x) * Mathf.Pow(Mathf.Cos(angleInRadians), 2));
                float v = Mathf.Sqrt(Mathf.Abs(v2));

                GameObject newBullet = Instantiate(_bullet, _spawnPoint.position, Quaternion.identity);
                newBullet.GetComponent<BulletController>().DamageDealed = damageGiven;
                newBullet.GetComponent<Rigidbody>().velocity = _spawnPoint.forward * v;
            }
        }
    }
}
