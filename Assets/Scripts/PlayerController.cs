using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private FixedJoystick joystick;

    private void Start()
    {
        joystick = FindObjectOfType<FixedJoystick>();
    }

    private void Update()
    {
        // Obtener la entrada del joystick
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        // Hacer algo con la entrada del joystick, como mover al personaje
        transform.position += new Vector3(horizontal, 0f, vertical) * Time.deltaTime;
    }
}
