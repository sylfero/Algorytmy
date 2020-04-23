using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Algorithms
{
    class Shannon_Fano
    {
        private List<Node> nodes;

        public string Encode(string text)
        {
            nodes = new List<Node>();

            //Set probability to characters in text
            foreach (char c in text)
            {
                Node currNode = nodes.Find(x => x.c == c);

                if (currNode != null)
                    currNode.probability++;
                else
                    nodes.Add(new Node(c));
            }

            nodes.Sort((x, y) => y.CompareTo(x));
            Node root = GetTree(nodes);
            
            StringBuilder output = new StringBuilder();
            foreach (char c in text)
            {
                output.Append(nodes.Find(x => x.c == c).code);
            }

            return output.ToString();
        }

        public string Decode(string code)
        {
            StringBuilder output = new StringBuilder();
            int jumpLength = 0;

            while (jumpLength < code.Length)
            {
                int codeLength = 1;
                while (true)
                {
                    char? c = nodes.Find(x => x.code == code.Substring(jumpLength, codeLength))?.c;
                    if (c != null)
                    {
                        output.Append(c);
                        jumpLength += codeLength;
                        codeLength = 1;
                        break;
                    }
                    else
                    {
                        codeLength++;
                    }
                }
            }
            return output.ToString();
        }

        private Node GetTree(List<Node> nodes, string code = "")
        {
            Node currNode = new Node(code);

            if (nodes.Count > 2)
            {
                currNode.left = GetTree(nodes.GetRange(0, nodes.Count / 2), code + '0');
                currNode.right = GetTree(nodes.GetRange(nodes.Count / 2, (int)Math.Ceiling(nodes.Count / 2.0)), code + '1');
            }
            else if (nodes.Count == 2)
            {
                currNode.left = nodes[0];
                currNode.right = nodes[1];
                currNode.left.code = code + '0';
                currNode.right.code = code + '1';
            }
            else if (nodes.Count == 1)
            {
                currNode = nodes[0];
                currNode.code = code;
            }
            return currNode;
        }

        private class Node : IComparable
        {
            public char? c;
            public int probability;
            public Node left = null;
            public Node right = null;
            public string code;

            public Node(char c)
            {
                this.c = c;
                probability = 1;
                code = null;
            }

            public Node(string code)
            {
                c = null;
                probability = 0;
                this.code = code;
            }

            public int CompareTo(object obj)
            {
                if (obj == null) return 1;

                Node node = (Node)obj;

                if (node != null)
                {
                    return probability.CompareTo(node.probability);
                }
                else
                {
                    throw new ArgumentException("Object is not a Node");
                }
            }
        }
    }
}
