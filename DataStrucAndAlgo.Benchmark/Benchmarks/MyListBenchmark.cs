using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using DataStrucAndAlgo.Implementations;

namespace DataStrucAndAlgo.Benchmark.Benchmarks
{
    [Orderer(SummaryOrderPolicy.Method, MethodOrderPolicy.Declared)]
    [RPlotExporter]
    [CsvMeasurementsExporter]
    public class MyListBenchmark
    {
        [Params(10, 100, 1000, 10000, 100000)]
        public int ElementCount { get; set; }

        [Benchmark]
        public void MyArrayList_AddToStart()
        {
            var list = new MyArrayList<int>();
            for (int i = 0; i < ElementCount; i++)
            {
                list.Add(i, 0);
            }
        }

        [Benchmark]
        public void MyLinkedList_AddToStart()
        {
            var list = new MyLinkedList<int>();
            for (int i = 0; i < ElementCount; i++)
            {
                list.Add(i, 0);
            }
        }

        [Benchmark]
        public void MyArrayList_AddToEnd()
        {
            var list = new MyArrayList<int>();
            for (int i = 0; i < ElementCount; i++)
            {
                list.Add(i);
            }
        }

        [Benchmark]
        public void MyLinkedList_AddToEnd()
        {
            var list = new MyLinkedList<int>();
            for (int i = 0; i < ElementCount; i++)
            {
                list.Add(i);
            }
        }
    }
}