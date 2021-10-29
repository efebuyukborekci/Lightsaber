using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Button swingButton;
    [SerializeField] GameObject collidePopup;
    [SerializeField] GameObject notCollidePopup;

    public void CollideToggle(bool toggle)
    {
        Debug.Log("Will Collide = " + toggle);
        collidePopup.SetActive(toggle);
        notCollidePopup.SetActive(!toggle);
    }

}
