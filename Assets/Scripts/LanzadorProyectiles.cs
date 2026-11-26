using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class LanzadorProyectiles : MonoBehaviour
{
    [SerializeField] GameObject prefabProyectil;
    [SerializeField] GameObject arma;
    [SerializeField] AudioSource sonidoDisparo;
    [SerializeField] AudioSource sonidoRecarga;
    [SerializeField] Transform salidaDisparo;
    private Animator animator;
    private int balasActuales = 8;
    private bool intentandoRecargar = false;
    public static event Action<int> ActualizaHUD;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 posicionPantalla;

        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            if (balasActuales > 0)
            {
                posicionPantalla = Touchscreen.current.primaryTouch.position.ReadValue();

                Ray rayo = Camera.main.ScreenPointToRay(posicionPantalla);
                arma.transform.LookAt(rayo.GetPoint(10f));

                Vector3 posicionSalida = salidaDisparo.position;

                GameObject bala = Instantiate(prefabProyectil, posicionSalida, Quaternion.LookRotation(rayo.direction));

                Rigidbody rb = bala.GetComponent<Rigidbody>();
                rb.AddForce(rayo.direction * 100, ForceMode.Impulse);
                //sonidoDisparo.Play();
                BalaDisparada();
            }
            else
            {
                if (intentandoRecargar == false)
                {
                    intentandoRecargar = true;
                    Debug.Log(animator);
                    animator.SetBool("intentandoRecargar", true);
                    Invoke("RecargarBalas", 2f);
                }
            }
        }
    }

    public void BalaDisparada()
    {
        balasActuales--;
        ActualizarHUD();
    }

    public void ActualizarHUD()
    {
        ActualizaHUD?.Invoke(balasActuales);
    }

    public void RecargarBalas()
    {
        //sonidoRecarga.Play();
        balasActuales = 8;
        ActualizarHUD();
        intentandoRecargar = false;
        animator.SetBool("intentandoRecargar", false);
    }
}