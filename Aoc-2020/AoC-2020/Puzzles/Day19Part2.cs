using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Aoc_2020.Puzzles
{
    public static class Day19Part2
    {
        private static Dictionary<int, string> rules;
        private static readonly Dictionary<string, IEnumerable<string>> resolved = new Dictionary<string, IEnumerable<string>>();

        public static void Execute()
        {
            var input = @"
72: 'b'
45: 46 52 | 9 72
85: 9 52 | 9 72
82: 52 87 | 72 77
133: 52 30 | 72 56
118: 7 52 | 70 72
18: 52 113 | 72 52
119: 72 46 | 52 18
25: 19 72 | 103 52
32: 90 52 | 78 72
50: 113 113
71: 72 106 | 52 128
3: 103 72 | 18 52
41: 86 72 | 19 52
96: 86 72 | 108 52
33: 44 52 | 104 72
127: 52 36 | 72 50
51: 72 79 | 52 38
43: 72 50 | 52 106
14: 32 72 | 129 52
6: 2 72 | 33 52
108: 52 72 | 72 52
129: 6 52 | 82 72
34: 127 72 | 3 52
74: 128 52 | 9 72
80: 52 103 | 72 19
2: 134 72 | 13 52
54: 128 72 | 114 52
19: 72 72 | 113 52
0: 8 11
30: 132 72 | 39 52
60: 72 64 | 52 5
4: 18 52 | 114 72
57: 72 71 | 52 54
111: 52 27 | 72 102
76: 122 52 | 75 72
134: 86 52 | 9 72
49: 17 52 | 81 72
124: 103 72 | 86 52
123: 72 28 | 52 121
117: 18 52 | 86 72
26: 51 72 | 58 52
62: 85 52 | 44 72
55: 126 52 | 92 72
115: 72 13 | 52 67
109: 128 72 | 106 52
52: 'a'
93: 60 52 | 133 72
64: 67 72 | 84 52
102: 52 128 | 72 48
84: 86 52 | 46 72
77: 41 72 | 21 52
27: 52 9 | 72 108
95: 89 72 | 105 52
36: 52 72
110: 72 50 | 52 9
9: 72 72
120: 72 19 | 52 18
67: 52 48
112: 65 72 | 119 52
75: 62 52 | 123 72
23: 15 72 | 119 52
42: 131 52 | 61 72
94: 52 91 | 72 18
66: 52 128 | 72 103
10: 113 108
37: 52 18 | 72 50
98: 72 69 | 52 94
126: 115 52 | 29 72
79: 59 52 | 94 72
104: 19 72 | 36 52
125: 96 72 | 4 52
122: 52 73 | 72 112
130: 52 20 | 72 45
90: 72 40 | 52 88
132: 103 52
121: 91 52 | 46 72
7: 52 114 | 72 128
5: 52 66 | 72 41
97: 52 18 | 72 91
89: 72 109 | 52 116
53: 52 108 | 72 128
114: 52 113 | 72 72
16: 1 52 | 110 72
113: 72 | 52
31: 52 14 | 72 12
69: 52 103 | 72 48
128: 72 52
40: 72 3 | 52 83
101: 63 52 | 127 72
1: 72 91 | 52 114
58: 52 111 | 72 99
13: 19 72 | 9 52
35: 22 72 | 125 52
65: 72 114 | 52 91
12: 52 24 | 72 93
46: 72 72 | 52 52
20: 9 72
73: 72 37 | 52 43
15: 52 50 | 72 108
103: 52 52
106: 72 52 | 72 72
21: 36 72
28: 72 50 | 52 46
78: 72 16 | 52 23
70: 36 72 | 19 52
87: 72 107 | 52 47
116: 19 52 | 106 72
29: 72 68 | 52 65
8: 42
68: 9 52 | 128 72
99: 110 72 | 25 52
17: 52 118 | 72 130
11: 42 31
48: 52 52 | 72 52
83: 48 113
105: 52 100 | 72 80
61: 55 52 | 26 72
100: 48 52 | 108 72
56: 52 53 | 72 74
63: 52 106 | 72 9
44: 72 114 | 52 128
47: 52 50 | 72 36
107: 52 36 | 72 91
39: 114 72 | 86 52
86: 52 72 | 52 52
24: 52 95 | 72 35
81: 98 72 | 34 52
131: 49 52 | 76 72
92: 52 101 | 72 57
59: 52 114 | 72 50
38: 52 74 | 72 124
88: 97 72 | 10 52
22: 117 72 | 120 52
91: 72 72 | 52 72

bbabbaabaabaaaababbbbabaabbaabab
baaabaaabaaababbabababaabababaaa
aaabbbabaabbbbbbbbabaaba
aaababbbaaabaabbabbbbabbaaaabbbb
ababaabbaabbbaabbbabbababbabbbbbbaaabbbbaaaabbbabbbaaabbaaaabbaa
bbbbaabaababaaabbbaaaaabbbbabbabaaabaabaabbaaaba
bbaababbbbbbaabbbbbaaaabbbbbabaaaabbbabaabbbaaaa
aaaaaaaaaababaaaabaaababaabbbbaababaaaaaaaaabaaabbaabbbaaabaabababbbbaaabbbbbabb
bbbbabbbbbbbbbbababbabbabbbabbbaaabbbbbaabbbbbaa
bbabaaababbbaabababbabbbabaabbbbbaaabbaaaaabbbaaaaabaabbaabbabba
babbbabaaabbaaaabaaaaabbbabaaaaa
ababaabbaaabbabbbbbbbaaaaabaabaabaaaababbaaaaaaa
baaaababaaaaaaababaaabba
bbaabbbaaabababbbaaaaabbbbbbbaaaaabbaabaabaaabaabbbaabaaaaaababbababbbbb
bbababbbaaabbabababbbabaaabbaababbbaaabaaabbbabbabababab
babbabbabbbaabbbbaabaaabbabababbbbbbbbaa
abbaaaaaabbabbaabbabbabababbaabaabbbaaaa
ababaabbabbbbbabbabbbaaaabbbaabbabbbbabb
aaabbbbaabbbababaabaaaaa
babbbaaaabaaabaaabbabbabbabaabab
aaabbaabaabbabaaaaaaaabb
ababbbabaabbaabbabaababababbbbaa
babbabaaabbbababbbababaaaaaabbaaababaaab
bbaababbbabaaababbaaabab
aabababbbbaabbbbabaabaababababaaabababab
baaaaabbbbbaabbbbbababbbbbbabbab
baaaabaaabaabaaabbabaaaababaaaab
aabbbabababaaabababbaaaa
ababbbaaabababbaaabaaababbaaaabaabbbbbab
ababbbaaaabaaaababababba
aaabbbabaabbaababbbbabbbbbabbabaababbabb
aabbabaaaabbaababbabbabbaaabaabababaaabaaaaaabab
abaaabbbabbaaababaaababa
bbaaabbbbababbababaababb
aaabbabababaaabaabbabaab
bbabbaaaabbbaabbaaabbbbbbbbabaabbbbbabbbbabbaabaabbaababaaabaabb
babbabbabbbbababaaaaabaababbbabbaabaabbbabaaaabb
bbabbaababababbabaaababb
babaaabaaabababbaabababbabbababaabbaaabbbababaaaababbbbbaaaabbbbabbbbaaa
aaabaabaaabbbaabbbabbbbbbbababba
aabaababbbaaaababbabaaaa
aaaabaaabbabababbabbbaab
baaabaabbaaaababbbaabaaaaabbabaaabaaabaabbbbbabbbabaabababaabbaaabbaaababbabbbbb
aabaabbbababbbababaababaabbbaaaa
aabaabbaaaabaabaabaaaaaabababbaababaaabbabbbbabbbaaaaaaabababbabbbbbabaa
baaabbbaaaaaabbbbbaaaaabbabbaabaaaaabbba
baaabaaaabbbbaaaaabbaababbabbababaaaabbbbabbaaabaabbbaabbaaaabbb
baaabbbabaabbabaabbabaaabaaabbbaabbaaabbabaaabab
abbaaabbaaabbabbabaaabba
aaaaaaabbabbbabababbbaaaababaabbabbaaabaabbaabab
aabababaaabbaabbbbaabbbababbaaaa
aabbbabaaabaabbbbbbabaabababbbbb
bbbababbbabbbbbbbabaaabaaaabbabaaabbbbabbabababaaabaaaaa
abaabbaabbbabaabbabaaabbaaabbaaaaabbaaabbaaabbbbbabbaabb
abbbbbabaabaabababababbaaabababbaabbbababbaabaaa
aaabbaabaabaaaabbbbabbbbbabaababaaaaabab
aabbbaabbbbbababaabbbbbbaababbbb
bbababbbaabaaaabbaaaaabbbaababaabbaabaab
aabaababaabbbbbbbabbbbab
aaaaabaababbbabbabbbaabbbbabbaaa
baaaabababbbabbbbaaababbbbbababaaaaaaabb
baaaabaabaaabbaaabbbbbbaabaabbaabbbbbbabbbbbbbbbbabaabababbbbabbaababbbb
bababbabaaabaaaaaaababbbbbabbbaabaaabbbb
bbbbbbbabbabaaabaaaaaaabaabaaabaaaaaaaaababbaaabbaabbaaababaaabbabaaaaaa
abbaaababbbabaabbaaabbab
aabaabbbabaaaababaaabbbabaaaabbbbabbbababbbbabaaaaaababbaaabaabbbbbaabababbaabbb
abaaabaabbabaabbaabbaabaababaaaa
babbabaabaaaaababaaaabba
bbabbbbaaabbbabaaaaabbbb
abbabababbabbbbbaaabaaabaaaaabbaabbabbababbaabbaaabbbabbabbaabbbaabbabaaabaabbab
baabaaabbbbbaabbbaaababa
bbaaabbabbbbabbabbaabbaabaaaaabbabaabbba
babbbabaaabbbaaababababb
abaabbbbbbbbbababaaabbbabbababaaabaaaabababaaaab
bbbbbabbbabbbbbababbabaaabbbaabbbbabbbbbabbabababababaabaaabaaabbaaabaaaaaabbaaa
bababababbbbbbaaaabbbbaabbaaabaababbbbaaabbabbab
ababbaabababaababbbbbabbbbabbababaaabbbabaaaabbbaaaaaaba
abaabababbbbabbbbabbaaab
bbaaaaaaabbababaabbbababbabbbabbbaabaaaabbabbaba
abbbaabbabbabaabbbbbbbaabaaaaabbbbaaaabbbbbbabba
aabbbbbbaaabbaabaababbbababbabaaaaabbaaa
abaabbaaaabababbabbabbabbbaaaaab
babbbababbbbbbbababaaaaa
baabbbbbaabbbaabbabbababbbbbbbbb
bbaaabbbbbbabaabaaaaabaa
bbababaaabbabbabbabbbaaabbabbbab
bbbbabbababbababaababbaa
bbababaabbabaabaabbaabab
aabbbaabbbbaababbabababa
ababaaababbbbaaaabbbbaaaaaababbb
baaaababbbaabaaabbabbbabaababbabbaaaaaaabbaaaaaa
abbbababbaababbbbbaabbbbababbbaabaaababaabaababbbabbbbab
bbabaaabbaabbaaabbbaaabaaaaabbabbaaaabaaabbbbabbbaabbbbbabbabaababaaaaab
bbbbabbabbbbbbaaaaaabbbbabaabababbabbbbbbabaabbaaabbbbbbbbbbaaaa
baababaaaaabbbaaabaabbba
bbbbababbbabbaabbbabaaababbaaaababababaa
aaaaaaaaaaaaaababaaababbabbbabaa
aaabbabababbbaaabaabbbbbababbbbaaabbbabb
aabaaaabbbbbaaaaababbaabaaabbbbabbaaaaaabbababbbaababaaabaabbaabbabaaaaa
aaaabaaabbaabbaaaabbabba
bbbbaaabbaababaaababbabb
abbbbababbbbabbbbbbbababbaabbbbbaaabaabaabababbabaaabaaa
baabbabaabbbaababbabbaba
bbbbaabbbabbabaaaabaaaaababbaababaaabaabbbaaabaaaaababab
abbbbbbababbabbbbaababababbabbabababbbbb
aaabbbabbbbaaaaaabbbabaababababb
aabbaaabaaabaaabbbaaabaaaabbaaaaaaabababbbaabaab
babaababbaabaaaababaaaaa
aaabbbaaaabaabbbaaabbbbb
abaabaabbaabbabaaaabbbbaaabbbbabaabbbabb
baaababbabaaababaaababbababbbbba
aabbaaaabbabaabbbabaaabaaaaaaaabbbbaaaaa
bbbabbbbaabbbbaabbbaaaabbbbaaabb
abaaabababbabababbaabbbabaaabaaaaaaaaaabaabbbaaaaabbbbbbabbabbaaabaaaaaa
bbbbbbbabbabbaabbabbbaaabaabbaaa
bababbabbaabaabbaaabbbbabaabbbbaaabaaabb
bbbbbababaaaaabbabbbbbbabaaaabab
babbabaabbbbaaabaaabbbbaababaabbaabbaabb
ababaabbbbbaaababaabbaaaabbabbbbaaabbaaa
ababbaabbbbbbaaaaaabbbbb
babbabaababbabbabaabbbab
bbaabbaabbbbaabbabbbbbbaabbbaabaaaababbbbaaabbbbbaabbaaa
aabaabbbbabbbbbbabbabbaaabaabababbbbbabbbbaabaaa
abbbbbbaaabbbbaaabbabbbb
aaaaaaaaababbbabaaabbaabababbbba
baaabbaabaaaabaaabaabaaabbaabbbbaaaaaaababaababb
ababbbaababbbbabbabaaaaabababbba
aaaaabaaaaabbbababaaabbbabbbabba
bbbabbbaaaaaaaaaaaabbbbb
abbbbbbabbabbabbabababaa
baaaaabaaaaabaaabbaabbba
baaaabbbaababbbaaaaaaabb
bbbabaabbabbabbbabaabbbbaabbaababaaabaaababaabbb
bbbabbaabbbaabbbbbbabbbabbababababbabbbb
baabaabbbbbaabbaaaababab
bbabbaabbababbabbbabaabbbabbbbbaaaabbabaabbbbbbbababbaba
babbabbaabbaaabbbbabbbbabaaaaaaabbbaaaaa
abaabbaabbbabbbaabbabaaaaababaaaaaaaabbb
aababbabbbabbaabbabaaabbabbabaabbbbaaababbabbaaabbaaaababbbaaabbbaabaabaabababaa
abbabababbaaabbbbaababbaabaabbbbbbbbbbaa
bbbabbbabbabbbbabaaabaaababaaababbbaababbbbabababbabbbabaaabaaaaaabaabbb
baaaaaababbabaabbbabaabaabbbbbabaaababab
baabaabababbbbbabbbbaabaaaaabbbb
baabbabaababbbabbabbbbab
bbbbaabbbbbaaaabbbbbaaaa
bbbbaababaabaaababbbbbaa
bbbbbabbaaabaababbbaaaababaaabba
ababbbabbbbaaaababaaaabbbbaabbbaaaaaababababbbbababbbbbaababbbabaaaaaaababaabbababbbaaaa
aabaababbbbbababbaabbbab
baaaaababbbababbababaaab
baabaabbaaabbaaaabaabbbabbabbbbababbbbab
abbbbbbababbbabaaabababbbbaabbbabbbbababaabaaabb
bbabbabbabbabababaaaabba
abbabbbabbbbbababaaabaaa
bbbbbaabbabbbbaaabaaaaaabbbabbabaabbbabbabbabaaaabaababbbbbaaabb
baaabbbaaabaabaababaabab
baabaababaaaaabaabaabbaababbbbbabaaabbababbaabab
bbabbbbabaaaabaaaabababbabbabaab
babbaababaaaaaabbbaabaab
abaabbabaaabbbabaaaaabbbbbabababbbbaabbabbbabbbbabaaaaab
ababbbabaababababaabaaaa
abaaabaaababbbabbaababaabaabbaab
aaabbbbabbbaabbabbabaabbbaabbbaa
aaabbbaaaabaabaaabbbbbbb
abbbbabbababaabbbbaababbaabaabbbabbbbabbababbbab
baabaabbbbaaaababbabaabbbbabbaaaabbbaaaaaaababaaaabaabbbbbaaaaabbbbaaaaaaaaabbababbabbba
abbaababbbaaaaabbaabbaaa
babbbbabbbaababaaaaaaaaaabbbbaabbbababbbabbaaaaabababbaabaabbaaaaabaabbbaaaaaaaaababbbbbabbaabaa
abbbabababbabaaaababaaaaababbbbaabaabbbababbaabb
abbaaabaaabbabaaababbaab
bbaabbbabaabbbbbabbabbbaaabbaaaabbaaabbbabbaabbababbbbababbaabab
abaaabbbbbabaababbabaaaa
bbababbbbbbababbaaaaaaabbabaaabb
bbbaabbbaabbbbaaabbabbaabaabaabbbababaaa
babbbaaaaabaabbbabbbbbaa
abaabbaabaabbbbbabbbaabbaaabbaaa
abbbaabaababbbabaaaaaaaabbbabbbabbbaabab
aaaabbaabbabbaabbbaababaabbabbbbabaaabbaabbbbbbbaababbbbbbaabbabaabbbaaabbaabbba
abababbabbabbabbbbabbbab
bbbababbaaaabaaabaabbbba
bbbbaababbbbbbabbbbbabbaababaabaaababaab
bbaaaaaaaabbbaaabaaabaab
babbbbbbbbbbbaaabbaaabbaaabbabbaaaabbaaa
abaabbabaaabaababbbaaabb
abaababaaaaaaabbbababaabaaaababaabbabaabababbbba
aaabbabaabaababaababbbba
bbaaaaaababaaababababaaa
abbabaaabaabaaabbabbaaba
abbabababbabaabbabbabababbbaaaaa
aabaaabaababbbaaababaaab
bbabbbbaabaaabbbabbaaaab
bbbbababbbbaaababbbaaaba
bbbbbbababbbbbbaaaaaabab
bbababbbabaaabaabaabbaaaabbbabbabbbbbbaaabbabbbb
baababbbaaabbbaaaabaabbbaabaaabb
abaabbabbaaaabababbaabbb
bbbabaababbbbbbabaabaaabbabbbbbbbbbaabaabbabbbaaabbababb
babbabbbbbbbbabbbaaaababbbbbbbbababababa
baabababaabbaabbaabbabba
baabaababaaaaabbbabaabbbababbbaaabbaaaba
bbbbabbbbaabbbababbbaabaabaabaaaaaaaabaaabbaaaaa
bbabababbaabbabaabbabbaabaababaabaaaabba
abbbbbbaaaaabbaabbbbbaabaabbabbbaabababaaaababbbbabbbbbabaaabbab
bbbbaaabaaaabaaaaabbbaab
aabbaabbaaaaaaaaabbbbababaabababbabbabbbbbbbababaaabaabb
bbabababbabbabbbbaaaabaaaabbaababbbaaaaaabbbaaaa
bbabbabbaaabababbabbbbababaabbabbbbabbbababbaaab
abaaaaaabbbaabaaaabbbbabbababaab
aabababbbabbabbabbaabaaa
ababbbaaaaabbabaaaabbabbaaaaaabb
baaaababbbaaaababbbbbabbbbbaaabaabbabaaabbbbbabaaaaaaaababbbababaabbbbbbaabbbbaa
baabbbbbbbbbaabaabbababb
bababbababaabbbbababaaab
baababbbbabbaabbabbabbaabababbabaaaabbbaabaabaaa
aabaabababaaaabaabababbbbaaabaaaabaaabab
abbaaaaababbabbabaaaabbbbaaaabba
babbbaaabaaaaabbbabbbbab
ababbbabbaabbabaabbbabba
abaabbabaaaabaabbaaabbbbbbbabbaaaaabaabb
bbbaabbaaabbbaabbaabaabaababbaab
ababbbaabbbbbbbabaababaaabbabbabaababaaabbbaaababaabbaab
bbbbbbbabbaaaaaaaaabbbababbbbbbb
aabaaababbabbabaaaaabaaabbabbaabaabbbbbbababaaaa
baabaaabaaabbbabbababbabababbaba
abbbabbbababbabbbbbbaaaababbabbbaaaaaaaaabbaabbabbaaaaabbbabaaaabababbbaaabbabbb
baabaaabbabbababbbbaabbaaaabbaabbbbbabbbabbbaaabbbbabaaa
abaaabbbabaabaaaabbbbbabaaabbbbabababbbbbabbbbabaabaaaaa
aaaaaaaaabaaaababbbaaabababababa
bbbbaabbbababaaaaaaaaaab
aaabaaaabaaaababbabbbbbbaaaabbababbbabaa
babaaababbbbbbbaabbbbabb
baaabbaaaabbbbaabbbababa
baababbbaababbbabbbaabbbbbbbabaaaabbaaab
baaaabaabaabaabbbababbababbbaabbaaabbaabbaaaabba
baabaababbbaabbbabbabababaaaaaaa
bbbababbaabbababaaaaabbb
bbbabaaaaaaaaaaabbbaabbbbabaabbaabaaabbbabbaabbbbabbbbab
aaaaaaabbaababaaaaabaaaababbbaab
abababbaababbbabaabbbbaaaaaabaaaabbaaaba
baababbaaabaabbbbbbaabbabbbbaabbaabbabaabbabbbabaabbabba
abaaabbbbabbbaaabbbbaabaabaabababbaaabbbaabbbbabbababbbabaabbaaabaaabaaa
aabaaabaababbaabbbbbbbabbaaaaabbaaaabbba
aabbabaaabbbbabababbbbbbbaaabbbabaabbaaababbbbabbbbabaaa
abaabbbbbbbbabbbabbaaaaabbaaaaaaabbabbbbabababaa
ababaabbbbbbabaaabbaabba
bbbbababaababaaaaaaabbaabaabaaaa
abbbababbbbbaaababaaaabb
aabbbbbbaababbbaababbbabbaabbabaabaababaaaabaaab
aabaababaaabbbaabbaababababbbaaaabababaa
abaabaabbabbbababbaaaabaabaaabaabaabaabbabbababbaaabaaababaaabba
baaaaabbbbbaaaabbbbbbabb
abbbababbbbbbbbaabbaaaaababbbabbabababbaabaababb
aabbaababbabbaabbbbbaabaaaabbabbababbaba
ababbbaababbbbbabbbabaaa
abaaabbbabababbaabaaabbb
abababbabbabbababbbaabbaababbbaaaabbaaab
abbbbabbbaabaabbbaaaabbbbaaabbbbbbbabbbaababbababbbabbab
bbbbbaabbbaababbabbbaaaababbbabaaaababaaabaabbaa
ababbbaababababaaabaabbbabaaabbbbaabababbabbbbbaababbaaa
baababaabbbabbbbaaabaabb
babaabbbbbaabbbbbbabbabaabbbaaaaabbaabbabbbbaabaabbabbbbbbabbbaa
baabbabaaabbbababbaaaaba
abbbbbabbaaabbbabbaabbaaaabbbbaaaabbabbabaabbbba
aaaaaaabbaaabbbaaaaabbab
baabbbbbbaaabbbbaabbabaaaababbabbbaababaaabbbbbaabaaaaaabaabaabababbbaaa
aabbaaaaabbabaaaabbbbbaa
bbbabaabbbaaaaaaaabbbabaababaaab
babbabaaaaabbbababaaaaaa
baabbabaabaaabbbaabaaaaa
aabbaababbababbbbababaabaabbbbba
abbbbabaaabaaababbbbbaaaaaabaaab
bbbabaabbbbbabbaaababaaa
bbbbbabaabbaaabaaaabbbaaabbbbbbabaabbbaaabbbbbbbbaabbaaa
bbbbaaaabaabaabbbbabbabbbbbbbabaaaaabaaabbabbbbbbaabbbabaaabaabb
bbbbbaaabbbbabaabbabbbbbbaabaaabbabbbbbaabbbabbaabbbbbaa
aaabbbabbabbabbbbabaaaaaabbbbbaaaaababaaaaaaabbaabbabababababaaabbbababaabbaaaabbaaabaaababbaabb
abbaaaaaabbababaaababababaaaaabbaaabbaaa
aaaabaaaaabbabaaaaaabbaa
bbbbbbbabaababbbbbbbaaaabbbbbaab
ababaaaababbabbabbbababaabbaaabbabbbbbbbaabbababbbabbaba
bbbbbbbaaaaaababbaabbaaaaaababbbabaaabab
baabbbaaaaabbbbabbababbaaaaababaabbababaaaabbbbbbbbaaaababbbbbaababaaabb
bbbabbbaaabbbaabaaababbaaaabbaaa
baabaababbbbbaaabbbbabaaaabbabbaaaabaabb
abbbaabbabbabbabbbbaabbbbbabbbab
babbabaaabbabbbabaababaabbabaaba
baababbbbaaaabaaabbbaabbbbbaaaaa
bbaababbaaabbbbabbbabaaa
babababaaabbababbbbbabbbbbbababbabbbabbaaabbabbbabbaaaabbabbbabbaabbaaba
bbbbaaaabaaaaaaabbaaabaabaaaababaabaababbbbabababbabbbbaabbaaaabbbbaaababbbabbababaababb
babaaabbaabaaabbbabbbaabaaaabbbaaaaaabababababbabbababba
aaaabaaabbabaaabaabbbaaabbbbabaa
abbababaabaabbaabbbababbbbabbbbbaabbaaaaaaaabbabaaababbbbbabbbaa
aababbbababbabaabbbbabbaaabaaababbbbabababaaabaaaababaaaaabbaaab
ababbbaaaababbbaabbbbabaabaaabaabbbaabbaabbbbbaabbbaaaaabaabbabb
bbbabbaabaabababaabbababaababaaa
aaaaaaabbbbbbbabbabaabaa
abaabaaaaabbaaaabbbbaabaaabaabaabbbaabaa
aabbabaabaaabbaaaaaabbbb
abbabbaabaabababaabbbaabbbbbaababbbbabbbabbbaaab
abbaaabbabaaaabaaaaaabaaaababbbbbaabaaabaaabaabbbbabbabbbbbaaabababbabbabbbbbaaa
abaaabbbbabaaaaaabbaaababaaaaabaababbaababaabaaaabaaaaabbbaaaaab
aababababbbbbbbaabaabbabbbbbbaaaabbbaaaa
aabbaabaaabbaaaaaabaababaabbbbab
aabaaababbaaaaaabbababababaaaaabbababaab
baababaababbabbbabbaabaababbaabbaabaabbabbbbbaab
abaaabaaaaabbbaaabbababababbbabaaababaaa
aabaaababbbbbabbbaabbabb
aaabbabbaaabbbaabbbbbbababbababb
aabaaaabaabbbbaaaaaabaaabbaabbbaabbbbbbb
bbbbabaaaabbababbbabaaabbabaabba
baabaabaaabababababbabbbbbababaaaaababab
aabbbaaaaabbbbaaababbaaaababbbbaababaaaabbbabaab
abbaaabbbaabbbbabababbbabaabbbbaaabbabaabbaaaaba
aaaaaaabbbabaabbaabbbabaabbababaabbbbbbaabbbbaaaabababaaaaaabbbbaabbabba
abbbbabaabaabaabbbabbbbaabbbbabaabababbbbbaabbabbaabaaaa
abaabababbbbbabbbabaaaab
bababbabbbbabaaabbaaaabb
abbabaaabbbababbbbbaabbaaabbbbaababbaaba
bbbbaabaaabbbbbbabaabaaaaabaababbabbabbbabaaabab
babbabbbbbbabbaabbbabaabbbbbbbbb
babaabaaababbbbaabaabbbaababaaabbbabbbaaaaaaaaaabaababbbbaabbaaa
bbbbaabaabbabbaaabaabaaababababa
abbaababbbbabbabaabbbbbaababaaabaaabbbaaabaababbbbbaabaa
aabbaaaabbbbababaaaabbab
aabaababbabbbabaaabababaabaaabbaabaaaabb
bbabbabbbbaabbbbabaabaaaaaaaaaababaaabba
aaababbaabababaabababaaababaabaaabaaaabb
baaabbbabbaaaaabbaabbbab
bababaabbabbbababaaaababbabbaabbbbbaababbabbabbb
bbababaaabbbaabbaaabbbabaaabbbaabbbaaaaa
aabbbbaaabbbbbabaabaaababbaabbaaaabbbbbaabaaababbbbaabab
aaaaaaabaaaababbabababbaaababaabaabaaaaaabbaaaaaabaabbbaaaaabaaa
abaabbbbbbbabbaaaababbab
bbaaaaaaababaabbbaabaaabaababaaa
aabbbababaabababbabbbaab
abaabbbbbbaaaaaabbbbbbbabbbbabbbbabbaabb
aabbbbaabbababaabababbba
bababbabaaaabaaabaababaaaaaaaabb
bbbbaababbbabbaabbaabbaaabbbaabbbbabbaabaaaaaabb
bbbbabbabbbbaabaaaabaaaabaaaaabbaaabbbbaabaabbbaaabaaaaaabbaabbb
abbabaaabbaababbaabaaabbbbabbaabbbaabbbb
bbaaabbabbbbbababababaababaaaaaababaaaaaaabbbbab
aababbbaabbbbabaabbabaab
bbbaabbbaaaaabaabbaaaaab
bbabbabbbbaaabbbbbaaaaaababaabbaababbabbabaabbbabbaaaabb
aaabbabaaabaabbbbbaababbbaaaaaababbabaab
abbabbabbbaabbaabbaaabaa
abaabbabaaaabaaaaaaaabab
abbbbaabaabbabbbaabaaabbbaaaaaaa
abbabbaaaababbbabbabbababbaababaabbabaabbbbaaabb
aabaaaaabbbababbbaaababbabbbbababababaaabbabbbba
aaabbabababbbababbbaabbbbaabbbbaaababaaa
aabababbaaabaaaabbababaaaaaababb
abbaaaaaabababbaabaabaababbaaababaababbbaaaababbbabbaaabaabbabbaabbaabba
bbaaaabaaaabbaabbbaaaabaababbbbb
ababbbabbaababbbabaabaababbbababbbaabbaaabaababbabaaaaab
aabaaabaababaabaababaaaa
baabbbbbbaaaaabbbaabbbaa
abbabbabbabbabbbabbbbabaabbbabbb
ababbaabaabbababbbbababbbbbbabaabbabbbabbabbbbaa
bbbabaabbababbabbbabbbaa
aabaabbbaaabbababaabaaababababbbaabababbabaabbbabaaabaabbababbba
abaabaabababaababaabbabb
bbaabbbaaaabbbabaaababaa
bbbbabbbaabbaaaaabaaabba
baaaabbbbbbbaaabbaaaaabbabaabbabaabaabbbbaabbbabaababbaa
bbabaabbbaababbabbaabbaaaaabbbababaabbbaaaaabbab
babaaababbbabbbbabaabaaababaabbb
baaabbaabaaaabaaaaabaabaaaaabaaaaaabababababaaab
bbbbbabbbbaaaaaabaababbababbaaaaabbaabbb
abaaabbbabbbaabbbaaabaab
bbbabbaaaaabaabaaabababaaaabbbabbbbbabbbaababaab
bbbbabbbbaabbabbaabbbbbbabaaababbbbaaabaaaaabaabaabbaaab
baaaabbaaaaababbbbaaaaabbbbbbbaababbbabb
bbaabbbaababbaabbabbabababbbaababaabaaaa
bbbabbbbbaaaabbbabbbbbbaabaabbabbababaab
baababbbaabaabaabbaababaabaaabbbbbbababbbaaaabba
babbabababbbbbabababbbba
aabbbaaabbaaabbaabaaabab
bbbbbbbaabaaabaabbbbbabaabaababbabbabaab
bbaabbbbaaabbaababaaabbabababbbaaaabababbababaaaaabaaaab
babbbabaaabbabaaaabbbaabbabaabab
bbaaaabaaaaaaabbababbaaaababbbbbabaabaaababbabbbabbaaaaaaaaaababaaabbabbbbbbabaa
ababaabbaabbaaaabaaaaabbababbbba
baaaababbbbbaabbbaaabaaa
aababababbbaabbabbaabbbb
baababbaaaabbabbababbaba
babbabaabbbbbbbaaabbbabb
bbbbbbabbbbbbbabbbbbbabbabaaaabb
bbbaabbbbbbbbababababbbb
aabbaaaabbabbabbbbbaabaa
bbababababbbbaabaaabaababbbbaaabaaaabbab
ababbaabaabbbaababbbaababbabbabbaaabbababaabbaabababaaaaaabaaaaa
aabaababbabbbaaaabababbaaaaabbab
abbaaabbaabbaababbbabbbaababaaaa
aabaabaabbbbbabbaabbaabaaabaabaabaabaabbaaaabaaababbaabb
aabaaaabbbbbaaaabaaabbbbbbbbaaabababaaabababbaabbbaabaabaababbaabaaaabab
bbbabbabaaabaaaabababbaabaaabbbabbaabbba
bbaaaabababbbbaabaaabbaababbabbaaabbbababaaaabaaabbbbbbb
bbaabbaaaaaaabaaaaabbbbabbbbbabbbaabaabaaabbbabb
bbaabbbaabbaaaaaaaabaabababababbaabaaaaa
babbababbaabaababaababbabbbbbbabbbbbaabbbaabbbbbbabaabab
ababaabbaabbbaabaaaabbba
aaaabaaaabbabbbabbbbababbbaabbab
aaabaaaaaaabbabaaaaaabbb
bbbbabbaababbaabbbabbabbabaaaabbabaaabba
ababbaabbbabbbbbaaaabbba
abbbbabaaabbbaabbbbaaaabababaaaa
aaabaabaaabbbbbbaaabaababbabbabbbbbabbab
aaabaababaaaaaabbababbabbabaabbaabababbabaabaabaaaababbabbaabbaa
baaabbbabbabbaababbbaaab
aabbabababaabbabaaaaaaba
aabbbabaabbaaaaaaababbaa
bbbbbbabbaaaabaaabbabbabbaaaababbbababaa
aababababaaaaabbaaaaabaabbabbabbabbbabba
bbbbaaababbbbabaabbbaaaa
babababbbabababaabaabbabbbbbbbbbaaaabbaaaababababbabaaab
abaaabbbaabbbaabbbbaaaba
aabbaabbbabaaabaabbabaaabbbbbaba
bbbbaaabaaabaabaababbaabbbababbbabaaabbbabbaabaababaabababbbbabbbababbba
abaaabbbaabbaabbabbabbbabbbaaaaabaaabaabbbbbaabbaaabbbbaabababab
bbabbbbaaabbbabaababbbaaababaabb
aabababbbaabbabaaaaaabab
abaababaabbababaaabbaabbbbbaabbaaaaababa
aaabbbabaababbbabbbaaaabbabbbbaabaaabaaa
"
                .Trim()
                .Split("\n\n");

            rules = input.First()
                .Split("\n")
                .ToDictionary(x => int.Parse(x.Split(":").First()), x => x.Split(":").Last().Trim());

            // Given rule 8 (endless loop of 42) and 11 (endless loop of x times 42 followed by x times 31) are loops
            // rule 0 is defined as "8 11". Any message that is a series of 42 followed by a series of 31 is valid as long
            // as the amount of 42 is bigger than the 31.
            // All possible sequences are 5 char long
            var r31 = ResolveRule(rules[31]).Select(r => r.Replace(" ", "")).ToArray();
            var r42 = ResolveRule(rules[42]).Select(r => r.Replace(" ", "")).ToArray();
            var length = r31.First().Length;

            var msgLines = input.Last().Split("\n");
            msgLines = msgLines.Select(msg =>
            {
                while (r42.Contains(msg.Substring(0, length)))
                {
                    msg = msg.Substring(length) + " 42 ";
                }

                return msg;
            }).ToArray();
            msgLines = msgLines.Select(msg =>
            {
                while (r31.Contains(msg.Substring(0, length)))
                {
                    msg = msg.Substring(length) + " 31 ";
                }

                return msg;
            }).ToArray();

            var matching = msgLines.Where(msg => !msg.Contains("a") && !msg.Contains("b"))
                .Where(msg => msg.Split(" ").Count(n => n == "42") > msg.Split(" ").Count(n => n == "31"))
                .Where(msg => msg.EndsWith(" 31 "));

            Console.WriteLine($"The answer is {matching.Count()}"); // 301
        }

        private static IEnumerable<string> ResolveRule(string rule)
        {
            Console.WriteLine($"Resolving rule {rule}");
            rule = rule.Trim();

            if (resolved.ContainsKey(rule))
            {
                Console.WriteLine($"Cache hit on {rule}");
                return resolved[rule];
            }

            IEnumerable<string> result;
            if (rule.Contains("|"))
            {
                // An or is the result of both sides  resolved
                result = rule.Split(" | ").Select(ResolveRule).SelectMany(x => x);
                resolved.Add(rule, result);
                return result;
            }

            if (rule == "'a'" | rule == "'b'")
            {
                return new string[] { rule.Replace("'", "")};
            }

            var chunks = rule.Split(" ").Select(int.Parse);

            if (chunks.Count() == 1)
            {
                result = ResolveRule(rules[chunks.First()]);
                resolved.Add(rule, result);
                return result;
            }

            if (chunks.Count() == 2)
            {
                var leftSide = ResolveRule(rules[chunks.First()]).ToArray();
                var rightSide = ResolveRule(rules[chunks.Last()]).ToArray();

                var cartesianProduct = new List<string>();

                foreach (var l in leftSide)
                {
                    cartesianProduct.AddRange(rightSide.Select(t => l + " " + t));
                }

                resolved.Add(rule, cartesianProduct);
                return cartesianProduct;
            }

            var resolvedRules = chunks.Select(c => ResolveRule(rules[c])).ToArray();

            result = resolvedRules[0].Select(z =>
                {
                    return resolvedRules[1].Select(o =>
                    {
                        return resolvedRules[2].Select(t => z + " " + o + " " + t);
                    });
                }).SelectMany(x => x)
                .SelectMany(x => x);

            resolved.Add(rule, result);
            return result;

        }
    }
}