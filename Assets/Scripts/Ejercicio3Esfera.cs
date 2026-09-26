using System.Globalization;
using TMPro;
using UnityEngine;

public class Ejercicio3Esfera : MonoBehaviour
{
    public TMP_Text textToDisplay;

    void Start() {

    }

    void Update() {
        // CultureInfo.InvariantCulture para asegurar que use puntos (.) en vez de comas (,)
        // "F2" limita a 2 decimales para que no salgan números kilométricos
        string xPositionText = transform.position.x.ToString("F2", CultureInfo.InvariantCulture);
        string yPositionText = transform.position.y.ToString("F2", CultureInfo.InvariantCulture);
        string zPositionText = transform.position.z.ToString("F2", CultureInfo.InvariantCulture);
        textToDisplay.text = "(" + xPositionText + ", " + yPositionText + ", " + zPositionText + ")";
    }
}
