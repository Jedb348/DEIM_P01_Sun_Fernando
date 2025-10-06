using UnityEngine;

public class movimiento : MonoBehaviour
{
    public Rigidbody2D rb;
    public float Velocidad = 10;
    public float Movimiento;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Movimiento = Input.GetAxis("Horizontal") * Velocidad;
    }
}
