using UnityEngine;

namespace Map_Generation
{
    public class ChunkDespawner : MonoBehaviour
    {
        // When the chunks hit the despawner collider, it will despawn the chunk.
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
