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
	public Sprite paveiksliukas;

	public Text generatoriauKainaTekstas;
	public Text generatoriausLygisTekstas;
	public Text generatoriasPavadinimoTekstas;
	public Image generatoriausPaveiksliukas;

	public float kiekEnergijoSusigeneruojaNuoVienoKliko;

	void Start()
    {
		if (generatoriasPavadinimoTekstas != null) 
		{
			generatoriasPavadinimoTekstas.text = generatoriausVardas;
		}
		if (generatoriausPaveiksliukas != null)
		{
			generatoriausPaveiksliukas.sprite = paveiksliukas;
		}
		kiekYraPatobulinimu = PlayerPrefs.GetInt(generatoriausVardas, 0);
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
			PlayerPrefs.SetInt(generatoriausVardas, kiekYraPatobulinimu);
		}
	}

	public float GrazinkDabartineKaina()
	{
		return kaina * Mathf.Pow(didejimoIvertis, kiekYraPatobulinimu);
	}

	public void KlikoGeneravimas()
	{
		GameManager.globalusKintamasis.klikuSugeneruotaEnergija = GameManager.globalusKintamasis.klikuSugeneruotaEnergija + kiekEnergijoSusigeneruojaNuoVienoKliko;
	}
}
