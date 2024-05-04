using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public Transform player;
    Vector3 offset;
    // Start is called before the first frame update
    private void Awake()
    {
        player = FindObjectOfType<PlayerController>().transform;
    }
    void Start()
    {
        offset = transform.position - player.position;   
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetpos=player.position+offset;
        targetpos.x = 0;
        transform.position = targetpos;
    }
}
