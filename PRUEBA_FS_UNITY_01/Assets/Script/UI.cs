using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public RectTransform StartButton;
    public RectTransform MenuButton;
    public RectTransform QuitButton;
    public Ease StartButtonEase;
    public Image FadeScreen;
    public GameObject MenuPrincipal;
    public GameObject MenuDeOpciones;
    private void Start()
    {
        StartButton.DOScale(2, 1).SetEase(StartButtonEase).OnComplete(() =>
        {
            StartButton.DOShakePosition(1,strength: 10,vibrato:10);
        });
        MenuButton.DOScale(2, 1).SetEase(StartButtonEase).OnComplete(() =>
        {
            MenuButton.DOShakePosition(1, strength: 10, vibrato: 10);
        });
        QuitButton.DOScale(2, 1).SetEase(StartButtonEase).OnComplete(() =>
        {
            QuitButton.DOShakePosition(1, strength: 10, vibrato: 10);
        });

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

  
}
