using UnityEngine;

public class ProyectilController : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Enemigo") || collider.gameObject.CompareTag("Amigo"))
        {
            Destroy(collider.gameObject);
            Destroy(gameObject);
        }
        if (collider.gameObject.CompareTag("Suelo"))
        {
            Destroy(gameObject);
        }
    }
}
