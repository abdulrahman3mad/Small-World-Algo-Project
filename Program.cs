using System;
using System.Collections.Generic;
using System.IO;

namespace SmallWorld
{
    class Program
    {
        public static IDictionary<string, List<string>> AdjacencyList = new Dictionary<string, List<string>>(); // O(V) space
        public static IDictionary<string, int> RelationStrengthList;  // O(E) space
        public static IDictionary<string, int> distances; // O(V) space
        public static HashSet<string> VisitedNodes;
        public static Queue<string> BFSActorsQueue;
        public static Queue<int> CurrentDistances;
        public static List<Stack<string>> AllPathesFromStoD;
        public static int StrongestRelation;
        public static string[] StrongestPath;
        public static int QueryNum;
        public static int DegreeOfSeperation;
        public static int[] DegreeFrequencies;

        static void Main(string[] args)
        {
            RunAllTestCases();
        }

        public static void RunAllTestCases()
        {
            RunSampleTestCases();
            RunSmallTestCases();
            RunMediumTestCases();
            RunLargeTestCases();
            RunExtremeTestCases();
        }

        private static void RunSampleTestCases()
        {
            List<KeyValuePair<string, string>> Queries = new List<KeyValuePair<string, string>>();
            Console.WriteLine("************Sample*************");
            ConstructAdjacencyList(@"SampleTests\movies1.txt");
            Queries = ReadQueriesFile(@"SampleTests\queries1.txt");
            RunAllQueries(Queries);
            Console.WriteLine("-------Sample is done...");
            Console.WriteLine("Press Any Key To Continue...");
            Console.ReadKey();
        }    
        public static void RunSmallTestCases()
        {
            List<KeyValuePair<string, string>> Queries = new List<KeyValuePair<string, string>>();

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            Console.WriteLine("************ Small *************");
            Console.WriteLine("----------- Case 1 ----------");
            ConstructAdjacencyList(@"SmallTests\Case 1\Movies193.txt");
            Queries = ReadQueriesFile(@"SmallTests\Case 1\queries110.txt");
            RunAllQueries(Queries);
            Console.WriteLine("----- Small Case 1 is done --------");
            watch.Stop();
            Console.WriteLine($"Execution time: {watch.ElapsedMilliseconds / 1000} Seconds");
            Console.WriteLine("Press Any Key To Continue...");
            Console.ReadKey();

            Console.WriteLine("----------- Case 2 ----------");
            ConstructAdjacencyList(@"SmallTests\Case 2\Movies187.txt");
            Queries = ReadQueriesFile(@"SmallTests\Case 2\queries50.txt");
            RunAllQueries(Queries);
            Console.WriteLine("----- Small Case 2 is done --------");
            watch.Stop();
            Console.WriteLine($"Execution time: {watch.ElapsedMilliseconds / 1000} Seconds");
            Console.WriteLine("Press Any Key To Continue...");
            Console.ReadKey();

        }
        private static void RunMediumTestCases()
        {
            List<KeyValuePair<string, string>> Queries = new List<KeyValuePair<string, string>>();
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            Console.WriteLine("*************Medium**************");
            Console.WriteLine("----------Medium Case 1-----------");
            ConstructAdjacencyList(@"MediumTests\Case 1\Movies967.txt");

            Console.WriteLine("----------Case 1--Queries26---------");
            Queries = ReadQueriesFile(@"MediumTests\Case 1\queries85.txt");
            RunAllQueries(Queries);

            Console.WriteLine("----------Case 1--Queries600--------");
            Queries = ReadQueriesFile(@"MediumTests\Case 1\queries4000.txt");
            RunAllQueries(Queries);
            Console.WriteLine("---------Medium Case 1 is done. Congrats!!!!!");
            watch.Stop();
            Console.WriteLine($"Execution time: {watch.ElapsedMilliseconds / 1000} Seconds");
            Console.WriteLine("Press Any Key To Continue...");
            Console.ReadKey();

            watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            Console.WriteLine("----------------Medium Case 2--------------");
            Console.WriteLine("----------Case 2-- File 1---------");
            ConstructAdjacencyList(@"MediumTests\Case 2\Movies4736.txt");
            Queries = ReadQueriesFile(@"MediumTests\Case 2\queries110.txt");
            RunAllQueries(Queries);
            
            Console.WriteLine("----------Case 2--File 2--------");
            Queries = ReadQueriesFile(@"MediumTests\Case 2\queries2000.txt");
            RunAllQueries(Queries);
            Console.WriteLine("----- ---Medium Case 2 is done. Congrats!!!!!");
            watch.Stop();
            Console.WriteLine($"Execution time: {watch.ElapsedMilliseconds / 1000} Seconds");
            Console.WriteLine("Press Any Key To Continue...");
            Console.ReadKey();
        }
        private static void RunLargeTestCases()
        {
            List<KeyValuePair<string, string>> Queries = new List<KeyValuePair<string, string>>();
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            Console.WriteLine("**************Large**************");
            Console.WriteLine("----------------Reading Files:-------------");

            ConstructAdjacencyList(@"LargeTests\Movies14129.txt");

            Console.WriteLine("----------Case 1- Queries26---------");
            Queries = ReadQueriesFile(@"LargeTests\queries26.txt");
            RunAllQueries(Queries);            

            Console.WriteLine("----------Case 1--Queries600--------");
            Queries = ReadQueriesFile(@"LargeTests\queries600.txt");
            RunAllQueries(Queries);

            watch.Stop();
            Console.WriteLine($"Execution time: {watch.ElapsedMilliseconds / 1000} Seconds");
            Console.ReadKey();
        }
        private static void RunExtremeTestCases()
        {
            List<KeyValuePair<string, string>> Queries = new List<KeyValuePair<string, string>>();
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            Console.WriteLine("**************Extreme**************");
            Console.WriteLine("-----------Reading Files:-------------");
            ConstructAdjacencyList(@"ExtremeTests\Movies.txt");
            Console.WriteLine("---------Reading File is done------");
            Console.WriteLine("----------Case 1- Queries---------");
            Queries = ReadQueriesFile(@"ExtremeTests\queries.txt");
            RunAllQueries(Queries);
            Console.WriteLine("----------Case 1- Queries2---------");
            Queries = ReadQueriesFile(@"ExtremeTests\queries2.txt");
            RunAllQueries(Queries);
            watch.Stop();
            Console.WriteLine($"Execution time: {watch.ElapsedMilliseconds / 1000} Seconds");
        }

