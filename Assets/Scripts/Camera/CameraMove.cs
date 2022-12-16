using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    Vector3 offset;

    private void Start()
    {
        offset = transform.position - Player.transform.position;
    }
    private void LateUpdate()
    {
        Vector3 targetPos = Player.transform.position + offset;
        transform.position = targetPos;
    }
}
