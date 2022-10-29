using UnityEngine;

public class ParkingArea : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI parkingText;
    private bool m_isInsideParking = false;
    private void OnTriggerEnter(Collider other)
    {
        var modeManager = other.GetComponent<ShipModeManager>();
        if(modeManager != null)
        {
            if (m_isInsideParking) return;
            modeManager.ChangeShipMode(ShipModeManager.ShipMode.PARKING);
            m_isInsideParking = true;
            parkingText.text = "Parking Area Reached";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var modeManager = other.GetComponent<ShipModeManager>();
        if (modeManager != null)
        {
            if (!m_isInsideParking) return;
            modeManager.ChangeShipMode(ShipModeManager.ShipMode.NAVIGATING);
            m_isInsideParking = false;
            parkingText.text = "Parking Area Left";

        }
    }
}