        public static List<KeyValuePair<string, string>> ReadQueriesFile(string FileName)
        {
            string filePath = @"C:\Users\abdul\source\repos\SmallWorldProject\SmallWorldProject\" + FileName;
            string[] QueriesLines = File.ReadAllLines(filePath);

            List<KeyValuePair<string, string>> Queries = new List<KeyValuePair<string, string>>();
            for (int i = 0; i < QueriesLines.Length; i++)
            {
                string[] QueryLine = QueriesLines[i].Split('/');
                Queries.Add(new KeyValuePair<string, string>(QueryLine[0], QueryLine[1]));
            }

            return Queries;
        }
        public static void ConstructAdjacencyList(string FileName)
        {
            string filePath = @"C:\Users\abdul\source\repos\SmallWorldProject\SmallWorldProject\" + FileName;
            AdjacencyList = new Dictionary<string, List<string>>();
            RelationStrengthList = new Dictionary<string, int>(1000000);

            using (StreamReader reader = new StreamReader(filePath))
            {
                string movieLine = "";
                while ((movieLine = reader.ReadLine()) != null)
                {
                    string[] movieLineValues = movieLine.Split('/');
                    for (int i = 1; i < movieLineValues.Length; i++) // O(V) --> v: #actors
                    {
                        if (!(AdjacencyList.Keys.Contains(movieLineValues[i])))
                            AdjacencyList.Add(movieLineValues[i], new List<string>());

                        for (int x = 1; x < movieLineValues.Length; x++) // O(V) --> v: #actors
                        {
                            if (x != i)
                            {
                                if (!AdjacencyList[movieLineValues[i]].Contains(movieLineValues[x]))
                                {
                                    AdjacencyList[movieLineValues[i]].Add(movieLineValues[x]);
                                    RelationStrengthList[movieLineValues[i] + movieLineValues[x]] = 1;
                                }
                                else
                                    RelationStrengthList[movieLineValues[i] + movieLineValues[x]]++;
                            }


                        }
                    }
                }
            }
        }
        public static void RunAllQueries(List<KeyValuePair<string, string>> Queries)
        {
            QueryNum = 1;
            foreach (KeyValuePair<string, string> Query in Queries)
            {
                DegreeOfSeperation = CalcDegreeByBFS(Query);
                FindAllShortestPathsByDFS(Query.Key, Query.Value);
                CalculateRelationStrength();
                //CalcDistributionOfDegree(Query); // Bonus 1
                DisplayFinalResult(Query);
                QueryNum++;
            }
        }

