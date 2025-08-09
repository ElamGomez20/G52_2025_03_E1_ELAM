using UnityEngine;
using System;
using packagePersona;
using System.Collections.Generic;

public class UsoEstudiante : MonoBehaviour
{
    List<Estudiante> ListaE = new List<Estudiante>();

    void Start()
    {
        Estudiante e1 = new Estudiante("2025_03", "Ing Multimedia", "Julian Ortega", "juli.orte@uao.edu.co",
            "Cra13b");
        Estudiante e2 = new Estudiante("2025_03", "Ing Informatica", "Robert Green", "robertcito@uao.edu.co",
            "Cra250C");

        ListaE.Add(e1);
        ListaE.Add(e2);

        for (int i = 0; i < ListaE.Count; i++)
        {
            Debug.Log("name: " + ListaE[i].NameP + "Carrera: " + ListaE[i].NameCarreraE);
        }
    }

    void Update()
    {

    }
}