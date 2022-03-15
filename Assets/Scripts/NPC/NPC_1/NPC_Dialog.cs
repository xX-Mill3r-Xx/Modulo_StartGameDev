using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialog : MonoBehaviour
{
    private List<string> sentences = new List<string>();
    private bool playerHit;

    public DialogSettings dialog;
    public float dialogRange; // tamanho do colisor que detecta o player
    public LayerMask playerLayer; // layer que define o player

    void Start()
    {
        GetNpcInfo();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire3") && playerHit)
        {
            DialogController.instance.Speech(sentences.ToArray());
        }
    }

    void GetNpcInfo()
    {
        for (int i = 0; i < dialog.dialogs.Count; i++)
        {
            switch (DialogController.instance.language)
            {
                case DialogController.Idioma.pt:
                    sentences.Add(dialog.dialogs[i].sentence.portugues);
                    break;

                case DialogController.Idioma.eng:
                    sentences.Add(dialog.dialogs[i].sentence.english);
                    break;

                case DialogController.Idioma.spa:
                    sentences.Add(dialog.dialogs[i].sentence.spanish);
                    break;
            }
        }
    }

    void FixedUpdate()
    {
        ShowDialog();
    }

    // metodo que desenha o colisor invisivel para detecta o Player
    void ShowDialog()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogRange, playerLayer);
        if (hit != null)
        {
            playerHit = true;
        }
        else
        {
            playerHit = false;
        }
    }

    // metodo que desenha um Gizmo na janela de desenvolvimento da cena
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogRange);
    }
}
