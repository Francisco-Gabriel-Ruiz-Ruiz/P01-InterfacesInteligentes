using UnityEngine;

public class Ejercicio1Cubo : MonoBehaviour
{
    public int frameThreshold = 120; // Parametrizable desde el inspector
    private Color randomColor;
    private int frameCount = 0;
    
    private MeshRenderer gameObjectRenderer;

    void Start() {
        // Obtener el componente del cubo
        gameObjectRenderer = GetComponent<MeshRenderer>(); // Referencia al objeto asociado al script
        // Inicializar el color con valores aleatorios entre 0.0 y 1.0
        float randomX = Random.Range(0.0f, 1.0f);
        float randomY = Random.Range(0.0f, 1.0f);
        float randomZ = Random.Range(0.0f, 1.0f);
        randomColor = new Color(randomX, randomY, randomZ);
        // Aplicar directamente al material actual del objeto
        gameObjectRenderer.material.color = randomColor;
    }

    void Update() {
        ++frameCount;
        if (frameCount >= frameThreshold) {
            float randomValue = Random.Range(0.0f, 1.0f);
            int randomPositionToModify = Random.Range(0, 3); // 0, 1 o 2 (red, green, blue)
            switch (randomPositionToModify) {
                case 0:
                    randomColor = new Color(randomValue, randomColor.g, randomColor.b);
                    break;
                case 1:
                    randomColor = new Color(randomColor.r, randomValue, randomColor.b);
                    break;
                case 2:
                    randomColor = new Color(randomColor.r, randomColor.g, randomValue);
                    break;
            }
            // Cambiar el color
            gameObjectRenderer.material.color = randomColor;
            // Reinicar contador
            frameCount = 0;
        }
    }
}