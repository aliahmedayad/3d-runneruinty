using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groundtile : MonoBehaviour
{
    // Start is called before the first frame update
    private Groundspawner spawner;
    public GameObject[] obstprefab;
    public GameObject coins;
    public Transform[] spaawnpoints;
    private void Awake()
    {
        spawner=GameObject.FindObjectOfType<Groundspawner>();
    }
    void Start()
    {
        spawnobs();
      
        
        spawnCoin();
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
        int spawnrpefab = Random.Range(0, obstprefab.Length);
        Vector3 spawnPosition = spaawnpoints[choosespawnpoint].transform.position;
       
        if (spawnrpefab == 2)
        {
            Quaternion spawnRotation = Quaternion.Euler(0f,180f, 0f); // Rotate 180 degrees around y-axis
            Instantiate(obstprefab[spawnrpefab], spawnPosition, spawnRotation, transform);
        }
        else if (spawnrpefab == 3)
        {

            Quaternion spawnRotation = Quaternion.Euler(0f, 90f, 0f); // Rotate 180 degrees around y-axis
            Instantiate(obstprefab[spawnrpefab], spawnPosition, spawnRotation, transform);
        }
        else
        {
            Instantiate(obstprefab[spawnrpefab], spaawnpoints[choosespawnpoint].transform.position, Quaternion.identity, transform);
        }
       


    }
    public void spawnCoin()
    {
        int spawnamount = 2;
        for(int i = 0;i< spawnamount; i++) {
            GameObject temp = Instantiate(coins);
            temp.transform.position = spawnRnd(GetComponent<Collider>());
        }
    }
    Vector3 spawnRnd(Collider coll)
    {
        Vector3 pnt = new Vector3(Random.Range(coll.bounds.min.x, coll.bounds.max.x), Random.Range(coll.bounds.min.y, coll.bounds.max.y), Random.Range(coll.bounds.min.z, coll.bounds.max.z));
        pnt.y = 1;
        return pnt;
    }
}
