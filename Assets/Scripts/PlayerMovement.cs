using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed = 30f;
    [SerializeField] float xClampRange = 23f;
    [SerializeField] float yClampRange = 13f;

    [SerializeField] float controlPitchFactor = 20f;
    [SerializeField] float controlRollFactor = 20f;
    [SerializeField] float rotationSpeed = 10f;



    Vector2 movement;
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    void OnMove(InputValue value)
    {
        Debug.Log("Move: " + value.Get<Vector2>());
        movement = value.Get<Vector2>();
    }
    private void ProcessTranslation()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);


        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRange, yClampRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }
    private void ProcessRotation()
    {
        float pitch = -controlPitchFactor * movement.y;
        float roll = -controlRollFactor * movement.x;

        Quaternion targetRotation = Quaternion.Euler(pitch, 0f, roll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
