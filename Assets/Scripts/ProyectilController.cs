using UnityEngine;

public class ProyectilController : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Enemigo") || collider.gameObject.CompareTag("Amigo"))
        {
            Destroy(collider.gameObject);
            //un segundo despues de destruir el enemigo, destruir el proyectil
            Invoke("DestroyProjectile", 1f);
        }
        if (collider.gameObject.CompareTag("Suelo"))
        {
            Destroy(gameObject);
        }
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}