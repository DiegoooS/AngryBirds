using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform slingHookTransform;

    private LineRenderer lineRenderer;
    private Camera cam;
    private Vector3 mousePos;

    private void Awake() => SetLineRenderer();

    private void SetLineRenderer() => lineRenderer = GetComponent<LineRenderer>();

    private void Start()
    {
        SetCamera();
        CreateLineFromPlayerToSling();
        RotatePlayer();
    }

    private void CreateLineFromPlayerToSling()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, slingHookTransform.position);
    }

    private void SetCamera() => cam = Camera.main;

    private void OnMouseDrag()
    {
        SetPlayerToMousePosition();
        SetLinePosition();
        RotatePlayer();
    }

    private void RotatePlayer()
    {
        Vector3 diff = transform.position - slingHookTransform.position;
        diff.Normalize();
        float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ + 90f);
    }

    private void SetLinePosition() => lineRenderer.SetPosition(0, transform.position);

    private void SetPlayerToMousePosition()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        transform.position = mousePos;
    }

    private void OnMouseUp() => HideLine();
    
    private void HideLine()
    {
        lineRenderer.SetPosition(0, slingHookTransform.position);
    }
}
