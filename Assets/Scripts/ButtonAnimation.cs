using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{
    public Animator animator; // Referencia al componente Animator de tu objeto

    void Start()
    {
        // Obtener una referencia al componente Animator de tu objeto
        //animator<Animator>();
    }

    public void OnButtonClick()
    {
        // Método que se llama al presionar el botón en tu dispositivo Android

        // Activar la animación
        animator.SetTrigger("SaltoAuto");
        animator.SetBool("Idle", false);
    }
}

