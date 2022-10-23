using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMarker : MonoBehaviour
{
    [SerializeField] private float distanceCorrection = -24f;
    protected ShipPathManager m_spawnner;
    public ShipPathManager PathManager
    {
        get
        {
            return m_spawnner;
        }
        set
        {
            m_spawnner = value;
        }
    }

    void Update()
    {
        if (PathManager.DriverSeat.transform.position.x - transform.position.x > distanceCorrection)
        {
            OnShipHitMarker();

        }
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     Debug.Log(Spawnner);
    //     Debug.Log(Spawnner.gameObject);

    //     if(other.gameObject == Spawnner.gameObject)
    //     {
    //         OnShipHitMarker();
    //     }
    // }

    protected virtual void OnShipHitMarker()
    {
        Debug.Log("trigger entered");
        PathManager.OnNewMarkerReached();
        Destroy(gameObject);
    }
}
