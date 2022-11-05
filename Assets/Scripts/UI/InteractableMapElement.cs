using UnityEngine;

public class InteractableMapElement : MonoBehaviour
{
    public delegate void ElementPressedHandler(string ID);
    public static event ElementPressedHandler OnElementPressed;
    private GameObject presser;
    [SerializeField]private string m_elementID;
    [SerializeField] GameEvent btnPressed;
    private bool isPressed;
    public string ElementID {set => m_elementID = value; }


    private void Start()
    {
        isPressed = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isPressed) return;
        presser = other.gameObject;
        isPressed = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject != presser) return;
        isPressed = false;
        OnElementPressed?.Invoke(m_elementID);
        btnPressed.Raise();
        Debug.Log(m_elementID + "selected");
    }
}
