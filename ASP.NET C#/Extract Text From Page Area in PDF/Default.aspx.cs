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
using System.Drawing;
using Bytescout.PDFExtractor;

namespace ExtractTextFromPageArea
{
	public partial class _Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			String inputFile = Server.MapPath(@".\bin\columns.pdf");

			// Create Bytescout.PDFExtractor.TextExtractor instance
			TextExtractor extractor = new TextExtractor();
			extractor.RegistrationName = "demo";
			extractor.RegistrationKey = "demo";
			
			// Load sample PDF document
			extractor.LoadDocumentFromFile(inputFile);

			// Get dimensions of the first document page
			RectangleF rectangle = extractor.GetPageRectangle(0);

			// Get text from the 1/3 of the page

			rectangle.Width = rectangle.Width / 3f;
			
			Response.Clear();
			Response.ContentType = "text/html";

			extractor.SetExtractionArea(rectangle);

			Response.Write("<pre>");

			// Save extracted text to output stream
			extractor.SavePageTextToStream(0, Response.OutputStream);

			Response.Write("</pre>");
			
			Response.End();
		}
	}
}
