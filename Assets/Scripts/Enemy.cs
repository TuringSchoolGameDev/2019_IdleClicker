using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
	public float bazineStartineEnergija;
	public float startineEnergija;
	public float startinisGyvybiuEilutesDydis;
	public float didejimoIvertis;

	[NonSerialized]
	public float energija;//float tai yra skaicius su kableliu 0.1, 0.5

	public RectTransform gyvybiuEilute;

	private void Start()
	{
		startinisGyvybiuEilutesDydis = gyvybiuEilute.sizeDelta.x;
	}

	public void PoPriesoSukurimo()
	{
		energija = KiekEnergijosTuriSitasPriesasPradzioje();
		startineEnergija = energija;//sukurimo metu energija yra startineenergija
	}

	public float KiekEnergijosTuriSitasPriesasPradzioje()
	{
		return bazineStartineEnergija * Mathf.Pow(didejimoIvertis, GameManager.globalusKintamasis.kiekEsamNugalejePriesu);
	}

	private void Update()//kiekvienam kadre mums atlieka kazkoki koda
	{
		Vector2 laikinasKintamasis = gyvybiuEilute.sizeDelta;
		laikinasKintamasis.x = startinisGyvybiuEilutesDydis * energija / startineEnergija;
		gyvybiuEilute.sizeDelta = laikinasKintamasis;
	}
}
