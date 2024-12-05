using UnityEngine;

public class GestionBloques : MonoBehaviour
{
    // Configuraciones de los bloques
    public int impactosBloque1 = 1;
    public int impactosBloque2 = 2;
    public int impactosBloque3 = 3;
    public int impactosBloque4 = 4;
    public int impactosBloque5 = 5;
    public int impactosBloque6 = 6;

    // Puntos que otorga cada tipo de bloque
    public int puntosBloque1 = 10;
    public int puntosBloque2 = 20;
    public int puntosBloque3 = 30;
    public int puntosBloque4 = 40;
    public int puntosBloque5 = 50;
    public int puntosBloque6 = 60;

    // Contadores de impactos para cada bloque
    private int contadorImpactos;

    // Variable para contar cuántos bloques quedan
    public static int bloquesRestantes; // Contador de bloques restantes

    private void Start()
    {
        // Inicializamos el contador de impactos en 0
        contadorImpactos = 0;

        // Asegurarnos de contar el bloque al inicio
        if (bloquesRestantes == 0)
        {
            bloquesRestantes = FindObjectsOfType<GestionBloques>().Length;
        }
    }

    // Método llamado al colisionar con la bola
    private void OnCollisionEnter(Collision col)
    {
        // Verificar si la colisión es con la pelota
        if (col.gameObject.CompareTag("Bola"))
        {
            // Incrementar el contador de impactos
            contadorImpactos++;

            // Comprobar si el bloque se debe destruir
            if (ShouldDestroyBlock())
            {
                OtorgarPuntos();
                

                // Decrementamos el contador de bloques restantes
                Ganador.Instance.bloquesRestantes--;
                //ControlSingleton.Instance.imagenGanador.SetActive(true);

                // Si no quedan bloques, mostrar el Canvas de Ganador
                if (Ganador.Instance.bloquesRestantes <= 0)
                {
                    ControlUI.instance.MostrarCanvasGanador(); // Llamamos al método que activa el Canvas de Ganador
                }

                // Si es Bloque6, generar un bono (aún no implementado)
                if (gameObject.CompareTag("Bloques6"))
                {
                    GenerarBono();
                }
                // Destruir el bloque
                Destroy(gameObject);
            }
        }
    }

    // Comprobar si el bloque debe destruirse
    private bool ShouldDestroyBlock()
    {
        // Obtener el nombre del bloque y comparar el contador de impactos
        switch (gameObject.tag)
        {
            case "Bloques1":
                return contadorImpactos >= impactosBloque1;
            case "Bloques2":
                return contadorImpactos >= impactosBloque2;
            case "Bloques3":
                return contadorImpactos >= impactosBloque3;
            case "Bloques4":
                return contadorImpactos >= impactosBloque4;
            case "Bloques5":
                return contadorImpactos >= impactosBloque5;
            case "Bloques6":
                return true; // Bloques6 siempre se destruye al generar un bono
            default:
                return false;
        }
    }

    // Método para otorgar puntos según el tipo de bloque
    private void OtorgarPuntos()
    {
        int puntos = 0;
        switch (gameObject.tag)
        {
            case "Bloques1":
                puntos = puntosBloque1;
                break;
            case "Bloques2":
                puntos = puntosBloque2;
                break;
            case "Bloques3":
                puntos = puntosBloque3;
                break;
            case "Bloques4":
                puntos = puntosBloque4;
                break;
            case "Bloques5":
                puntos = puntosBloque5;
                break;
            case "Bloques6":
                puntos = puntosBloque6;
                break;
        }
        // Llama al sistema de puntaje para sumar los puntos
        ControlSingleton.Instance.SumarPuntosPorEtiqueta(gameObject.tag);
    }

    // Método para generar un bono (placeholder)
    private void GenerarBono()
    {
        // Aquí deberías implementar la lógica para crear un bono aleatorio
        // Para ahora, solo imprimimos en consola como placeholder
        Debug.Log("Generando bono para Bloque6");
        // Puedes añadir la lógica de tu bono aquí más tarde.
    }
}
