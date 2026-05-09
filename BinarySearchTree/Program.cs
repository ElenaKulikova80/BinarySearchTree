using System.Diagnostics;

namespace BinarySearchTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int N = 10000;
            const int OPS = N / 10;

            Console.WriteLine($"Тестирование BST: N = {N}, операций поиска/удаления = {OPS}\n");

            // Генерация данных
            var random = new Random(30); 
            var randomKeys = Enumerable.Range(0, N).Select(_ => random.Next(1, N * 10)).ToArray();
            var sortedKeys = Enumerable.Range(1, N).ToArray();
            var searchKeys = randomKeys.Take(OPS).ToArray();
            var deleteKeys = randomKeys.Skip(OPS).Take(OPS).ToArray();

            // Дерево 1: вставка в случайном порядке
            var treeRandom = new Tree();
            var sw = Stopwatch.StartNew();
            foreach (var k in randomKeys) treeRandom.Insert(k);
            sw.Stop();
            Console.WriteLine($"[Random] Вставка {N} элементов: {sw.ElapsedMilliseconds} мс");

            sw.Restart();
            foreach (var k in searchKeys) treeRandom.Search(k);
            sw.Stop();
            Console.WriteLine($"[Random] Поиск {OPS} элементов: {sw.ElapsedMilliseconds} мс");

            sw.Restart();
            foreach (var k in deleteKeys) treeRandom.Remove(k);
            sw.Stop();
            Console.WriteLine($"[Random] Удаление {OPS} элементов: {sw.ElapsedMilliseconds} мс\n");

            // Дерево 2: вставка в возрастающем порядке
            var treeSorted = new Tree();
            sw.Restart();
            foreach (var k in sortedKeys) treeSorted.Insert(k);
            sw.Stop();
            Console.WriteLine($"[Sorted] Вставка {N} элементов: {sw.ElapsedMilliseconds} мс");

            sw.Restart();
            foreach (var k in searchKeys) treeSorted.Search(k);
            sw.Stop();
            Console.WriteLine($"[Sorted] Поиск {OPS} элементов: {sw.ElapsedMilliseconds} мс");

            sw.Restart();
            foreach (var k in deleteKeys) treeSorted.Remove(k);
            sw.Stop();
            Console.WriteLine($"[Sorted] Удаление {OPS} элементов: {sw.ElapsedMilliseconds} мс");

            Console.WriteLine("\n Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

    }
}
