using UnityEngine;

namespace Map_Generation
{
    public class ChunkMover : MonoBehaviour
    {
        [SerializeField] private float speed = 1f; // TODO change to global speed variable
        
        // Update is called once per frame
        void Update()
        {
            transform.position += (new Vector3(-1, 0, 0) * (speed * Time.deltaTime));
        }
    }
}
