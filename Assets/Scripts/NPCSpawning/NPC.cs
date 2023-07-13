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
        List<string> hats = new List<string>();
        hats.Add("Hat 1");
        hats.Add("Hat 2");
        hats.Add("Hat 3");

        List<string> faces = new List<string>();
        faces.Add("Face 1");
        faces.Add("Face 2");
        faces.Add("Face 3");

        List<string> outfits = new List<string>();
        outfits.Add("Outfit 1");
        outfits.Add("Outfit 2");
        outfits.Add("Outfit 3");

        string[] traits = GenerateTraits(hats, faces, outfits);
        hat = traits[0];
        face = traits[1];
        outfit = traits[2];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    string[] GenerateTraits(List<string> traits1, List<string> traits2, List<string> traits3)
    {
        string[] traits = new string[3];
        traits[0] = traits1[Random.Range(0, 3)];
        traits[1] = traits2[Random.Range(0, 3)];
        traits[2] = traits3[Random.Range(0, 3)];
        return traits;
    }
}
