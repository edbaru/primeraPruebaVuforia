using UnityEngine;
using UnityEngine.InputSystem;

public class LanzadorProyectiles : MonoBehaviour
{
    [SerializeField] GameObject prefabProyectil;
    [SerializeField] GameObject arma;
    
    void Update()
    {
        Vector2 posicionPantalla;
        arma.transform.localEulerAngles = new Vector3(arma.transform.localEulerAngles.x, arma.transform.localEulerAngles.y, 0);

        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            posicionPantalla = Touchscreen.current.primaryTouch.position.ReadValue();

            Ray rayo = Camera.main.ScreenPointToRay(posicionPantalla);
            arma.transform.LookAt(rayo.GetPoint(10));

            Vector3 posicionSalida = arma.transform.position + arma.transform.forward * 1f + arma.transform.up * 0.4f;

            GameObject bala = Instantiate(prefabProyectil, posicionSalida, Quaternion.LookRotation(rayo.direction));

            Rigidbody rb = bala.GetComponent<Rigidbody>();
            rb.AddForce(rayo.direction * 100, ForceMode.Impulse);
        }
    }
}
