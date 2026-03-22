using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlspeed = 10f;
    [SerializeField] float xClampRange = 5f;
    [SerializeField] float yClampRange = 5f;

    [SerializeField] float ControlPitchFactor = 20f;
    [SerializeField] float ControlRollFactor = 20f;
    [SerializeField] float RotationSpeed = 10f;
    Vector2 movement;
    void Update()
    {
        ProcessTranslation();
        processRotation();
    }


    public void OnMove(InputValue value)
    {
        movement =  value.Get<Vector2>();
    }
    void ProcessTranslation()
    {
        float xoffset = movement.x * Time.deltaTime * controlspeed;
        float RawXPosition = transform.localPosition.x + xoffset;
        float clampedXPosition = Mathf.Clamp(RawXPosition, -xClampRange, xClampRange);
        float yoffset = movement.y * Time.deltaTime * controlspeed;
        float RawYPosition = transform.localPosition.y + yoffset;
        float clampedYPosition = Mathf.Clamp(RawYPosition, -yClampRange, yClampRange);
        transform.localPosition = new Vector3(clampedXPosition, clampedYPosition, 0f);
    }
    void processRotation()
    {
        float Pitch = movement.y * ControlPitchFactor;
        float Roll = movement.x * ControlRollFactor;
        Quaternion targetRotation = Quaternion.Euler(Pitch,0f, -Roll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * RotationSpeed);




    }
}
