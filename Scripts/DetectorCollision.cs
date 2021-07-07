using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorCollision : MonoBehaviour
{
    //Script attaccato al child del powerUp. Quando il suo mesh Collider rileva la collisione, chiama i metodi dello script PowerUp assegnato all'oggetto padre

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        gameObject.transform.parent.GetComponent<PowerUp>().CollisioneAvvenuta(collision);
    }
}
