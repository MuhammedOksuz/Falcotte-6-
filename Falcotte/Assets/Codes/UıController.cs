using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class UıController : MonoBehaviour
{
    PlayerController playerController;
    public bool coinRose;
    Sequence seq;

    private void Awake()
    {
        playerController = Object.FindObjectOfType<PlayerController>();
    }
    public void Rose()
    {
        seq = DOTween.Sequence();
        playerController.coinText.transform.DOScale(1.5f, 0.1f).OnComplete(() =>playerController.coinText.transform.DOScale(1, 0.1f));
        //other.gameObject.transform.DOMoveY(1, 0.1f);
        seq.Append(transform.DOMoveY(1, 1));
    }
}
