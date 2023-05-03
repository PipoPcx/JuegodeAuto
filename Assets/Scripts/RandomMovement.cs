using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    // Definimos los l�mites de movimiento en X e Y
    public float xMin = -10f;
    public float xMax = 10f;
    public float yMin = -5f;
    public float yMax = 5f;

    // Velocidad del movimiento
    public float speed = 5f;

    // Variable para guardar la direcci�n del movimiento
    private Vector2 direction;

    void Start()
    {
        // Elegimos una direcci�n de movimiento aleatoria al iniciar
        direction = new Vector2(Random.Range(-10f, 10f), Random.Range(-2f, 2f));
    }

    void Update()
    {
        // Movemos el objeto en la direcci�n y velocidad elegidas
        transform.Translate(direction * speed * Time.deltaTime);

        // Si el objeto se sale del rango definido, cambiamos la direcci�n de movimiento
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
