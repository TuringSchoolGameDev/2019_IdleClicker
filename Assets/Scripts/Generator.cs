using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
	//matomumas - kintamojo tipas - kintamojo vardas
	public string generatoriausVardas;
	public float kaina;
	public int kiekYraPatobulinimu;
	public float energijosGeneravimas;

	public Text generatoriasPavadinimoTekstas;

	public float kiekEnergijoSusigeneruojaNuoVienoKliko;

	void Start()
    {
		if (generatoriasPavadinimoTekstas != null) 
		{
			generatoriasPavadinimoTekstas.text = generatoriausVardas;
		}
	}

	public void Patobulinimas()
	{
		if (GameManager.globalusKintamasis.visiSukauptiPinigai >= kaina)
		{
			GameManager.globalusKintamasis.visiSukauptiPinigai = GameManager.globalusKintamasis.visiSukauptiPinigai - kaina;
			kiekYraPatobulinimu = kiekYraPatobulinimu + 1;
		}
	}

	public void KlikoGeneravimas()
	{
		GameManager.globalusKintamasis.klikuSugeneruotaEnergija = GameManager.globalusKintamasis.klikuSugeneruotaEnergija + kiekEnergijoSusigeneruojaNuoVienoKliko * kiekYraPatobulinimu;
	}
}
