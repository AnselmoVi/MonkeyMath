using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorCollision1 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        gameObject.transform.parent.GetComponent<PowerUplvl2>().CollisioneAvvenuta(collision);
    }
}
