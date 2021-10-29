using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LightsaberController : MonoBehaviour
{
    [SerializeField] Transform saberLightMesh;
    [SerializeField] Light saberLight;
    [SerializeField] Animator myAnimator;

    float openingSpeed = 1f;
    Material mat;
    Tween lightsaberTween;

    private void Start()
    {
        mat = saberLightMesh.GetComponent<Renderer>().material;
    }

    public void InitializeLightsaber(LightsaberData lightsaberData)
    {
        mat.SetColor("_EmissionColor", lightsaberData.lightsaberColor * lightsaberData.emissiveIntensity);
        saberLight.color = lightsaberData.lightsaberColor;
        openingSpeed = lightsaberData.lightsaberOpeningSpeed;
    }

    public void LightsaberToggle(bool toggle)
    {
        if (toggle)
        {
            myAnimator.Play("LightsaberOpen");
        }
        else
        {
            myAnimator.Play("LightsaberClose");
        }
    }
}
