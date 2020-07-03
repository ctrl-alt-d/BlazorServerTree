using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorTreeControl
{
    public class UITree
    {
        public List<UITreeNode> UiNodes { get; set; } = null;

        public void ReArrange(  ) {
            List<UITreeNode> unorderedNodes = UiNodes.Select(x=>x).ToList();
            List<UITreeNode> orderedNodes = new List<UITreeNode>();
            int? currentParentId = null;
            ProcessNode(currentParentId, orderedNodes, unorderedNodes, 0, true);
            UiNodes=orderedNodes;
        }

        private static void ProcessNode(int? currentParentId, 
                                        List<UITreeNode> orderedNodes, 
                                        List<UITreeNode> unorderedNodes, 
                                        int deep,
                                        bool visible )
        {
            int[] nodesToProcess = unorderedNodes
                                  .Where(x=>x.ParentId == currentParentId )
                                  .OrderBy(x=>x.Text )
                                  .Select(x=>x.Id)
                                  .ToArray();
            foreach( int Id in nodesToProcess ) {
                UITreeNode n = unorderedNodes.Where(x=>x.Id == Id).First();
                n.Deep = deep;
                n.IsVisible = visible;
                orderedNodes.Add( n );
                ProcessNode( Id, orderedNodes, unorderedNodes, deep+1, n.IsVisible && n.IsExpanded );
            }
        }        
    }
}
