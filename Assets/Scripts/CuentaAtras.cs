using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuentaAtras : MonoBehaviour
{

    public GameObject motorCarreteraGO;
    public MotorCarreteras motorCarreterasScript;
    public Sprite[] numeros;

    public GameObject contadorNumerosGO;
    public SpriteRenderer contadorNumerosComp;

    public GameObject controladorPlayerGO;
    public GameObject playerGO;

    // Start is called before the first frame update
    void Start()
    {
        InicioComponentes();

    }

    void InicioComponentes()
    {
        motorCarreteraGO = GameObject.Find("MotorCarreteras");
        motorCarreterasScript = motorCarreteraGO.GetComponent<MotorCarreteras>();

        contadorNumerosGO = GameObject.Find("ContadorNumeros");
        contadorNumerosComp = contadorNumerosGO.GetComponent<SpriteRenderer>();

        playerGO = GameObject.Find("Buggy");
        controladorPlayerGO = GameObject.Find("Player");

        InicioCuentaAtras();

    }

    void InicioCuentaAtras()
    {
        StartCoroutine(Contando());
    }

    IEnumerator Contando()
    {
        controladorPlayerGO.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2);

        contadorNumerosComp.sprite = numeros[1];
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        contadorNumerosComp.sprite = numeros[2];
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        contadorNumerosComp.sprite = numeros[3];
        motorCarreterasScript.inicioJuego = true;
        motorCarreterasScript.juegoTerminado = false;
        this.gameObject.GetComponent<AudioSource>().Play();
        playerGO.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2);

        contadorNumerosGO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
