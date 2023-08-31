using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{
    [SerializeField]
    powerUpType type;

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            switch (type)
            {
                case powerUpType.health:
                    playerHealth.upHealth(25);
                    break;

                case powerUpType.ammo:
                    shootingScript.addAmmo(25);
                    break;

            }

            this.gameObject.SetActive(false);
        }
    }
}
