using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jump = 5f;

    private GameManager gameManager;
    private Rigidbody rb;
    public float velocity;

    public Cronometro cronometro;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = GameObject.FindAnyObjectByType<GameManager>();
    }


    void Update()
    {
        float h = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
       // float v = Input.GetAxis("vertical") * speed * Time.deltaTime;
        velocity = Mathf.Clamp(velocity, 20f, 100f);
        transform.Translate(0, 0, h);
        
        gameManager.UpdateVelocity();

        if (Input.GetKeyDown("space") && velocity>30f) {
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            cronometro.resGas(20);
        }

        if (Input.GetKey("w")) {

            velocity += Time.deltaTime * 5f;
            cronometro.resGas(5f * Time.deltaTime);
        }
        else {
            velocity -= Time.deltaTime * 5f;
        }

    }


}
