using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerStack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            gameObject.SetActive(false);
        }

        
    }
}
