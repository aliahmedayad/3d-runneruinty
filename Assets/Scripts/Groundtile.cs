using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groundtile : MonoBehaviour
{
    // Start is called before the first frame update
    private Groundspawner spawner;
    public GameObject[] obstprefab;
    public Transform[] spaawnpoints;
    private void Awake()
    {
        spawner=GameObject.FindObjectOfType<Groundspawner>();
    }
    void Start()
    {
        spawnobs();
    }
    private void OnTriggerExit(Collider other)
    {
        spawner.spawn();
        Destroy(gameObject, 1.5f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void spawnobs()
    {
        int choosespawnpoint = Random.Range(0, spaawnpoints.Length); 
        int spawnrpefab=Random.Range(0,obstprefab.Length);
        Instantiate(obstprefab[spawnrpefab], spaawnpoints[choosespawnpoint].transform.position, Quaternion.identity, transform);
    }
}
