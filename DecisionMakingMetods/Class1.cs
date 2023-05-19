using System;

namespace Decision_Making_Metods
{

   namespace UnderCertainly
   {
     
    public abstract class Certainly
        {
          public int[,] data;
          protected  int noofProjects;
          protected  int noofAtrributes;
            public Certainly(int nProjects,int nAttributes)
            {
                noofProjects = nProjects;
                noofAtrributes = nAttributes;
                data = new int[noofProjects,noofAtrributes];
            }
         
            public abstract int[] Solve(out string answer ); 
            public void Print()
            {
                foreach (var item in data)
                {
                    Console.WriteLine(item);
                }
            }
        }
   
        public class Maximax:Certainly
        {
            public Maximax(int nprojects,int nAtter):base(nprojects,nAtter)
            {

            }
            public override int[] Solve(out string answer)
            {
                int[] arr = new int[noofProjects];
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        if (data[i, j] > arr[i])
                            arr[i] = data[i, j];
                    }
                }
                int greater=0;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] > greater)
                        greater = arr[i];
                }
                Console.WriteLine( greater);
                answer = $"optimal solution according Maximax method is {greater}";
                return arr;
                
            }

        }
        public class Maximin:Certainly
        {
            public Maximin(int nProject,int nAttr):base(nProject,nAttr)
            {

            }
            public override int[] Solve(out string ansewr)
            {
                int[] arr = new int[noofProjects];
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    arr[i] = int.MaxValue;
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        if (data[i, j] < arr[i])
                            arr[i] = data[i, j];
                    }
                }
                int greater = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] > greater)
                        greater = arr[i];
                }
                Console.WriteLine(greater);
                ansewr = $"optimal solution according Maximax method is {greater}";
                return arr;
            }
        }
        public class EquallyLikelyCriterion : Certainly
        {
            public EquallyLikelyCriterion(int nProject, int nAttr) : base(nProject, nAttr)
            {

            }
            public override int[] Solve(out string answer)
            {
                int[] arr = new int[noofProjects];
                int sum=0;
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        sum += data[i, j];
                    }
                        arr[i] = sum / data.GetLength(1);//Attributes
                        sum = 0;
                }
                int greater = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] > greater)
                        greater = arr[i];
                }
                Console.WriteLine(greater);
                answer = $"optimal solution according Equally Likely method is {greater}";
                return arr;

            }
        }
        public class MiniMax_Regret:Certainly
        {
            public MiniMax_Regret(int nprojects, int nAtter) : base(nprojects, nAtter)
            {

            }
            public override int[] Solve(out string answer)
            {
                getRegretTable();
                int[] arr = new int[noofProjects];
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        if (data[i, j] > arr[i])
                            arr[i] = data[i, j];
                    }
                }
                int greater = int.MaxValue;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] < greater)
                        greater = arr[i];
                }
                Console.WriteLine(greater);
                answer = $"optimal solution according Maximax method is {greater}";
                return arr;



            }
            private void getRegretTable()
            {
                int[] arr = new int[noofAtrributes];
                for (int i = 0; i < data.GetLength(1); i++)
                {

                    for (int j = 0; j < data.GetLength(0); j++)
                    {
                        if (data[j, i] > arr[i])
                            arr[i] = data[j, i];
                    }
                }
                //Console.WriteLine("Regret Values");
                //foreach (var item in arr)
                //{
                //    Console.WriteLine( item);
                //}
                //Console.WriteLine("Regret Table");
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        data[j, i] = arr[i] - data[j, i];
                    }
                }
                //foreach (var item in data)
                //{
                //    Console.WriteLine(item);
                //}

            }
        }
    }


   

}
