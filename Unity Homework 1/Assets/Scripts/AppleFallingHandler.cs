using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            foreach (var apple in TreeBehaviour.Apples) Destroy(apple);
            TreeBehaviour.Apples.Clear();
            var bowl = TreeBehaviour.Bowls.Last();
            Destroy(bowl);
            TreeBehaviour.Bowls.Remove(bowl);
            if (TreeBehaviour.Bowls.All(x => x == null))
            {
                for (int i = 0; i < 3; i++)
                {
                    TreeBehaviour.Bowls.Add(Instantiate(BowlPrefab));
                }
            }
        }
    }
}
