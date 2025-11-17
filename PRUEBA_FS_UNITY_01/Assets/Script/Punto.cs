using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Punto : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI MaxScoreText;
    public float PuntoPorSegundo = 1f;
    private float score = 0f;
    public float MaxPunto;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        score += PuntoPorSegundo * Time.deltaTime;
        ScoreText.text = "Puntos: " + Mathf.FloorToInt(score);
        PuntoMax();
        MaxScoreText.text = "Mejor puntuación: " + Mathf.FloorToInt(PlayerPrefs.GetFloat("MaxPunto"));
    }
    void PuntoMax() 
    {

        if (score >= PlayerPrefs.GetFloat("MaxPunto"))
        {
            PlayerPrefs.SetFloat("MaxPunto", score);
            MaxPunto = score;
        }
    }
}
