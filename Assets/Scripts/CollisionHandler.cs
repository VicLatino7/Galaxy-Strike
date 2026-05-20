using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject destroyedVFX;

    void OnTriggerEnter(Collider other)
    {
        Instantiate(destroyedVFX, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
