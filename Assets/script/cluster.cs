using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine;

public class cluster : MonoBehaviour
{   
    public bool parity = true;
    private float x1;
    private float x2;
    private float y1;
    private float y2;

    public GameObject fly1;
    public GameObject fly2;
     
    private float sigmoid(float x)
    {
        return x/ (1 + x * x);
    }



    private void move(float x, float y, GameObject fly)
    {
        float current_x = fly.transform.position.x;
        float current_y = fly.transform.position.y;
        
        Vector2 displacemet = new Vector2(x - current_x, y - current_y);
        float distance = displacemet.magnitude;
        float dx = displacemet.x / distance;
        float dy = displacemet.y / distance;

        while (distance > 0.1f)
        {
            //   float speed = sigmoid(distance);
            current_x = current_x + dx;
            current_y = current_y + dy;
            fly.transform.position = new Vector2(current_x, current_y);

        }
    }

    void OnMouseDown()
    {
        parity = parity!;
        if (parity)
        {
            x2 = gameObject.transform.position.x;
            y2 = gameObject.transform.position.y;
            float midx = (x1 + x2) / 2;
            float midy = (y1 + y2) / 2;
            move(midx, midy, gameObject);
        }
        else
        {
            x1 = gameObject.transform.position.x;
            y1 = gameObject.transform.position.y;
        }
    }
}