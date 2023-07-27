using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Characteristics : MonoBehaviour
{
    public NPC npc;
    //NPC npc;
    //[SerializeField] GameObject target;
    public Text text;

    //Called before Start
    void Awake()
    {
        //npc = target.GetComponent<NPC>();
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

        text.text = "Hello World";

        string[] target = npc.GenerateTraits(hats, faces, outfits);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
