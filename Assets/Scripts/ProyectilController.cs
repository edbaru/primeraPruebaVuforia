using UnityEngine;

public class ProyectilController : MonoBehaviour
{
    void Start()
    {
        Invoke("DestroyProjectile", 2f);
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Enemigo") || collider.gameObject.CompareTag("Amigo"))
        {
            Destroy(collider.gameObject);
        }
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}