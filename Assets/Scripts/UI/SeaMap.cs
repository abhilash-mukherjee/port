using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeaMap : MonoBehaviour
{
    [SerializeField] private Vector3 seaCenter;
    [SerializeField] private float seaSquareSide;
    [SerializeField] private RectTransform mapBG;
    [SerializeField] private List<MapElement> mapElements;
    private Vector3[] corners;
    private float m_scaleReductionFactor = 1;
    private void Start()
    {
        corners = new Vector3[4];
        mapBG.GetWorldCorners(corners);
        var imgSide = Vector3.Magnitude(corners[0] - corners[1]);
        m_scaleReductionFactor = imgSide / seaSquareSide;
    }

    private void Update()
    {
        foreach (var element in mapElements)
        {
            element.UpdateTransform(seaCenter, m_scaleReductionFactor);
            element.UpdateRotation(seaCenter, transform);
        }
    }
    
}

[System.Serializable]
public class MapElement
{
    public Sprite sprite;
    public Transform GlobalTransform;
    public RectTransform mapElementTransform;

    public void UpdateTransform(Vector3 globalCentre, float scaleReductionFactor)
    {
        var locaPos = GetScaledPosition(mapElementTransform, globalCentre, scaleReductionFactor);
        mapElementTransform.anchoredPosition = new Vector2(locaPos.x, locaPos.z);
        
    }

    internal void UpdateRotation(Vector3 globalCentre, Transform transform)
    {
        var centreDir = Vector3.Scale(globalCentre - GlobalTransform.position, new Vector3(1, 0, 1));
        var forward = Vector3.Scale(GlobalTransform.forward, new Vector3(1, 0, 1));
        var angle = Vector3.SignedAngle(centreDir, forward, Vector3.up);
        Debug.Log("Angle = " + angle);
        var mapElementUp = Quaternion.AngleAxis(angle, -transform.forward) * Vector3.up;
        mapElementTransform.up = mapElementUp;
    }

    private Vector3 GetScaledPosition(Transform _transform, Vector3 globalCentre, float scaleReductionFactor)
    {
        var _globalRelativePositionVector = (GlobalTransform.position - globalCentre);
        var _scalingVector = new Vector3(scaleReductionFactor, 0, scaleReductionFactor);
        var relPos = Vector3.Scale(_globalRelativePositionVector, _scalingVector);
        return relPos; 
    }
}