using UnityEngine;

public class PathArrow : MonoBehaviour
{
    [SerializeField] private ShipPathManager pathManager;
    [SerializeField] private ShipModeManager modeManager;
    [SerializeField] private GameObject driverSeat;
    [SerializeField] private GameObject arrowModel;
    [SerializeField] private float distanceCorrection = -24f;

    // Start is called before the first frame update
    private Vector3 m_nextMilestone;
    private void Update()
    {
        if(modeManager.Mode == ShipModeManager.ShipMode.NAVIGATING)
        arrowModel.transform.LookAt(m_nextMilestone);
        if (modeManager.Mode == ShipModeManager.ShipMode.PARKING) return;

    }
    public void OnDirectionUpdated()
    {
        m_nextMilestone = pathManager.NextMileStone;
    }
}


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
