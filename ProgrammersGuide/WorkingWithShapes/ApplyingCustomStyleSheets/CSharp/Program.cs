//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2013 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Diagram. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Diagram;

namespace ApplyingCustomStyleSheets
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");

            //Load diagram
            Diagram vsdDiagram = new Diagram(dataDir + "Drawing1.vsd");

            Shape sourceShape = null;

            //Find the shape that you want to apply style to
            foreach (Aspose.Diagram.Shape shape in vsdDiagram.Pages[0].Shapes)
            {
                if (shape.Name == "Process")
                {
                    sourceShape = shape;
                    break;
                }
            }

            StyleSheet customStyleSheet = null;

            //Find the required style sheet
            foreach (StyleSheet styleSheet in vsdDiagram.StyleSheets)
            {
                if (styleSheet.Name == "Basic")
                {
                    customStyleSheet = styleSheet;
                    break;
                }
            }

            if (sourceShape != null && customStyleSheet != null)
            {
                //Apply text style
                sourceShape.TextStyle = customStyleSheet;
                //Apply fill style
                sourceShape.FillStyle = customStyleSheet;
                //Apply line style
                sourceShape.LineStyle = customStyleSheet;
            }

            //Save changed diagram as VDX
            vsdDiagram.Save(dataDir + "output.vdx", SaveFileFormat.VDX);
           
 
        }
    }
}