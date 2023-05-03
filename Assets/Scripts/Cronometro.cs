using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Cronometro : MonoBehaviour

{
    public GameObject motorCarreterasGO;
    public MotorCarreteras motorCarreteraScript;

    public float tiempo;
    public float distancia;
    public TextMeshProUGUI txtRiempo;
    public TextMeshProUGUI txtDistancia;
    // Start is called before the first frame update
    void Start()
    {
        motorCarreterasGO = GameObject.Find("MotorCarreteras");
        motorCarreteraScript = motorCarreterasGO.GetComponent<MotorCarreteras>();

        txtRiempo.text = "2:00";
        txtDistancia.text = "0";

        tiempo = 120;
    }

    // Update is called once per frame
    void Update()
    {
        if(motorCarreteraScript.inicioJuego == true && motorCarreteraScript.juegoTerminado == false)
        {
            CalculaTiempoDistancia();
        }

        if(tiempo <= 0 && motorCarreteraScript.juegoTerminado == false)
        {
            motorCarreteraScript.juegoTerminado = true;
        }


    }

    void CalculaTiempoDistancia()
    {
        distancia += Time.deltaTime * motorCarreteraScript.velocidad;

        txtDistancia.text = ((int) distancia).ToString();

        tiempo -= Time.deltaTime;
        int minutos = (int)tiempo / 60;
        int segundos = (int)tiempo % 60;
        txtRiempo.text = minutos.ToString() + ":" + segundos.ToString().PadLeft(2, '0');
    }
}
