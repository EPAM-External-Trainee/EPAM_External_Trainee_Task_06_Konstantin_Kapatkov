using OfficeOpenXml;
using OfficeOpenXml.Style;
using ResultsOfTheSession.PreparationOfReports.Models.ExpelledStudentsReport;
using ResultsOfTheSession.PreparationOfReports.Models.SessionResultForGroupReport;
using ResultsOfTheSession.PreparationOfReports.Models.SessionResultWithGroupMarksReport;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace ResultsOfTheSession.ExcelWorker
{
    public static class MyExcelWorker
    {
        public static void WriteToExcel(List<SessionResultForGroupReportData> dataToWrite, string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excel = new ExcelPackage();
            ExcelWorksheet workSheet = null;

            foreach (var data in dataToWrite)
            {
                int currentRow = 1;
                workSheet = excel.Workbook.Worksheets.Add(data.GroupName);

                workSheet.TabColor = Color.Black;
                workSheet.DefaultRowHeight = 12;
                workSheet.DefaultColWidth = 20;

                workSheet.Row(currentRow).Height = 20;
                workSheet.Row(currentRow).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Row(currentRow).Style.Font.Bold = true;

                workSheet.Cells[currentRow, currentRow].Value = data.SessionInfo;
                workSheet.Cells[currentRow, currentRow, currentRow, data.Headers.Length].Merge = true;

                workSheet.Row(++currentRow).Height = 20;
                workSheet.Row(currentRow).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Row(currentRow).Style.Font.Bold = true;

                workSheet.Cells[currentRow, currentRow].Value = $"Group: {data.GroupName}";
                workSheet.Cells[currentRow, currentRow, currentRow, data.Headers.Length].Merge = true;

                workSheet.Row(++currentRow).Height = 20;
                workSheet.Row(currentRow).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Row(currentRow).Style.Font.Bold = true;

                for (int i = 0; i < data.Headers.Length; i++)
                {
                    workSheet.Cells[currentRow, ++i].Value = data.Headers[--i];
                }

                for (int i = ++currentRow, j = 0; j < data.SessionResultForGroupRawViews.Count(); i++, j++)
                {
                    workSheet.Cells[i, 1].Value = data.SessionResultForGroupRawViews[j].Surname;
                    workSheet.Cells[i, 2].Value = data.SessionResultForGroupRawViews[j].Name;
                    workSheet.Cells[i, 3].Value = data.SessionResultForGroupRawViews[j].Patronymic;
                    workSheet.Cells[i, 4].Value = data.SessionResultForGroupRawViews[j].Subject;
                    workSheet.Cells[i, 5].Value = data.SessionResultForGroupRawViews[j].Type;
                    workSheet.Cells[i, 6].Value = data.SessionResultForGroupRawViews[j].Date;
                    workSheet.Cells[i, 7].Value = data.SessionResultForGroupRawViews[j].Assessment;
                }

                SetBorder(excel, workSheet, data.GroupName);
            }

            FileStream objFileStrm = File.Create(filePath);
            objFileStrm.Close();
            File.WriteAllBytes(filePath, excel.GetAsByteArray());
            excel.Dispose();
            workSheet.Dispose();
        }

        public static void WriteToExcel(List<SessionResultWithGroupMarksReportData> dataToWrite, string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excel = new ExcelPackage();
            ExcelWorksheet workSheet = null;

            foreach (var data in dataToWrite)
            {
                int currentRow = 1;
                workSheet = excel.Workbook.Worksheets.Add(data.AcademicYear);

                workSheet.TabColor = Color.Black;
                workSheet.DefaultRowHeight = 12;
                workSheet.DefaultColWidth = 20;

                workSheet.Row(currentRow).Height = 20;
                workSheet.Row(currentRow).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Row(currentRow).Style.Font.Bold = true;

                workSheet.Cells[currentRow, currentRow].Value = data.SessionName;
                workSheet.Cells[currentRow, currentRow, currentRow, data.Headers.Length].Merge = true;

                workSheet.Row(++currentRow).Height = 20;
                workSheet.Row(currentRow).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Row(currentRow).Style.Font.Bold = true;

                for (int i = 0; i < data.Headers.Length; i++)
                {
                    workSheet.Cells[currentRow, ++i].Value = data.Headers[--i];
                }

                for (int i = ++currentRow, j = 0; j < data.PrepareSessionResultWithGroupMarksRowViews.Count(); i++, j++)
                {
                    workSheet.Cells[i, 1].Value = data.PrepareSessionResultWithGroupMarksRowViews[j].GroupName;
                    workSheet.Cells[i, 2].Value = data.PrepareSessionResultWithGroupMarksRowViews[j].MaxAssessment;
                    workSheet.Cells[i, 3].Value = data.PrepareSessionResultWithGroupMarksRowViews[j].MinAssessment;
                    workSheet.Cells[i, 4].Value = data.PrepareSessionResultWithGroupMarksRowViews[j].AvgAssessment;
                }

                SetBorder(excel, workSheet, data.AcademicYear);
            }

            using FileStream objFileStrm = File.Create(filePath);
            objFileStrm.Close();
            File.WriteAllBytes(filePath, excel.GetAsByteArray());
            excel.Dispose();
            workSheet.Dispose();
        }

        public static void WriteToExcel(List<ExpelledStudentsReportData> dataToWrite, string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excel = new ExcelPackage();
            ExcelWorksheet workSheet = null;

            foreach (var data in dataToWrite)
            {
                int currentRow = 1;
                workSheet = excel.Workbook.Worksheets.Add(data.GroupName);

                workSheet.TabColor = Color.Black;
                workSheet.DefaultRowHeight = 12;
                workSheet.DefaultColWidth = 20;

                workSheet.Row(currentRow).Height = 20;
                workSheet.Row(currentRow).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Row(currentRow).Style.Font.Bold = true;

                workSheet.Cells[currentRow, currentRow].Value = $"{data.GroupName} students to be expelled";
                workSheet.Cells[currentRow, currentRow, currentRow, data.Headers.Length].Merge = true;

                workSheet.Row(++currentRow).Height = 20;
                workSheet.Row(currentRow).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Row(currentRow).Style.Font.Bold = true;

                for (int i = 0; i < data.Headers.Length; i++)
                {
                    workSheet.Cells[currentRow, ++i].Value = data.Headers[--i];
                }

                for (int i = ++currentRow, j = 0; j < data.ExpelledStudentsReportRawViews.Count(); i++, j++)
                {
                    workSheet.Cells[i, 1].Value = data.ExpelledStudentsReportRawViews[j].Surname;
                    workSheet.Cells[i, 2].Value = data.ExpelledStudentsReportRawViews[j].Name;
                    workSheet.Cells[i, 3].Value = data.ExpelledStudentsReportRawViews[j].Patronymic;
                }

                SetBorder(excel, workSheet, data.GroupName);
            }

            using FileStream objFileStrm = File.Create(filePath);
            objFileStrm.Close();
            File.WriteAllBytes(filePath, excel.GetAsByteArray());
            excel.Dispose();
            workSheet.Dispose();
        }

        private static void SetBorder(ExcelPackage excel, ExcelWorksheet workSheet, string workSheetName)
        {
            workSheet = excel.Workbook.Worksheets[workSheetName];
            workSheet.Cells[workSheet.Dimension.Address].AutoFitColumns();
            workSheet.Cells[workSheet.Dimension.Address].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            workSheet.Cells[workSheet.Dimension.Address].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            workSheet.Cells[workSheet.Dimension.Address].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            workSheet.Cells[workSheet.Dimension.Address].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
        }
    }
}