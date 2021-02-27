using System;
using System.Collections.Generic;
using System.Timers;

namespace ARVR
{

    /*
    Objects & Classes
    Encapsulation, Inheritance and Polymorphism
    Method overloading & Overriding
    Inheritance vs Composition
    Interfaces
    Virtual methods
    Deep & shallow cloning
    Arrow functions
    Casting objects using the as keyword
    Data structures (Vector, List, Queue, Set, Dictionary)
   
     */
    class Program
    {
        private Timer timer;

        static void Main(string[] args)
        {
            Program theApp = new Program();
            theApp.Start();
        }

        private void Start()
        {
            DemoTransformClone();
            DemoGameObject();


            timer = new System.Timers.Timer();
            timer.Elapsed += OnTick;
            timer.Interval = 1000; //ms
            timer.Enabled = true;
            timer.AutoReset = true;
        }

        private void DemoGameObject()
        {
            List<GameObject> scene = new List<GameObject>();


            GameObject camera = new GameObject();
            camera.AddComponent(new FirstPersonCamera());
            scene.Add(camera);

            GameObject selectionManager = new GameObject();
            selectionManager.AddComponent(new SelectionManager());
            scene.Add(selectionManager);

            //update on scene objects
            for(int i = 0; i < scene.Count; i++)
            {
                scene[i].Update();
            }

            //draw on scene objects
            for (int i = 0; i < scene.Count; i++)
            {
                //scene[i].GetComponent<MeshRenderer>().Draw();
            }
        }

        private void DemoTransformClone()
        {
            Transform t1 = new Transform(1, 2, 3);

            //try
            //{
            //    Transform cloneT1 = (Transform)t1.Clone();             //if this cast fails, then we get an Exception
            //} catch (Exception e)
            //{
            //    Console.WriteLine("Cast failed?");
            //}

            Transform cloneT1 = (Transform)t1.Clone();             //if this cast fails, then we get an Exception
            Transform cloneDeepT1 = t1.GetDeepCopy() as Transform;  //if this cast fails, value will be null

            Console.WriteLine("cloneT1:" + cloneT1);
            Console.WriteLine("cloneDeepT1:" + cloneDeepT1);

            //lets test for a shallow copy?
            //cloneT1.X = 50;
            //Console.WriteLine("t1:" + t1);
            //Console.WriteLine("cloneT1:" + cloneT1);

            //lets test for a deep copy?
            cloneDeepT1.Z = 999;
            Console.WriteLine("t1:" + t1);
            Console.WriteLine("cloneDeepT1:" + cloneDeepT1);


        }

        #region Update Draw Loop
        private void OnTick(object sender, ElapsedEventArgs e)
        {
            Update();
            Draw();
        }

        private void Update()
        {

        }

        private void Draw()
        {

        }

        #endregion



    }
}
