using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
	public float startineEnergija;
	public float startinisGyvybiuEilutesDydis;

	[NonSerialized]
	public float energija;//float tai yra skaicius su kableliu 0.1, 0.5
	public float pinigai;//float tai yra skaicius su kableliu 0.1, 0.5, 21.0

	public RectTransform gyvybiuEilute;

	private void Start()
	{
		startinisGyvybiuEilutesDydis = gyvybiuEilute.sizeDelta.x;
	}

	public void PoPriesoSukurimo(float kiekEnergijos)
	{
		energija = kiekEnergijos;
		startineEnergija = energija;//sukurimo metu energija yra startineenergija
	}


	private void Update()//kiekvienam kadre mums atlieka kazkoki koda
	{
		Vector2 laikinasKintamasis = gyvybiuEilute.sizeDelta;
		laikinasKintamasis.x = startinisGyvybiuEilutesDydis * energija / startineEnergija;
		gyvybiuEilute.sizeDelta = laikinasKintamasis;
	}
}
