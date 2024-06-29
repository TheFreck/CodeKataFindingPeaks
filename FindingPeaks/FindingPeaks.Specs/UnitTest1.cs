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
                new int[]{2,1,3,2,2,2,2,5,6,2,1,3,2,2,2,2,1,1,2,5,4,3,2,3,6,4,1,2,3,3,4,5,3,2,1,2,3,5,5,4,3},
                //new int[] { 1, 2, 3, 6, 4, 1, 2, 3, 2, 1 },
                //new int[] { 3, 2, 3, 6, 4, 1, 2, 3, 2, 1, 2, 3 },
                //new int[] { 3, 2, 3, 6, 4, 1, 2, 3, 2, 1, 2, 2, 2, 1 },
                new int[] { 2, 1, 3, 1, 2, 2, 2, 2, 1 },
                //new int[] { 2, 1, 3, 1, 2, 2, 2, 2 }
            };
            expectations = new Dictionary<string, List<int>>[]
            {
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
                new Dictionary<string, List<int>>
                {
                    {"pos", new List<int>{2,4} },
                    {"peaks", new List<int> {3,2}}
                },
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