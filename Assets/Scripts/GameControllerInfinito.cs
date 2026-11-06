using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerInfinito : MonoBehaviour
{
    [SerializeField] float tiempoTotal = 10f;
    [SerializeField] int puntuacion = 0;
    [SerializeField] int vidas = 3;
    [SerializeField] static int mejorPuntuacion = 0;
    [SerializeField] TextMeshProUGUI vidasTxt;
    [SerializeField] TextMeshProUGUI tiempoTxt;
    [SerializeField] TextMeshProUGUI puntuacionTxt;
    [SerializeField] TextMeshProUGUI planetaAdivinarTxt;
    [SerializeField] TextMeshProUGUI puntuacionFinalTxt;
    [SerializeField] TextMeshProUGUI puntuacionMejorTxt;
    [SerializeField] string[] opcionesMostrar = {"Sol, Mercurio, Venus, Tierra, Marte, Jupiter, Saturno, Neptuno, Urano"};
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject gameUI;
    [SerializeField] AudioSource efectoSonidoCorrecto;
    [SerializeField] AudioSource efectoSonidoIncorrecto;
    [SerializeField] AudioSource efectoSonidoGameOver;

    public int ultimoPlanetaElegido = -1;
    void Start()
    {
        gameOver.SetActive(false);
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
                GuardarPuntuacion(puntuacion);
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
    }

    private void ElegirNuevoPlaneta()
    {
        int posAleatoria = Random.Range(0, opcionesMostrar.Length);
        while (ultimoPlanetaElegido == posAleatoria)
        {
            posAleatoria = Random.Range(0, opcionesMostrar.Length);
        }
        planetaAdivinarTxt.text = opcionesMostrar[posAleatoria];
    }

    public void Chequar(string planetaEncontrado)
    {
        if(planetaEncontrado == planetaAdivinarTxt.text)
        {
            puntuacion++;
            puntuacionTxt.text = "Puntuacion: " + puntuacion;
            efectoSonidoCorrecto.Play();
            ReiniciarContador();
            ElegirNuevoPlaneta();
        }
        
        if(planetaEncontrado != planetaAdivinarTxt.text)
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

    public void ReiniciarPartida()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale=1f;
    }

    public void GuardarPuntuacion(int puntuacion)
    {
        if (puntuacion > mejorPuntuacion)
        {
            mejorPuntuacion = puntuacion;
        }
        puntuacionFinalTxt.text = "Puntuacion: " + puntuacion;
        puntuacionMejorTxt.text = "Record actual: " + mejorPuntuacion;
    }
}