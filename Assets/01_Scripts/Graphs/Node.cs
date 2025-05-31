namespace TFG.Graphs
{
    internal struct Node
    {
        private readonly int[] edges;
        public int[] Edges => edges;

        private int visited;
        public int Visited => visited;

        public Node(int[] edges)
        {
            this.edges = edges;
            visited = 0;
        }

        public void Visit()
        {
            visited++;
        }
    }
}