using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    [SerializeField] LightsaberController myLightsaber;
    [SerializeField] CollidePrediction myPrediction;
    [SerializeField] Slider mySlider;
    [SerializeField] AudioSource roar;
    [SerializeField] AudioSource laser;
    [SerializeField] Renderer[] meshes;

    Animator myAnimator;
    bool isSwingReady;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        mySlider.onValueChanged.AddListener(SetLightsaberPosition);
    }

    public void InitializeCharacter(CharacterData characterData)
    {
        myLightsaber.InitializeLightsaber(characterData.lightsaberData);
        SetMaterial(characterData.characterMaterial);
    }

    public void SetMaterial(Material material)
    {
        for (int i = 0; i < meshes.Length; i++)
        {
            meshes[i].material = material;
        }
    }

    public void SetLightsaberPosition(float height)
    {
        myAnimator.SetFloat("AttackHeight", height);
        if (myPrediction != null)
        {
            GameManager.instance.uIController.CollideToggle(myPrediction.HitTest()); 
        }
    }

    public void DecisionPoint()
    {
        myAnimator.speed = 0f;
        isSwingReady = true;
        if (myPrediction != null)
        {
            GameManager.instance.uIController.CollideToggle(myPrediction.HitTest());
        }
    }

    public void RoarSound()
    {
        roar.Play();
        GameManager.instance.cameraShake.ShakeCamera(3f, 0.03f);
    }
    public void LaserSound()
    {
        laser.Play();
    }
    public void Swing()
    {
        if (isSwingReady)
        {
            myAnimator.speed = GameManager.instance.levelSettings.characterSlowmotionSpeed;
            Invoke(nameof(LaserSound), 0f);
            isSwingReady = false;
        }
    }
}
