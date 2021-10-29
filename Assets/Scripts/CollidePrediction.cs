using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidePrediction : MonoBehaviour
{
    Transform[] caster;

    void Start()
    {
        caster = GetComponentsInChildren<Transform>();
    }

    public bool HitTest()
    {
        for (int i = 0; i < caster.Length; i++)
        {
            RaycastHit hit;
            if (Physics.BoxCast(caster[i].position, caster[i].lossyScale / 2, transform.forward, out hit, Quaternion.identity, 100f))
            {
                if (hit.collider.CompareTag("Saber"))
                {
                    return true;
                }
            }
        }
        return false;
    }
}
