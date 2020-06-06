using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

	public int kiekEsamNugalejePriesu;

	public float bazinisPiniguSkaicius;
	public float piniguDidejimoIvertis;
	public float superBonusas;

	public GameObject sprogimoPrefabas;

	void Awake()
	{
		globalusKintamasis = this;
	}

	private void Start()
	{
		kiekEsamNugalejePriesu = PlayerPrefs.GetInt("NugaletiPriesai", 0);
		visiSukauptiPinigai = PlayerPrefs.GetFloat("VisiSukauptiPinigai", 0);
		superBonusas = PlayerPrefs.GetFloat("SuperBonusas", 1);
	}

	void Update()
	{
		float sugeneruotaEnergijaVienameKadre = VisaVienameKadreSugeneruotaMusuEnergija();
		AtnaujinkMusuTekstus();
		SukurkimPriesaJeiJisNeegzistuoja();
		DarytiZalaPriesui(sugeneruotaEnergijaVienameKadre);
		klikuSugeneruotaEnergija = 0;

		test = GrazinkDabartineKaina();
	}

	float VisaVienameKadreSugeneruotaMusuEnergija()
	{
		float visaSugeneruotaEnergija = 0;
		for (int i = 0; i < generatoriai.Count; i++)
		{
			visaSugeneruotaEnergija = visaSugeneruotaEnergija + Mathf.Pow(generatoriai[i].energijosGeneravimas * generatoriai[i].kiekYraPatobulinimu * Time.deltaTime, superBonusas);
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
			dabartinisPriesas.PoPriesoSukurimo();
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
				visiSukauptiPinigai = visiSukauptiPinigai + KiekPiniguGrazinsPriesas();
				kiekEsamNugalejePriesu = kiekEsamNugalejePriesu + 1;
				PlayerPrefs.SetInt("NugaletiPriesai", kiekEsamNugalejePriesu);
				PlayerPrefs.SetFloat("VisiSukauptiPinigai", visiSukauptiPinigai);
				GameObject sprogimoEfektas = Instantiate(sprogimoPrefabas, dabartinisPriesas.transform.position, Quaternion.identity, null);
				Destroy(dabartinisPriesas.gameObject);
			}
		}
	}

	public float KiekPiniguGrazinsPriesas()
	{
		return bazinisPiniguSkaicius * Mathf.Pow(piniguDidejimoIvertis, kiekEsamNugalejePriesu);
	}

	public void PradetiPerNauja()
	{
		if (GameManager.globalusKintamasis.visiSukauptiPinigai >= GrazinkDabartineKaina())
		{
			GameManager.globalusKintamasis.visiSukauptiPinigai = GameManager.globalusKintamasis.visiSukauptiPinigai - GrazinkDabartineKaina();

			PlayerPrefs.SetInt("NugaletiPriesai", 0);
			PlayerPrefs.SetFloat("VisiSukauptiPinigai", 0);
			for (int i = 0; i < generatoriai.Count; i++)
			{
				PlayerPrefs.SetInt(generatoriai[i].generatoriausVardas, 0);
			}

			superBonusas = superBonusas + 0.01f; 
			PlayerPrefs.SetFloat("SuperBonusas", superBonusas);
			SceneManager.LoadScene(0);
		}
	}

	public float test;
	public float GrazinkDabartineKaina()
	{
		return 100;
	}
}
