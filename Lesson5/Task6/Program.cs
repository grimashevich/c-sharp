using System;
using System.Collections.Generic;
using System.IO;

namespace Task6
{
    class WordCounter
    {
        public List<(int, string)> WordCount = new List<(int, string)>();
        public int TopWordsCount { get; set;} //Количество слов в топе, выводимых при печати объекта 

        public WordCounter()
        {
            WordCount.Clear();
            TopWordsCount = 5;
        }

        public void AddWord(string word)
        {
            word = word.ToLower();
            for (int i = 0; i < WordCount.Count; i++)
            {
                if (WordCount[i].Item2 != word) continue;
                WordCount[i] = (WordCount[i].Item1 + 1, WordCount[i].Item2);
                return;
            }
            WordCount.Add((1, word));
        }
        
        public override string ToString()
        {
            var str = "";
            var len = WordCount.Count > TopWordsCount ? WordCount.Count - TopWordsCount : 0;
            WordCount.Sort();
            for (int i = WordCount.Count - 1; i >= len; i--)
            {
                str = str.Length > 0 ? str + "\n" : str;
                str += $"{WordCount[i].Item2} ({WordCount[i].Item1})";
            }

            return str;
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            var minCharinWord = 3; // Не учитыываем слова, меньше этого значения
            var topList = new WordCounter();
            var fileName = "../../../text.txt";
            var text = File.ReadAllText(fileName);
            var wordArr = text.Split(" ");
            foreach (var word in wordArr)
            {
                if (word == "" || word.Length < minCharinWord) continue;
                topList.AddWord(word);
            }
            Console.WriteLine(topList);
        }
    }
}