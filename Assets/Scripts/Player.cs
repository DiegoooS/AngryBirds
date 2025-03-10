using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform slingHookTransform;
    [SerializeField] private float shootMultiplier = 5f;

    private LineRenderer lineRenderer;
    private Camera cam;
    private Vector3 mousePos;
    private Rigidbody2D rb;

    private void Awake()
    {
        SetLineRenderer();
        SetRigidBody();
    }

    private void SetRigidBody() => rb = GetComponent<Rigidbody2D>();

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
        transform.rotation = Quaternion.Euler(0, 0, rotZ + 180f);
    }

    private void SetLinePosition() => lineRenderer.SetPosition(0, transform.position);

    private void SetPlayerToMousePosition()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        transform.position = mousePos;
    }

    private void OnMouseUp()
    {
        HideLine();
        ShootBird();
    }

    private void ShootBird()
    {
        Vector3 shootDirection = slingHookTransform.position - transform.position;
        float shootForce = shootDirection.magnitude * shootMultiplier;
        Debug.Log(shootDirection * shootForce);
        rb.AddForce( shootDirection * shootForce, ForceMode2D.Impulse);
    }

    private void HideLine()
    {
        lineRenderer.SetPosition(0, slingHookTransform.position);
    }
}
