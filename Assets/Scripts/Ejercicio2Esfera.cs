using UnityEngine;

public class Ejercicio2Esfera : MonoBehaviour
{
    public Vector3 firstVector;
    public Vector3 secondVector;

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
        Debug.Log("Magnitud primer vector: " + firstVector.magnitude);
        Debug.Log("Magnitud segundo vector: " + secondVector.magnitude);
        // Mostrar ángulo que forman
        Debug.Log("Ángulo from primer vector to segundo vector: " + Vector3.Angle(firstVector, secondVector));
        // Mostrar distancia entre ambos
         Debug.Log("Distancia entre vectores: " + Vector3.Distance(firstVector, secondVector));
         // Mostrar mensaje indicando qué vector está a mayor altura
         if (firstVector.y > secondVector.y){
            Debug.Log("El primer vector está a mayor altura.");
        } else if (firstVector.y < secondVector.y) {
            Debug.Log("El segundo vector está a mayor altura.");
        } else {
            Debug.Log("Ambos vectores están a la misma altura.");
        }
    }
}
