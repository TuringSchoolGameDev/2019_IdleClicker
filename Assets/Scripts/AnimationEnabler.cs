using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEnabler : MonoBehaviour
{
	public GameObject objectas1;
	public GameObject objektas2;
    public void OnButtonPressed()
	{
		objectas1.SetActive(true);
		objektas2.SetActive(false);
	}
}
