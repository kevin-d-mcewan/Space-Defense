using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // var to continually update "input value" in the 'Input System'
    Vector2 rawInput;

    [SerializeField] float moveSpeed = 3.5f;

    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float PaddingTop;
    [SerializeField] float paddingBottom;

    Vector2 minBounds;
    Vector2 maxBounds;

    Shooter shooter;

    private void Awake()
    {
        shooter = GetComponent<Shooter>();
    }

    void Start()
    {
        initBounds();
    }


    void Update()
    {
        // "delta" stores our delta position for our movement. Then we can apply to our 'transform.position'

        // 'deltaTime' is the last time it took a frame to render... which makes our movement "FrameRate Independent"
        Move();
    }

    // Initializing the Out-of-Bounds Boxes for Screen
    void initBounds()
    {
        // Creating a Ref (mainCamera) to the Camera in the Hierarchy with the tag of 'main'
        Camera mainCamera = Camera.main;

        // "ViewPortToWorldPoint" requires a Vector3 but by using a Vector2 it automatically uses an index of 0 for z
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0)); //BottomLeft of Viewport
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1)); //TOpRight of Viewport
    }

    private void Move()
    {
        // Vector3 delta = rawInput * moveSpeed * Time.deltaTime;
        // Can change the above from Vector3 to Vector2 bc all other are using Vector2
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();

        //Will use a 'Clamp' from the "Mathf class" and this restricts the given values between min and max float values...
        // Returns the value if it is within the Min and Max range
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - PaddingTop);
        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
        // Debug.Log(rawInput);
    }

    void OnFire(InputValue value)
    {
        if (shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }

}
