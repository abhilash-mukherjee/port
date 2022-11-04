using UnityEngine;

public class PathArrow : MonoBehaviour
{
    [SerializeField] private ShipPathManager pathManager;
    [SerializeField] private GameObject driverSeat;
    [SerializeField] private GameObject arrowModel;
    [SerializeField] private Transform targetParkingArea;
    [SerializeField] private ShipModeName navigatingMode, parkingMode, dockedMode;
    [SerializeField] private ShipModeNameContainer currentMode;

    [SerializeField] private float rotationSpeed = 1f;
    // Start is called before the first frame update
    private Vector3 m_nextMilestone;
    private void Update()
    {
        if (currentMode.ModeName == navigatingMode)
        {
            var milstone = m_nextMilestone;
            milstone.y = arrowModel.transform.position.y;
            var dir = (milstone - arrowModel.transform.position).normalized;
            var rotGoal = Quaternion.LookRotation(dir);
            var ang = Quaternion.Slerp(transform.rotation,rotGoal, Time.deltaTime * rotationSpeed);
            arrowModel.transform.rotation = (ang);
        }
        if (currentMode.ModeName == parkingMode)
        {
            var targetRot = Quaternion.LookRotation(targetParkingArea.forward);
            var ang = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * rotationSpeed);
            arrowModel.transform.rotation = (ang);
            return; 
        }

    }
    public void OnDirectionUpdated()
    {
        m_nextMilestone = pathManager.NextMileStone;
    }
}
