using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    [SerializeField]
    private GameObject _shopCanvas;



    private void OnTriggerEnter2D(Collider2D other)
    {
        _shopCanvas.SetActive(true);
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                UIManager.Instance.OpenShop(player.diamonds);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _shopCanvas.SetActive(false);
        }
    }
    public void SelectItem(int itemID)
    {
        print("SelectItem()" + itemID);

        switch (itemID)
        {
            case 0:
                UIManager.Instance.UpdateItemSelection(35);
                break;
            case 1:
                UIManager.Instance.UpdateItemSelection(-10);
                break;
            case 2:
                UIManager.Instance.UpdateItemSelection(-55);
                break;
        }

    }
}
