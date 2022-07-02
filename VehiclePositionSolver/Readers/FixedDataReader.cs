using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePositionSolver.Buffer;
using VehiclePositionSolver.Parser;
using VehiclePositionSolver.Pipeline;

namespace VehiclePositionSolver.Readers
{
    /// <summary>
    /// This reader assumes the size of the file is known beforehand, and that each record is 30 bytes long
    /// </summary>
    internal class FixedDataReader : IPipelineReader
    {

        private readonly IPositionBuffer _positionBuffer;
        private readonly IPositionParser _parser;
        private readonly string fileName;
        private MemoryStream stream;

        public IPositionBuffer PositionBuffer => _positionBuffer;

        public FixedDataReader(long bufferSize = 2000000, string fileName = "VehiclePositions.dat")
        {
            _positionBuffer = new PositionBuffer(bufferSize);
            _parser = new PositionParser();
            this.fileName = fileName;
        }

        public void Read()
        {
            if (File.Exists(fileName))
            {
                var bytes = File.ReadAllBytes(fileName);
                stream = new(bytes);
                Parse(stream);
            }
            else throw new Exception("Datafile " + fileName + " not found. You may need to copy VehiclePositions.dat to same folder as the binary");
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

        string ReadNullTerminated(StreamReader rdr)
        {
            var bldr = new StringBuilder();
            int nc;
            while ((nc = rdr.Read()) > 0)
                bldr.Append((char)nc);

            return bldr.ToString();
        }

        public string RegistrationNrAt(int bufferIndex)
        {
            stream.Position = bufferIndex * 30 + 4;
            StreamReader reader = new StreamReader(stream);
            return ReadNullTerminated(reader);
        }
    }

}
