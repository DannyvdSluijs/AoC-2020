using System;
using System.Linq;

namespace Aoc_2020.Puzzles
{
    public static class Day10Part1
    {
        public static void Execute()
        {
            var input = @"66
7
73
162
62
165
157
158
137
125
138
59
36
40
94
95
13
35
136
96
156
155
24
84
42
171
142
3
104
149
83
129
19
122
68
103
74
118
20
110
54
127
88
31
135
26
126
2
51
91
16
65
128
119
67
48
111
29
49
12
132
17
41
166
75
146
50
30
1
164
112
34
18
72
97
145
11
117
58
78
152
90
172
163
89
107
45
37
79
159
141
105
10
115
69
170
25
100
80
4
85
169
106
57
116
23".Split("\n")
                .Select(int.Parse)
                .ToList();

            input.Add(0);
            input.Add(input.Max() + 3);
            input.Sort();

            var diffs = Enumerable.Range(0, input.Count - 1).Select(x => input[x + 1] - input[x]);
            var ones = diffs.Count(x => x == 1);
            var threes = diffs.Count(x => x == 3);

            Console.WriteLine($"The product of diffs of 1 and 3 is {ones * threes}");
        }
    }
}