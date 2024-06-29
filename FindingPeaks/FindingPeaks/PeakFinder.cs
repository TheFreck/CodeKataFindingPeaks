using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPeaks
{
    public class PeakFinder
    {
        public static Dictionary<string, List<int>> GetPeaks(int[] input)
        {
            var goingUp = false;
            var peaks = new Dictionary<string, List<int>>
            {
                { "pos", [] },
                { "peaks", [] }
            };
            var plateau = false;
            var plateauStart = 0;
            if (input[1] > input[0]) goingUp = true;
            for(var i=2; i<input.Length; i++)
            {
                if (input[i] < input[i - 1])
                {
                    if (goingUp || plateau)
                    {
                        peaks["peaks"].Add(input[i - 1]);
                        peaks["pos"].Add(plateau ? plateauStart : i - 1);
                    }
                    goingUp = false;
                    plateau = false;
                }
                else if (input[i] == input[i-1])
                {
                    if (goingUp)
                    {
                        plateau = true;
                        plateauStart = i - 1;
                        goingUp = false;
                    }
                }
                else
                {
                    goingUp = true;
                    //plateau = false;
                }
            }
            return peaks;
        }
    }
}
