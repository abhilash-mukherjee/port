using UnityEngine;

public class ShipModeManager : MonoBehaviour
{
    [SerializeField] private ShipParkingManager shipParkingManager;
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
    public void OnDockToggled()
    {
        if (m_mode == ShipMode.DOCKED) m_mode = ShipMode.PARKING;
        else if (m_mode == ShipMode.PARKING && shipParkingManager.IsDockable) m_mode = ShipMode.DOCKED;
    }
    private void Awake()
    {
        m_mode = ShipMode.NAVIGATING;
    }
}