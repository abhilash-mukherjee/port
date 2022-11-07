using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using System.Linq;

public class ShipPathManager : MonoBehaviour
{
    public delegate void TargetParkingUpdateHandler(ShipPathManager pathManager, Transform targetParkingTransform);
    public static event TargetParkingUpdateHandler OnTargetParkingAreaUpdated;

    [SerializeField]
    private PathMarker pathMarker;
    [SerializeField]
    private GameEvent OnMilestoneUpdated;

    [SerializeField]
    private float markerGap;
    [SerializeField] private float distanceCorrection = 24f;
    [SerializeField] private GameObject driverSeat;
    [SerializeField] private List<ParkingToPath> paths;



    public Queue<PathMarker> pathMarkers;
    public List<PathMarker> pathMarkerList;

    public Vector3 NextMileStone { get => m_nextMileStone; }
    public GameObject DriverSeat { get => driverSeat; }

    private Vector3 m_nextMileStone;
    private GameObject m_pathObjectContainer;
    private PathCreator m_currentPathCreator;

    private void OnEnable()
    {
        ParkingAreaSelector.OnAreaSelected += OnPathŪpdated;
    }
    private void OnDisable()
    {
        ParkingAreaSelector.OnAreaSelected -= OnPathŪpdated;
    }

    private void OnPathŪpdated(ElementID parkingAreaID)
    {
        var path = paths.Find(p => p.parkingAreaID == parkingAreaID);
        UpdateTargetPath(path.pathCreator);
        OnTargetParkingAreaUpdated?.Invoke(this, path.parkingAreaTransform);
    }

    private void UpdateTargetPath(PathCreator pathCreator)
    {
        if (m_pathObjectContainer != null) Destroy(m_pathObjectContainer);
        m_currentPathCreator = pathCreator;
        m_pathObjectContainer = SpawnObjects(pathCreator);
        UpdateMilestone(pathCreator);
    }

    private GameObject SpawnObjects(PathCreator pathCreator)
    {
        pathMarkers = new Queue<PathMarker>();
        float dist = 0;
        VertexPath path = pathCreator.path;
        var pathObjectContainer = Instantiate(new GameObject());
        while (dist < path.length)
        {
            Vector3 point = path.GetPointAtDistance(dist);
            Quaternion rot = path.GetRotationAtDistance(dist);
            var obj = Instantiate(pathMarker.gameObject, point, Quaternion.identity);
            var marker = obj.GetComponent<PathMarker>();
            marker.PathManager = this;
            pathMarkers.Enqueue(marker);
            marker.transform.SetParent(pathObjectContainer.transform);
            dist += markerGap;
        }
        return pathObjectContainer;
    }
    public void OnNewMarkerReached()
    {
        if (pathMarkers.Count <= 1)
            return;
        pathMarkers.Dequeue();
        if(m_currentPathCreator != null) UpdateMilestone(m_currentPathCreator);
    }
    public void UpdateMilestone(PathCreator pathCreator)
    {
        if (pathMarkers.Count == 0)
        {
            Debug.Log("ZERO");
            SpawnObjects(pathCreator);
            return;
        }
        m_nextMileStone = GetNextMilestone();
        OnMilestoneUpdated.Raise();
    }

    private Vector3 GetNextMilestone()
    {
        return pathMarkers.Peek().gameObject.transform.position;

    }
    [System.Serializable]
    public class ParkingToPath
    {
        public PathCreator pathCreator;
        public ElementID parkingAreaID;
        public Transform parkingAreaTransform;
    }
}
