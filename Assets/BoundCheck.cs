using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundCheck : MonoBehaviour
{
    public float radius = 1f;
    private float _camWidth;
    private float _camHeight;
    private void Awake()
    {
        _camHeight = Camera.main.orthographicSize;
        _camWidth = _camHeight * Camera.main.aspect;
    }
    private void Update()
    {
        Vector3 pos = transform.position;
        if (pos.x > _camWidth - radius)
            pos.x = _camWidth - radius;
        if (pos.x < -_camWidth + radius)
            pos.x = -_camWidth + radius;
        if (pos.y > _camHeight - radius)
            pos.y = _camHeight - radius;
        if (pos.y < -_camHeight + radius)
            pos.y = -_camHeight + radius;

        transform.position = pos;
    }
}
