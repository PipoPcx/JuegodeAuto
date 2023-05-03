using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocheObstaculo : MonoBehaviour
{
    public GameObject cronometroGO;
    public Cronometro cronometroScript;

    public GameObject audioFXGO;
    public AudioFX audioFXSCript;

    private void Start()
    {
        cronometroGO = GameObject.FindObjectOfType<Cronometro>().gameObject;
        cronometroScript = cronometroGO.GetComponent<Cronometro>();

        audioFXGO = GameManager.FindObjectOfType<AudioFX>().gameObject;
        audioFXSCript = audioFXGO.GetComponent<AudioFX>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerController>()!= null)
        {
            audioFXSCript.FXSonidoChoque();
            cronometroScript.tiempo = cronometroScript.tiempo - 20;
            Destroy(this.gameObject);
        }
    }
}
