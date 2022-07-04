Vehicle position solver
-----------------------
Finds nearest position to a predefined set of positions, given a data file with 
2 million records. Optimised to be faster than the benchmark.

Assumptions
---------------------
Fixed record length of 30 bytes.
2,000,000 position records (but it is a command line parameter).

Building and Running
--------------------
Main project is VehiclePositionSolver, running in .NET 6. 
Run with --help for command line options.
By default, it uses the faster GridSolver.
 
Notes
----------
- minimal error checking
- no "wrapping" implemented - grid cache will fail across min/max longitude 

Benchmark
----------------------------------------------
Benchmarked by running 3 times and taking best result (Release profile)
Test Hardware : i7 @ 3.4GHz, 8 GB RAM, SSD

Benchmark application :
- read time : 969
- process time : 3694
- total time : 4663

VehiclePositionSolver (fixed size reader, unoptimized solver) :
- read time : 483
- process time : 2753
- total time : 3236

VehiclePositionSolver (fixed size reader, Grid solver, *BEFORE* read optimisation) :
- read time : 2871
- process time : 3
- total time : 2874

VehiclePositionSolver (fixed size reader, Grid solver, *AFTER* read optimisation) :
- read time : 1552
- process time : 3
- total time : 1555






 





