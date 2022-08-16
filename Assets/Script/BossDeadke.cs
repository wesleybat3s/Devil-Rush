using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeadke : MonoBehaviour
{
    private Animator bossDead;

    private void Start()
    {
        bossDead = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Damage"))
        {


            bossDead.SetTrigger("BDead");
            
        }

     
    }


}
