using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject npc;
    NPC test;

    // Start is called before the first frame update
    void Start()
    {
        test.Hat = "Test Hat";
        Instantiate(npc, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
