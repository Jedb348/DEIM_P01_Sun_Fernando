using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
[RequireComponent(typeof(Rigidbody2D))]
public class movimiento : MonoBehaviour
{
    public Rigidbody2D rb;
    public static float Velocidad = 3;
    public float Movimiento;
    public static movimiento movi;
    public Transform Protagonista;
    public Ease ease;
    public GameObject Particles;
    public GameObject Sombra;
    public float JumpTime;
    private bool Saltando = false;

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
        AumentodeVel();
        //FingerMovement();
        //rb.linearVelocity = new Vector2(Movimiento * Velocidad, rb.linearVelocity.y * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.CompareTag("Daño"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Escena_1");
        }
        if (collider.gameObject.CompareTag("Rampa"))
        {
            Protagonista.DOScale(1.5f, 0.5f).SetEase(ease);
            Particles.SetActive(false);
            Sombra.SetActive(true);
            Saltando = true;
            Invoke("Finsalto", 1.0f);
        }
    }
    void MoviminetoScreen()
    {
        if (Saltando == false)
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
            Velocidad = (float)(Velocidad + 0.1 * Time.deltaTime);
        }
    }
    void Finsalto()
    {
        Protagonista.DOScale(1, 0.5f).SetEase(ease);
        Particles.SetActive(true);
        Sombra.SetActive(false);
        Saltando = false;
    }
}
