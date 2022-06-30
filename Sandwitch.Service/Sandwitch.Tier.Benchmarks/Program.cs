using BenchmarkDotNet.Running;

using Sandwitch.Tier.Benchmarks.Services;

BenchmarkRunner.Run<ProvinciaService>();
BenchmarkRunner.Run<BanderaService>();
BenchmarkRunner.Run<ArenalService>();
BenchmarkRunner.Run<PoblacionService>();