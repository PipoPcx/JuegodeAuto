using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasCan : MonoBehaviour
{
   private GameManager gameManager;

    private void Awake() {
        gameManager = GameObject.FindAnyObjectByType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            gameManager.sumGas(30f);
            Destroy(gameObject);

        }
    }
}
