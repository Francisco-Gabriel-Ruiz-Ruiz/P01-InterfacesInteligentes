using UnityEngine;

public class Ejercicio4Esfera : MonoBehaviour
{
    GameObject cube;
    GameObject cylinder;
    Vector3 previousCubePosition;
    Vector3 previousCylinderPosition;
    Vector3 currentCubePosition;
    Vector3 currentCylinderPosition;

    void Start() {
        cube = GameObject.FindWithTag("CuboColorCambiante");
        cylinder = GameObject.FindWithTag("CilindroEjercicio4");
        if (!cube || !cylinder) {
            Debug.LogError(" No se ha encontrado el Cubo o el Cilindro. Revisar que tengan asignados los Tags correctamente.");
            return;
        }
        previousCubePosition = cube.transform.position;
        previousCylinderPosition = cylinder.transform.position;
        currentCubePosition = previousCubePosition;
        currentCylinderPosition = previousCylinderPosition;
        Debug.Log("Distancia entre el cubo y cilindro: " + Vector3.Distance(currentCubePosition, currentCylinderPosition));
    }

    void Update() {
        if (!cube || !cylinder) {
            return;
        }
        currentCubePosition = cube.transform.position;
        currentCylinderPosition = cylinder.transform.position;
        if (previousCubePosition != currentCubePosition || previousCylinderPosition != currentCylinderPosition) {
            Debug.Log("Distancia entre el cubo y cilindro: " + Vector3.Distance(currentCubePosition, currentCylinderPosition));
            previousCubePosition = currentCubePosition;
            previousCylinderPosition = currentCylinderPosition;
        }
    }
}
