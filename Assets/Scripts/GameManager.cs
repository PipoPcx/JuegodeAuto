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

    private void Awake() {
        jump.color = Color.red;
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
}
