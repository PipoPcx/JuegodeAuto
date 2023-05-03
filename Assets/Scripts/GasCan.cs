using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasCan : MonoBehaviour
{
    private Cronometro cronometro;

    private void Awake()
    {
        cronometro = GameObject.FindAnyObjectByType<Cronometro>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cronometro.sumGas(30f);
            Destroy(gameObject);

        }
    }
}
