using System;
using UnityEngine;

namespace Player
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private float score = 0;
        private GameMode _gameMode;

        private void Start()
        {
            _gameMode = GetComponent<GameMode>();
        }

        public float GetScore()
        {
            return score;
        }
        // We should probably get score as an integer too (I'm looking at you UI)
        public int GetScoreAsInt()
        {
            return (int)score;
        }

        // Will allow for other classes to change score through OOP goodness while including the multiplier
        public void AddScore(float scoreToAdd)
        {
            score += scoreToAdd * _gameMode.GetScoreMultiplier();
        }

        // Saves the high score
        public void UpdateHighScore()
        {
            if (PlayerPrefs.HasKey("hiScore"))
            {
                if(score > PlayerPrefs.GetFloat("highScore"))
                {
                    PlayerPrefs.SetFloat("hiScore", score);
                    PlayerPrefs.Save();
                }
            }
            else
            {   
                PlayerPrefs.SetFloat("highScore", score);
                PlayerPrefs.Save();
            }
        }
    }
}
