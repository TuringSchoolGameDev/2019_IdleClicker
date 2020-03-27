using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public static GameManager globalusKintamasis;

	public float visaSugeneruotaEnergija;
	public Text visosSugeneruotosEnergijosTekstas;

	public float visiSukauptiPinigai;
	public Text visiSukauptiPinigaiTekstas;

	public List<Generator> generatoriai;

	void Awake()
	{
		globalusKintamasis = this;
	}

	void Update()
	{
		for (int i = 0; i < generatoriai.Count; i++)
		{
			visaSugeneruotaEnergija = visaSugeneruotaEnergija + generatoriai[i].energijosGeneravimas * generatoriai[i].kiekYraPatobulinimu * Time.deltaTime;
		}

		visosSugeneruotosEnergijosTekstas.text = visaSugeneruotaEnergija + "";
		visiSukauptiPinigaiTekstas.text = visiSukauptiPinigai + "";
	}
}
