using BenchmarkDotNet.Running;
using Sandwitch.Benchmark.Service.Controllers;

BenchmarkRunner.Run<ProvinciaController>();
BenchmarkRunner.Run<BanderaController>();
BenchmarkRunner.Run<VientoController>();
BenchmarkRunner.Run<ArenalController>();
BenchmarkRunner.Run<BuscadorController>();
BenchmarkRunner.Run<PoblacionController>();