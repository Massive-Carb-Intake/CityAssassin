using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string hat;
    public string face;
    public string outfit;
    bool target;
    
    public string Hat
    {
        get
        {
            return hat;
        }
        set
        {
            hat = value;
        }
    }

    public string Face
    {
        get
        {
            return face;
        }
        set
        {
            face = value;
        }
    }

    public string Outfit
    {
        get
        {
            return outfit;
        }
        set
        {
            outfit = value;
        }
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
