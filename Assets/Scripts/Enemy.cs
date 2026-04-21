using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyedVFX;
    private void OnParticleCollision(GameObject other) 
    {
        Instantiate(destroyedVFX, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
