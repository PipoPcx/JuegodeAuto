using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchAndroid : MonoBehaviour
{
    public float speed = 0.4f;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0);
        {

            Touch touch = Input.GetTouch(0);
            float screeHalf = Screen.width / 2;
            Vector3 movement = Vector2.zero;

            if(touch.position.x > screeHalf)
            {
                movement = Vector2.right;
            }

            else
            {
                movement = Vector2.left;
            }

            this.transform.position += movement * this.speed * Time.deltaTime;
        }
    }
}
