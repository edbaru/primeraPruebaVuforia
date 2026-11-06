using UnityEngine;
using Vuforia;
using TMPro;

public class TierraController : MonoBehaviour
{
    private ObserverBehaviour observer;
    [SerializeField] TextMeshProUGUI texto;
    public GameControllerFinito controladorJuego;
    void Awake()
    {
        observer = GetComponent<ObserverBehaviour>();
    }

    private void OnEnable()
    {
        if (observer != null)
        {
            observer.OnTargetStatusChanged += onTargetStatusChange;
        }
    }

    private void OnDisable()
    {
        if (observer != null)
        {
            observer.OnTargetStatusChanged -= onTargetStatusChange;
        }
    }

    private void onTargetStatusChange(ObserverBehaviour behaviour, TargetStatus status)
    {
        //texto.text = "Reconozco la tierra";
        controladorJuego.Chequar("Tierra");
    }
}
