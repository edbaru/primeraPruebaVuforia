using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void JugarFinito()
    {
        SceneManager.LoadScene("SistemaSolarFinito");
    }

    public void JugarInfinito()
    {
        SceneManager.LoadScene("SistemaSolarInfinito");
        
    }

    public void Salir()
    {
        Application.Quit();
    }
}
