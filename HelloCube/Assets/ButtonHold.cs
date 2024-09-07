using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonHold : MonoBehaviour
{

    public BallPrefab ballPrefab;
    private int force = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Touchscreen.current.press.isPressed)
        {
            force += 20; // increase force as button is held
        }
        else if (force > 0)
        {
            BallPrefab ball = Instantiate<BallPrefab>(ballPrefab);
            ball.transform.localPosition = transform.position;
            ball.GetComponent<Rigidbody>().AddForce(Camera.main.transform.right *
                force);

            // change color of ball based on force
            float red = (float)Math.Min(force, 5000) / 5000;
            float green = 1 - red;
            Color color = new Color(red, green, 0, 1);
            var render = ball.GetComponent<Renderer>();
            render.material.SetColor("_Color", color);

            force = 0; // reset force to zero so only one ball shoots
        }
    }
}
