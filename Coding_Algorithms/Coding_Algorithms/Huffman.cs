using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Algorithms
{
    class Huffman
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

            //Create huffman tree
            List<Node> treeBase = nodes.ToList();
            while (treeBase.Count() > 1)
            {
                treeBase.Sort();
                treeBase.Add(new Node(treeBase[0], treeBase[1]));
                treeBase.RemoveRange(0, 2);
            }
            
            SetCode(treeBase[0]);
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

        //Set code to each char
        private void SetCode(Node node, string code = "")
        {
            node.code = code;
            
            if (node.left != null && node.right != null)
            {
                SetCode(node.left, code + '0');
                SetCode(node.right, code + '1');
            }
        }

        private class Node : IComparable
        {
            public char? c;
            public int probability;
            public Node left;
            public Node right;
            public string code = null;

            public Node(char c)
            {
                this.c = c;
                probability = 1;
                left = null;
                right = null;
            }

            public Node(Node left, Node right)
            {
                c = null;
                probability = left.probability + right.probability;
                this.left = left;
                this.right = right;
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
