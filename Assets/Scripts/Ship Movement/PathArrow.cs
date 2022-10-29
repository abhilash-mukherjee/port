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
