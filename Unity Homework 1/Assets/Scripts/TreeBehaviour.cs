using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TreeBehaviour : MonoBehaviour
{
    public float BoundingRadius = 15f;

    public float Speed = 5f;

    public int AppleTime = 1;

    private float cd = 1;

    public GameObject ApplePrefab;

    // Start is called before the first frame update
    void Start()
    {
        cd = AppleTime;
        Bowls = GameObject.FindGameObjectsWithTag("Bowl").ToList();
        Apples = GameObject.FindGameObjectsWithTag("Apple").ToList();
    }

    public static List<GameObject> Bowls;

    public static List<GameObject> Apples;

    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(transform.position.x) > BoundingRadius || UnityEngine.Random.value < 0.005f)
        {
            Speed *= -1;
        }
        transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
        if (cd <= 0)
        {
            var apple = Instantiate(ApplePrefab, transform.position - new Vector3(0, 2, 0), transform.rotation);
            Apples.Add(apple);
            cd = AppleTime;
        }
        cd -= Time.deltaTime;
    }
}
