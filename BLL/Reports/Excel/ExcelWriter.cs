using BLL.Reports.Excel.Views.ExpelledStudentsReport.ReportDataViews;
using BLL.Reports.Excel.Views.ExpelledStudentsReport.TableViews;
using BLL.Reports.Excel.Views.GroupSessionResultReport.ReportDataViews;
using BLL.Reports.Excel.Views.Interfaces.GroupSessionResultReport.TableViews;
using BLL.Reports.Excel.Views.SessionResultReport.ReportDataViews;
using BLL.Reports.Excel.Views.SessionResultReport.TableViews;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace BLL.Reports.Excel
{
    /// <summary>Functionality for working with excel documents</summary>
    public static class ExcelWriter
    {
        /// <summary>Setting borders for cells</summary>
        /// <param name="excel"><see cref="ExcelPackage"/> object</param>
        /// <param name="workSheet"><see cref="ExcelWorksheet"/> object</param>
        /// <param name="workSheetName">work sheet name</param>
        private static void SetBorder(ExcelPackage excel, ExcelWorksheet workSheet, string workSheetName)
        {
            workSheet = excel.Workbook.Worksheets[workSheetName];
            workSheet.Cells[workSheet.Dimension.Address].AutoFitColumns();
            workSheet.Cells[workSheet.Dimension.Address].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            workSheet.Cells[workSheet.Dimension.Address].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            workSheet.Cells[workSheet.Dimension.Address].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            workSheet.Cells[workSheet.Dimension.Address].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
        }

        /// <summary>Setting style for work sheet</summary>
        /// <param name="workSheet"><see cref="ExcelWorksheet"/> object</param>
        private static void SetWorkSheetStyle(ExcelWorksheet workSheet)
        {
            workSheet.TabColor = Color.Black;
            workSheet.DefaultRowHeight = 12;
            workSheet.DefaultColWidth = 20;
        }

        /// <summary>Setting row style for excel row</summary>
        /// <param name="row"><see cref="ExcelRow"/> object</param>
        private static void SetRowStyle(ExcelRow row)
        {
            row.Height = 20;
            row.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            row.Style.Font.Bold = true;
        }

        /// <summary>Writing <see cref="GroupTableView"/> objects to an excel file</summary>
        /// <param name="dataToWrite"><see cref="IEnumerable{GroupTableView}"/> objects to write</param>
        /// <param name="excel"><see cref="ExcelPackage"/> object</param>
        /// <param name="workSheet"><see cref="ExcelWorksheet"/> object</param>
        private static void WriteGroupTable(IEnumerable<GroupTableView> dataToWrite, ExcelPackage excel, ExcelWorksheet workSheet)
        {
            foreach (var groupTableView in dataToWrite)
            {
                int currentRow = 1;
                workSheet = excel.Workbook.Worksheets.Add(groupTableView.GroupName);

                SetWorkSheetStyle(workSheet);
                SetRowStyle(workSheet.Row(currentRow));

                workSheet.Cells[currentRow, currentRow].Value = groupTableView.SessionName;
                workSheet.Cells[currentRow, currentRow, currentRow, groupTableView.Headers.Length].Merge = true;

                SetRowStyle(workSheet.Row(++currentRow));

                workSheet.Cells[currentRow, currentRow].Value = $"Group: {groupTableView.GroupName}";
                workSheet.Cells[currentRow, currentRow, currentRow, groupTableView.Headers.Length].Merge = true;

                SetRowStyle(workSheet.Row(++currentRow));

                for (int i = 0; i < groupTableView.Headers.Length; i++)
                {
                    workSheet.Cells[currentRow, ++i].Value = groupTableView.Headers[--i];
                }

                for (int i = ++currentRow, j = 0; j < groupTableView.TableRawViews.Count(); i++, j++)
                {
                    workSheet.Cells[i, 1].Value = groupTableView.TableRawViews.ToList()[j].StudentSurname;
                    workSheet.Cells[i, 2].Value = groupTableView.TableRawViews.ToList()[j].StudentName;
                    workSheet.Cells[i, 3].Value = groupTableView.TableRawViews.ToList()[j].StudentPatronymic;
                    workSheet.Cells[i, 4].Value = groupTableView.TableRawViews.ToList()[j].Subject;
                    workSheet.Cells[i, 5].Value = groupTableView.TableRawViews.ToList()[j].AssessmentForm;
                    workSheet.Cells[i, 6].Value = groupTableView.TableRawViews.ToList()[j].Date;
                    workSheet.Cells[i, 7].Value = groupTableView.TableRawViews.ToList()[j].Assessment;
                }

                SetBorder(excel, workSheet, groupTableView.GroupName);
            }
        }

        /// <summary>Writing <see cref="GroupSessionResultTableView"/> objects to an excel file</summary>
        /// <param name="dataToWrite"><see cref="IEnumerable{GroupSessionResultTableView}"/> objects to write</param>
        /// <param name="excel"><see cref="ExcelPackage"/> object</param>
        /// <param name="workSheet"><see cref="ExcelWorksheet"/> object</param>
        private static void WriteGroupSessionResultTable(IEnumerable<GroupSessionResultTableView> dataToWrite, ExcelPackage excel, ExcelWorksheet workSheet)
        {
            foreach (var table in dataToWrite)
            {
                int currentRow = 1;
                workSheet = excel.Workbook.Worksheets.Add(table.AcademicYear);

                SetWorkSheetStyle(workSheet);
                SetRowStyle(workSheet.Row(currentRow));

                workSheet.Cells[currentRow, currentRow].Value = table.SessionName;
                workSheet.Cells[currentRow, currentRow, currentRow, table.Headers.Length].Merge = true;

                SetRowStyle(workSheet.Row(++currentRow));

                for (int j = 0; j < table.Headers.Length; j++)
                {
                    workSheet.Cells[currentRow, ++j].Value = table.Headers[--j];
                }

                for (int k = ++currentRow, j = 0; j < table.TableRowViews.Count(); k++, j++)
                {
                    workSheet.Cells[k, 1].Value = table.TableRowViews.ToList()[j].GroupName;
                    workSheet.Cells[k, 2].Value = table.TableRowViews.ToList()[j].MaxAssessment;
                    workSheet.Cells[k, 3].Value = table.TableRowViews.ToList()[j].MinAssessment;
                    workSheet.Cells[k, 4].Value = table.TableRowViews.ToList()[j].AvgAssessment;
                }

                SetBorder(excel, workSheet, table.AcademicYear);
            }
        }

        private static void WriteExpelledStudentsTable(IEnumerable<ExpelledStudentsTableView> dataToWrite, ExcelPackage excel, ExcelWorksheet workSheet)
        {
            foreach (var data in dataToWrite)
            {
                int currentRow = 1;
                workSheet = excel.Workbook.Worksheets.Add(data.GroupName);

                SetWorkSheetStyle(workSheet);
                SetRowStyle(workSheet.Row(currentRow));

                workSheet.Cells[currentRow, currentRow].Value = $"{data.GroupName} students to be expelled";
                workSheet.Cells[currentRow, currentRow, currentRow, data.Headers.Length].Merge = true;

                SetRowStyle(workSheet.Row(++currentRow));

                for (int i = 0; i < data.Headers.Length; i++)
                {
                    workSheet.Cells[currentRow, ++i].Value = data.Headers[--i];
                }

                for (int i = ++currentRow, j = 0; j < data.TableRowViews.Count(); i++, j++)
                {
                    workSheet.Cells[i, 1].Value = data.TableRowViews.ToList()[j].StudentSurname;
                    workSheet.Cells[i, 2].Value = data.TableRowViews.ToList()[j].StudentName;
                    workSheet.Cells[i, 3].Value = data.TableRowViews.ToList()[j].StudentPatronymic;
                }

                SetBorder(excel, workSheet, data.GroupName);
            }
        }

        /// <summary>Writing <see cref="SessionResultReportView"/> object to an excel file</summary>
        /// <param name="dataToWrite"><see cref="SessionResultReportView"/> object to write</param>
        /// <param name="filePath">File path</param>
        public static void WriteToExcel(SessionResultReportView dataToWrite, string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excel = new ExcelPackage();
            ExcelWorksheet workSheet = null;

            WriteGroupTable(dataToWrite.GroupTables, excel, workSheet);

            using FileStream objFileStrm = File.Create(filePath);
            objFileStrm?.Close();
            File.WriteAllBytes(filePath, excel.GetAsByteArray());

            excel?.Dispose();
            workSheet?.Dispose();
        }

        /// <summary>Writing <see cref="GroupSessionResultReportView"/> object to an excel file</summary>
        /// <param name="dataToWrite"><see cref="GroupSessionResultReportView"/> object to write</param>
        /// <param name="filePath">File path</param>
        public static void WriteToExcel(GroupSessionResultReportView dataToWrite, string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excel = new ExcelPackage();
            ExcelWorksheet workSheet = null;

            WriteGroupSessionResultTable(dataToWrite.GroupSessionResultTables, excel, workSheet);

            using FileStream objFileStrm = File.Create(filePath);
            objFileStrm?.Close();
            File.WriteAllBytes(filePath, excel.GetAsByteArray());

            excel?.Dispose();
            workSheet?.Dispose();
        }

        public static void WriteToExcel(ExpelledStudentsReportView dataToWrite, string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excel = new ExcelPackage();
            ExcelWorksheet workSheet = null;

            WriteExpelledStudentsTable(dataToWrite.ExpelledStudentsTables, excel, workSheet);

            using FileStream objFileStrm = File.Create(filePath);
            objFileStrm?.Close();
            File.WriteAllBytes(filePath, excel.GetAsByteArray());

            excel?.Dispose();
            workSheet?.Dispose();
        }
    }
}