using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimation : MonoBehaviour
{
    public Animator animator; // Referencia al componente Animator de tu objeto
    public Button button; // Referencia al componente Button de tu objeto

    void Start()
    {
        // Obtener una referencia al componente Animator de tu objeto
        animator = GetComponent<Animator>();

        // Obtener una referencia al componente Button de tu objeto
        button = GetComponent<Button>();

        // Agregar un listener al bot�n para detectar el clic
        button.onClick.AddListener(OnButtonClick);
    }

    public void OnButtonClick()
    {
        // M�todo que se llama al presionar el bot�n en tu dispositivo Android

        // Activar la animaci�n
        animator.SetTrigger("SaltoAuto");
        StartCoroutine(DesactivarAnimacion());
    }

    IEnumerator DesactivarAnimacion()
    {
        // Esperar a que la animaci�n termine
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Activar la animaci�n
        animator.SetBool("Boton", true);

        // Desactivar la animaci�n
        animator.SetBool("Boton", false);
    }
}

