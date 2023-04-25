using UnityEngine;

public class Rebote : MonoBehaviour
{
    public float fuerza = 10.0f; // La fuerza del rebote
    public float tiempoImpulso = 1.0f; // Tiempo durante el cual se aplica impulso

    private float tiempoActual = 0.0f; // Tiempo actual transcurrido

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ObjetoRebote")) // Si el objeto que colisiona tiene la etiqueta "ObjetoRebote"
        {
            Rigidbody rb = GetComponent<Rigidbody>(); // Obtener el componente Rigidbody del objeto que tiene este script
            Vector3 direccion = collision.contacts[0].normal; // Obtener la dirección de la colisión
            rb.AddForce(direccion * fuerza, ForceMode.Impulse); // Aplicar una fuerza de impulso en la dirección de la colisión
            tiempoActual = 0.0f; // Reiniciar el tiempo actual
        }
    }

    private void Update()
    {
        if (tiempoActual < tiempoImpulso) // Si no han pasado suficientes segundos
        {
            tiempoActual += Time.deltaTime; // Añadir tiempo transcurrido
        }
        else // Si han pasado suficientes segundos
        {
            Rigidbody rb = GetComponent<Rigidbody>(); // Obtener el componente Rigidbody del objeto que tiene este script
            rb.velocity = Vector3.zero; // Detener la velocidad del objeto
            rb.angularVelocity = Vector3.zero; // Detener la rotación del objeto
        }
    }
}