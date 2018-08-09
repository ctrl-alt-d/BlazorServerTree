using System;

namespace BlazorServerTree.App.UIHelpers
{
    public class UITreeNode
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public int Deep {get; set;}
        public string Text { get; set; }
        public string OpenIconic { get; set; } = "oi-bug";
        public bool IsExpanded  { get; set; } = false;
        public bool IsSelected  { get; set; } = false;
        public bool ChildrenLoaded { get; set; } = false;
        public bool IsVisible  { get; set; } = true;
        public string IsExpanded_display {
            get {
                return (IsExpanded)?"oi oi-caret-bottom":"oi oi-caret-right";
            }
        }

        public string IsSelected_display {
            get {
                return (IsSelected)?" active ":"";
            }
        } 

    }


}
