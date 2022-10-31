using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityCameraManager : MonoBehaviour
{
    [SerializeField] List<Camera> proximityCams;
    private void Start()
    {
        foreach (var cam in proximityCams) cam.gameObject.SetActive(false);
    }
    public void OnParkingAreaReached()
    {
        foreach (var cam in proximityCams) cam.gameObject.SetActive(true);
    }
    public void OnParkingAreaLeft()
    {
        foreach (var cam in proximityCams) cam.gameObject.SetActive(false);
    }
}
