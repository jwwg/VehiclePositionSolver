using GeoCoordinatePortable;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclePositionSolver.Pipeline
{

    public class Pipeline
    {

        IPipelineReader reader;
        IPipelineSolver solver;
        IPipelineWriter writer;

        public Pipeline AddReader(IPipelineReader reader)
        {
            this.reader = reader;
            return this;
        }

        public Pipeline AddSolver(IPipelineSolver solver)
        {
            this.solver = solver;
            return this;
        }

        public Pipeline AddWriter(IPipelineWriter writer)
        {
            this.writer = writer;
            return this;
        }


        public void Run()
        {
            Console.WriteLine("Reading with  " + reader.ToString() + " and solving with " + solver.ToString());
            Console.WriteLine("Reading");
            Stopwatch stopWatch = new();
            stopWatch.Start();
            reader.Read();
            long readTime = stopWatch.ElapsedMilliseconds;
            Console.WriteLine("Read time : " + stopWatch.ElapsedMilliseconds);
            var inputValues = CoordinateInitialiser.Init();
            solver.Solve(inputValues, reader.PositionBuffer);
            long totalMs = stopWatch.ElapsedMilliseconds;
            stopWatch.Stop();
            Console.WriteLine("Process time : " + (totalMs - readTime));
            writer.WriteResults(inputValues, reader);
            Console.WriteLine("Total time " + totalMs);
        }

    }
}
