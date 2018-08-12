using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorServerTree.App.UIHelpers
{
    public class UITree
    {
        public List<UITreeNode> uiNodes { get; set; } = null;

        public void ReArrange(  ) {
            List<UITreeNode> unorderedNodes = uiNodes.Select(x=>x).ToList();
            List<UITreeNode> orderedNodes = new List<UITreeNode>();
            int? currentParentId = null;
            processNode(currentParentId, orderedNodes, unorderedNodes, 0, true);
            uiNodes=orderedNodes;
        }

        private static void processNode(int? currentParentId, 
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
                processNode( Id, orderedNodes, unorderedNodes, deep+1, n.IsVisible && n.IsExpanded );
            }
        }        
    }
}
