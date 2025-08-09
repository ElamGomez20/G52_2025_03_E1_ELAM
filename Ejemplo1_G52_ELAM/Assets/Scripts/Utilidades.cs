using packagePersona;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class Utilidades
{
    private static string rutaArchivo = Application.persistentDataPath + "/datos.json";

    [System.Serializable]
    public class Registro
    {
        public Estudiante estudiante;
        public double X;
        public double Y;
    }

    [System.Serializable]
    private class ListaRegistros
    {
        public List<Registro> registros;
    }

    public static void Guardar(Estudiante est, double x, double y)
    {

        List<Registro> lista = Cargar();

        Registro nuevo = new Registro
        {
            estudiante = est,
            X = x,
            Y = y
        };

        lista.Add(nuevo);

        ListaRegistros wrapper = new ListaRegistros { registros = lista };
        string json = JsonUtility.ToJson(wrapper, true);
        File.WriteAllText(rutaArchivo, json);

        Debug.Log("Datos guardados en: " + rutaArchivo);
    }

    public static List<Registro> Cargar()
    {

        if (!File.Exists(rutaArchivo))
        {
            return new List<Registro>();
        }

        string json = File.ReadAllText(rutaArchivo);

        if (string.IsNullOrEmpty(json))
        {
            return new List<Registro>();
        }

        ListaRegistros wrapper = JsonUtility.FromJson<ListaRegistros>(json);

        if (wrapper != null && wrapper.registros != null)
        {
            return wrapper.registros;
        }

        return new List<Registro>();
    }
}
