using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBehaviour : MonoBehaviour
{
    public float BoundingRadius = 30f;

    public float Speed = 5f;

    public int AppleTime = 1;

    private int cd;

    public GameObject ApplePrefab;

    // Start is called before the first frame update
    void Start()
    {
        cd = AppleTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(transform.position.x) > BoundingRadius || UnityEngine.Random.value < 0.005f)
        {
            Speed *= -1;
        }
        transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
        if (Time.realtimeSinceStartup >= cd)
        {
            Instantiate(ApplePrefab, transform.position - new Vector3(0, 2, 0), transform.rotation);
            cd += AppleTime;
        }
    }
}
