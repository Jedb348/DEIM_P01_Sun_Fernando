using Unity.Mathematics;
using UnityEngine;
 [RequireComponent(typeof(Rigidbody2D))]
public class movimiento : MonoBehaviour
{
    public Rigidbody2D rb;
    public static float Velocidad = 3;
    public float Movimiento;
    public static movimiento movi;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movi = this;
        //Llamada al RigidBody2D
      rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Movimiento = Input.GetAxisRaw("Horizontal");
    }
    private void FixedUpdate()
    {
        MoviminetoScreen();
        //FingerMovement();
        //rb.linearVelocity = new Vector2(Movimiento * Velocidad, rb.linearVelocity.y * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.CompareTag("Daño"))
        {
            Destroy(gameObject);
        }
    }
    void MoviminetoScreen()
    {
        if (Input.touchCount > 0)
        {
            float TouchScreenPositionX = Input.touches[0].position.x;
            float ScreenCenter = Screen.width / 2;
            if (TouchScreenPositionX > ScreenCenter)
            {
                rb.linearVelocityX = Velocidad;
            }
            else
            {
                rb.linearVelocityX = -Velocidad;
            }
        }
        else
        {
            rb.linearVelocityX = 0;
        }
    }
    void FingerMovement() 
    {
        if (Input.touchCount > 0)
        {
            float FingerMovementX = Input.touches[0].deltaPosition.x;
            rb.linearVelocityX = FingerMovementX * Velocidad;
        }
        else
        {
            rb.linearVelocityX = 0;
        }
    }
    void AumentodeVel()
    {
        if (Velocidad < 20)
        {
            Velocidad = (float)(Velocidad + 0.1);
        }
    }
}
