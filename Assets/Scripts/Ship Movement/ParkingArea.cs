using UnityEngine;

public class ParkingArea : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI parkingText;
    [SerializeField] GameEvent OnParkingAreaReached, OnParkingAreaLeft;
    [SerializeField] private ShipModeName navigatingMode, parkingMode, dockedMode;
    [SerializeField] private ShipModeNameContainer currentMode;
    [SerializeField] GameEvent OnModeChanged;

    private bool m_isInsideParking = false;
    private void OnTriggerEnter(Collider other)
    {
        var modeManager = other.GetComponent<ShipModeManager>();
        if(modeManager != null)
        {
            if (m_isInsideParking) return;
            currentMode.ModeName = parkingMode;
            OnModeChanged.Raise();
            m_isInsideParking = true;
            parkingText.text = "Parking Area Reached";
            OnParkingAreaReached.Raise();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var modeManager = other.GetComponent<ShipModeManager>();
        if (modeManager != null)
        {
            if (!m_isInsideParking) return;
            currentMode.ModeName = navigatingMode;
            OnModeChanged.Raise();
            m_isInsideParking = false;
            parkingText.text = "Parking Area Left";
            OnParkingAreaLeft.Raise();

        }
    }
}