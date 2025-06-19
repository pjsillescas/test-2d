# Test 2D
Prueba hecha con el ejemplo gratuito TopDownRace, actualizado para usar el Input System y escenas aditivas.

# Input System

Este juego solamente tiene control por teclado, y el control por joystick en pantalla está desactivado por simplicidad. El uso del Input System se hace mediante la clase C# $InputActions$ ubicada en el archivo Scripts/InputActions.cs y se usa en la clase $PlayerCar$ (TopDownRace/Scripts/Gameplay/PlayerCar.cs).

# Escenas Aditivas

El juego se compone de 4 escenas completas:
1. MainMenu (UI)
2. Forest (Circuito)
3. Desert (Circuito)
4. Snow (Circuito)

Aprovechando que los circuitos tienen una estructura similar, se ha hecho el siguiente diseño de escenas aditivas:

**Base**: Escena base que siempre va a estar cargada. Tiene la lógica de gestión de escenas y la cámara.
**MainMenu**: Menú inicial sin la cámara. No hay mucha diferencia sin la inicial
**Desert, Forest, Snow**: Escenas de circuitos sin cámara ni hud
**HUD**: Escena únicamente con el hud de los circuitos
**Audio**: Escena únicamente con el audiosource con música para los circuitos

Con esta disposición, al iniciar el juego se inicia únicamente la escena **Base**, que carga **MainMenu** para empezar a jugar. Al cambiar de escena, se descarga la escena **MainMenu** y se carga, además del circuito elegido, las escenas **HUD** y **Audio** para añadir el hud y la música al juego.

De la misma manera, para salir del juego al menú inicial, se descargan las escenas de circuito, hud y audio para cargar de nuevo la escena de menú principal.

Toda esta lógica está en la clase *Test2DSceneLoader* (Scripts/Scenes/Test2DSceneLoader.cs), que hereda de *SceneLoader* (misma carpeta) que tiene las funciones de carga y descarga aditiva.

Bugs

No funciona bien la recarga de la misma escena de circuito, se inicia con el menú desplegado.