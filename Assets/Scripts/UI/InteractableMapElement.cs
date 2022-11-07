using UnityEngine;

public class InteractableMapElement : MonoBehaviour
{
    public delegate void ElementPressedHandler(ElementID ID);
    public static event ElementPressedHandler OnElementPressed;
    private GameObject presser;
    [SerializeField]private ElementID m_elementID;
    [SerializeField] GameEvent btnPressed;
    private bool isPressed;
    public ElementID ElementID {set => m_elementID = value; }


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
