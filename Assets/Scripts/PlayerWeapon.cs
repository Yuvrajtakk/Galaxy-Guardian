using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{   
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float TargetDistance = 100f;
    bool isFiring = false;

    void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
        AimLasers();
    }


    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }
    private void ProcessFiring()
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isFiring;
        }

    }
    void MoveCrosshair()
    {
        crosshair.position = Mouse.current.position.ReadValue();
    }

    void MoveTargetPoint()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector3 targetPointPosition = new Vector3(mousePos.x, mousePos.y, TargetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }
    void AimLasers()
    {
        foreach (GameObject laser in lasers)
        {
            Vector3 Firedirection = targetPoint.position - this.transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(Firedirection);
            laser.transform.rotation = rotationToTarget;
        }
    }
}
