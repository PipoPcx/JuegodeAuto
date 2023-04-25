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


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = GameObject.FindAnyObjectByType<GameManager>();
    }


    void Update()
    {
        float v = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(0, 0, v);

        if (Input.GetKeyDown("space") && velocity>30f) {
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            gameManager.UpdateGas(20);
        }

        if (Input.GetKey("w")) {

            velocity += Time.deltaTime * 5f;
            gameManager.UpdateGas(5f * Time.deltaTime);
        }
        else {
            velocity -= Time.deltaTime * 5f;
        }

        velocity = Mathf.Clamp(velocity, 20f, 100f);
        gameManager.UpdateVelocity();
    }


}
