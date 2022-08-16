using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakip : MonoBehaviour
{
    [SerializeField] Transform playerDevil;
    private Vector3 mesafe;
    [SerializeField] float lerpZaman;
    void Start()
    {
        mesafe = transform.position - playerDevil.position;
    }

    void LateUpdate()
    {
        Vector3 yeniPos = Vector3.Lerp(transform.position, playerDevil.position + mesafe, lerpZaman * Time.deltaTime);
        transform.position = yeniPos;
    }
}
