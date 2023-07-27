using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMode : MonoBehaviour
{
    /*
     * This component basically controls the game loop. mainly concerns:
     * Death
     * Score
     * So worldly events that aren't tied to the player which is basically the entire game so yeah
     * In my head it's kind of like defining a difficulty for the level.
     */

    [SerializeField] private float outOfBoundsX = 13;
    [SerializeField] private float outOfBoundsY = 6;
    /*
     * Thinking about this rn:
     * Could tie multiplier to worldSpeed - 4
     * No clue if it should step up based on time frame or after hitting a certain score
     */
    [SerializeField] private float worldSpeedBase = 5f;
    // [SerializeField] private float worldSpeedMax = 5f;
    [SerializeField] private float currentWorldSpeed;
    public float GetWorldSpeed()
    {
        return currentWorldSpeed;
    }
    
    // Potential to tie this to currentWorldSpeed
    [SerializeField] private float scoreMultiplier = 1;
    
    public float GetScoreMultiplier()
    {
        return scoreMultiplier;
    }
    
    private bool _scoreSaved;

    [SerializeField] private float resurrectionSpawnPointY = 3;

    private Rigidbody _rigidbody;
    private Health _health;
    private Score _score;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _health = GetComponent<Health>();
        _score = GetComponent<Score>();

        currentWorldSpeed = worldSpeedBase;
        
        UnpauseGame(); // To start the level after a reload
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
        if (!_health.GetIsDead()) return;
        PauseGame();
        LetUserDecideOnDeath();
    }

    private void LetUserDecideOnDeath()
    {
        /*
         * Here's where instead of keyboard input we would use the UI
         * But for now it will just wait until keyboard input
         */

        if (Input.GetKeyDown(KeyCode.R))
        {
            EndGame();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Resurrect();
        }
    }

    private void Resurrect()
    {
        UnpauseGame();
        
        // For right now, I'm just making the player spawn super high up in the middle of the screen when they are resurrected
        _rigidbody.position = new Vector3(0, resurrectionSpawnPointY, 0);;
        _rigidbody.velocity = Vector3.zero; 

        _health.SetCurrentHealth(_health.GetMaxHealth());
        _health.SetIsDead(false);
        // Should probably make them be invulnerable to the next few seconds or float or something but
        // no clue what to do until we actually have a working game.

    }

    private void EndGame()
    {
        if (!_scoreSaved)
        {
            _score.UpdateHighScore();
            _scoreSaved = true;
        }

        ReloadGame();
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
            _health.ApplyDamage(_health.GetCurrentHealth());
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
