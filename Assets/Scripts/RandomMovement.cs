using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    // Definimos los límites de movimiento en X e Y
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    // Velocidad del movimiento
    public float speed = 5f;

    // Variable para guardar la dirección del movimiento
    private Vector2 direction;

    void Start()
    {
        // Elegimos una dirección de movimiento aleatoria al iniciar
        direction = new Vector2(Random.Range(-5f, 5f), Random.Range(-1f, 1f));
    }

    void Update()
    {
        // Movemos el objeto en la dirección y velocidad elegidas
        transform.Translate(direction * speed * Time.deltaTime);

        // Si el objeto se sale del rango definido, cambiamos la dirección de movimiento
        if (transform.position.x < xMin || transform.position.x > xMax)
        {
            direction.x = -direction.x;
        }
        if (transform.position.y < yMin || transform.position.y > yMax)
        {
            direction.y = -direction.y;
        }
    }
}
