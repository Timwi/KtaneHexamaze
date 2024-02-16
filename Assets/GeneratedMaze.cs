﻿using System.Linq;
using UnityEngine;

namespace Hexamaze
{
    sealed class GeneratedMaze
    {
        private readonly bool[] _walls;
        private readonly Marking[] _markings;
        public GeneratedMaze(bool[] walls, Marking[] markings)
        {
            _walls = walls;
            _markings = markings;
        }

        public Marking GetMarking(Hex hex)
        {
            return _markings[markingIndex(hex)];
        }

        public bool HasWall(Hex hex, int dir)
        {
            var ix = wallIndex(hex, dir);
            if (ix < 0 || ix >= _walls.Length)
                Debug.LogFormat("<> {0}, {1}", ix, _walls.Length);
            return _walls[ix];
        }

        private static int markingIndex(Hex h)
        {
            return (h.Q + HexamazeRuleGenerator.Size) * HexamazeRuleGenerator.sw + h.R + HexamazeRuleGenerator.Size;
        }

        private static int wallIndex(Hex hex, int dir)
        {
            return dir < 3
                ? 3 * HexamazeRuleGenerator.sw * (hex.Q + HexamazeRuleGenerator.Size) + 3 * (hex.R + HexamazeRuleGenerator.Size) + dir
                : wallIndex(hex.GetNeighbor(dir), dir - 3);
        }

        public static readonly GeneratedMaze Default = new GeneratedMaze(
            new[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, true, false, false, true, false, false, true, false, false, false, false, false, true, false, false, true, false, false, true, false, false, true, false, false, true, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, true, true, false, true, true, true, true, false, false, true, true, false, true, true, false, true, false, true, false, false, true, true, false, false, true, false, true, true, false, true, true, true, false, false, true, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, true, true, false, true, true, false, true, true, false, false, true, true, false, true, true, false, true, false, true, true, false, false, true, true, false, true, true, false, true, true, true, true, true, true, true, true, false, false, true, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, false, true, true, true, true, true, true, true, true, false, true, false, true, true, false, true, true, true, true, true, true, true, true, true, true, true, true, false, true, true, true, false, true, true, false, false, true, true, true, true, false, true, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, true, true, true, true, false, true, true, false, true, true, true, false, true, true, false, true, false, true, true, false, false, true, false, false, true, false, true, false, true, false, false, false, false, true, false, false, true, true, true, false, false, false, true, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, false, false, true, true, false, true, true, false, true, true, false, true, true, true, true, false, false, true, true, false, true, true, true, true, false, false, true, false, true, true, false, true, true, false, true, false, false, false, true, false, true, true, false, false, true, true, false, true, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, false, false, true, true, false, true, true, false, true, false, false, false, true, false, true, false, false, true, false, false, false, true, false, false, true, false, false, false, true, true, false, true, true, false, true, true, false, true, true, false, true, false, true, true, false, true, false, true, true, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, false, true, false, true, false, true, true, false, false, false, true, true, false, false, false, false, true, true, false, true, false, true, true, false, true, true, false, false, true, true, false, true, false, false, true, true, false, false, true, true, true, false, true, true, false, true, true, false, false, false, true, false, false, true, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, true, true, false, false, true, true, true, true, true, true, true, false, true, true, false, true, true, false, false, true, true, true, false, true, true, false, true, true, false, false, true, true, false, false, true, false, false, true, false, false, false, true, true, false, false, true, true, false, true, false, true, true, false, true, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, false, true, true, false, false, true, false, false, false, true, false, false, false, true, true, true, true, false, true, false, true, true, false, true, true, false, true, true, true, true, false, true, true, false, true, true, false, true, true, false, true, false, true, true, false, false, true, true, false, true, false, true, true, true, false, true, false, true, false, true, true, false, false, false, false, false, false, false, false, false, true, true, true, true, false, false, true, true, false, true, true, true, true, false, true, true, false, true, false, false, true, false, true, true, false, true, true, false, true, true, false, true, true, true, true, false, true, true, false, true, true, false, false, true, false, true, true, false, true, true, false, true, false, true, true, false, true, true, true, false, false, true, true, false, true, true, false, false, false, false, false, false, true, true, false, true, false, false, true, true, false, true, true, false, false, false, false, false, true, true, true, false, true, false, false, true, false, false, true, false, false, false, false, false, true, false, false, true, true, false, true, false, true, true, true, true, false, false, true, true, false, true, true, true, false, true, false, true, false, true, false, true, true, false, true, true, false, true, false, true, true, false, false, false, false, true, true, true, true, true, true, false, true, true, true, true, true, true, false, false, true, true, false, true, true, true, false, true, true, false, true, true, false, false, false, true, false, true, false, true, true, false, false, false, false, true, false, false, true, true, false, true, false, false, true, false, true, true, true, false, true, true, false, true, true, false, false, true, false, true, false, true, true, false, true, false, false, false, false, true, true, true, true, false, true, false, false, false, false, true, false, true, true, false, false, false, false, false, true, true, true, false, true, true, false, true, true, true, false, true, false, true, true, false, true, false, true, true, true, false, true, true, false, true, true, false, true, false, false, false, false, false, true, true, false, true, true, true, false, true, true, false, true, true, false, true, true, false, false, false, false, false, false, false, true, true, true, true, false, true, false, true, true, true, false, false, true, true, false, false, true, true, false, false, true, false, true, true, false, true, true, true, false, true, false, false, false, false, true, false, false, true, true, false, true, false, true, false, false, true, false, true, false, true, false, true, false, true, true, false, true, false, true, true, true, false, true, true, true, false, false, false, false, false, false, false, false, false, false, false, true, false, true, true, true, true, false, false, true, true, false, false, true, false, true, false, false, false, false, false, false, true, true, false, true, true, true, false, true, false, true, true, false, true, true, false, true, true, true, false, true, true, false, true, true, false, false, false, true, true, true, false, true, true, false, true, false, true, true, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, true, true, true, true, false, false, true, true, true, true, true, true, true, true, true, false, false, false, false, false, false, false, false, true, false, false, false, false, true, true, false, true, true, false, false, true, false, false, true, true, true, false, true, false, true, false, false, true, false, true, true, true, false, true, true, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, true, true, false, true, true, false, false, false, true, false, true, true, true, false, false, true, true, false, true, false, false, true, false, false, false, true, false, false, false, true, false, true, false, false, false, true, true, true, false, false, true, false, false, true, true, false, true, true, false, true, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, false, true, false, true, true, false, false, false, true, true, false, true, true, false, true, true, true, false, true, true, false, true, true, false, false, true, true, false, true, true, false, true, false, true, true, false, true, true, false, true, false, true, true, false, true, true, true, false, true, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, true, true, true, true, true, true, true, false, false, true, true, false, false, true, false, false, true, true, false, true, true, false, false, true, true, false, true, true, true, false, true, true, false, true, true, false, true, true, false, true, true, false, true, false, true, true, true, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, true, false, false, true, false, true, true, true, true, true, true, true, false, true, true, false, true, false, true, false, true, false, false, false, false, false, true, false, true, false, false, false, false, true, false, true, true, false, true, true, true, false, false, true, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, true, false, false, true, false, true, true, true, true, false, false, true, true, false, true, false, true, true, false, true, true, false, false, true, true, true, true, false, true, false, true, true, false, true, false, false, false, true, true, true, true, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, false, true, true, false, true, false, false, true, false, true, true, true, true, true, false, true, true, false, false, true, false, true, true, false, false, true, false, true, false, false, true, true, false, true, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, true, true, true, true, true, false, true, false, true, false, true, true, true, true, true, true, true, true, true, false, true, true, true, true, true, true, true, true, true, true, true, true, true, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, true, false, false, true, false, false, true, false, false, true, false, false, true, false, false, true, false, false, true, false, false, false, false, false, true, false, false, true, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false },
            new[] { Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.Hexagon, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.TriangleLeft, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.Circle, Marking.None, Marking.None, Marking.Circle, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.Hexagon, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.TriangleDown, Marking.None, Marking.None, Marking.None, Marking.TriangleUp, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.Circle, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.TriangleRight, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.TriangleRight, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.Hexagon, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.TriangleUp, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.Circle, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.Hexagon, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.Circle, Marking.None, Marking.None, Marking.None, Marking.TriangleDown, Marking.None, Marking.None, Marking.None, Marking.TriangleRight, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.TriangleLeft, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.Hexagon, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None, Marking.None });

