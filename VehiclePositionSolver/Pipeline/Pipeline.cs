﻿using GeoCoordinatePortable;
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

        public void Run()
        {
            Console.WriteLine("Reading");
            Stopwatch stopWatch = new();
            stopWatch.Start();
            reader.Read();
            long readTime = stopWatch.ElapsedMilliseconds;
            Console.WriteLine("Read time : " + stopWatch.ElapsedMilliseconds);
            GeoCoordinate[] geoCoordinates = CoordinateInitialiser.Init();
            solver.Solve(geoCoordinates, reader.PositionBuffer);
            long totalMs = stopWatch.ElapsedMilliseconds;
            stopWatch.Stop();
            Console.WriteLine("Process time : " + (totalMs - readTime));
            foreach (var result in solver.Results)
            {
                Console.WriteLine(result.distance.ToString("F2") + " m, vehicle  " + reader.RegistrationNrAt(result.bufferIndex));
            }
            Console.WriteLine("Total time " + totalMs);
        }

    }
}