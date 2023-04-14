using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MotorCarreteras : MonoBehaviour
{
    public GameObject contenedorCallesGO;
    public GameObject[] contenedorCallesArray;

    public float velocidad;
    public bool inicioJuego;
    public bool juegoTerminado;

    int contadorCalles = 0;
    int numeroSelectorCalles;

    public GameObject calleAnterior;
    public GameObject calleNueva;

    public float tamanoCalle;

    public Vector3 medidaLimitePantalla;
    public bool salioPantalla;

    public GameObject mCamGo;
    public Camera mCamComp;

    void Start()
    {
        //contenedorCallesGO = GameObject.Find("ContenedorCalles");
        InicioJuego();
        
    }

    // Update is called once per frame

    void InicioJuego()
    {
        contenedorCallesGO = GameObject.Find("ContenedorCalles");
        mCamGo = GameObject.Find("MainCamera");
        mCamComp = mCamGo.GetComponent<Camera>();
        VelocidadMotoCarretera();
        MedirPantalla();
        BuscoCalles();
    }

    void VelocidadMotoCarretera()
    {
        velocidad = 10;
    }

    void BuscoCalles()
    {

        contenedorCallesArray = GameObject.FindGameObjectsWithTag("Calle");
        for (int i = 0; i < contenedorCallesArray.Length; i++)
        {
            contenedorCallesArray[i].gameObject.transform.parent = contenedorCallesGO.transform;
            contenedorCallesArray[i].gameObject.SetActive(false);
            contenedorCallesArray[i].gameObject.name = "CalleOFF_" + i;
        }
        CrearCalles();
    }

    void CrearCalles()
    {
        contadorCalles++;
        numeroSelectorCalles = Random.Range(0, contenedorCallesArray.Length);
        GameObject Calle = Instantiate(contenedorCallesArray[numeroSelectorCalles]);
        Calle.SetActive(true);
        Calle.name = "Calle" + contadorCalles;
        Calle.transform.parent = gameObject.transform;
        PosicionoCalles();
    }

    void PosicionoCalles()
    {
        calleAnterior = GameObject.Find("Calle" + (contadorCalles - 1));
        calleNueva = GameObject.Find("Calle" + contadorCalles);
        MidoCalles();
        calleNueva.transform.position = new Vector3(calleAnterior.transform.position.x, calleAnterior.transform.position.y + tamanoCalle, 0);
        salioPantalla = false;
    }

    void MidoCalles()
    {
        for (int i = 0; i < calleAnterior.transform.childCount; i++)
        {
            if (calleAnterior.transform.GetChild(i).gameObject.GetComponent<Pieza>() != null)
            {
                float tamanoPieza = calleAnterior.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().bounds.size.y; tamanoCalle = tamanoCalle + tamanoPieza;
            }
        }
    }

    void MedirPantalla()
    {
        medidaLimitePantalla = new Vector3(0, mCamComp.ScreenToWorldPoint(new Vector3(0, 0, 0)).y - 0.5f, 0);
    }
    void Update()
    {
        if (inicioJuego == true && juegoTerminado == false)
            transform.Translate(Vector3.down * velocidad * Time.deltaTime);
        if (calleAnterior.transform.position.y + tamanoCalle < medidaLimitePantalla.y && salioPantalla == false)
        {
            salioPantalla = true;
            DestruyoCalles();

        }
    }

    void DestruyoCalles()
    {

        Destroy(calleAnterior);
        tamanoCalle = 0;
        calleAnterior = null;
        CrearCalles();
    }

}
