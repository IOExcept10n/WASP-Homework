using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleFallingHandler : MonoBehaviour
{
    public float BottomLimit = -10f;

    public GameObject BowlPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < BottomLimit)
        {
            var bowls = GameObject.FindGameObjectsWithTag("Bowl");
            var apples = GameObject.FindGameObjectsWithTag("Apple");
            foreach (var apple in apples) Destroy(apple);
            if (bowls != null && bowls.Length > 1)
            {
                Destroy(bowls[0]);
            }
            else
            {
                Destroy(bowls[0]);
                for (int i = 0; i < 3; i++)
                {
                    Instantiate(BowlPrefab);
                }
            }
        }
    }
}
