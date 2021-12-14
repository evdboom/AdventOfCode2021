﻿using AdventOfCode2021.Services;
using System;
using System.Threading.Tasks;

namespace AdventOfCode2021.Tests
{
    public class TestData : IFileImporter
    {
        public Task<string[]> GetInputAsync(int dayNumber)
        {
            var result = dayNumber switch
            {
                1 => Day01(),
                2 => Day02(),
                3 => Day03(),
                4 => Day04(),
                5 => Day05(),
                6 => Day06(),
                7 => Day07(),
                8 => Day08(),
                9 => Day09(),
                10 => Day10(),
                11 => Day11(),
                12 => Day12(),
                13 => Day13(),
                14 => Day14(),
                15 => Day15(),
                16 => Day16(),
                17 => Day17(),
                18 => Day18(),
                19 => Day19(),
                20 => Day20(),
                21 => Day21(),
                22 => Day22(),
                23 => Day23(),
                24 => Day24(),
                25 => Day25(),
                _ => throw new ArgumentException(nameof(dayNumber))
            };

            return Task.FromResult(result);
        }

        private string[] Day01()
        {
            return new[]
            {
                "199",
                "200",
                "208",
                "210",
                "200",
                "207",
                "240",
                "269",
                "260",
                "263"
            };
        }

        private string[] Day02()
        {
            return new[]
            {
                "forward 5",
                "down 5",
                "forward 8",
                "up 3",
                "down 8",
                "forward 2"
            };
        }

        private string[] Day03()
        {
            return new[]
            {
                "00100",
                "11110",
                "10110",
                "10111",
                "10101",
                "01111",
                "00111",
                "11100",
                "10000",
                "11001",
                "00010",
                "01010"
            };
        }

        private string[] Day04()
        {
            return new[]
            {
                "7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1",
                "",
                "22 13 17 11  0",
                " 8  2 23  4 24",
                "21  9 14 16  7",
                " 6 10  3 18  5",
                " 1 12 20 15 19",
                "",
                " 3 15  0  2 22",
                " 9 18 13 17  5",
                "19  8  7 25 23",
                "20 11 10 24  4",
                "14 21 16 12  6",
                "",
                "14 21 17 24  4",
                "10 16 15  9 19",
                "18  8 23 26 20",
                "22 11 13  6  5",
                "2  0 12  3  7"
            };
        }

        private string[] Day05()
        {
            return new[]
            {
                "0,9 -> 5,9",
                "8,0 -> 0,8",
                "9,4 -> 3,4",
                "2,2 -> 2,1",
                "7,0 -> 7,4",
                "6,4 -> 2,0",
                "0,9 -> 2,9",
                "3,4 -> 1,4",
                "0,0 -> 8,8",
                "5,5 -> 8,2"
            };
        }

        private string[] Day06()
        {
            return new[]
            {
                "3,4,3,1,2"
            };
        }

        private string[] Day07()
        {
            return new[]
            {
                "16,1,2,0,4,2,7,1,2,14"
            };
        }

        private string[] Day08()
        {
            return new[]
            {
                "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe",
                "edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc",
                "fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg",
                "fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb",
                "aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea",
                "fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb",
                "dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe",
                "bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef",
                "egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb",
                "gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce"
            };
        }

        private string[] Day09()
        {
            return new[]
            {
                "2199943210",
                "3987894921",
                "9856789892",
                "8767896789",
                "9899965678"
            };
        }

        private string[] Day10()
        {
            return new[]
            {
                "[({(<(())[]>[[{[]{<()<>>",
                "[(()[<>])]({[<{<<[]>>(",
                "{([(<{}[<>[]}>{[]{[(<()>",
                "(((({<>}<{<{<>}{[]{[]{}",
                "[[<[([]))<([[{}[[()]]]",
                "[{[{({}]{}}([{[{{{}}([]",
                "{<[[]]>}<{[{[{[]{()[[[]",
                "[<(<(<(<{}))><([]([]()",
                "<{([([[(<>()){}]>(<<{{",
                "<{([{{}}[<[[[<>{}]]]>[]]"
            };
        }

        private string[] Day11()
        {
            return new[]
            {
                "5483143223",
                "2745854711",
                "5264556173",
                "6141336146",
                "6357385478",
                "4167524645",
                "2176841721",
                "6882881134",
                "4846848554",
                "5283751526"
            };
        }

        private string[] Day12()
        {
            return new[]
            {
                "fs-end",
                "he-DX",
                "fs-he",
                "start-DX",
                "pj-DX",
                "end-zg",
                "zg-sl",
                "zg-pj",
                "pj-he",
                "RW-he",
                "fs-DX",
                "pj-RW",
                "zg-RW",
                "start-pj",
                "he-WI",
                "zg-he",
                "pj-fs",
                "start-RW"
            };
        }

        private string[] Day13()
        {
            return new[]
            {
                "6,10",
                "0,14",
                "9,10",
                "0,3",
                "10,4",
                "4,11",
                "6,0",
                "6,12",
                "4,1",
                "0,13",
                "10,12",
                "3,4",
                "3,0",
                "8,4",
                "1,10",
                "2,14",
                "8,10",
                "9,0",
                "",
                "fold along y=7",
                "fold along x=5"
            };
        }

        private string[] Day14()
        {
            return new[]
            {
                "NNCB",
                "",
                "CH -> B",
                "HH -> N",
                "CB -> H",
                "NH -> C",
                "HB -> C",
                "HC -> B",
                "HN -> C",
                "NN -> C",
                "BH -> H",
                "NC -> B",
                "NB -> B",
                "BN -> B",
                "BB -> N",
                "BC -> B",
                "CC -> N",
                "CN -> C"
            };
        }

        private string[] Day15()
        {
            throw new NotImplementedException();
        }

        private string[] Day16()
        {
            throw new NotImplementedException();
        }

        private string[] Day17()
        {
            throw new NotImplementedException();
        }

        private string[] Day18()
        {
            throw new NotImplementedException();
        }

        private string[] Day19()
        {
            throw new NotImplementedException();
        }

        private string[] Day20()
        {
            throw new NotImplementedException();
        }

        private string[] Day21()
        {
            throw new NotImplementedException();
        }

        private string[] Day22()
        {
            throw new NotImplementedException();
        }

        private string[] Day23()
        {
            throw new NotImplementedException();
        }

        private string[] Day24()
        {
            throw new NotImplementedException();
        }

        private string[] Day25()
        {
            throw new NotImplementedException();
        }
    }
}