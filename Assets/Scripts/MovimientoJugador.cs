using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public static MovimientoJugador Instance;
    public float velocidadMovimiento = 1.5f;
    public GameObject bola;
    public float velocidadInicialBola = 10f;

    private Rigidbody _rb;
    private bool bolaEnMovimiento = false;
    ControlSingleton _cs;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        ResetBola();
        
    }

    private void FixedUpdate()
    {
        // Movimiento horizontal del jugador
        float movimientoEjeX = Input.GetAxis("Horizontal") * velocidadMovimiento;
        _rb.velocity = new Vector3(movimientoEjeX, 0, 0);
    }

    private void Update()
    {
        if (!bolaEnMovimiento && Input.GetKeyDown(KeyCode.Space))
        {
            ControlUI.instance.juegoIniciado = true;
            SoltarBola();

        }
    }

    public void ResetBola()
    {
        bola.SetActive(true); // Activar la bola por si estaba desactivada
        bola.transform.SetParent(this.transform);

        Rigidbody rbBola = bola.GetComponent<Rigidbody>();
        if (rbBola != null)
        {
            rbBola.isKinematic = true;
            rbBola.velocity = Vector3.zero;
        }

        bolaEnMovimiento = false;
    }

    private void SoltarBola()
    {
        bola.transform.SetParent(null);
        Rigidbody rbBola = bola.GetComponent<Rigidbody>();
        if (rbBola != null)
        {
            rbBola.isKinematic = false;
            rbBola.velocity = Vector3.up * velocidadInicialBola;
        }

        bolaEnMovimiento = true;
    }
}
