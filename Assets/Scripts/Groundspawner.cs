using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groundspawner : MonoBehaviour
{
    public GameObject ground;
    Vector3 next;
    public void spawn()
    {
        GameObject tempground=Instantiate(ground,next,Quaternion.identity);
        next=tempground.transform.GetChild(1).transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            spawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
