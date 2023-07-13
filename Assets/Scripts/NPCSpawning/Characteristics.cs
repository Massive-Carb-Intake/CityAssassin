using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characteristics : MonoBehaviour
{
    NPC npc;
    [SerializeField] GameObject target;

    //Called before Start
    void Awake()
    {
        npc = target.GetComponent<NPC>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
