using BenchmarkDotNet.Running;

using Sandwitch.Tier.Benchmarks.Services;

BenchmarkRunner.Run<ProvinciaService>();
BenchmarkRunner.Run<BanderaService>();
BenchmarkRunner.Run<VientoService>();
BenchmarkRunner.Run<ArenalService>();
BenchmarkRunner.Run<BuscadorService>();
BenchmarkRunner.Run<PoblacionService>();