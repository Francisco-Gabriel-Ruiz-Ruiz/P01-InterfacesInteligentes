# Práctica #1 de Interfaces Inteligentes: Introducción C# - Scripts

Esta es la primera práctica de la asignatura **Interfaces Inteligentes** (curso 2026-2027), perteneciente al [Grado en Ingeniería Informática](https://www.ull.es/grados/ingenieria-informatica/) de [La Universidad de La Laguna](https://www.ull.es/).

El objetivo principal de esta práctica es familiarizarse con la herramienta Unity y el lenguaje de programación asociado a él por excelencia: C#. Este informe documenta la realización de los cuatro primeros ejercicios presentes en la hoja de problemas propuesta.

[Enlace a la hoja de problemas.](https://docs.google.com/document/d/1eL4NESQfyvbkEFGkTgvQwmgPjrnUmd03bNzlArNYYEs/edit?tab=t.0)

La metodología seguida para su realización es la siguiente:

* Sincronización del proyecto de Unity con este repositorio. Por lo general, un commit para cada ejercicio.
* Creación del directorio **Scripts** con todo el código C# desarrollado.
* Un script para cada ejercicio.
* Una misma escena para todos los ejercicios.

## Ejercicio 1

* Código desarrollado en [Assets/Scripts/Ejercicio1Cubo.cs](/Assets/Scripts/Ejercicio1Cubo.cs)
* Demostración en GIF:
![Demostración ejercicio 1](/GitImages/Ejercicio1-P01-II.gif)

Vemos que se ha logrado que la cantidad de frames sea parametrizable desde el Inspector. En el GIF comienza con 120 (por defecto), luego lo cambiamos a 30 y finalmente a 240. Se aprecian los cambios por la rapidez con que cambia el cubo.

En cuanto al script:
* Se ha definido la variable pública `frameThreshold` (inicializada a 120 por defecto) para permitir configurar y parametrizar la cantidad de frames de espera directamente desde el Inspector de Unity.
* Se utiliza el componente `MeshRenderer` mediante la llamada a `GetComponent<MeshRenderer>()` en el método `Start()` para obtener una referencia directa al objeto y poder modificar las propiedades visuales de su material.
* Se hace uso de la clase estática `Random.Range()` de Unity para generar valores aleatorios comprendidos entre 0.0 y 1.0, empleados tanto para inicializar los canales de color del cubo como para modificar posteriormente una componente aleatoria del color.
* Se emplea un contador de fotogramas dentro del método `Update()` que se incrementa en cada frame. Al alcanzar o superar el umbral fijado (`frameThreshold`), se selecciona aleatoriamente mediante una estructura `switch` uno de los componentes de color ($R$, $G$ o $B$), se actualiza el color del cubo, y se reinicia el contador a cero.

## Ejercicio 2

* Código desarrollado en [Assets/Scripts/Ejercicio2Esfera.cs](/Assets/Scripts/Ejercicio2Esfera.cs)
* Demostración en GIF:
![Demostración ejercicio 2](/GitImages/Ejercicio2-P01-II.gif)

Vemos en el GIF que se muestran mensajes en consola para la magnitud de cada vector, el ángulo que forman, la distancia entre ambos y cuál está a una altura mayor. El script está configurado para que solo se manden los mensajes a consola cuando se detecte un cambio en cualquiera de los vectores.

Se prueban con los siguientes valores (se adjunta una captura de pantalla de los mensajes para facilitar su comprobación. En el GIF también aparecen):

* (0,0,0) (0,0,0)

![Demostración ejercicio 2 con (0,0,0) (0,0,0)](/GitImages/Ejercicio2-PrimerEjemplo.png)

* (1,0,0) (0,0,0)

![Demostración ejercicio 2 con (1,0,0) (0,0,0)](/GitImages/Ejercicio2-SegundoEjemplo.png)

* (1,0,0) (0,2,0)

![Demostración ejercicio 2 con (1,0,0) (0,0,0)](/GitImages/Ejercicio2-TercerEjemplo.png)

En cuanto al script:

* Se han definido dos variables públicas de tipo `Vector3` para permitir configurar sus coordenadas directamente desde el Inspector de Unity.
* Se ha implementado un mecanismo de control de cambios comparando los vectores actuales con los almacenados en variables auxiliares privadas. De este modo, el método `ComputeShowingData()` solo se ejecuta en el `Update` cuando se detecta una modificación real, evitando colapsar la consola con mensajes innecesarios en cada frame.
* Para el cálculo de los datos solicitados se han utilizado las funciones nativas de la clase `Vector3` de Unity:
  * `.magnitude` para obtener la longitud de cada vector.
  * `Vector3.Angle()` para calcular el ángulo que forman entre ambos.
  * `Vector3.Distance()` para la distancia euclidiana.
* Se ha añadido una estructura condicional (`if-else`) basada en la componente vertical (`.y`) para determinar dinámicamente cuál de los dos vectores se encuentra a mayor altura.

## Ejercicio 3

* Código desarrollado en [Assets/Scripts/Ejercicio3Esfera.cs](/Assets/Scripts/Ejercicio3Esfera.cs)
* Demostración en GIF:
![Demostración ejercicio 3](/GitImages/Ejercicio3-P01-II.gif)

Vemos en el GIF cómo se sincroniza la posición de la esfera con el texto en pantalla. Si nos fijamos en las coordenadas del Inspector, vemos que cambian síncronamente con las coordenadas en pantalla.

Hemos optado por crear un **Canvas** y dentro de este un objeto **Text - TextMeshPro**. Desde el script solicitamos que se introduzca un objeto del tipo `TMP_Text` (Text Mesh Pro) desde el Inspector, tal y como se muestra en la siguiente imagen:

![TextToDisplay Inspector](/GitImages/Ejercicio3-TextToDisplayInspector.png)

Para mostrar la posición de forma limpia y legible, aplicamos dos configuraciones en la conversión de los números flotantes a texto:

* **CultureInfo.InvariantCulture:** Fuerza el uso del punto (`.`) como separador decimal estándar. Esto es fundamental para evitar confusiones visuales, ya que las comas (`,`) se reservan exclusivamente para separar las coordenadas $X$, $Y$ y $Z$ entre sí.

* **Formato "F2":** Limita el valor numérico a un fijo de dos decimales.

Para situar el texto en esa posición inferior izquierda de la pantalla, aplicamos la configuración que Unity nos trae por defecto en Rect Transform (tras pulsar el icono y luego `Ctrl` + `Alt`):

![Posición por defecto en Rect Transform](/GitImages/Ejercicio3-PosicionTexto.png)

En cuanto al script:
* Se usa el método `.ToString` para pasar de un `float` a `string`.
* Al estar el script adjunto a la esfera, se accede directamente a su posición con `transform.position` sin necesidad de usar `GetComponent<Transform>()`.
* Se usan las configuraciones `CultureInfo.InvariantCulture` y formato `"F2"` anteriormente explicadas.

## Ejercicio 4

* Código desarrollado en [Assets/Scripts/Ejercicio4Esfera.cs](/Assets/Scripts/Ejercicio4Esfera.cs)
* Demostración en GIF:
![Demostración ejercicio 4](/GitImages/Ejercicio4-P01-II.gif)

Vemos en el GIF cómo tanto el cubo como el cilindro tienen asignado un tag cada uno para facilitar su uso en el script de la esfera. Para hacer más sencilla su comprobación, he aquí capturas de ello:

* Tag del cubo (*CuboColorCambiante*):

![Demostración ejercicio 4](/GitImages/Ejercicio4-TagCubo.png)

* Tag del cilindro (*CilindroEjercicio4*):

![Demostración ejercicio 4](/GitImages/Ejercicio4-TagCilindro.png)

*Nota: los tags usados fueron creados y asignados manualmente.*

Al igual que en el ejercicio 2, sólo se mandarán mensajes en consola cuando se detecten cambios en la posición del cubo o cilindro. Es por este motivo que, en el GIF, la consola recibe muchos mensajes al mover progresivamente los objetos y solamente uno cuando se actualiza un valor mediante el Inspector.

En cuanto al script:
* Se usó el método `Vector3.Distance` para calcular la distancia.
* Si no se detecta uno de los objetos tras usar `GameObject.FindWithTag`, se lanza un error crítico a la consola (`Debug.LogError`) y en el método `Update` no se ejecuta nada para evitar errores de referencias. No se comprueba aquí con `GameObject.FindWithTag` para no sobrecargar el programa en cada frame con un método tan costoso.
* Se ha implementado un mecanismo de control de cambios comparando las posiciones actuales con los almacenados en variables auxiliares privadas. De este modo, solo se actualizan dichas variables y muestra en consola en el `Update` cuando se detecta una modificación real, evitando colapsar la consola con mensajes innecesarios en cada frame.