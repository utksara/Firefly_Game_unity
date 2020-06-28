using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defaultMotion : MonoBehaviour
{
    Vector2 m_NewPosition;
    Vector2 m_NewPosition2;
    //This is the new X position. Set it in the Inspector.
    public float Ycoord;
    public float Xcoord;
    public float time = 0.0f;
    public float timePeriod = 1.0f;
    public float phase = 0.0f;
    public float radius = 1.0f;
    public Vector2 initPos;
    public GameObject fly;
    public GameObject fly2;

    void setTimePeriod(float value) {
        timePeriod = value;
    }

    void setRadius(float value){
        radius = value;
    }

    void setInitPos(){
        initPos.y = fly.transform.position.y;
        initPos.x = fly.transform.position.x;
    }

    void setPhase(float value)
    {
        phase = value;
    }
    // Use this for initialization
    void Start()
    {
        setTimePeriod(0.5f);
        setRadius(0.1f);
        setPhase(Random.Range(0.0f, 1.0f));
        setInitPos();
    }

    void Update()
    {
        time += Time.deltaTime;  
        Ycoord = initPos.y + radius * (float)System.Math.Sin(phase + time/timePeriod);
        Xcoord = initPos.x + radius * (float)System.Math.Cos(phase + time/timePeriod);
        m_NewPosition = new Vector2(Xcoord, Ycoord);
        m_NewPosition2 = new Vector2(Xcoord+2, Ycoord+2);
        fly.transform.position = m_NewPosition;
        fly2.transform.position = m_NewPosition2;
    }
}
