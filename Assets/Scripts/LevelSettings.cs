using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSettings", menuName = "LevelSettings/NewSettings", order = 1)]
public class LevelSettings : ScriptableObject
{
    public float characterAnimationSpeed;
    public float characterSlowmotionSpeed;

    public List<CharacterData> characters = new List<CharacterData>();

}

[System.Serializable]
public class CharacterData
{
    public Material characterMaterial;
    public LightsaberData lightsaberData;
}

[System.Serializable]
public class LightsaberData
{
    public Color lightsaberColor;
    public float emissiveIntensity;
    public float lightIntensity;
    public float lightsaberLength;
    public float lightsaberOpeningSpeed;
    public float lightsaberStartDelay;
}
