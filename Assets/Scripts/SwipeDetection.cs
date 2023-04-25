using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    private Vector2 fingerDown;
    private Vector2 fingerUp;

    public bool detectSwipeOnlyAfterRelease = false;

    public float minDistanceForSwipe = 20f;

    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                fingerUp = touch.position;
                fingerDown = touch.position;
            }

            if (!detectSwipeOnlyAfterRelease && touch.phase == TouchPhase.Moved)
            {
                fingerDown = touch.position;
                CheckSwipe();
            }

            if (touch.phase == TouchPhase.Ended)
            {
                fingerDown = touch.position;
                CheckSwipe();
            }
        }
    }

    void CheckSwipe()
    {
        float distance = Vector2.Distance(fingerDown, fingerUp);

        if (distance > minDistanceForSwipe)
        {
            Vector2 direction = fingerDown - fingerUp;

            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                if (direction.x > 0)
                {
                    rb.velocity = new Vector2(5f, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(-5f, rb.velocity.y);
                }
            }
            else
            {
                if (direction.y > 0)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 5f);
                }
                else
                {
                    rb.velocity = new Vector2(rb.velocity.x, -5f);
                }
            }
        }
    }
}
