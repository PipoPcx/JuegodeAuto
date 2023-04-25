using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI mph;
    [SerializeField] private Player player;
    [SerializeField] private TextMeshProUGUI jump;
    [SerializeField] private TextMeshProUGUI gas;
   // [SerializeField] private TextMeshProUGUI showGas;

    private float gasInicial;
   

    

    private void Awake() {
        jump.color = Color.red;
        gasInicial = 100;
       // showGas.color = Color.green;
    }

    private void Update()
    {
       UpdateGas();
    }

    public void UpdateVelocity() {
        float newVelocity = player.velocity;
        int newVelocityInt = (int)newVelocity;
        mph.text = "Mph/" + newVelocityInt.ToString();

        if (newVelocityInt >= 30 ) {
            jump.color = Color.green;
        }
        else { 
            jump.color = Color.red;
        }

       // if (newVelocity >= 30f) {
       //     velBar.transform.localScale = new Vector3(1, 1, 1);   
     //   }
     //   else {
      //      float hScale = newVelocity / 30f;
     //       velBar.transform.localScale = new Vector3(hScale, 1, 1);
     //   }

    }

    public void UpdateGas(float cantidad) {
        gasInicial -= cantidad;
    }

    void UpdateGas() {
        gasInicial -= Time.deltaTime * 3f;
        gas.text = "Gas: " + gasInicial.ToString();

        if (gasInicial >= 30) { 
            gas.color = Color.green;
        }
        else { 
            gas.color= Color.red;
        }
    }
}
