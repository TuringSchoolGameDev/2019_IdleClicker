using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticleSystem : MonoBehaviour
{
	public ParticleSystem efektuSistema;

    void Start()
    {
		Destroy(gameObject, efektuSistema.main.duration);

	}
}
