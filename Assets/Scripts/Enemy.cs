using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyedVFX;
    [SerializeField] int hitCount = 6;
    [SerializeField] int scoreValue = 10;
    ScoreBoard scoreBoard;
    private void Start()
    {
        scoreBoard = FindFirstObjectByType<ScoreBoard>();
    }
    void OnParticleCollision(GameObject other)
    {
        processHit();
    }

    private void processHit()
    {
        hitCount--;
        if (hitCount <= 0)
        {
            scoreBoard.IncreaseScore(scoreValue);
            Instantiate(destroyedVFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
