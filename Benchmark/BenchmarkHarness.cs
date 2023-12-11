using Benchmark.Services;
using BenchmarkDotNet.Attributes;

namespace Benchmark;

[HtmlExporter]
public class BenchmarkHarness
{
    [Params( 5, 10, 20 , 100)]
    public int IterationCount;
    private readonly BadHttpClient _studentHttpClient = new BadHttpClient();
    private readonly GoodHttpClient _studentGoodHttpClient = new GoodHttpClient();

    /// <summary>
    /// Has Data within Include statement
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public async Task GetMessageCassandra()
    {
        for (int i = 0; i < IterationCount; i++)
        {
            await _studentHttpClient.GetMessageCassandra();
        }
    }
    [Benchmark]
    public async Task GetMessagePsg()
    {
        for (int i = 0; i < IterationCount; i++)
        {
            await _studentGoodHttpClient.GetMessagePsg();
        }
    }


}