        // O(V+E) Overall
        static int CalcDegreeByBFS(KeyValuePair<string, string> Query)
        {
            //-- BFS Variables & Setting---
            distances = new Dictionary<string, int>(AdjacencyList.Count);
            VisitedNodes = new HashSet<string>(AdjacencyList.Count);
            BFSActorsQueue = new Queue<string>();
            CurrentDistances = new Queue<int>();
            bool keep = true;
            //----

            distances.Add(new KeyValuePair<string, int>(Query.Key, 0));
            BFSActorsQueue.Enqueue(Query.Key);
            CurrentDistances.Enqueue(0);

            // O(V + E) overall 
            while (BFSActorsQueue.Count > 0 && keep == true) // O(V) --> v=only non duplicate actors values 
            {
                string actor = BFSActorsQueue.Dequeue();
                CurrentDistances.Dequeue();
                VisitedNodes.Add(actor);
                foreach (string AdjacentActor in AdjacencyList[actor]) // O(Deg(U)) each time 
                {
                    if (!VisitedNodes.Contains(AdjacentActor))
                    {
                        BFSActorsQueue.Enqueue(AdjacentActor);
                        distances[AdjacentActor] = distances[actor] + 1;
                        VisitedNodes.Add(AdjacentActor);
                        CurrentDistances.Enqueue(distances[AdjacentActor]);

                    }

                    if (AdjacentActor == Query.Value)
                    {
                        keep = false;
                        break;
                    }
                }
            }
            return distances[Query.Value];
        }

        static void FindAllShortestPathsByDFS(string source, string destination)
        {
            AllPathesFromStoD = new List<Stack<string>>();
            Stack<string> path = new Stack<string>(distances[destination]);
            if (DegreeOfSeperation == 1)
            {
                path.Push(destination);
                path.Push(source);
                AllPathesFromStoD.Add(path);
            }
            else
            {
                FindAllDistancesByBFS(source, destination, true);
                DFS(source, destination, destination, path);
            }
        }

