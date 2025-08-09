using UnityEngine;
using TMPro;

public class Punto2D : MonoBehaviour
{
    public TMP_InputField inputX;
    public TMP_InputField inputY;

    public double X { get; private set; }
    public double Y { get; private set; }

    public void GuardarValores()
    {
        if (double.TryParse(inputX.text, out double valorX) && double.TryParse(inputY.text, out double valorY))
        {
            X = valorX;
            Y = valorY;
            Debug.Log($"Punto guardado: ({X}, {Y})");
        }
        else
        {
            Debug.LogError("Error: Valores inválidos para X o Y");
        }
    }
}
