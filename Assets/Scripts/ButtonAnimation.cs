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
        // M�todo que se llama al presionar el bot�n en tu dispositivo Android

        // Activar la animaci�n
        animator.SetTrigger("SaltoAuto");
        animator.SetBool("Idle", false);
    }
}

