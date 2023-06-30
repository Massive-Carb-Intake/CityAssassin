using UnityEngine;

namespace Map_Generation
{
    public class ChunkDespawner : MonoBehaviour
    {
        void OnCollisionEnter(Collision collision)
        {
            // The only way this works is if the chunk has a rigidbody (idk don't ask)
            // and a tag that specifies it as chunk
            switch (collision.gameObject.tag)
            {
                case "Chunk":
                    Destroy(collision.gameObject);
                    break;
            }
        }
    }
}
