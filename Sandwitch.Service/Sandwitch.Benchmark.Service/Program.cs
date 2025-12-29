using BenchmarkDotNet.Running;
using Sandwitch.Benchmark.Service.Controllers;

BenchmarkRunner.Run<StateController>();
BenchmarkRunner.Run<FlagController>();
BenchmarkRunner.Run<WindController>();
BenchmarkRunner.Run<BeachController>();
BenchmarkRunner.Run<FinderController>();
BenchmarkRunner.Run<TownController>();