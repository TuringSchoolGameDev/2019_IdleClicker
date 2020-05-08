using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
	//matomumas - kintamojo tipas - kintamojo vardas
	public string generatoriausVardas;
	public float kaina;
	public float didejimoIvertis;
	public int kiekYraPatobulinimu;
	public float energijosGeneravimas;

	public Text generatoriauKainaTekstas;
	public Text generatoriausLygisTekstas;
	public Text generatoriasPavadinimoTekstas;

	public float kiekEnergijoSusigeneruojaNuoVienoKliko;

	void Start()
    {
		if (generatoriasPavadinimoTekstas != null) 
		{
			generatoriasPavadinimoTekstas.text = generatoriausVardas;
		}
	}

	private void Update()
	{
		if (generatoriauKainaTekstas != null)
		{
			generatoriauKainaTekstas.text = GrazinkDabartineKaina() + "";
		}
		if (generatoriausLygisTekstas != null)
		{
			generatoriausLygisTekstas.text = kiekYraPatobulinimu + "";
		}
	}

	public void Patobulinimas()
	{
		if (GameManager.globalusKintamasis.visiSukauptiPinigai >= GrazinkDabartineKaina())
		{
			GrazinkDabartineKaina();
			GameManager.globalusKintamasis.visiSukauptiPinigai = GameManager.globalusKintamasis.visiSukauptiPinigai - GrazinkDabartineKaina();
			kiekYraPatobulinimu = kiekYraPatobulinimu + 1;
		}
	}

	public float GrazinkDabartineKaina()
	{
		return kaina * Mathf.Pow(didejimoIvertis, kiekYraPatobulinimu);
	}

	public void KlikoGeneravimas()
	{
		GameManager.globalusKintamasis.klikuSugeneruotaEnergija = GameManager.globalusKintamasis.klikuSugeneruotaEnergija + kiekEnergijoSusigeneruojaNuoVienoKliko * kiekYraPatobulinimu;
	}
}
