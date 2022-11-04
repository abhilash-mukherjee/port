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
        foreach (var element in mapElements) element.UpdatePosition(seaCenter, m_scaleReductionFactor);
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
            element.mapElementTransform = imgComp.GetComponent<RectTransform>();
            var rectTrans = imgObj.GetComponent<RectTransform>();
            var col = imgObj.AddComponent<CircleCollider2D>();
            col.radius = Mathf.Min(rectTrans.rect.height, rectTrans.rect.width);
            var rbd = imgObj.AddComponent<Rigidbody2D>();
            rbd.freezeRotation = true;
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

    public void UpdatePosition(Vector3 globalCentre, float scaleReductionFactor)
    {
        var locaPos = GetScaledPosition(mapElementTransform, globalCentre, scaleReductionFactor);
        mapElementTransform.anchoredPosition = new Vector2(locaPos.x, locaPos.z);
        mapElementTransform.Rotate(new Vector3(0, GlobalTransform.rotation.y, 0));
    }

    private Vector3 GetScaledPosition(Transform _transform, Vector3 globalCentre, float scaleReductionFactor)
    {
        var _globalRelativePositionVector = (GlobalTransform.position - globalCentre);
        var _scalingVector = new Vector3(scaleReductionFactor, 0, scaleReductionFactor);
        var relPos = Vector3.Scale(_globalRelativePositionVector, _scalingVector);
        return relPos;
    }
}