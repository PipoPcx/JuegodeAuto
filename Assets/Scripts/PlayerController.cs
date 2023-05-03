using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private FixedJoystick joystick;
    public float maxHeight = 5f;
    public float minHeight = 0f;
    public float velocidadHorizontal = 5f;


    private void Start()
    {
        joystick = FindObjectOfType<FixedJoystick>();
    }

    private void Update()
    {
        // Obtener la entrada del joystick
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        // Cambiar la velocidad del personaje
        if (vertical > 0)
        {
            MotorCarreteras.instance.velocidad = 20;
        }
        else if (vertical < 0)
        {
            MotorCarreteras.instance.velocidad = 5;
        }

        else if (vertical == 0)
        {
            MotorCarreteras.instance.velocidad = 10;
        }


        // Limitar el movimiento vertical del personaje
        float newY = Mathf.Clamp(transform.position.y + vertical * Time.deltaTime, minHeight, maxHeight);

        // Mover al personaje
        transform.position = new Vector3(transform.position.x + horizontal * velocidadHorizontal * Time.deltaTime, newY, transform.position.z);
    }
}
