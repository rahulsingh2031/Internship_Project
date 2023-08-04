using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerFollow : MonoBehaviour
{
    TrailRenderer trailRenderer;
    Camera _camera;
    Vector3 mousePosition;
    private void Awake()
    {
        _camera = Camera.main;
        trailRenderer = GetComponent<TrailRenderer>();
    }
    void Update()
    {
        trailRenderer.enabled = Input.GetMouseButton(0);
        mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        transform.position = mousePosition;

        if (Input.GetMouseButton(0))
        {
            DetectRing();
        }
    }

    void DetectRing()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(mousePosition, Vector3.forward, 0.3f);
        if (hit2D.collider != null)
        {
            if (hit2D.collider.TryGetComponent<IDetectable>(out IDetectable component))
            {
                component.OnDetect();
            }
        }
    }
}
