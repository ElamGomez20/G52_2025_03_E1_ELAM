using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using packagePersona;

public class UIManager : MonoBehaviour
{
    [Header("Campos Estudiante")]
    public TMP_InputField inputNombre;
    public TMP_InputField inputCorreo;
    public TMP_InputField inputDireccion;
    public TMP_InputField inputCodigo;
    public TMP_InputField inputCarrera;
    public Button btnGuardarEstudiante;
    public Button btnEliminarEstudiante;
    public TMP_Text listaEstudiantesText;

    [Header("Campos Punto2D")]
    public TMP_InputField inputX;
    public TMP_InputField inputY;
    public Button btnGuardarPunto;
    public TMP_Text listaPuntosText;

    private List<Estudiante> listaEstudiantes = new List<Estudiante>();
    private List<Vector2> listaPuntos = new List<Vector2>();

    private void Start()
    {
        listaEstudiantes.Add(new Estudiante("2025_03", "Ing Multimedia", "Julian Ortega", "juli.orte@uao.edu.co", "Cra13b"));
        listaEstudiantes.Add(new Estudiante("2025_03", "Ing Informatica", "Robert Green", "robertcito@uao.edu.co", "Cra250C"));

        ActualizarListaEstudiantes();
        ActualizarListaPuntos();

        btnGuardarEstudiante.onClick.AddListener(GuardarEstudiante);
        btnEliminarEstudiante.onClick.AddListener(EliminarEstudiante);
        btnGuardarPunto.onClick.AddListener(GuardarPunto);
    }

    private void GuardarEstudiante()
    {
        Estudiante nuevo = new Estudiante(
            inputCodigo.text,
            inputCarrera.text,
            inputNombre.text,
            inputCorreo.text,
            inputDireccion.text
        );

        listaEstudiantes.Add(nuevo);
        ActualizarListaEstudiantes();

        inputNombre.text = "";
        inputCorreo.text = "";
        inputDireccion.text = "";
        inputCodigo.text = "";
        inputCarrera.text = "";

        Debug.Log("Estudiante guardado.");
    }

    private void EliminarEstudiante()
    {
        if (listaEstudiantes.Count > 0)
        {
            listaEstudiantes.RemoveAt(listaEstudiantes.Count - 1);
            ActualizarListaEstudiantes();
            Debug.Log("Último estudiante eliminado.");
        }
        else
        {
            Debug.LogWarning("No hay estudiantes para eliminar.");
        }
    }

    private void GuardarPunto()
    {
        if (float.TryParse(inputX.text, out float x) && float.TryParse(inputY.text, out float y))
        {
            listaPuntos.Add(new Vector2(x, y));
            ActualizarListaPuntos();

            inputX.text = "";
            inputY.text = "";

            Debug.Log($"Punto guardado: ({x}, {y})");
        }
        else
        {
            Debug.LogWarning("Coordenadas inválidas.");
        }
    }

    private void ActualizarListaEstudiantes()
    {
        listaEstudiantesText.text = "Lista de Estudiantes:\n";
        foreach (var est in listaEstudiantes)
        {
            listaEstudiantesText.text += $"- {est.NameP} ({est.NameCarreraE})\n";
        }
    }

    private void ActualizarListaPuntos()
    {
        listaPuntosText.text = "Lista de Puntos:\n";
        foreach (var p in listaPuntos)
        {
            listaPuntosText.text += $"- ({p.x}, {p.y})\n";
        }
    }
}
