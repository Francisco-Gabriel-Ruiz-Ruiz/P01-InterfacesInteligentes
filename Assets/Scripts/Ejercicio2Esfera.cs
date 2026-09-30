using UnityEngine;

public class Ejercicio2Esfera : MonoBehaviour
{
    public Vector3 firstVector;
    public Vector3 secondVector;
    // Variables públicas para mostrar los resultados en el Inspector
    public float magnitudeFirstVector;
    public float magnitudeSecondVector;
    public float angleBetweenVectors;
    public float distanceBetweenVectors;
    public string heightComparisonMessage;

    // Variables privadas para detectar cambios y evitar inundar la consola
    private Vector3 previousFirstVector;
    private Vector3 previousSecondVector;
    
    void Start() {
        // Calcular los valores iniciales
        ComputeShowingData();
        // Guardar el estado actual como anterior
        previousFirstVector = firstVector;
        previousSecondVector = secondVector;
    }

    void Update() {
        // Solo actuar si detecta que se ha modificado algún vector desde el Inspector
        if (firstVector != previousFirstVector || secondVector != previousSecondVector) {
            ComputeShowingData();
            // Actualizar los valores anteriores para la siguiente comprobación
            previousFirstVector = firstVector;
            previousSecondVector = secondVector;
        }
    }

    void ComputeShowingData() {
        Debug.Log("Primer vector: (" + firstVector.x + ", " + firstVector.y + ", " + firstVector.z + ")");
        Debug.Log("Segundo vector: (" + secondVector.x + ", " + secondVector.y + ", " + secondVector.z + ")");
        // Mostrar magnitudes
        magnitudeFirstVector = firstVector.magnitude;
        magnitudeSecondVector = secondVector.magnitude;
        Debug.Log("Magnitud primer vector: " + magnitudeFirstVector);
        Debug.Log("Magnitud segundo vector: " + magnitudeSecondVector);
        // Mostrar ángulo que forman
        angleBetweenVectors = Vector3.Angle(firstVector, secondVector);
        Debug.Log("Ángulo from primer vector to segundo vector: " + angleBetweenVectors);
        // Mostrar distancia entre ambos
        distanceBetweenVectors = Vector3.Distance(firstVector, secondVector);
        Debug.Log("Distancia entre vectores: " + distanceBetweenVectors);
        // Mostrar mensaje indicando qué vector está a mayor altura
        if (firstVector.y > secondVector.y){
            heightComparisonMessage = "El primer vector está a mayor altura.";
            Debug.Log(heightComparisonMessage);
        } else if (firstVector.y < secondVector.y) {
            heightComparisonMessage = "El segundo vector está a mayor altura.";
            Debug.Log(heightComparisonMessage);
        } else {
            heightComparisonMessage = "Ambos vectores están a la misma altura.";
            Debug.Log(heightComparisonMessage);
        }
    }
}
