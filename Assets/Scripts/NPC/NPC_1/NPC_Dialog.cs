using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialog : MonoBehaviour
{
    private bool playerHit;

    public DialogSettings dialog;
    public float dialogRange; // tamanho do colisor que detecta o player
    public LayerMask playerLayer; // layer que define o player

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire3") && playerHit)
        {
            DialogController.instance.Speech();
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
        if(hit != null)
        {
            playerHit = true;
            Debug.Log("Detectou");
        }
        else
        {
            playerHit = false;
            Debug.Log("Não detectou");
        }
    }

    // metodo que desenha um Gizmo na janela de desenvolvimento da cena
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogRange);
    }
}