        public void __Debug_ASCIImaze(int moduleId)
        {
            var w = 6 * HexamazeRuleGenerator.Size - 2;
            var h = 4 * HexamazeRuleGenerator.Size - 1;
            var chs = new char[w, h];
            for (var x = 0; x < w; x++)
                for (var y = 0; y < h; y++)
                    chs[x, y] = ' ';

            // Walls
            for (var ix = 0; ix < _walls.Length; ix++)
            {
                if (!_walls[ix])
                    continue;

                var dir = ix % 3;
                var r = (ix / 3) % HexamazeRuleGenerator.sw - HexamazeRuleGenerator.Size;
                var q = (ix / 3) / HexamazeRuleGenerator.sw - HexamazeRuleGenerator.Size;
                switch (dir)
                {
                    // NW wall
                    case 0:
                        chs[w / 2 + 3 * q - 2, h / 2 + q + 2 * r] = '/';
                        break;

                    // N wall
                    case 1:
                    {
                        chs[w / 2 + 3 * q - 1, h / 2 + q + 2 * r - 1] = '_';
                        chs[w / 2 + 3 * q, h / 2 + q + 2 * r - 1] = '_';
                    }
                    break;

                    // NE wall
                    case 2:
                        chs[w / 2 + 3 * q + 1, h / 2 + q + 2 * r] = '\\';
                        break;
                }
            }

            // Markings
            foreach (var hex in Hex.LargeHexagon(HexamazeRuleGenerator.Size))
            {
                var m = _markings[markingIndex(hex)];
                if (m != Marking.None)
                {
                    chs[w / 2 + 3 * hex.Q - 1, h / 2 + hex.Q + 2 * hex.R] = " (/\\<|{"[(int) m];
                    chs[w / 2 + 3 * hex.Q, h / 2 + hex.Q + 2 * hex.R] = " )\\/|>}"[(int) m];
                }
            }
            Debug.LogFormat("<Hexamaze #{0}>\n{1}", moduleId, Enumerable.Range(0, h).Select(y => Enumerable.Range(0, w).Select(x => chs[x, y]).Join("")).Join("\n"));
        }
    }
}
