using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cronometro : MonoBehaviour

{
    public GameObject motorCarreterasGO;
    public MotorCarreteras motorCarreteraScript;

    public float tiempo;
    public float distancia;
    public TextMeshProUGUI txtRiempo;
    public TextMeshProUGUI txtDistancia;
    public TextMeshProUGUI gas;
    public TextMeshProUGUI txtDistanciaFinal;

    private float gasInicial;
    // Start is called before the first frame update
    void Start()
    {
        motorCarreterasGO = GameObject.Find("MotorCarreteras");
        motorCarreteraScript = motorCarreterasGO.GetComponent<MotorCarreteras>();

        txtRiempo.text = "00:00";
        txtDistancia.text = "0";
        gas.text = ("0.0");

        tiempo = 120;
    }

    private void Awake()
    {
        //Button. = Color.red;
        gasInicial = 100;
        // showGas.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        if (motorCarreteraScript.inicioJuego == true && motorCarreteraScript.juegoTerminado == false)
        {
            CalculoTiempoDistancia();
        }

        if (tiempo <= 0 && motorCarreteraScript.juegoTerminado == false)
        {
            motorCarreteraScript.juegoTerminado = true;
            motorCarreteraScript.JuegoTerminadoEstados();
            txtDistanciaFinal.text = ((int)distancia).ToString();

        }
        showGas();


    }

    void CalculoTiempoDistancia()
    {
        distancia += Time.deltaTime * motorCarreteraScript.velocidad;

        txtDistancia.text = ((int)distancia).ToString();

        tiempo -= Time.deltaTime;
        int minutos = (int)tiempo / 60;
        int segundos = (int)tiempo % 60;
        txtRiempo.text = minutos.ToString() + ":" + segundos.ToString().PadLeft(2, '0');
        gas.text = " " + gasInicial.ToString("0.0");
    }
    public void resGas(float cantidad)
    {
        gasInicial -= cantidad;
    }

    public void sumGas(float cantidad)
    {
        gasInicial += cantidad;

    }

    void showGas()
    {
        gasInicial -= Time.deltaTime * 1;
        
        gasInicial = Mathf.Clamp(gasInicial, 0f, 100f);

        if (gasInicial >= 30)
        {
            gas.color = Color.green;
        }
        else
        {
            gas.color = Color.red;
        }

        if (gasInicial <= 0)
        {
            SceneManager.LoadScene("Test");
        }
    }
}
