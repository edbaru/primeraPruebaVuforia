using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class JuegoSueloController : MonoBehaviour
{
    /*
     * Cosas que faltan por hacer:
     * Musica y efectos de sonido
     * Revisar la velocidad de caida de los objetos
     * Fin del juego con vidas
     * Modelo 3D para objetos que caen y arma que dispara
     * Efectos visuales cuando se dispara y cuando golpea un objeto
     * Pullir menu inicio y hacer menu fin del juego
     */
    [SerializeField] GameObject prefabEnemigo;
    [SerializeField] GameObject prefabAmigo;
    [SerializeField] TextMeshProUGUI textoVidas;
    [SerializeField] TextMeshProUGUI textoBalas;
    public bool juegoActivo = false;
    private float rangoSpawn = 1.0f;
    private float alturaBolaCae = 3f;
    private int puntuacion = 0;
    private int vidas = 5;
    public static JuegoSueloController instanciaJuego;

    public static event Action<int> BalaDisparada;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LanzadorProyectiles.ActualizaHUD += OnActualizarHUD;
    }

    private void Awake()
    {
        if (instanciaJuego == null)
        {
            instanciaJuego = this;
        }
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

            GameObject prefabInstanciar = (UnityEngine.Random.value > 0.3f) ? prefabEnemigo : prefabAmigo;

            Vector3 posicionAleatoria = transform.position + new Vector3(UnityEngine.Random.Range(-rangoSpawn, rangoSpawn), alturaBolaCae, 3.0f);

            Instantiate(prefabInstanciar, posicionAleatoria, Quaternion.identity, transform);
        }
    }

    public void ChoqueSueloEnemigo()
    {
        vidas--;
        textoVidas.text = "Puntuacion: " + puntuacion;
    }
    public void ChoqueSueloAmigo()
    {
        puntuacion++;
        textoVidas.text = "Puntuacion: " + puntuacion;
    }

    public void SalirJuego()
    {
        juegoActivo = false;
        StopAllCoroutines();
        Application.Quit();
    }

    public void OnActualizarHUD(int balas)
    {
        textoBalas.text = "Balas: " + balas + "/8";
    }
}
