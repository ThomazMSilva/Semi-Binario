using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerPeca5 : MonoBehaviour
{

    [SerializeField] private GameObject poemaMeninoTrans;
    [SerializeField] private GameObject peça5QuebraCabeça;

    private void Ativar()
    {
        if (poemaMeninoTrans.activeInHierarchy)
        {
            BoxCollider2D boxCollider2Dpeca = peça5QuebraCabeça.GetComponent<BoxCollider2D>();
            boxCollider2Dpeca.enabled = false;
        }
    }

    private void Desativar()
    {
        if (!poemaMeninoTrans.activeInHierarchy)
        {
            BoxCollider2D boxCollider2Dpeca = peça5QuebraCabeça.GetComponent<BoxCollider2D>();
            boxCollider2Dpeca.enabled = true;
        }
    }
}
