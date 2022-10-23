using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;


public class ShipPathManager : MonoBehaviour
{
    [SerializeField]
    private PathCreator pathCreator;
    [SerializeField]
    private PathMarker pathMarker;
    [SerializeField]
    private GameEvent onPathInstructionsUpdated;

    [SerializeField]
    private float markerGap;
    [SerializeField] private float distanceCorrection = 24f;
    [SerializeField] private GameObject driverSeat;



    private Vector3 m_nextMileStone;


    public Queue<PathMarker> pathMarkers;
    public List<PathMarker> pathMarkerList;

    public Vector3 NextMileStone { get => m_nextMileStone; }
    public GameObject DriverSeat { get => driverSeat; }

    void Start()
    {
        SpawnObjects();
        UpdatePathInstructions();
    }

    private void SpawnObjects()
    {
        pathMarkers = new Queue<PathMarker>();
        float dist = 0;
        VertexPath path = pathCreator.path;
        while (dist < path.length)
        {
            Vector3 point = path.GetPointAtDistance(dist);
            Quaternion rot = path.GetRotationAtDistance(dist);
            var obj = Instantiate(pathMarker.gameObject, point, rot);
            var marker = obj.GetComponent<PathMarker>();
            marker.PathManager = this;
            pathMarkers.Enqueue(marker);
            dist += markerGap;
        }
    }
    public void OnNewMarkerReached()
    {
        pathMarkers.Dequeue();
        UpdatePathInstructions();
    }
    public void UpdatePathInstructions()
    {
        if (pathMarkers.Count == 0)
        {
            Debug.Log("ZERO");
            SpawnObjects();
            return;
        }
        m_nextMileStone = GetNextMilestone();
        onPathInstructionsUpdated.Raise();
    }

    private Vector3 GetNextMilestone()
    {
        return pathMarkers.Peek().gameObject.transform.position;

    }
}
