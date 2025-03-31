using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance; // can be used in this script only
    public static UIManager Instance // a way to call this script via other scripts
    {
        get
        {
            if (_instance == null) // checks is _instance doesnt have value
            {
                Debug.LogError("UI Manager is null");
            }
            return _instance; // if so then return the value to UInstance
        }
    }
    public TMP_Text playerGemCountText;
    public Image selectionImage;

    public void UpdateItemSelection(int yPos)
    {
        selectionImage.rectTransform.anchoredPosition = new Vector2(selectionImage.rectTransform.anchoredPosition.x, yPos);
    }

    public void OpenShop(int gemCount)
    {
        playerGemCountText.text = gemCount.ToString() + "G";
    }
    private void Awake()
    {
        _instance = this; // gives _instance the value of this script which called UIManager
    }
}
