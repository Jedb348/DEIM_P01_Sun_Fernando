using Unity.Mathematics;
using UnityEngine;
 [RequireComponent(typeof(Rigidbody2D))]
public class movimiento : MonoBehaviour
{
    public Rigidbody2D rb;
    public float Velocidad = 3;
    public float Movimiento;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Llamada al RigidBody2D
      rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            float TouchScreenPositionX = Input.touches[0].position.x;
            float ScreenCenter = Screen.width / 2;
            if (TouchScreenPositionX > ScreenCenter)
            {
                
            }
        }

        //Movimietno Horizaontal
        Movimiento = Input.GetAxisRaw("Horizontal");

    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(Movimiento * Velocidad, rb.linearVelocity.y * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.CompareTag("Daño"))
        {
            Destroy(gameObject);
        }
    }

}
