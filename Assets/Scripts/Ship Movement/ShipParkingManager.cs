using UnityEngine;

public class ShipParkingManager : MonoBehaviour
{
    [SerializeField]
    private Transform targetParkingSlot;
    [SerializeField]
    private float parkingPositionError = 2f, parkingOrientationError = 5f;
    [SerializeField]
    private ShipModeManager shipModeManager;
    [SerializeField]
    private Transform shipCOM;
    private bool m_hasReachedPosition, m_hasReachedOrientation;
    private void Update()
    {
        m_hasReachedPosition = (shipCOM.position - targetParkingSlot.position).magnitude < parkingPositionError;
        m_hasReachedOrientation = Mathf.Abs(Vector3.SignedAngle(shipCOM.forward, targetParkingSlot.forward, Vector3.up)) < parkingOrientationError ;
    }

   
}
