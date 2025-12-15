using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public RectTransform StartButton;
    public RectTransform MenuButton;
    public RectTransform QuitButton;
    public RectTransform Title;
    public Ease StartButtonEase;
    public Image FadeScreen;
    public GameObject MenuPrincipal;
    public GameObject MenuDeOpciones;
    public GameObject Play;
    public GameObject Exit;
    public GameObject MenuButton2;
    public float Duracion_Animacion = 1f;
   
    private void Start()
    {
        Title.DOScale(2, Duracion_Animacion).SetEase(StartButtonEase).OnComplete(() =>
        {
            Title.DOShakePosition(1, strength: 10, vibrato: 10);
        });
        MenuDeOpciones.SetActive(false);
        Play.SetActive(false);
        Exit.SetActive(false);
        MenuButton2.SetActive(false);
        Invoke("aparicion", Duracion_Animacion);
    }
    public void LoadGame()
    {
        FadeScreen.DOFade(1, 1).OnComplete(() => 
        {
            SceneManager.LoadScene("Escena_1");
        });
    }
    public void Menu()
    {
        MenuPrincipal.gameObject.SetActive(false);
        MenuDeOpciones.gameObject.SetActive(true);
    }
    public void Salir()
    {
       Application.Quit();
    }
    public void Atras()
    {
        MenuDeOpciones.gameObject.SetActive(false);
        MenuPrincipal.gameObject.SetActive(true);
    }
    void aparicion()
    {
       
        Play.SetActive(true);
        Exit.SetActive(true);
        MenuButton2.SetActive(true);
        StartButton.DOScale(2, Duracion_Animacion).SetEase(StartButtonEase).OnComplete(() =>
        {
            StartButton.DOShakePosition(1, strength: 10, vibrato: 10);
        });
        MenuButton.DOScale(2, Duracion_Animacion).SetEase(StartButtonEase).OnComplete(() =>
        {
            MenuButton.DOShakePosition(1, strength: 10, vibrato: 10);
        });
        QuitButton.DOScale(2, Duracion_Animacion).SetEase(StartButtonEase).OnComplete(() =>
        {
            QuitButton.DOShakePosition(1, strength: 10, vibrato: 10);
        });
    }
  
}
