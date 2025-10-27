using UnityEngine;

public class LevelController : MonoBehaviour
{
    public float speed = 5f;
    
    private void Start()
    {

    }
    private void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EliminarMap"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Mapa"))
        {
            LevelGenerator.AddNewPiece();
        }
    }
}
