using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject destroyedVFX;
    GameSceneManager gameSceneManager;
    public void Start()
    {
        gameSceneManager = FindFirstObjectByType<GameSceneManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        Instantiate(destroyedVFX, transform.position, Quaternion.identity);
        if (gameSceneManager != null)
            gameSceneManager.ReloadScene();
        Destroy(gameObject);
    }
}
