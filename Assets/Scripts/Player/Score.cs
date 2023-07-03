using UnityEngine;

namespace Player
{
    public class Score : MonoBehaviour
    {
        private float _score = 0;
    
        public float GetScore()
        {
            return _score;
        }
        // We should probably get score as an integer too (I'm looking at you UI)
        public int GetScoreAsInt()
        {
            return (int)_score;
        }

        // Will allow for other classes to change score through OOP goodness
        public void AddScore(float scoreToAdd)
        {
            _score += scoreToAdd;
        }
    }
}
