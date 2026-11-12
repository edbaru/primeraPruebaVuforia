using System.Collections;
using TMPro;
using UnityEngine;

public class JuegoSueloController : MonoBehaviour
{
    [SerializeField] GameObject prefabEnemigo;
    [SerializeField] GameObject prefabAmigo;
    [SerializeField] TextMeshProUGUI textoVidas;
    public bool juegoActivo = false;
    private float rangoSpawn = 1.0f;
    private float alturaEnemigo = 3.0f;
    private int puntuacion = 0;
    
    public static JuegoSueloController instanciaJuego;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Awake()
    {
        if (instanciaJuego == null)
        {
            instanciaJuego = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IniciaJuego()
    {
        if (!juegoActivo)
        {
            juegoActivo = true;
            StartCoroutine(GenerarObjetos());
        }
    }
    IEnumerator GenerarObjetos()
    {
        while (juegoActivo)
        {
            yield return new WaitForSeconds(1);
            
            GameObject prefabInstanciar = (Random.value > 0.3f) ? prefabEnemigo : prefabAmigo;

            Vector3 posicionAleatoria = transform.position + new Vector3(Random.Range(-rangoSpawn, rangoSpawn), alturaEnemigo, 3.0f);

            Instantiate(prefabInstanciar, posicionAleatoria, Quaternion.identity, transform);
        }
    }

    public void ChoqueSueloEnemigo()
    {
        puntuacion--;
        textoVidas.text = "Puntuacion" + puntuacion;
    }
    public void ChoqueSueloAmigo()
    {
        puntuacion++;
        textoVidas.text = "Puntuacion" + puntuacion;
    }
}