        static void FindAllDistancesByBFS(string source, string destination, bool isSpecificDestination)
        {

            // O(V + E) overall 
            while (BFSActorsQueue.Count > 0) // O(V) --> v=only non duplicate actors values 
            {
                CurrentDistances.Dequeue();
                string actor = BFSActorsQueue.Dequeue();
                VisitedNodes.Add(actor);
                foreach (string AdjacentActor in AdjacencyList[actor]) // O(Deg(U)) each time 
                {
                    if (!VisitedNodes.Contains(AdjacentActor))
                    {
                        distances[AdjacentActor] = distances[actor] + 1;
                        CurrentDistances.Enqueue(distances[AdjacentActor]);
                        BFSActorsQueue.Enqueue(AdjacentActor);
                        VisitedNodes.Add(AdjacentActor);
                    }

                }
                if (isSpecificDestination && distances[actor] == (DegreeOfSeperation - 1) && !CurrentDistances.Contains(distances[actor])) 
                    break;
            }
        }
        static Stack<string> DFS(string source, string destination, string end, Stack<string> path)
        {
            if (destination == end)
                path.Push(end);

            if (destination == source)
            {
                AllPathesFromStoD.Add(new Stack<string>(path));
                path.Pop();
                return path;
            }

            List<string> DestinationAdjacencyList = AdjacencyList[destination];
            if (DestinationAdjacencyList.Count <= 0)
                return path;


            foreach (string AdjacentItem in DestinationAdjacencyList)
            {
                if (distances.Keys.Contains(AdjacentItem))
                {
                    if (distances[AdjacentItem] == (distances[destination] - 1))
                    {
                        path.Push(AdjacentItem);
                        path = DFS(source, AdjacentItem, end, path);
                    }
                }
            }
            path.Pop();
            return path;
        }

        static int CalculateRelationStrength()
        {
            int PathRelationStrength = 0;
            StrongestRelation = 0;

            foreach (Stack<string> path in AllPathesFromStoD)
            {

                Stack<string> TempPath = new Stack<string>(path);
                string ParentNode = "";
                PathRelationStrength = 0;

                while (TempPath.Count > 1)
                {
                    ParentNode = TempPath.Pop();
                    PathRelationStrength += RelationStrengthList[ParentNode + TempPath.Peek()];
                }

                if (PathRelationStrength > StrongestRelation)
                {
                    StrongestRelation = PathRelationStrength;
                    // Bonus 2
                    StrongestPath = new string[path.Count];
                    path.CopyTo(StrongestPath, 0);
                    // ---
                }
            }

            return StrongestRelation;
        }

        static void CalcDistributionOfDegree(KeyValuePair<string, string> Query)
        {
            
            FindAllDistancesByBFS(Query.Key, Query.Value, false);
            DegreeFrequencies = new int[12];
            foreach (int distance in distances.Values) { 
                if (distance >= 11)
                    DegreeFrequencies[11]++;
                else if (distance != distances[Query.Key])
                    DegreeFrequencies[distance]++;
            }
        }

        public static void DisplayFinalResult(KeyValuePair<string, string> Query)
        {
            Console.WriteLine($"---------Q:{QueryNum}" + Query.Key + "-->" + Query.Value + "---------");
            Console.WriteLine("deg: " + DegreeOfSeperation);
            Console.WriteLine("Relation Strength: " + StrongestRelation);

            DisplayShortestPath();
            //DisplayStrongestPath();
            //DisplayDistributionOfDegree();
        }
        private static void DisplayShortestPath()
        {
            Console.Write("Shortest Path: ");
            while (AllPathesFromStoD[0].Count > 1)
                Console.Write((AllPathesFromStoD[0].Pop()) + "->");
            Console.WriteLine(AllPathesFromStoD[0].Pop());
        }

        private static void DisplayStrongestPath()
        {
            Console.Write("Strongest Path: ");
            for (int i = 0; i < StrongestPath.Length - 1; i++)
                Console.Write(StrongestPath[i] + "->");
            Console.WriteLine(StrongestPath[StrongestPath.Length - 1]);
        }

        private static void DisplayDistributionOfDegree()
        {
            Console.WriteLine("Deg. of Separation.    Frequency");
            Console.WriteLine("---------------------------------");
            for (int i = 1; i < DegreeFrequencies.Length; i++)
            {
                if (i > 11)
                    Console.Write("   " + 11);
                else
                    Console.Write("   " + i);

                Console.Write("                     " + DegreeFrequencies[i]);
                Console.WriteLine();
            }
        }
    }
}
