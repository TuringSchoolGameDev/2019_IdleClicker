using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public float visaSugeneruotaEnergija;
	public Text visosSugeneruotosEnergijosTekstas;

	public List<Generator> generatoriai;

	void Start()
	{

	}

	void Update()
	{
		for (int i = 0; i < generatoriai.Count; i++)
		{
			visaSugeneruotaEnergija = visaSugeneruotaEnergija + generatoriai[i].energijosGeneravimas * generatoriai[i].kiekYraPatobulinimu * Time.deltaTime;
		}

		visosSugeneruotosEnergijosTekstas.text = visaSugeneruotaEnergija + "";
	}
}
