using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class InteractionSpawner : MonoBehaviour
{
    // Add the specified interaction to their respective interaction size spawners
    [SerializeField] private List<GameObject> interactions;

    // Start is called before the first frame update
    // In this context, it sets the transform to be in the local space of the chunk(transform.parent).
    void Start()
    {
        Instantiate(interactions[Random.Range(0, interactions.Count)], transform.parent);
        Destroy(gameObject);
    }
}
