Sub CopyToWord()
 Dim wdApp As Object
 Dim wdDoc As Object
 Dim rng As Range
 
 ' Открываем новый документ Word
 Set wdApp = CreateObject("Word.Application")
 wdApp.Visible = True
 Set wdDoc = wdApp.Documents.Add
 
 ' Получаем диапазон ячеек из Excel
 Set rng = ActiveCell
 
 ' Копируем диапазон в Word
 rng.Copy
 wdDoc.Paragraphs(1).Range.PasteExcelTable LinkedToExcel:=False, WordFormatting:=False, RTF:=False
 
 ' Форматируем шрифт в Times New Roman
 With wdDoc.Paragraphs(1).Range.Font
     .Name = "Times New Roman"
     .Size = 14
 End With
 
 ' Сохраняем и закрываем документ Word
 wdDoc.SaveAs "C:\Path\To\Document.docx"
 wdDoc.Close
 
 ' Закрываем приложение Word
 wdApp.Quit
 
 ' Освобождаем объекты
 Set wdDoc = Nothing
 Set wdApp = Nothing
End Sub
