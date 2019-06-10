//*******************************************************************************************//
//                                                                                           //
// Download Free Evaluation Version From: https://bytescout.com/download/web-installer       //
//                                                                                           //
// Also available as Web API! Get Your Free API Key: https://app.pdf.co/signup               //
//                                                                                           //
// Copyright © 2017-2019 ByteScout, Inc. All rights reserved.                                //
// https://www.bytescout.com                                                                 //
// https://pdf.co                                                                            //
//                                                                                           //
//*******************************************************************************************//


using System;
using System.IO;
using Bytescout.PDFExtractor;

namespace BatchProcessing
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Directory containing test files
            String inputFolder = Server.MapPath(@".\bin");

            // Create Bytescout.PDFExtractor.TextExtractor instance
            TextExtractor extractor = new TextExtractor();
            extractor.RegistrationName = "demo";
            extractor.RegistrationKey = "demo";

            Response.Clear();
            Response.ContentType = "text/html";

            // Get PDF files 
            string[] pdfFiles = Directory.GetFiles(inputFolder, "*.pdf");

            foreach (string file in pdfFiles)
            {
                // Load document
                extractor.LoadDocumentFromFile(file);

                Response.Output.Write("<pre>");

                // Extract document text and write to the output stream
                extractor.SaveTextToStream(Response.OutputStream);

                Response.Output.Write("</pre>");
                Response.Output.Write("<br/>");
                
                // Reset the extractor before loading another file
                extractor.Reset();
            }

            Response.End();
        }
    }
}