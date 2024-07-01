using Machine.Specifications;

namespace FindingPeaks.Specs
{
    public class When_Identifying_Peaks
    {
        Establish context = () =>
        {
            input = new int[] { 2, 1, 2, 3, 2, 3, 4, 3, 2, 1, 2, 3 };
            expect = new Dictionary<string, List<int>> { { "peaks", [3,4] } };
            answer = new Dictionary<string, List<int>>();
        };

        Because of = () => answer = PeakFinder.GetPeaks(input);

        It Should_Return_Expected_Peaks = () =>
        {
            for (var i = 0; i < expect.Count; i++)
            {
                for(var j=0; j < expect.Values.Count; j++)
                {
                    var ans = answer["peaks"];
                    var exp = expect["peaks"];
                    answer["peaks"][j].ShouldEqual(expect["peaks"][j]);
                }
            }
        };

        private static int[] input;
        private static Dictionary<string, List<int>> expect;
        private static Dictionary<string, List<int>> answer;
    }

    public class When_Getting_The_Indexes_Of_The_Peaks
    {
        Establish context = () =>
        {
            input = new int[] { 3, 2, 1, 2, 3, 2, 3, 4, 3, 2, 1, 2, 3, 4, 5 };
            expect = new Dictionary<string, List<int>> { { "pos", [4,7] }, {"peaks", [3, 4]} };
            answer = new Dictionary<string, List<int>>();
        };

        Because of = () => answer = PeakFinder.GetPeaks(input);

        It Should_Return_Expected_Peaks = () =>
        {
            for (var i = 0; i < expect.Count; i++)
            {
                for (var j = 0; j < expect.Values.Count; j++)
                {
                    answer["peaks"][j].ShouldEqual(expect["peaks"][j]);
                }
            }
        };

        private static int[] input;
        private static Dictionary<string,List<int>> expect;
        private static Dictionary<string,List<int>> answer;
    }

    public class When_Identifying_A_Plateau
    {
        Establish context = () =>
        {
            input = new int[] { 3, 2, 1, 2, 1, 2, 3, 3, 2, 2, 3, 3, 4, 5, 5, 5, 4, 5 };
            expect = new Dictionary<string, List<int>> { { "pos", [3, 6, 13] }, { "peaks", [2, 3, 5] } };
            answer = new Dictionary<string, List<int>>();
        };

        Because of = () => answer = PeakFinder.GetPeaks(input);

        It Should_Return_Expected_Peaks = () =>
        {
            for (var i = 0; i < expect.Count; i++)
            {
                for (var j = 0; j < expect.Values.Count; j++)
                {
                    answer["peaks"][j].ShouldEqual(expect["peaks"][j]);
                }
            }
        };

        private static int[] input;
        private static Dictionary<string, List<int>> expect;
        private static Dictionary<string, List<int>> answer;
    }

