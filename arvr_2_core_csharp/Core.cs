using System.Collections.Generic;

namespace ARVR
{
    public class Transform
    {
        private float x, y, z;

        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }
        public float Z { get => z; set => z = value; }

        //public float X { get => x; private set => x = value; }
        //public float Y { get => y; private set => y = value; }
        //public float Z { get => z; private set => z = value; }

        public Transform(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        //shallow copy
        public object Clone()
        {
            return this; //reference to the current Transform
        }

        //deep copy
        public object GetDeepCopy()
        {
            return new Transform(x, y, z); //"new" keyword indicates that we are allocating space in RAM for new object
        }

        public override string ToString()
        {
            return "(x: " + x + ", y: " + y + ", z: " + z + ")";
        }
    }

    public class GameObject
    {
        private Transform transform;
        private List<IBehave> behaviours;

        public Transform Transform { get => transform; set => transform = value; }

        public GameObject()
        {
            Transform = new Transform(0, 0, 0);
            behaviours = new List<IBehave>();
        }

        public GameObject(Transform transform)
        {
            Transform = transform;
            behaviours = new List<IBehave>();
        }

        public void AddComponent(IBehave behavior)
        {
            behaviours.Add(behavior);
        }

        public override string ToString()
        {
            return "transform: " + transform;
        }

        public void Update()
        {
            for (int i = 0; i < behaviours.Count; i++)
            {
                IBehave behavior = behaviours[i];
                behavior.Update();
            //    behaviours[i].Update();
            }

            foreach (IBehave behaviour in behaviours)
            {
                behaviour.Update();
                //delete a behaviour from the behaviours list
            }
        }
    }


    public interface IBehave
    {
        public void Update();
        public void Awake();
        public void Start();
        public void Destroy();

    }

    public class MonoBehaviour : IBehave  //implements
    {
        public virtual void Awake()
        {
           //some code in here that happens for all classes extending MonoBehaviour
        }

        public virtual void Destroy()
        {
 
        }

        public virtual void Start()
        {

        }

        public virtual void Update()
        {
 
        }
    }

    public class SelectionManager : MonoBehaviour//, IHandleInput, IHaveHealth, IRestorable   //extends
    {
        public override void Awake()
        {
            //rb = transform.GetComponent<RigidBody>();
        }

        public override void Update()
        {
            //check selection
            //...
        }
    }

    public class FirstPersonCamera : MonoBehaviour
    {
        public override void Update()
        {
            //if (Input.GetKeyDown(KeyCode.W))
            //{
            //    transform.position += transform.forward;
            //}
        }
    }









}
