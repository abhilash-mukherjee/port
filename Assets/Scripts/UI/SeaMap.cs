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
        InstantiateMapObjects();
    }

    private void Update()
    {
        foreach (var element in mapElements)
        {
            element.UpdateTransform(seaCenter, m_scaleReductionFactor);
            element.UpdateRotation(seaCenter, transform);
        }
    }
    private void InstantiateMapObjects()
    {
        foreach(var element in mapElements)
        {
            var imgObj = Instantiate(new GameObject());
            imgObj.AddComponent<Image>();
            var imgComp = imgObj.GetComponent<Image>();
            imgComp.sprite = element.sprite;
            imgComp.preserveAspect = true;
            imgComp.transform.SetParent(mapBG.transform);
            imgComp.transform.localScale = element.scaleIndex * Vector3.one;
            imgComp.transform.localPosition = Vector3.zero;
            element.mapElementTransform = imgComp.GetComponent<RectTransform>();
            var rectTrans = imgObj.GetComponent<RectTransform>();
            var col = imgObj.AddComponent<CircleCollider2D>();
            col.radius = Mathf.Min(rectTrans.rect.height, rectTrans.rect.width);
            var rbd = imgObj.AddComponent<Rigidbody2D>();
            rbd.freezeRotation = true;
            rbd.bodyType = RigidbodyType2D.Kinematic;
            rbd.gravityScale = 0;

        }
    }
}

[System.Serializable]
public class MapElement
{
    public Sprite sprite;
    public Transform GlobalTransform;
    public float scaleIndex;
    [HideInInspector]
    public RectTransform mapElementTransform;

    public void UpdateTransform(Vector3 globalCentre, float scaleReductionFactor)
    {
        var locaPos = GetScaledPosition(mapElementTransform, globalCentre, scaleReductionFactor);
        mapElementTransform.anchoredPosition = new Vector2(-locaPos.x, locaPos.z);
        
    }

    internal void UpdateRotation(Vector3 globalCentre, Transform transform)
    {
        var centreDir = Vector3.Scale(globalCentre - GlobalTransform.position, new Vector3(1, 0, 1));
        var forward = Vector3.Scale(GlobalTransform.forward, new Vector3(1, 0, 1));
        var angle = Vector3.SignedAngle(centreDir, forward, Vector3.up);
        Debug.Log("Angle = " + angle);
        var mapElementUp = Quaternion.AngleAxis(angle, transform.forward) * Vector3.up;
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