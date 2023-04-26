using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private FixedJoystick joystick;
    public float maxHeight = 5f;
    public float minHeight = 0f;
    

    private void Start()
    {
        joystick = FindObjectOfType<FixedJoystick>();
    }

    private void Update()
    {
        // Obtener la entrada del joystick
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        // Limitar el movimiento vertical del personaje
        float newY = Mathf.Clamp(transform.position.y + vertical * Time.deltaTime, minHeight, maxHeight);

        if (vertical < 0)

        {
            MotorCarreteras.instance.velocidad = 10;

        }
        if (vertical > 0)

        {
            MotorCarreteras.instance.velocidad = 20;

        }


        // Mover al personaje
        transform.position = new Vector3(transform.position.x + horizontal * Time.deltaTime, newY, transform.position.z);
    }
}
