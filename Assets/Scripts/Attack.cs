using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    private bool _canDamage = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();

        if (damageable != null)
        {
            if (_canDamage)
            {
                _canDamage = false;
                damageable.Damage();
                StartCoroutine(FunctionCoolDown());
            }
        }
    }

    IEnumerator FunctionCoolDown()
    {
        yield return new WaitForSeconds(0.5f);
        _canDamage = true;
    }
}
