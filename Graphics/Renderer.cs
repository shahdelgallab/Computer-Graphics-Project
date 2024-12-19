using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace Graphics
{
    class Renderer
    {
        Shader sh;
        uint vertexBufferID;
        uint IndexBufferID;

        public void Initialize()
        {
            string projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            sh = new Shader(projectPath + "\\Shaders\\SimpleVertexShader.vertexshader", projectPath + "\\Shaders\\SimpleFragmentShader.fragmentshader");

            Gl.glClearColor(0.235f, 0.702f, 0.671f, 1);

            float[] verts = { 

                // Clipbaord
		        0.20f, 0.78f, 0.0f,         //0
                0.376f,0.396f,0.655f,       
                0.75f, .78f, 0.0f,          //1
                0.376f,0.396f,0.655f,
                0.75f, -0.27f, 0.0f,        //2
                0.376f,0.396f,0.655f,
                0.20f, -0.27f, 0.0f,        //3
                0.376f,0.396f,0.655f,

                // Dark purple
                0.30f, 0.78f, 0.0f,         //4
                0.314f, 0.337f, 0.573f,     
                0.65f, 0.78f, 0.0f,         //5
                0.314f, 0.337f, 0.573f,
                0.65f, 0.68f, 0.0f,         //6
                0.314f, 0.337f, 0.573f,
                0.30f, 0.68f, 0.0f,         //7
                0.314f, 0.337f, 0.573f,

                // Above dark purple
                0.44f, 0.84f, 0.0f,         //8
                0.376f,0.396f,0.655f,
                0.50f, 0.84f, 0.0f,         //9
                0.376f,0.396f,0.655f,
                0.50f, 0.73f, 0.0f,         //10
                0.376f,0.396f,0.655f,
                0.44f, 0.73f, 0.0f,         //11
                0.376f,0.396f,0.655f,       


                // Paper
                0.24f, 0.72f, 0.0f,     //12
                1,1,1,
                0.71f, .72f, 0.0f,      //13
                1,1,1,
                0.71f, -0.2f, 0.0f,     //14
                1,1,1,
                0.24f, -0.2f, 0.0f,     //15
                1,1,1,
		
                // lines 
                0.35f, 0.50f, 0.0f,     //16
                0.314f, 0.337f, 0.573f,
                0.64f, 0.50f, 0.0f,     //17
                0.314f, 0.337f, 0.573f,
                0.35f, 0.505f, 0.0f,     //18
                0.376f,0.396f,0.655f,
                0.64f, 0.505f, 0.0f,     //19
                0.314f, 0.337f, 0.573f,

                0.35f, 0.35f, 0.0f,     //20
                0.314f, 0.337f, 0.573f,
                0.64f, 0.35f, 0.0f,     //21
                0.314f, 0.337f, 0.573f,
                0.35f, 0.355f, 0.0f,     //22
                0.314f, 0.337f, 0.573f,
                0.64f, 0.355f, 0.0f,     //23
                0.314f, 0.337f, 0.573f,

                0.35f, 0.20f, 0.0f,     //24
                0.314f, 0.337f, 0.573f,
                0.64f, 0.20f, 0.0f,     //25
                0.314f, 0.337f, 0.573f,
                0.35f, 0.205f, 0.0f,     //26
                0.314f, 0.337f, 0.573f,
                0.64f, 0.205f, 0.0f,     //27
                0.314f, 0.337f, 0.573f,

                0.35f, 0.05f, 0.0f,     //28
                0.314f, 0.337f, 0.573f,
                0.64f, 0.05f, 0.0f,     //29
                0.314f, 0.337f, 0.573f,
                0.35f, 0.055f, 0.0f,     //30
                0.314f, 0.337f, 0.573f,
                0.64f, 0.055f, 0.0f,     //31
                0.314f, 0.337f, 0.573f,

                // Checkbox
                0.265f, 0.45f, 0.0f,     //32
                0.314f, 0.337f, 0.573f,
                0.32f, 0.45f, 0.0f,     //33
                0.314f, 0.337f, 0.573f,
                0.32f, 0.55f, 0.0f,     //34
                0.314f, 0.337f, 0.573f,
                0.265f, 0.55f, 0.0f,     //35
                0.314f, 0.337f, 0.573f,

                0.265f, 0.30f, 0.0f,     //36
                0.314f, 0.337f, 0.573f,
                0.32f, 0.30f, 0.0f,     //37
                0.314f, 0.337f, 0.573f,
                0.32f, 0.40f, 0.0f,     //38
                0.314f, 0.337f, 0.573f,
                0.265f, 0.40f, 0.0f,     //39
                0.314f, 0.337f, 0.573f,

                0.265f, 0.15f, 0.0f,     //40
                0.314f, 0.337f, 0.573f,
                0.32f, 0.15f, 0.0f,     //41
                0.314f, 0.337f, 0.573f,
                0.32f, 0.25f, 0.0f,     //42
                0.314f, 0.337f, 0.573f,
                0.265f, 0.25f, 0.0f,     //43
                0.314f, 0.337f, 0.573f,

                0.265f, 0.0f, 0.0f,     //44
                0.314f, 0.337f, 0.573f,
                0.32f, 0.0f, 0.0f,     //45
                0.314f, 0.337f, 0.573f,
                0.32f, 0.10f, 0.0f,     //46
                0.314f, 0.337f, 0.573f,
                0.265f, 0.10f, 0.0f,     //47
                0.314f, 0.337f, 0.573f,

                //pen 
                //body
                0.52f, -0.18f, 0.0f,    //48
                0.945f, 0.745f, 0.364f,
                0.72f, -0.18f, 0.0f,
                0.945f, 0.745f, 0.364f,
                0.72f, -0.30f, 0.0f,
                0.945f, 0.745f, 0.364f,
                0.52f, -0.30f, 0.0f,
                0.945f, 0.745f, 0.364f,

                //Ruber
                0.72f, -0.18f, 0.0f,     //52
                0.953f, 0.365f, 0.306f,
                0.78f, -0.18f, 0.0f,
                0.953f, 0.365f, 0.306f,
                0.78f, -0.3f, 0.0f,
                0.953f, 0.365f, 0.306f,
                0.72f, -0.3f, 0.0f,
                0.953f, 0.365f, 0.306f,


                //Front
                0.52f, -0.18f, 0.0f,    //56
                0.8627f, 0.8f, 0.7412f,
                0.52f, -0.3f, 0.0f,
                0.8627f, 0.8f, 0.7412f,
                0.45f, -0.24f, 0.0f,
                0.8627f, 0.8f, 0.7412f,

                0.46f, -0.24f, 0.0f,
                .22f, .22f, .22f,
                0.43f, -0.24f, 0.0f,
                .22f, .22f, .22f,

            };

            vertexBufferID = GPU.GenerateBuffer(verts);

            // Array of indices
            ushort[] indices = { 0, 1, 2, 1, 2, 3 };
            IndexBufferID = GPU.GenerateElementBuffer(indices);

        }

        public void Draw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            sh.UseShader();

            Gl.glEnableVertexAttribArray(0);
            Gl.glEnableVertexAttribArray(2);

            //// Positions of points
            //Gl.glVertexAttribPointer(0, 3, Gl.GL_FLOAT, Gl.GL_FALSE, 0, IntPtr.Zero);
            Gl.glVertexAttribPointer(0, 3, Gl.GL_FLOAT, Gl.GL_FALSE, sizeof(float) * 6, IntPtr.Zero);

            //// Color 
            Gl.glVertexAttribPointer(2, 3, Gl.GL_FLOAT, Gl.GL_FALSE, sizeof(float) * 6, (IntPtr)(sizeof(float) * 3));


            //Gl.glDrawArrays(Gl.GL_TRIANGLES, 0, 6);

            Gl.glDrawElements(Gl.GL_TRIANGLES, 6, Gl.GL_UNSIGNED_SHORT, IntPtr.Zero);


            Gl.glDrawArrays(Gl.GL_POLYGON, 48, 4);
            Gl.glDrawArrays(Gl.GL_POLYGON, 0, 4);
            Gl.glDrawArrays(Gl.GL_POLYGON, 12, 4);
            Gl.glDrawArrays(Gl.GL_POLYGON, 4, 4);
            Gl.glDrawArrays(Gl.GL_POLYGON, 8, 4);

            //Lines
            Gl.glDrawArrays(Gl.GL_LINE_STRIP, 16, 2);
            Gl.glDrawArrays(Gl.GL_LINE_STRIP, 18, 2);
            Gl.glDrawArrays(Gl.GL_LINE_STRIP, 20, 2);
            Gl.glDrawArrays(Gl.GL_LINE_STRIP, 22, 2);
            Gl.glDrawArrays(Gl.GL_LINE_STRIP, 24, 2);
            Gl.glDrawArrays(Gl.GL_LINE_STRIP, 26, 2);
            Gl.glDrawArrays(Gl.GL_LINE_STRIP, 28, 2);
            Gl.glDrawArrays(Gl.GL_LINE_STRIP, 30, 2);

            //Checkbox
            Gl.glDrawArrays(Gl.GL_LINE_LOOP, 32, 4);
            Gl.glDrawArrays(Gl.GL_LINE_LOOP, 36, 4);
            Gl.glDrawArrays(Gl.GL_LINE_LOOP, 40, 4);
            Gl.glDrawArrays(Gl.GL_LINE_LOOP, 44, 4);

            //Pen
            Gl.glDrawArrays(Gl.GL_POLYGON, 48, 4);
            Gl.glDrawArrays(Gl.GL_POLYGON, 52, 4);
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 56, 3);
            Gl.glDrawArrays(Gl.GL_LINE_STRIP, 59, 2);

        }

        public void Update()
        {

        }
        public void CleanUp()
        {
            sh.DestroyShader();
        }
    }
}
