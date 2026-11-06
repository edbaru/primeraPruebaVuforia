using UnityEngine;

public class GameControllerPlaneFinder : MonoBehaviour
{
    private float velocidad = 0f;
    private float giroVehiculo = 0f;
    [SerializeField] GameObject vehiculo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movimimiento = transform.forward * velocidad * Time.deltaTime;

        if(velocidad != 0){
            float cantidadGiro = giroVehiculo * Time.deltaTime;
            Quaternion giro = Quaternion.Euler(0f, cantidadGiro, 0f);
        }
    }

    public void Acelerar()
    {
        velocidad = 30f;
    }

    public void Girar()
    {
        giroVehiculo = 10f;
    }
}
