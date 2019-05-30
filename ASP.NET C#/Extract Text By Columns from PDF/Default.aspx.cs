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
using Bytescout.PDFExtractor;

namespace ExtractTextByColumns
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

			// Extract text by columns (useful if PDF document is designed in column layout like a newspaper)
			extractor.ExtractColumnByColumn = true;
			
			// Load sample PDF document
			extractor.LoadDocumentFromFile(inputFile);
			
			Response.Clear();
			Response.ContentType = "text/html";

			Response.Write("<pre>");

			// Save extracted text to output stream
			extractor.SaveTextToStream(Response.OutputStream);

			Response.Write("</pre>");

			Response.End();
		}
	}
}
