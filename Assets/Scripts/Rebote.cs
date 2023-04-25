using UnityEngine;

public class Rebote : MonoBehaviour
{
    public float fuerza = 10.0f; // La fuerza del rebote

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ObjetoRebote")) // Si el objeto que colisiona tiene la etiqueta "ObjetoRebote"
        {
            Rigidbody rb = GetComponent<Rigidbody>(); // Obtener el componente Rigidbody del objeto que tiene este script
            Vector3 direccion = collision.contacts[0].normal; // Obtener la dirección de la colisión
            rb.AddForce(direccion * fuerza, ForceMode.Impulse); // Aplicar una fuerza de impulso en la dirección de la colisión
        }
    }
}

