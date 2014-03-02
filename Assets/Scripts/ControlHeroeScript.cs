using UnityEngine;

public class HeroController : MonoBehaviour
{

	// Velocidad de movimiento del personaje
	public float moveSpeed;

	// Velocidad de giro del personaje
	public float turnSpeed;
	
	// Vector normalizado que apunta a la posicion destino
	public Vector3 moveDirection;

	// Informacion de depuracion
	public Vector3 currentPosition;	// posicion actual
	public Vector3 moveToward;		// punto destino
	public Vector3 target;			// punto destino este frame
	public float distance;			// distancia al punto de destino
	public float lerp;				// avance este frame
	public float targetAngle;		// angulo objetivo

	private Animator animator;


	// Inicializamos las referencias a los componentes
	void Awake ()
	{
		animator = GetComponent<Animator>();
	}


	// Inicializamos las variables
	void Start ()
	{
		currentPosition = transform.position;
		target = currentPosition;
		distance = 0;
		lerp = 0;
	}


	// Update is called once per frame
	void Update ()
	{
		// Actualizamos la posicion
		currentPosition = transform.position;

		// Obtenemos la posicion destino y su vector de direccion
		if ( Input.GetButtonDown("Fire1") )
		{
			moveToward = Camera.main.ScreenToWorldPoint( Input.mousePosition );
			moveToward.z = 0;
			moveDirection = moveToward - currentPosition;
			moveDirection.Normalize();

			// Distancia entre el punto destino y nuestra posicion
			distance = (moveToward - currentPosition).magnitude;

			// Activamos el estado "andando", para mostrar la animacion
			animator.SetBool("isWalking", true);
		}

		// Si no hemos llegado todavia al destino:
		if ( distance > 0 )
		{
			// Calculamos el punto de destino para este frame
			target = moveDirection * moveSpeed + currentPosition;

			// Nos movemos en la direccion destino
			transform.position = Vector3.Lerp( currentPosition, target, Time.deltaTime );

			// Restamos nuestro avance a la distancia que habia entre el destino y nosotros
			lerp = moveDirection.magnitude * moveSpeed * Time.deltaTime;
			distance = distance - lerp;
			
			// Giramos el personaje
			targetAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Slerp( transform.rotation,
			                                      Quaternion.Euler( 0, 0, targetAngle ),
			                                      turnSpeed * Time.deltaTime );

		} 
		else
		{
			animator.SetBool("isWalking", false);
		}
	}

}
