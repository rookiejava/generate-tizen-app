using System.Collections.Generic;
using System.Runtime.InteropServices;
using Tizen.UI;
using Tizen.UI.Internal;
using Tizen.UI.Layouts;

namespace TizenUIGallery.TC
{
    public class RendererTest1 : Grid, ITestCase
    {
        Renderer _customRenderer;
        public RendererTest1()
        {
            WidthResizePolicy = ResizePolicy.FillToParent;
            HeightResizePolicy = ResizePolicy.FillToParent;
            BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 1f);

            RowDefinitions.Add(100);
            RowDefinitions.Add(GridLength.Star);
            ColumnDefinitions.Add(GridLength.Star);

            Add(new TextView
            {
                BackgroundColor = Color.FromHex("#D1FFBD"),
                VerticalAlignment = TextAlignment.Center,
                HorizontalAlignment = TextAlignment.Center,
                Text = "Renderer Test1",
                FontSize = 30,
            });

            var mask = new ViewGroup()
            {
                ClippingMode = ClippingMode.ClipChildren,
            }.Row(1);

            Geometry geometry = CreateTriGeometry();
            Shader shader = new Shader(VERTEX_SHADER, FRAGMENT_SHADER);
            _customRenderer = new Renderer(geometry, shader);
            mask.AddRenderer(_customRenderer);

            ImageView target = new ImageView
            {
                WidthResizePolicy = ResizePolicy.FillToParent,
                HeightResizePolicy = ResizePolicy.FillToParent,
                ResourceUrl = "image2.jpg"
            };
            mask.Add(target);
            Add(mask);

        }


        [StructLayout(LayoutKind.Sequential)]
        private struct Vertex
        {
            public Vec2 pos;
        };
        [StructLayout(LayoutKind.Sequential)]
        private struct Vec2
        {
            float x;
            float y;
            public Vec2(float xx, float yy)
            {
                x = xx;
                y = yy;
            }
        };
        Geometry CreateTriGeometry()
        {
            Vertex[] vertices = new Vertex[3];
            vertices[0] = new Vertex(); vertices[0].pos = new Vec2(0.0f, -0.5f);
            vertices[1] = new Vertex(); vertices[1].pos = new Vec2(-0.5f, 0.5f);
            vertices[2] = new Vertex(); vertices[2].pos = new Vec2(0.5f, 0.5f);

            VertexBuffer vertexBuffer = new VertexBuffer(new Dictionary<string, DaliPropertyType>()
            {
                { "aPosition", DaliPropertyType.Vector2 }
            });

            vertexBuffer.SetData(vertices);

            Geometry geometry = new Geometry();
            geometry.AddVertexBuffer(vertexBuffer);
            geometry.GeometryType = GeometryType.TRIANGLE_STRIP;

            return geometry;
        }
        string VERTEX_SHADER =
            "attribute mediump vec2 aPosition;\n" +
            "uniform   highp   mat4 uMvpMatrix;\n" +
            "uniform   mediump vec3 uSize;\n" +
            "\n" +
            "varying mediump vec2 vTexCoord;\n" +
            "\n" +
            "void main(){\n" +
            "  mediump vec4 vertexPosition = vec4(aPosition, 0.0, 1.0);\n" +
            "  vTexCoord = aPosition + vec2(0.5);\n" +
            "  vertexPosition.xyz *= uSize;\n" +
            "  gl_Position = uMvpMatrix * vertexPosition;\n" +
            "}\n" +
            "";
        string FRAGMENT_SHADER = "" +
            "uniform sampler2D uTexture;\n" +
            "varying mediump vec2 vTexCoord;\n" +
            "\n" +
            "void main(){\n" +
            "  gl_FragColor = vec4(1.0, 1.0, 1.0, 1.0);\n" +
            "}\n" +
            "";

        public void Activate()
        {
            Window.Default.DefaultLayer.Add(this);
        }

        public void Deactivate()
        {
            Dispose();
        }
    }
}
