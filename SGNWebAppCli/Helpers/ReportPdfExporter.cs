using iTextSharp.text;
using iTextSharp.text.pdf;
using SGNWebAppCli.Data;
using SGNWebAppCli.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SGNWebAppCli.Helpers
{
    /// <summary>
    /// Pdf Footer section definition
    /// </summary>
    public class PdfFooterContent : PdfPageEventHelper
    {
        private readonly Font _pageNumberFont = new Font(Font.NORMAL, 8f, Font.NORMAL, BaseColor.Black);

        public override void OnStartPage(PdfWriter writer, Document document)
        {
            this.AddHeaderDate(writer, document);
        }
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            this.AddPageNumber(writer, document);
        }

        /// <summary>
        /// page number and datetime
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="document"></param>
        public void AddPageNumber(PdfWriter writer, Document document)
        {
            var numberTable = new PdfPTable(1);
            string text = "strona: " + writer.PageNumber.ToString("00"),
                text1 = " Dnia: " + DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss");

            var pdfCell = new PdfPCell(new Phrase(text, _pageNumberFont));
            pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            pdfCell.Border = 0;

            numberTable.AddCell(pdfCell);

            pdfCell = new PdfPCell(new Phrase(text1, _pageNumberFont));
            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell.Border = 0;

            numberTable.AddCell(pdfCell);

            numberTable.TotalWidth = 450;
            numberTable.WriteSelectedRows(0, -1, document.Left + 80, document.Bottom, writer.DirectContent);

        }
        public void AddHeaderDate(PdfWriter writer, Document document)
        {

        }
    }



    public class RptPdf<T> : PdfFooterContent where T : new()
    {
        #region Declaration
        int _maxColumn = 6;
        Document _document;
        PdfPTable _pdfTable = new PdfPTable(6);
        PdfPCell _pdfCell;
        Font _fontStyle;
        MemoryStream _memoryStream = new MemoryStream();
        PdfWriter _pdfWriter;
        List<T> _incommingCollection = new List<T>();

        #endregion

        #region polish characters in pdf

        private Font GetFont(string fontNameWithExt, int fontSize = 10)
        {
            var fontLocation = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\pdfSupportFonts\" + fontNameWithExt}";
            BaseFont baseFontDef = BaseFont.CreateFont(fontLocation, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            Font fontSupport = new Font(baseFontDef, fontSize);
            return fontSupport;
        }

        #endregion


        public byte[] Report(List<T> incommingCollection, string ReportTitle)
        {
            _incommingCollection = incommingCollection;
            _document = new Document(PageSize.A4, 10f, 10f, 20f, 30f);
            _pdfTable.WidthPercentage = 100;
            _pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

            _pdfWriter = PdfWriter.GetInstance(_document, _memoryStream);
            _pdfWriter.PageEvent = new PdfFooterContent();
            _document.Open();

            float[] sizes = new float[6];

            for (int i = 0; i < _maxColumn; i++)
            {
                if (i == 0)
                    sizes[i] = 50;
                else
                    sizes[i] = 100;
            }

            _pdfTable.SetWidths(sizes);

            this.ReportHeader(ReportTitle);
            this.ReportBody();

            _pdfTable.HeaderRows = 2;
            _document.Add(_pdfTable);
            this.OnEndPage(_pdfWriter, _document);

            _document.Close();
            return _memoryStream.ToArray();
        }

        private void ReportHeader(string RepTitle)
        {
            _pdfCell = new PdfPCell(new Phrase(RepTitle, this.GetFont("arialuni.ttf", 16)));
            _pdfCell.Colspan = _maxColumn;
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.Border = 0;
            _pdfCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfCell);
            _pdfTable.CompleteRow();
        }

        private void ReportBody()
        {

            _fontStyle = this.GetFont("arialuni.ttf", 12);
            var fontStyle = this.GetFont("arialuni.ttf");

            #region Table Header
            _pdfCell = new PdfPCell(new Phrase("Id", _fontStyle));
            _pdfCell.Colspan = 0;
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.Gray;
            _pdfTable.AddCell(_pdfCell);


            _pdfCell = new PdfPCell(new Phrase("Nazwa", _fontStyle));
            _pdfCell.Colspan = 0;
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.Gray;
            _pdfTable.AddCell(_pdfCell);


            _pdfCell = new PdfPCell(new Phrase("Sukces", _fontStyle));
            _pdfCell.Colspan = 0;
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.Gray;
            _pdfTable.AddCell(_pdfCell);


            _pdfCell = new PdfPCell(new Phrase("Opis błędu", _fontStyle));
            _pdfCell.Colspan = 0;
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.Gray;
            _pdfTable.AddCell(_pdfCell);

            _pdfCell = new PdfPCell(new Phrase("Data", _fontStyle));
            _pdfCell.Colspan = 0;
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.Gray;
            _pdfTable.AddCell(_pdfCell);

            _pdfCell = new PdfPCell(new Phrase("Historia zliczenia", _fontStyle));
            _pdfCell.Colspan = 0;
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.Gray;
            _pdfTable.AddCell(_pdfCell);


            _pdfTable.CompleteRow();
            #endregion

            #region Table Body
            var xx = (_incommingCollection as List<FileHistory>);
            foreach (var item in xx)
            {
                _pdfCell = new PdfPCell(new Phrase(item.IdFileHistory.ToString(), fontStyle));
                _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfCell.BackgroundColor = BaseColor.White;
                _pdfTable.AddCell(_pdfCell);


                _pdfCell = new PdfPCell(new Phrase(item.FileName, fontStyle));
                _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfCell.BackgroundColor = BaseColor.White;
                _pdfTable.AddCell(_pdfCell);


                _pdfCell = new PdfPCell(new Phrase(item.IsProceededSuccess.ToString(), fontStyle));
                _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfCell.BackgroundColor = BaseColor.White;
                _pdfTable.AddCell(_pdfCell);


                _pdfCell = new PdfPCell(new Phrase(item.ErrorDescription, fontStyle));
                _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfCell.BackgroundColor = BaseColor.White;
                _pdfTable.AddCell(_pdfCell);

                _pdfCell = new PdfPCell(new Phrase(item.ProcessDate.ToString(), fontStyle));
                _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfCell.BackgroundColor = BaseColor.White;
                _pdfTable.AddCell(_pdfCell);


                _pdfCell = new PdfPCell(new Phrase(item.IdCountResult.ToString(), fontStyle));
                _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfCell.BackgroundColor = BaseColor.White;
                _pdfTable.AddCell(_pdfCell);
                _pdfTable.CompleteRow();
            }
            #endregion
        }

    }

}
