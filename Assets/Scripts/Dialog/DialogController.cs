using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    [System.Serializable]
    public enum Idioma
    {
        pt,
        eng,
        spa
    }

    public Idioma language;

    public static DialogController instance;

    [Header("Components")]
    public GameObject dialogObj; // janela do dialogo
    public Image profileSprite; // sprite do perfil
    public Text speechText; // texto da fala
    public Text actorNameText; // nome do NPC

    [Header("Settings")]
    public float typingSpeed; //velocidade da fala

    //variaveis de controle
    [HideInInspector] public bool isShowing; // se a janela esta vizivel
    private int index; // pra saber a quantidade de falas do NPC
    private string[] sentences;

    // Awake é chamado antes de qualquer start;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {

    }

    void Update()
    {

    }

    IEnumerator TypeSentence()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    //pular para a proxima fala
    public void NextSentence()
    {

        if (speechText.text == sentences[index])
        {
            if (index < sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else
            {
                speechText.text = "";
                index = 0;
                dialogObj.SetActive(false);
                sentences = null;
                isShowing = false;
            }
        }
    }

    //chamar a fala do NPC
    public void Speech(string[] txt)
    {
        if (!isShowing)
        {
            dialogObj.SetActive(true);
            sentences = txt;
            StartCoroutine(TypeSentence());
            isShowing = true;
        }
    }
}
