using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerFinito : MonoBehaviour
{
    [SerializeField] float tiempoTotal = 10f;
    [SerializeField] int puntuacion = 0;
    [SerializeField] int vidas = 3;
    [SerializeField] static int mejorPuntuacion = 0;
    [SerializeField] TextMeshProUGUI vidasTxt;
    [SerializeField] TextMeshProUGUI tiempoTxt;
    [SerializeField] TextMeshProUGUI puntuacionTxt;
    [SerializeField] TextMeshProUGUI planetaAdivinarTxt;
    [SerializeField] TextMeshProUGUI puntuacionFinalTxtGameOver;
    [SerializeField] TextMeshProUGUI puntuacionMejorTxtGameOver;
    [SerializeField] TextMeshProUGUI puntuacionFinalTxtWin;
    [SerializeField] TextMeshProUGUI puntuacionMejorTxtWin;
    [SerializeField] List<string> opcionesMostrar = new List<string>{"Sol, Mercurio, Venus, Tierra, Marte, Jupiter, Saturno, Neptuno, Urano"};
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject gameWin;
    [SerializeField] GameObject gameUI;
    [SerializeField] AudioSource efectoSonidoCorrecto;
    [SerializeField] AudioSource efectoSonidoIncorrecto;
    [SerializeField] AudioSource efectoSonidoGameOver;
    [SerializeField] AudioSource efectoSonidoGameWin;

    private int posAleatoria;
    private bool victoriaProcesada;

    void Start()
    {
        Time.timeScale=1f;
        gameOver.SetActive(false);
        gameWin.SetActive(false);
        ElegirNuevoPlaneta();
    }

    void Update()
    {
        //Controllo que no se acabe el tiempo
        tiempoTotal = tiempoTotal-Time.deltaTime;
        if (tiempoTotal <= 0)
        {
            vidas--;
            vidasTxt.text = "Vidas: " + vidas.ToString();
            if (vidas == 0)
            {
                GuardarPuntuacionGameOver(puntuacion);
                gameOver.SetActive(true);
                gameUI.SetActive(false);
                efectoSonidoGameOver.Play();
                Time.timeScale=0f;
            }
            efectoSonidoIncorrecto.Play();
            ReiniciarContador();
            ElegirNuevoPlaneta();
        }
        else
        {
            tiempoTxt.text = "Tiempo: " + tiempoTotal.ToString("F1");
        }
        if (opcionesMostrar.Count == 0 && !victoriaProcesada)
        {
            victoriaProcesada = true;
            GuardarPuntuacionWin(puntuacion);
            gameWin.SetActive(true);
            gameUI.SetActive(false);
            efectoSonidoGameWin.Play();
            Time.timeScale=0f;
        }
    }

    private void ElegirNuevoPlaneta()
    {
        posAleatoria = Random.Range(0, opcionesMostrar.Count);
        planetaAdivinarTxt.text = opcionesMostrar[posAleatoria];
    }

    public void Chequar(string planetaEncontrado)
    {
        if(planetaEncontrado == planetaAdivinarTxt.text)
        {
            puntuacion++;
            puntuacionTxt.text = "Correctos: " + puntuacion;
            efectoSonidoCorrecto.Play();
            ReiniciarContador();
            opcionesMostrar.RemoveAt(posAleatoria);
            ElegirNuevoPlaneta();
            Time.timeScale = 0f;
        }

        else
        {
            vidas--;
            vidasTxt.text = "Vidas: " + vidas.ToString();
            efectoSonidoIncorrecto.Play();
            ReiniciarContador();
            ElegirNuevoPlaneta();
        }
    }

    private void ReiniciarContador()
    {
        tiempoTotal = 10f;
    }

    public void ResumirPartida()
    {
        Time.timeScale = 1f;
    }

    public void ReiniciarPartida()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale=1f;
    }

    public void GuardarPuntuacionGameOver(int puntuacion)
    {
        if (puntuacion > mejorPuntuacion)
        {
            mejorPuntuacion = puntuacion;
        }
        puntuacionFinalTxtGameOver.text = "Correctos: " + puntuacion + "/9";
        puntuacionMejorTxtGameOver.text = "Mejor intento: " + mejorPuntuacion + "/9";
    }

    public void GuardarPuntuacionWin(int puntuacion)
    {
        if (puntuacion > mejorPuntuacion)
        {
            mejorPuntuacion = puntuacion;
        }
        puntuacionFinalTxtWin.text = "Correctos: " + puntuacion + "/9";
        puntuacionMejorTxtWin.text = "Mejor intento: " + mejorPuntuacion + "/9";
    }

    public void VolverAtras()
    {
        SceneManager.LoadScene(0);
    }
}