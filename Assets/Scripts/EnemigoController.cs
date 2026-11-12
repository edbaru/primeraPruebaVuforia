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

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Suelo"))
        {
            if (gameObject.CompareTag("Enemigo"))
            {
                JuegoSueloController.instanciaJuego.ChoqueSueloEnemigo();
            }
            if (gameObject.CompareTag("Amigo"))
            {
                JuegoSueloController.instanciaJuego.ChoqueSueloAmigo();
            }
            Destroy(gameObject);
        }
    }
}
