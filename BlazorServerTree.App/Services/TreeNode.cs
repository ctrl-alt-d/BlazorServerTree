using System;

namespace BlazorServerTree.App.Services
{
    public class TreeNode
    {

        /*
        
        Replace this class with your model

        */

        public DateTime Date { get; set; }
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
}
