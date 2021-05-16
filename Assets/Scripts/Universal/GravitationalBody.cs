// using UnityEngine;

// [RequireComponent(typeof(Rigidbody))]
// public class GravitationalBody : MonoBehaviour
// {
//     public string myName = "NoName";

//     public float radius;
//     public Vector3 initialVelocity;
//     public Vector3 Velocity;
//     public float Mass;

//     [SerializeField] protected float surfaceGravity = 9.81f;


//     protected Rigidbody rb;

//     public Vector3 Position { get { return rb.position; } }

//     private void Awake() 
//     {
//         rb = GetComponent<Rigidbody>();
//         rb.useGravity = false;
//         rb.mass = Mass;
//         Velocity = initialVelocity;
//     }

//     public virtual void UpdateVel(GravitationalBody[] bodies)
//     {
//         print(bodies.Length);
//         foreach(var body in bodies)
//         {
//             if (body != this)
//             {
//                 float distSqr = (body.Position - Position).sqrMagnitude;
//                 Vector3 forceDir = (body.Position - Position).normalized;
//                 Vector3 acceleration = forceDir * UniverseSettings.GRAVITY_CONSTANT  * body.Mass / distSqr;
//                 // Velocity += acceleration * Time.deltaTime;
//                 rb.velocity += acceleration * Time.deltaTime;
//                 Debug.DrawRay(transform.position, acceleration * 15f, Color.red); 
//             }
//         }
//     }


//     public void UpdatePos() 
//     {
//         //rb.MovePosition(rb.position + Velocity * Time.deltaTime);
//     }

//     private void FixedUpdate() 
//     {
//         UpdatePos();    
//     }
// }
