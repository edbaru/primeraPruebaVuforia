using UnityEngine;

public class EnemigoController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            if (gameObject.CompareTag("Enemigo"))
            {
                Debug.Log("Pierdes vida");
            }
            Destroy(gameObject);
        }
    }
}
