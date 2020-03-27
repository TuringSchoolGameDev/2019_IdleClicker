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

	void Start()
    {
		generatoriasPavadinimoTekstas.text = generatoriausVardas;

	}

	void Update()
    {
        
    }

}
