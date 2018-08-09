using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorServerTree.App.UIHelpers
{
    public class UITreeHelper
    {
        static public List<UITreeNode> ReArrange( List<UITreeNode> unorderedNodes ) {
            List<UITreeNode> orderedNodes = new List<UITreeNode>();
            int? currentParentId = null;
            processNode(currentParentId, orderedNodes, unorderedNodes, 0, true);
            return orderedNodes;
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
