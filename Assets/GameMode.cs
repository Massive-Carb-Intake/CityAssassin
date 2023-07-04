using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMode : MonoBehaviour
{
    /*
     * Out of bounds causes kill
     * Update scoreboard
     * Game end (scoreboard update)
     * Resurrection
     */

    [SerializeField] private float outOfBoundsX = 13;
    [SerializeField] private float outOfBoundsY = 6;

    [SerializeField] private float scoreMultiplier = 1;

    public float GetScoreMultiplier()
    {
        return scoreMultiplier;
    }

    private Rigidbody _rigidbody;
    private Health _health;
    private Score _score;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _health = GetComponent<Health>();
        _score = GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleOutOfBounds();
        IncreaseScoreContinuously();
        HandleDeath();
    }

    private void HandleDeath()
    {
        if (_health.GetIsDead())
        {
            PauseGame();
            _score.UpdateHighScore();
            ReloadGame();
        }
    }

    private void IncreaseScoreContinuously()
    {
        _score.AddScore(Time.deltaTime);
    }

    private void HandleOutOfBounds()
    {
        if (_rigidbody.position.x <= -outOfBoundsX || _rigidbody.position.x >= outOfBoundsX ||
            _rigidbody.position.y <= -outOfBoundsY || _rigidbody.position.y >= outOfBoundsY)
        {
            _health.ApplyDamage(_health.GetHealth());
        }
    }

    // Used https://gamedevbeginner.com/the-right-way-to-pause-the-game-in-unity/
    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(0); // Set the right level in build manager pretty please
    }
}
