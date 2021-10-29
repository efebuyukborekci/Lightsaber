using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
	public float shakeDuration;
	public float shakeAmount;
	public float decreaseFactor;

	Transform camTransform;
	Vector3 originalPos;

    private void Start()
    {
		camTransform = GetComponent<Transform>();
		originalPos = camTransform.localPosition;
	}

	public void ShakeCamera(float shakeDuration, float shakeAmount)
    {
		this.shakeDuration = shakeDuration;
		this.shakeAmount = shakeAmount;
    }

	void Update()
	{
		if (shakeDuration > 0)
		{
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			shakeDuration -= Time.deltaTime;
		}
		else
		{
			shakeDuration = 0f;
			camTransform.localPosition = originalPos;
		}
	}
}