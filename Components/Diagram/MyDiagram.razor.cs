using Blazor.Diagrams;
using Blazor.Diagrams.Core.Anchors;
using Blazor.Diagrams.Core.Geometry;
using Blazor.Diagrams.Core.Models;
using Blazor.Diagrams.Core.PathGenerators;
using Blazor.Diagrams.Core.Routers;
using Blazor.Diagrams.Options;

namespace diagrams.Components.Diagram;

public partial class MyDiagram
{
    private BlazorDiagram Diagram { get; set; } = null!;

    protected override void OnInitialized()
    {
        // Diagram containing 2 nodes, 2 ports and one link
        var options = new BlazorDiagramOptions
        {
            AllowMultiSelection = true,
            Zoom =
            {
                Enabled = false,
            },
            Links =
            {
                DefaultRouter = new NormalRouter(),
                DefaultPathGenerator = new SmoothPathGenerator()
            },
        };

        Diagram = new BlazorDiagram(options);

        var firstNode = Diagram.Nodes.Add(new NodeModel(position: new Point(50, 50))
        {
            Title = "Node 1",
        });
        var secondNode = Diagram.Nodes.Add(new NodeModel(position: new Point(200, 100))
        {
            Title = "Node 2"
        });
        var thirdNode = Diagram.Nodes.Add(new NodeModel(position: new Point(400, 150))
        {
            Title = "Node 3"
        });
        var rightPortNode1 = firstNode.AddPort(PortAlignment.Right);
        var leftPortNode2 = secondNode.AddPort(PortAlignment.Left);
        var rightPortNode2 = secondNode.AddPort(PortAlignment.Right);
        var leftPortNode3 = thirdNode.AddPort(PortAlignment.Left);

        // // The connection point will be the intersection of
        // // a line going from the target to the center of the source

        // // var sourceAnchor = new SinglePortAnchor(rightPort);
        // // The connection point will be the port's position

        var link1 = Diagram.Links.Add(new LinkModel(new ShapeIntersectionAnchor(firstNode), new SinglePortAnchor(leftPortNode2)));
        var link2 = Diagram.Links.Add(new LinkModel(new SinglePortAnchor(rightPortNode2), new SinglePortAnchor(leftPortNode3)));
    }
}
