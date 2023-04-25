using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimation2 : MonoBehaviour
{
    public Animator playerAnimator; // Referencia al componente Animator del jugador
    public Animator buttonAnimator; // Referencia al componente Animator del botón

    void Start()
    {
        // Obtener una referencia al componente Animator del jugador
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();

        // Obtener una referencia al componente Animator del botón
        buttonAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        // Obtener el estado actual de la animación del jugador
        var currentState = playerAnimator.GetCurrentAnimatorStateInfo(0);

        // Obtener el progreso actual de la animación del jugador
        var currentNormalizedTime = currentState.normalizedTime % 1;

        // Activar la animación del botón si la animación del jugador está activa
        if (currentNormalizedTime > 0 && currentNormalizedTime < 1)
        {
            buttonAnimator.SetTrigger("Boton");
        }
        // Desactivar la animación del botón si la animación del jugador está inactiva
        else
        {
            buttonAnimator.SetTrigger("Boton");
        }
    }
}

