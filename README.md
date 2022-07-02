Vehicle position solver
-----------------------
Finds nearest position to a predefined set of positions, given a data file with 
2 million records. Optimised to be faster than the benchmark.

Assumptions
---------------------
- the default parser assumes a fixed record length of 30 bytes

Building and Running
--------------------
Main project is VehiclePositionSolver, running in .NET 6. 
 
Notes
----------


Benchmark
----------------------------------------------
Benchmarked by running 3 times and taking best result (Release profile)
Test Hardware : i7 @ 3.4GHz, 8 GB RAM, SSD

Benchmark application :
- read time : 969
- process time : 3694
- total time : 4663

VehiclePositionSolver (fixed size reader, unoptimized solver) :
- read time : 390
- process time : 2605
- total time : 2995






 





