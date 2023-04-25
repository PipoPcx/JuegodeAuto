using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimation2 : MonoBehaviour
{
    public Animator playerAnimator; // Referencia al componente Animator del jugador
    public Animator buttonAnimator; // Referencia al componente Animator del bot�n

    void Start()
    {
        // Obtener una referencia al componente Animator del jugador
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();

        // Obtener una referencia al componente Animator del bot�n
        buttonAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        // Obtener el estado actual de la animaci�n del jugador
        var currentState = playerAnimator.GetCurrentAnimatorStateInfo(0);

        // Obtener el progreso actual de la animaci�n del jugador
        var currentNormalizedTime = currentState.normalizedTime % 1;

        // Activar la animaci�n del bot�n si la animaci�n del jugador est� activa
        if (currentNormalizedTime > 0 && currentNormalizedTime < 1)
        {
            buttonAnimator.SetTrigger("Boton");
        }
        // Desactivar la animaci�n del bot�n si la animaci�n del jugador est� inactiva
        else
        {
            buttonAnimator.SetTrigger("Boton");
        }
    }
}

