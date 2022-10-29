using UnityEngine;

public class ShipModeManager : MonoBehaviour
{
    public enum ShipMode
    {
        NAVIGATING,
        PARKING,
        DOCKED
    }
    private ShipMode m_mode;

    public ShipMode Mode { get => m_mode; }
    public void ChangeShipMode(ShipMode newMode)
    {
        m_mode = newMode;
    }
    private void Awake()
    {
        m_mode = ShipMode.NAVIGATING;
    }
}