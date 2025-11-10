using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Punto : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public float PuntoPorSegundo = 1f;
    private float score = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score += PuntoPorSegundo * Time.deltaTime;
        ScoreText.text = "Puntos: " +Mathf.FloorToInt(score);
    }
}
