using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public static GameManager globalusKintamasis;

	public float klikuSugeneruotaEnergija;

	public float visiSukauptiPinigai;
	public Text visiSukauptiPinigaiTekstas;

	public List<Generator> generatoriai;

	public List<GameObject> priesoPrefabai;
	public Transform priesoTevas;
	public Enemy dabartinisPriesas;
	public float kiekEnergijosTuresPriesas;

	void Awake()
	{
		globalusKintamasis = this;
	}

	void Update()
	{
		float sugeneruotaEnergijaVienameKadre = VisaVienameKadreSugeneruotaMusuEnergija();
		AtnaujinkMusuTekstus();
		SukurkimPriesaJeiJisNeegzistuoja();
		DarytiZalaPriesui(sugeneruotaEnergijaVienameKadre);
		klikuSugeneruotaEnergija = 0;
	}

	float VisaVienameKadreSugeneruotaMusuEnergija()
	{
		float visaSugeneruotaEnergija = 0;
		for (int i = 0; i < generatoriai.Count; i++)
		{
			visaSugeneruotaEnergija = visaSugeneruotaEnergija + generatoriai[i].energijosGeneravimas * generatoriai[i].kiekYraPatobulinimu * Time.deltaTime;
		}
		return visaSugeneruotaEnergija;
	}

	void AtnaujinkMusuTekstus()
	{
		visiSukauptiPinigaiTekstas.text = visiSukauptiPinigai + "";
	}

	void SukurkimPriesaJeiJisNeegzistuoja()
	{
		if (dabartinisPriesas == null)//true || false
		{
			GameObject vienasPriesoPrefabas = priesoPrefabai[Random.Range(0, priesoPrefabai.Count)];
			GameObject priesas = Instantiate(vienasPriesoPrefabas, priesoTevas);
			dabartinisPriesas = priesas.GetComponent<Enemy>();
			dabartinisPriesas.PoPriesoSukurimo(kiekEnergijosTuresPriesas);
			kiekEnergijosTuresPriesas = kiekEnergijosTuresPriesas + 1;
		}
	}

	void DarytiZalaPriesui(float energija)
	{
		if (dabartinisPriesas != null)
		{
			dabartinisPriesas.energija = dabartinisPriesas.energija - energija;
			dabartinisPriesas.energija = dabartinisPriesas.energija - klikuSugeneruotaEnergija;
			if (dabartinisPriesas.energija <= 0)
			{
				visiSukauptiPinigai = visiSukauptiPinigai + dabartinisPriesas.pinigai;
				Destroy(dabartinisPriesas.gameObject);
			}
		}
	}
}
