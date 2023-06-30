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

        private CharacterMovement _characterMovement;
        
        // Sets the despawn location
        // All self-initializations (stuff that doesn't rely on other components) should happen in Awake()
        private void Awake()
        {
            chunkDespawnLocation = new Vector3(-chunkSpawnLocation.x, chunkSpawnLocation.y, chunkSpawnLocation.z);
        }

        // Start is called before the first frame update
        void Start()
        {
            _characterMovement = GameObject.Find("Player").GetComponent<CharacterMovement>();
            UpdateSpawnInterval();
            
            // Self-initialization but it has to happen after a chunk is generated
            GenerateChunk();
            _timePassed = 0;
        }

        private void UpdateSpawnInterval()
        {
            spawnInterval = chunkLength / _characterMovement.worldSpeed;
        }

        // Update is called once per frame
        void Update()
        {
            // Spawns a chunk as soon as time passed is equal to the interval
            // Used https://discussions.unity.com/t/simple-timer/56201/2 to figure out a timer system
            if (_timePassed >= spawnInterval)
            {
                GenerateChunk();
                // Grabs the new speed only after one interval has passed because otherwise it will generate chunks wrong
                UpdateSpawnInterval();
                _timePassed = 0;
            }
            //UpdateSpawnInterval();
            _timePassed += Time.deltaTime;
        }

        private void GenerateChunk()
        {
            Instantiate(chunks[Random.Range(0, chunks.Count)], chunkSpawnLocation, Quaternion.identity);
        }
    }
}
