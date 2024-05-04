using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent enmey;
    public Transform player;
    public Rigidbody rb;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
       
    }
    void Start()

    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enmey.SetDestination(player.position);
    }
}
