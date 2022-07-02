using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePositionLookup.Buffer;
using VehiclePositionLookup.Parser;

namespace VehiclePositionLookup.DataLoad
{
    internal class DataLoader
    {
        private readonly IPositionBuffer _positionBuffer;
        private readonly IPositionParser _parser;

        public DataLoader(IPositionBuffer positionBuffer, IPositionParser parser)
        {
            _positionBuffer = positionBuffer;
            _parser = parser;
        }

        internal long Load()
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();
            ReadFile();   
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        private void ReadFile()
        {
            string fileName = "VehiclePositions.dat";
            if (File.Exists(fileName))
            {
                var bytes = File.ReadAllBytes(fileName);
                MemoryStream stream = new(bytes);
                Parse(stream);
            }
        }

        private void Parse(MemoryStream stream)
        {
            bool reading = true;
            _positionBuffer.PreAllocate();
            _parser.PositionBuffer = _positionBuffer;
            while (reading)
            {
                reading = _parser.ParseTo(stream);
            }
            Console.WriteLine("Read " + _positionBuffer);
        }

        string ReadNullTerminated(System.IO.StreamReader rdr)
        {
            var bldr = new System.Text.StringBuilder();
            int nc;
            while ((nc = rdr.Read()) > 0)
                bldr.Append((char)nc);

            return bldr.ToString();
        }

    }
    
}
