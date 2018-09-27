﻿using SplitExcel.Office;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SplitExcel
{
    internal static class Dialogs
    {
        internal static string OpenExcelFileDialog()
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "Файлы Excel|*.xls;*.xlsx;*.xlsm";
            f.Title = "Выберите файл";
            if (f.ShowDialog() == DialogResult.OK)
                return f.FileName;
            return null;
        }
        internal static ExcelBook GetExcelFileInformation(string filePath)
        {
            string s = System.IO.Path.GetExtension(filePath).ToLower();
            try
            {
                if (!(s == ".xls" || s == ".xlsx" || s == ".xlsm"))
                    throw new Exception($"Это не файл Excel! Расширение - {s}.\n{filePath}");

                using (Office.UsingExcel excel = new Office.UsingExcel())
                    return excel.ReadExcelFile(filePath);
            }
            catch (Exception ex) { throw ex; }
        }
        internal static List<string> ReadSplitValuesList(SplitFileParameters splParams)
        {
            try {
                using (Office.UsingExcel usXl = new Office.UsingExcel())
                    return usXl.GetSplitValues(splParams);
            }
            catch (Exception ex) { throw ex; }
        }
        internal static List<List<T>> SplitList<T>(List<T> source, bool UseMultithreading)
        {
            int sourseCount = source.Count;
            int threadsNumber = (UseMultithreading) ? GetThreadsNumber() : 1;
            int listLen = sourseCount / threadsNumber;
            int rem = sourseCount % threadsNumber;
            if (rem > 0) listLen++;
            return SplitList(source, listLen);
        }
        private static List<List<T>> SplitList<T>(List<T> source, int len)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / len)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
        private static int GetThreadsNumber()
        {
            try {
                int processorCount = Environment.ProcessorCount;
                if (processorCount > 1 && processorCount < 4) return 2;
                else if (processorCount >= 4) return 4;
                else return 1;
            }
            catch { return 1; }
        }
    }
}