# BlazorServerTree

A simple Server-Side Blazor sample app to deal with hierarchical data.

The project has a fake data layer service that allow running it without database backend configuration.

The basic functionality is ready:

* Unexpand nodes and expand nodes with Lazy load.
* Select and unselect a node.


### Screenshot ( because all us love screenshots ):

![screenshot](./screenshots/screenshot_smallv2.gif)

### Show me the code

```
    <UITreeComponent SourceData=@uiTree
                     SelectChangeDelegate=@OnSelectionChanged
                     LazyLoadNodesAsyncDelegate=@LoadNodes
                     CollapseAsyncDelegate=@OnCollapse
                     ExpandAsyncDelegate=@OnExpand
                     TriggerActionAsyncDelegate=@OnAction>
    </UITreeComponent>  

@functions {

    //UITreeComponent myUiTree;
    UITree uiTree = new UITree();


    private async Task<bool> OnExpand(int Id)
    {
        System.Console.WriteLine("Expanded " + Id);
        return await Task.FromResult(true);
    }

```


Don't hesitate to contact me for further information :)

