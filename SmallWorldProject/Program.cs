using System;
using System.Collections.Generic;
using System.IO;

namespace SmallWorld
{
    class Program
    {
        public static IDictionary<string, IDictionary<string, List<string>>> AdjacencyList; // O(V) space
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
        #region TestCases
        private static void RunSampleTestCases()
        {
            List<KeyValuePair<string, string>> Queries = new List<KeyValuePair<string, string>>();
            Console.WriteLine("************Sample*************");
            ConstructAdjacencyList(@".\SampleTests\movies1.txt");
            Queries = ReadQueriesFile(@"SampleTests\queries1.txt");
            RunAllQueries(Queries);
            Console.WriteLine("-------Sample is done...");
            Console.WriteLine("Press Any Key To Continue...");
            Console.ReadKey();
        }    
        public static void RunSmallTestCases()
        {
            List<KeyValuePair<string, string>> Queries = new List<KeyValuePair<string, string>>();
            Console.WriteLine("************ Small *************");
            Console.WriteLine("----------- Case 1 ----------");
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            ConstructAdjacencyList(@"SmallTests\Case 1\Movies193.txt");
            Queries = ReadQueriesFile(@"SmallTests\Case 1\queries110.txt");
            RunAllQueries(Queries);
            Console.WriteLine("----- Small Case 1 is done --------");
            watch.Stop();
            Console.WriteLine($"Execution time: {watch.ElapsedMilliseconds} MilliSeconds");
            Console.WriteLine($"Execution time: {watch.ElapsedMilliseconds / 1000} Seconds");
            Console.WriteLine($"Execution time: {watch.ElapsedMilliseconds / 1000 / 60} Minutes");
            Console.WriteLine("Press Any Key To Continue...");
            Console.ReadKey();

            Console.WriteLine("----------- Case 2 ----------");
            watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            ConstructAdjacencyList(@"SmallTests\Case 2\Movies187.txt");
            Queries = ReadQueriesFile(@"SmallTests\Case 2\queries50.txt");
            RunAllQueries(Queries);
            Console.WriteLine("----- Small Case 2 is done --------");
            watch.Stop();
            Console.WriteLine($"Execution time: {watch.ElapsedMilliseconds} MilliSeconds");
            Console.WriteLine($"Execution time: {watch.ElapsedMilliseconds / 1000} Seconds");
            Console.WriteLine($"Execution time: {watch.ElapsedMilliseconds / 1000 / 60} Minutes");
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
            watch.Stop();
            Console.WriteLine($"Execution time: {watch.ElapsedMilliseconds} MilliSeconds");
            Console.WriteLine($"Execution time: {watch.ElapsedMilliseconds / 1000} Seconds");
            Console.WriteLine($"Execution time: {watch.ElapsedMilliseconds / 1000 / 60} Minutes");
            Console.WriteLine("Press Any Key To Continue...");
            Console.ReadKey();

            Console.WriteLine("----------Case 1--Queries600--------");
            watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            ConstructAdjacencyList(@"MediumTests\Case 1\Movies967.txt");
            Queries = ReadQueriesFile(@"MediumTests\Case 1\queries4000.txt");
            RunAllQueries(Queries);
            Console.WriteLine("---------Medium Case 1 is done. Congrats!!!!!");
            watch.Stop();
            Console.WriteLine($"Execution time: {watch.ElapsedMilliseconds} MilliSeconds");
            Console.WriteLine($"Execution time: {watch.ElapsedMilliseconds / 1000} Seconds");
            Console.WriteLine($"Execution time: {watch.ElapsedMilliseconds / 1000 / 60} Minutes");
            Console.WriteLine("Press Any Key To Continue...");
            Console.ReadKey();
            
            Console.WriteLine("----------------Medium Case 2--------------");
            Console.WriteLine("----------Case 2-- File 1---------");
            watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            ConstructAdjacencyList(@"MediumTests\Case 2\Movies4736.txt");
            Queries = ReadQueriesFile(@"MediumTests\Case 2\queries110.txt");
            RunAllQueries(Queries);
            watch.Stop();
            Console.WriteLine($"Execution time: {watch.ElapsedMilliseconds} MilliSeconds");
            Console.WriteLine($"Execution time: {watch.ElapsedMilliseconds / 1000} Seconds");
            Console.WriteLine($"Execution time: {watch.ElapsedMilliseconds / 1000 / 60} Minutes");
            Console.WriteLine("Press Any Key To Continue...");
            Console.ReadKey();
            

            Console.WriteLine("----------Case 2--File 2--------");
            watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            ConstructAdjacencyList(@"MediumTests\Case 2\Movies4736.txt");
            Queries = ReadQueriesFile(@"MediumTests\Case 2\queries2000.txt");
            RunAllQueries(Queries);
            Console.WriteLine("----- ---Medium Case 2 is done. Congrats!!!!!");
            watch.Stop();
            Console.WriteLine($"Execution time: {watch.ElapsedMilliseconds} MilliSeconds");
            Console.WriteLine($"Execution time: {watch.ElapsedMilliseconds / 1000} Seconds");
            Console.WriteLine($"Execution time: {watch.ElapsedMilliseconds / 1000 / 60} Minutes");
            Console.WriteLine("Press Any Key To Continue...");
            Console.ReadKey();
        }
        private static void RunLargeTestCases()
        {
            List<KeyValuePair<string, string>> Queries = new List<KeyValuePair<string, string>>();
            Console.WriteLine("**************Large**************");
            
            Console.WriteLine("----------Case 1- Queries26---------");
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            ConstructAdjacencyList(@"LargeTests\Movies14129.txt");
            Queries = ReadQueriesFile(@"LargeTests\queries26.txt");
            RunAllQueries(Queries);
            watch.Stop();
            Console.WriteLine($"Execution time: {watch.ElapsedMilliseconds} MilliSeconds");
            Console.WriteLine($"Execution time: {watch.ElapsedMilliseconds / 1000} Seconds");
            Console.WriteLine($"Execution time: {watch.ElapsedMilliseconds / 1000 / 60} Minutes");
            Console.ReadKey();
            

            Console.WriteLine("----------Case 1--Queries600--------");
            watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            ConstructAdjacencyList(@"LargeTests\Movies14129.txt");
            Queries = ReadQueriesFile(@"LargeTests\queries600.txt");
            RunAllQueries(Queries);
            watch.Stop();
            Console.WriteLine($"Execution time: {watch.ElapsedMilliseconds} MilliSeconds");
            Console.WriteLine($"Execution time: {watch.ElapsedMilliseconds / 1000} Seconds");
            Console.WriteLine($"Execution time: {watch.ElapsedMilliseconds / 1000 / 60} Minutes");
            Console.ReadKey();
        }
        private static void RunExtremeTestCases()
        {
            List<KeyValuePair<string, string>> Queries = new List<KeyValuePair<string, string>>();
            
            Console.WriteLine("**************Extreme**************");
            
            Console.WriteLine("----------Case 1- Queries---------");
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            ConstructAdjacencyList(@"ExtremeTests\Movies.txt");
            Queries = ReadQueriesFile(@"ExtremeTests\queries.txt");
            RunAllQueries(Queries);
            watch.Stop();
            Console.WriteLine($"Execution time: {watch.ElapsedMilliseconds} MilliSeconds");
            Console.WriteLine($"Execution time: {watch.ElapsedMilliseconds / 1000} Seconds");
            Console.WriteLine($"Execution time: {watch.ElapsedMilliseconds / 1000 / 60} Minutes");

            GC.Collect();

            Console.WriteLine("----------Case 1- Queries2---------");
            watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            ConstructAdjacencyList(@"ExtremeTests\Movies.txt");
            Queries = ReadQueriesFile(@"ExtremeTests\queries2.txt");
            RunAllQueries(Queries);
            watch.Stop();
            Console.WriteLine($"Execution time: {watch.ElapsedMilliseconds} MilliSeconds");
            Console.WriteLine($"Execution time: {watch.ElapsedMilliseconds / 1000} Seconds");
            Console.WriteLine($"Execution time: {watch.ElapsedMilliseconds / 1000 / 60} Minutes");
        }
        #endregion