    public class When_Using_The_Test_Cases_From_Code_Wars
    {
        Establish context = () =>
        {
            inputs = new int[][]
            {
                new int[]{ },
                //new int[]{2,1,3,2,2,2,2,5,6,2,1,3,2,2,2,2,1,1,2,5,4,3,2,3,6,4,1,2,3,3,4,5,3,2,1,2,3,5,5,4,3},
                //new int[]{2, 1, 3, 2, 2, 2, 2, 5, 6, 2, 1, 3, 2, 2, 2, 2, 1, 1, 2, 5, 4, 3, 2, 3, 6, 4, 1, 2, 3, 3, 4, 5, 3, 2, 1, 2, 3, 5, 5, 4, 3},
                //new int[]{ 17, 13, 9, 5, 12, 14, 5, 9, 11, 1, 9, 14, 10, 8, -5, 16, 0, -5, 13, 8, 7, 9, -1, 6, 0, 12, 9, 1, 17, 3, 5, 14, 7, 8, 19, 9, 1, 19, 6, 18, 6, 0, 15, 1, 8, -1, -2, 13, -5, 2, 18, 6, -5, 9, 17, 5, 14, -2, 1, 0, 14, 18, 3, 16, 0, 7, 7, 17, 15, 18, 0, 9, 18, 3, 6, 14, 2, -1, -5, 7, 19, 9 },
                //new int[]{ 1, 2, 5, 4, 3, 2, 3, 6, 4, 1, 2, 3, 3, 4, 5, 3, 2, 1, 2, 3, 5, 5, 4, 3 },
                //new int[] { 1, 2, 3, 6, 4, 1, 2, 3, 2, 1 },
                //new int[] { 3, 2, 3, 6, 4, 1, 2, 3, 2, 1, 2, 3 },
                //new int[] { 3, 2, 3, 6, 4, 1, 2, 3, 2, 1, 2, 2, 2, 1 },
                //new int[] { 2, 1, 3, 1, 2, 2, 2, 2, 1 },
                //new int[] { 2, 1, 3, 1, 2, 2, 2, 2 }
            };
            expectations = new Dictionary<string, List<int>>[]
            {
                new Dictionary<string, List<int>>
                {
                    {"pos", new List<int>() },
                    {"peaks", new List<int>() }
                },
                //new Dictionary<string, List<int>>
                //{
                //    {"pos", new List<int>{2,8,11,19,24,31,37 } },
                //    {"peaks", new List<int>{3,6,3,5,6,5,5 } }
                //},
                //new Dictionary<string, List<int>>
                //{
                //    {"pos", new List<int>{ 2,8,11,19,24,31,37 } },
                //    {"peaks", new List<int>{ 3, 6, 3, 5, 6, 5, 5 } }
                //},
                //new Dictionary<string, List<int>>
                //{
                //    {"pos", new List<int>{ 5, 8, 11, 15, 18, 21, 23, 25, 28, 31, 34, 37, 39, 42, 44, 47, 50, 54, 56, 58, 61, 63, 67, 69, 72, 75, 80 } },
                //    {"peaks", new List<int>{ 14, 11, 14, 16, 13, 9, 6, 12, 17, 14, 19, 19, 18, 15, 8, 13, 18, 17, 14, 1, 18, 16, 17, 18, 18, 14, 19 } }
                //},
                //new Dictionary<string, List<int>>
                //{
                //    {"pos", new List<int>{2,7,14,20 } },
                //    {"peaks", new List<int>{5,6,5,5 } }
                //},
                //new Dictionary<string, List<int>>
                //{
                //    {"pos", new List<int>{3,7} },
                //    {"peaks", new List<int> {6,3}}
                //},
                //new Dictionary<string, List<int>>
                //{
                //    {"pos", new List<int>{3,7} },
                //    {"peaks", new List<int> {6,3}}
                //},
                //new Dictionary<string, List<int>>
                //{
                //    {"pos", new List<int>{3,7,10} },
                //    {"peaks", new List<int> {6,3,2}}
                //},
                //new Dictionary<string, List<int>>
                //{
                //    {"pos", new List<int>{2,4} },
                //    {"peaks", new List<int> {3,2}}
                //},
                //new Dictionary<string, List<int>>
                //{
                //    {"pos", new List<int>{2} },
                //    {"peaks", new List<int> {3}}
                //},
            };
            answers = new Dictionary<string, List<int>>[expectations.Length];
        };

        Because of = () =>
        {
            for (var i = 0; i < inputs.Length; i++)
            {
                answers[i] = PeakFinder.GetPeaks(inputs[i]);
            }
        };

        It Should_Return_Correctly = () =>
        {
            for (var i = 0; i < expectations.Length; i++)
            {
                for (var j = 0; j < expectations[i].Values.Count; j++)
                {
                    if (answers[i]["peaks"].Count == 0 || answers[i]["pos"].Count == 0) continue;
                    var ansPeak = answers[i]["peaks"][j];
                    var expPeak = expectations[i]["peaks"][j];
                    if (answers[i]["peaks"][j] != expectations[i]["peaks"][j])
                    {
                        ansPeak = answers[i]["peaks"][j];
                        expPeak = expectations[i]["peaks"][j];
                    }
                    answers[i]["peaks"][j].ShouldEqual(expectations[i]["peaks"][j]);
                    var ansPos = answers[i]["pos"][j];
                    var expPos = expectations[i]["pos"][j];
                    if (answers[i]["pos"][j] != expectations[i]["pos"][j])
                    {
                        ansPos = answers[i]["pos"][j];
                        expPos = expectations[i]["pos"][j];
                    }
                    answers[i]["pos"][j].ShouldEqual(expectations[i]["pos"][j]);
                }
            }
        };

        private static int[][] inputs;
        private static Dictionary<string, List<int>>[] expectations;
        private static Dictionary<string, List<int>>[] answers;
    }
}