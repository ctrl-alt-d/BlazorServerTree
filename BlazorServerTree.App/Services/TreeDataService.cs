using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BlazorServerTree.App.Services
{
    public class TreeDataService
    {

        /*
        
        Replace this class by your data layer.

        */

        private static List<TreeNode> nodes = new List<TreeNode> { 
                        new TreeNode { Id = 1, ParentId = null, Label = "Label (z) 1", Description = "Hooa", Type = "Unitat" },
                        new TreeNode { Id = 2, ParentId = null, Label = "Label (a) 2", Description = "Hooa 2", Type = "Unitat" },
                        new TreeNode { Id = 10, ParentId = 1, Label = "Label 10", Description = "Hooa 2", Type = "Unitat" } 
                        };

        public Task<TreeNode[]> GetNodesAsync(int? ParentId = null)
        {
            TreeNode[] aux_nodes = nodes.Where(x=>x.ParentId==ParentId).ToArray();
            if (!aux_nodes.Any() ) {
                //some fake data
                var rng = new Random();
                int notesToApped = rng.Next(0, 5);
                aux_nodes = Enumerable
                            .Range(0, notesToApped)
                            .Select( x =>
                                     new TreeNode { Id = ParentId.GetValueOrDefault(0)*10+x, 
                                                    ParentId = ParentId, 
                                                    Label = $"Label (z) {ParentId.GetValueOrDefault(0)*10+x}", 
                                                    Description = "Hooa", 
                                                    Type = "Unitat" }
                                     )
                            .ToArray();
            }
            return Task.FromResult(aux_nodes);
        }
    }
}
