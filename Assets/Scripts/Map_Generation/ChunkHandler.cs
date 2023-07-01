using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Map_Generation
{
    public class ChunkHandler : MonoBehaviour
    {
        // Spawn locations
        [SerializeField] private Vector3 chunkSpawnLocation = new Vector3(30, 0, 0);
        public Vector3 chunkDespawnLocation;
        
        // Chunk parameters
        [SerializeField] public float chunkLength = 10f;
        private float _timePassed;
        public float spawnInterval;
        
        // Chunk prefabs
        [SerializeField] private List<GameObject> chunks;
        
        private PlayerMovement _playerMovement;
        
        // Sets the despawn location
        // All self-initializations (stuff that doesn't rely on other components) should happen in Awake()
        private void Awake()
        {
            chunkDespawnLocation = new Vector3(-chunkSpawnLocation.x, chunkSpawnLocation.y, chunkSpawnLocation.z);
        }

        // Start is called before the first frame update
        void Start()
        {
            // Used https://www.youtube.com/watch?v=Y7pp2gzCzUI to figure out how to reference other components
            _playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
            GenerateChunk();
            // Self-initialization but it has to happen after a chunk is generated
            _timePassed = 0;
        }

        private void UpdateSpawnInterval()
        {
            spawnInterval = chunkLength / _playerMovement.worldSpeed;
        }

        // Update is called once per frame
        void Update()
        {
            // Spawns a chunk as soon as time passed is equal to the interval
            // Used https://discussions.unity.com/t/simple-timer/56201/2 to figure out a timer system
            if (_timePassed >= spawnInterval)
            {
                GenerateChunk();
                _timePassed = 0;
            }
            //UpdateSpawnInterval();
            _timePassed += Time.deltaTime;
        }

        private void GenerateChunk()
        {
            // Grabs the new speed only after one interval has passed because otherwise it will generate chunks wrong
            UpdateSpawnInterval();
            Instantiate(chunks[Random.Range(0, chunks.Count)], chunkSpawnLocation, Quaternion.identity);
        }
    }
}