        #region Files Read & Initilization Data structures
        public static List<KeyValuePair<string, string>> ReadQueriesFile(string FileName)
        {
            string filePath = @"D:\SmallWorldProject\SmallWorldProject\" + FileName;
            string[] QueriesLines = File.ReadAllLines(filePath);

            List<KeyValuePair<string, string>> Queries = new List<KeyValuePair<string, string>>();
            for (int i = 0; i < QueriesLines.Length; i++)
            {
                string[] QueryLine = QueriesLines[i].Split('/');
                Queries.Add(new KeyValuePair<string, string>(QueryLine[0], QueryLine[1]));
            }

            return Queries;
        }
        public static void ConstructAdjacencyList(string FileName)  // O(n*V^2)
        {
            string filePath = @"D:\SmallWorldProject\SmallWorldProject\" + FileName;
            IDictionary<string, List<string>> Actors = new Dictionary<string, List<string>>();
            AdjacencyList = new Dictionary<string, IDictionary<string, List<string>>>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string movieLine = "";
                while ((movieLine = reader.ReadLine()) != null) // 0(n) --> n: #movies
                {
                    string[] movieLineValues = movieLine.Split('/');

                    for (int i = 1; i < movieLineValues.Length; i++) // O(V) --> v: #actors
                    {
                        string Actor = movieLineValues[i];

                        if (!(AdjacencyList.Keys.Contains(Actor))) // 0(1)
                            AdjacencyList.Add(Actor, new Dictionary<string, List<string>>());

                        for (int x = 1; x < movieLineValues.Length; x++) // O(V) --> v: #actors
                        {
                            if (x != i)
                            {
                                string AdjacentActor = movieLineValues[x];
                                if (!AdjacencyList[Actor].Keys.Contains(AdjacentActor)) // 0(1)
                                    AdjacencyList[Actor].Add(AdjacentActor, new List<string>());

                                AdjacencyList[Actor][AdjacentActor].Add(movieLineValues[0]);
                            }
                        }        
                    }
                }
            }
        }
        #endregion
        public static void RunAllQueries(List<KeyValuePair<string, string>> Queries)
        {
            QueryNum = 1;
            bool isOptimized = true;
            foreach (KeyValuePair<string, string> Query in Queries)
            {
                DegreeOfSeperation = CalcDegreeByBFS(Query, isOptimized);
                FindAllShortestPathsByDFS(Query.Key, Query.Value);
                CalculateRelationStrength();
                CalcDistributionOfDegree(Query); // Bonus 1
                DisplayFinalResult(Query);
                QueryNum++;
            }
        }
        static int CalcDegreeByBFS(KeyValuePair<string, string> Query, bool IsOptimized)
        {
            //-- BFS Variables & Setting---
            distances = new Dictionary<string, int>();
            VisitedNodes = new HashSet<string>();
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
                foreach (string AdjacentActor in AdjacencyList[actor].Keys) // O(Deg(U)) each time 
                {
                    if (!VisitedNodes.Contains(AdjacentActor))
                    {
                        BFSActorsQueue.Enqueue(AdjacentActor);
                        distances[AdjacentActor] = distances[actor] + 1;
                        VisitedNodes.Add(AdjacentActor);
                        CurrentDistances.Enqueue(distances[AdjacentActor]);

                    }
                    
                    if (IsOptimized && (AdjacentActor == Query.Value))
                    {
                        keep = false;
                        break;
                    }
                }
            }
            return distances[Query.Value];
        }
        static void FindAllShortestPathsByDFS(string source, string destination) // 0(V+E) + O(V^2)
        { 
            AllPathesFromStoD = new List<Stack<string>>();
            Stack<string> path = new Stack<string>();
            if (DegreeOfSeperation == 1)
            {
                path.Push(destination);
                path.Push(source);
                AllPathesFromStoD.Add(path);
            }
            else
            {
                FindAllDistancesByBFS(source, destination, true); // 0(V+E)
                DFS(source, destination, destination, path);  // O(V^2)
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
                foreach (string AdjacentActor in AdjacencyList[actor].Keys) // O(Deg(U)) each time 
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
        static Stack<string> DFS(string source, string destination, string end, Stack<string> path) // O(V^2)
        {
            if (destination == end)
                path.Push(end);

            if (destination == source) // --> BASE CASE
            {
                AllPathesFromStoD.Add(new Stack<string>(path)); // O(V)
                path.Pop();
                return path;
            }

            ICollection<string> DestinationAdjacencyList = AdjacencyList[destination].Keys;
            if (DestinationAdjacencyList.Count <= 0)
                return path;

            foreach (string AdjacentItem in DestinationAdjacencyList) // O(V)
            {
                if (distances.Keys.Contains(AdjacentItem))
                {
                    if (distances[AdjacentItem] == (distances[destination] - 1))
                    {
                        path.Push(AdjacentItem);
                        // O(V) --> decrease by 1 each time & in case between it and the destination 
                        path = DFS(source, AdjacentItem, end, path);
                    }
                }
            }
            path.Pop();
            return path;
        }
        static int CalculateRelationStrength() // O(V^2*deg(source))
        {
            int PathRelationStrength = 0; // O(1)
            StrongestRelation = 0; // O(1)

            foreach (Stack<string> path in AllPathesFromStoD) // O(V*deg(Source))
            {
                Stack<string> TempPath = new Stack<string>(path);  // O(V)
                string ParentNode = ""; // O(1)
                PathRelationStrength = 0; // O(1)

                while (TempPath.Count > 1) // O(V)
                {
                    ParentNode = TempPath.Pop(); // O(1)
                    PathRelationStrength += AdjacencyList[ParentNode][TempPath.Peek()].Count; // O(1)
                }

                if (PathRelationStrength > StrongestRelation)
                {
                    StrongestRelation = PathRelationStrength; 
                    StrongestPath = new string[path.Count];
                    path.CopyTo(StrongestPath, 0);
                    
                }
            }
            return StrongestRelation;
        }
        static void CalcDistributionOfDegree(KeyValuePair<string, string> Query) // Θ(E+2V)
        {
            
            FindAllDistancesByBFS(Query.Key, Query.Value, false); // Θ(V+E)
            DegreeFrequencies = new int[12]; 
            foreach (int distance in distances.Values){  // Θ(V)
                if (distance >= 11)
                    DegreeFrequencies[11]++;
                else if (distance != distances[Query.Key])
                    DegreeFrequencies[distance]++;
            }
        }

        #region Display Results
        public static void DisplayFinalResult(KeyValuePair<string, string> Query)
        {
            Console.WriteLine($"---------Q:{QueryNum}" + Query.Key + "-->" + Query.Value + "---------");
            Console.WriteLine("deg: " + DegreeOfSeperation);
            Console.WriteLine("Relation Strength: " + StrongestRelation);

            DisplayShortestPath();
            DisplayStrongestPath();
            DisplayDistributionOfDegree();
        }
        private static void DisplayShortestPath()
        {
            Stack<string> path = new Stack<string>(AllPathesFromStoD[0]);
            Console.Write("Shortest Path: ");
            while (path.Count > 2)
                Console.Write(AdjacencyList[path.Pop()][path.Peek()][0] + "-->");
            
            Console.Write(AdjacencyList[path.Pop()][path.Peek()][0]);
            Console.WriteLine();
        }
        private static void DisplayStrongestPath()
        {
            Console.Write("Strongest Path: ");
            for (int i = (StrongestPath.Length-1); i > 0; i--)
                Console.Write(StrongestPath[i] + "->");
            Console.WriteLine(StrongestPath[0]);
        }
        private static void DisplayDistributionOfDegree()
        {
            Console.WriteLine("Deg. of Separation.    Frequency");
            Console.WriteLine("---------------------------------");
            for (int i = 1; i < DegreeFrequencies.Length; i++) // O(V): (Length = number of distinct distances = number of vertices(upper bound)) when all vertices distances are distinct
            {
                if (i > 11)
                    Console.Write("   " + 11);
                else
                    Console.Write("   " + i);

                Console.Write("                     " + DegreeFrequencies[i]);
                Console.WriteLine();
            }
        }
        #endregion

    }
}
