using System.Collections.Generic;
using UnityEngine;

namespace Map_Generation
{
    public class ChunkSpawner : MonoBehaviour
    {
        // Spawn locations
        [SerializeField] private Vector3 chunkSpawnLocation = new Vector3(30, 0, 0);
        [SerializeField] private Vector3 chunkDespawnerSpawnLocation = new Vector3(-30, 0, 0);
        
        // Chunk parameters
        [SerializeField] private float chunkLength = 10f;
        [SerializeField] private float speed = 1f; // TODO change to global speed variable
        private float _spawnInterval;
        private float _timePassed;
        
        // Chunk prefabs
        [SerializeField] private List<GameObject> chunks;
        [SerializeField] private GameObject chunkDespawner;

        // Start is called before the first frame update
        // Sets all the variables 
        void Start()
        {
            _spawnInterval = chunkLength / speed;
            SpawnChunkDespawner();
            GenerateChunk();
            _timePassed = 0;
        }

        // Update is called once per frame
        void Update()
        {
            // Spawns a chunk as soon as time passed is equal to the interval
            // Used https://discussions.unity.com/t/simple-timer/56201/2 to figure out a timer system
            if (_timePassed >= _spawnInterval)
            {
                GenerateChunk();
                _timePassed = 0;
            }
            _timePassed += Time.deltaTime;
        }

        private void SpawnChunkDespawner()
        {
            Instantiate(chunkDespawner, chunkDespawnerSpawnLocation, Quaternion.identity);
        }

        private void GenerateChunk()
        {
            Instantiate(chunks[Random.Range(0, chunks.Count)], chunkSpawnLocation, Quaternion.identity);
        }
    }
}
