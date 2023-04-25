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

        // Agregar un listener al botón para detectar el clic
        button.onClick.AddListener(OnButtonClick);
    }

    public void OnButtonClick()
    {
        // Método que se llama al presionar el botón en tu dispositivo Android

        // Activar la animación
        animator.SetTrigger("SaltoAuto");
        StartCoroutine(DesactivarAnimacion());
    }

    IEnumerator DesactivarAnimacion()
    {
        // Esperar a que la animación termine
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Activar la animación
        animator.SetBool("Boton", true);

        // Desactivar la animación
        animator.SetBool("Boton", false);
    }
}

