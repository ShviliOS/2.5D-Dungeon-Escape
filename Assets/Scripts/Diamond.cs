using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public int gems = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player _player = GameObject.Find("Player").GetComponent<Player>();
            if (_player != null)
            {
                _player.diamonds += gems;
                Destroy(gameObject);

            }
        }
    }
}
