using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject destroyedVFX;
    void OnTriggerEnter(Collider other)
    {

        Instantiate(destroyedVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
}
