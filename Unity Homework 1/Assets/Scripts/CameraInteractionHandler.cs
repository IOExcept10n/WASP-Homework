using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInteractionHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10));// + new Vector3(0, 0, transform.position.z - Camera.main.transform.position.z)
        var bowls = GameObject.FindGameObjectsWithTag("Bowl");
        if (bowls != null)
        {
            int offset = -8;
            foreach (var bowl in bowls)
            {
                bowl.transform.position = new Vector3(position.x, offset, 10);
                offset += 2;
            }
        }
    }
}
