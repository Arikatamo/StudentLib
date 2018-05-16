using Microsoft.Office.Interop.Word;
using StudentBlank.Controller;
using StudentBlank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank
{
    public static class DocumentFirst
    {
        public static void CreateDocument(string FilePath, EStudent student)
        {
            try
            {
                Photo photo = new Photo();
                //Create an instance for word app
                Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();
                Document wordDoc = winword.Documents.Add();
                Range range = wordDoc.Range();
                int fontStandart = 10;
                int fontBig = 11;
                int fontSmall = 8;
                int fontHead = 14;

                //Set animation status for word application
                // winword.ShowAnimation = true;

                //Set status for word application is to be visible or not.
                winword.Visible = false;

                //Create a missing variable for missing value
                object missing = System.Reflection.Missing.Value;

                //Create a new document
                Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);

                //Add header into the document
                foreach (Microsoft.Office.Interop.Word.Section section in document.Sections)
                {
                    //Get the header range and add the header details.
                    Microsoft.Office.Interop.Word.Range headerRange = section.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage);
                    headerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    headerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlue;
                    headerRange.Font.Size = 10;
                    headerRange.Text = "";
                }

                //Add the footers into the document
                foreach (Microsoft.Office.Interop.Word.Section wordSection in document.Sections)
                {
                    //Get the footer range and add the footer details.
                    Microsoft.Office.Interop.Word.Range footerRange = wordSection.Footers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    footerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdDarkRed;
                    footerRange.Font.Size = 10;
                    footerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    footerRange.Text = "";
                }






                //adding text to document
                document.Content.SetRange(0, 0);
                //document.Content.Text = "ЗАТВЕРДЖЕНО" +
                //    "Наказ Міністерства освіти" +
                //    "і науки України" +
                //    "06.06.2017 № 794" + Environment.NewLine;


                Microsoft.Office.Interop.Word.Paragraph oPara2 = document.Content.Paragraphs.Add(ref missing);
                Range rng = oPara2.Range;
                rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseStart);
                InlineShape shape = document.InlineShapes.AddPicture(@"C:\Users\Arikatamo\Pictures\img8.jpg", ref missing, ref missing, rng);
                //InlineShape shape = document.InlineShapes.AddPicture(photo.ByteToImage(student.Image), ref missing, ref missing, rng);

                shape.Width = 100;
                shape.Height = 100;
                rng = shape.Range;
                Microsoft.Office.Interop.Word.Shape s2 = shape.ConvertToShape();
                oPara2.Format.SpaceAfter = 0;
                s2.WrapFormat.Type = WdWrapType.wdWrapTight;

                //Add paragraph with Heading 1 style
                Microsoft.Office.Interop.Word.Paragraph para1 = document.Content.Paragraphs.Add(ref missing);
                object styleHeading = "No Spacing";
                para1.Range.set_Style(ref styleHeading);
                // And paste it to the target Range
                string[] Parahraps = { "ЗАТВЕРДЖЕНО", "Наказ Міністерства освіти", "і науки України", "06.06.2017 № 794" };
                foreach (var item in Parahraps)
                {
                    para1.Range.Text = item;
                    para1.Range.set_Style(ref styleHeading);
                    para1.Range.Font.Size = fontBig;
                    para1.Range.Font.Color = WdColor.wdColorBlack;
                    para1.Format.SpaceAfter = 5;
                    para1.Format.FirstLineIndent = 170;
                    para1.Range.InsertParagraphAfter();
                }
                string TempLine = "__________________________________________________________________________________________";
                int MaxCount = TempLine.Length;
                Microsoft.Office.Interop.Word.Paragraph para2 = document.Content.Paragraphs.Add(ref missing);
                para2.Range.Text = "Форма № Н - 1.01.2.3";
                para2.Range.Font.Size = fontHead;
                para2.Range.Font.Color = WdColor.wdColorBlack;
                para2.Range.Font.Bold = 1;
                para2.Format.SpaceAfter = 10;
                para2.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                para2.Range.InsertParagraphAfter();
                para2.Range.Font.Bold = 0;

                string[] Named = { student.Name, student.SName, student.FName };
                //Керівнику
                Microsoft.Office.Interop.Word.Paragraph Para1 = document.Content.Paragraphs.Add(ref missing);
                string temp = $"Керівнику:";
                Para1.Range.Text = temp;
                var ll = Para1.Range.End;
                Para1.Format.FirstLineIndent = 0;
                Para1.Range.Font.Size = fontStandart;
                Para1.Range.Font.Color = WdColor.wdColorBlack;
                Para1.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                Para1.SpaceAfter = 0;
                // Назва Закладу
                Range rr = Para1.Range;
                rr.Start = ll;
                rr.Text = $"\t{Named[0]}  {Named[1]}  {Named[2]}";
                rr.Font.Size = fontBig;
                rr.Font.Bold = 1;
                Para1.Range.InsertParagraphAfter();
                /// (найменування вищого навчального закладу)
                Para1.Range.Text = "(найменування вищого навчального закладу)";
                Para1.Range.Font.Size = fontSmall;
                Para1.Range.Font.Bold = 0;
                Para1.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                Para1.Range.InsertParagraphAfter();
                //вступника
                temp = $"Вступника:";
                Para1.Range.Text = temp;
                ll = Para1.Range.End;
                Para1.Format.FirstLineIndent = 0;
                Para1.Range.Font.Size = fontStandart;
                Para1.Range.Font.Color = WdColor.wdColorBlack;
                Para1.SpaceAfter = 0;
                Para1.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                // Вступник
                rr = Para1.Range;
                rr.Start = ll;
                rr.Text = $"\t{Named[0]}  {Named[1]}  {Named[2]}";
                rr.Font.Size = fontBig;
                rr.Font.Bold = 1;
                Para1.Range.InsertParagraphAfter();
                /// (прізвище, ім&#39;я та по батькові)
                Para1.Range.Text = "(прізвище, ім&#39;я та по батькові)";
                Para1.Range.Font.Size = fontSmall;
                Para1.Range.Font.Bold = 0;
                Para1.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                Para1.Range.InsertParagraphAfter();
                // Заява
                Para1.Range.Text = "Заява";
                styleHeading = "Title";
                Para1.Range.set_Style(ref styleHeading);
                Para1.SpaceAfter = 1;
                Para1.SpaceBefore = 3;
                Para1.Range.Font.Size = fontHead;
                Para1.Range.Font.Bold = 1;
                Para1.Range.Font.Color = WdColor.wdColorBlack;
                Para1.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                Para1.Range.InsertParagraphAfter();
                // Прошу допустити мене до участі в конкурсному відборі на навчання:
                Para1.Range.Text = "Прошу допустити мене до участі в конкурсному відборі на навчання:";
                Para1.Format.FirstLineIndent = 0;
                Para1.Range.Font.Size = fontStandart;
                Para1.Range.Font.Color = WdColor.wdColorBlack;
                Para1.SpaceAfter = 1;
                Para1.Range.InsertParagraphAfter();
                //форма навчання
                temp = $"форма навчання:";
                Para1.Range.Text = temp;
                ll = Para1.Range.End;
                Para1.Format.FirstLineIndent = 0;
                Para1.Range.Font.Size = fontStandart;
                Para1.Range.Font.Color = WdColor.wdColorBlack;
                Para1.SpaceAfter = 0;
                Para1.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                // Форма
                int rangeDays;

                rr = Para1.Range;
                rr.Start = ll;
                rangeDays = rr.Start;
                rr.Text = $"\t{student.FormEdu.Name}\t,";
                rr.Font.Size = fontBig;
                rr.Font.Bold = 1;
                ll = Para1.Range.End;

                // освітньо-кваліфікаційний рівень молодший спеціаліст,
                rr = Para1.Range;
                rr.Start = ll;
                rr.Text = $"\tосвітньо - кваліфікаційний рівень молодший спеціаліст,";
                rr.Font.Bold = 0;
                rr.Font.Size = fontStandart;
                Para1.Range.InsertParagraphAfter();

                /// (денна, заочна (дистанційна), вечірня)
                Para1.Range.Text = "\t\t(денна, заочна (дистанційна), вечірня)";
                Para1.Range.Font.Size = fontSmall;
                Para1.Range.Font.Bold = 0;
                Para1.SpaceAfter = 1;
                Para1.Range.InsertParagraphAfter();
                /// конкурсна пропозиція
                temp = $"конкурсна пропозиція:";
                Para1.Range.Text = temp;
                ll = Para1.Range.End;
                Para1.Format.FirstLineIndent = 0;
                Para1.Range.Font.Size = fontStandart;
                Para1.Range.Font.Color = WdColor.wdColorBlack;
                Para1.SpaceAfter = 0;
                Para1.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                //Сама пропозиція
                var NamedPropos = "Конкурсна Пропозиція";
                rr = Para1.Range;
                rr.Start = ll;
                rangeDays = rr.Start;
                rr.Text = $"\t{NamedPropos}\t";
                rr.Font.Size = fontBig;
                rr.Font.Bold = 1;
                ll = Para1.Range.End;
                Para1.Range.InsertParagraphAfter();
                /// (назва конкурсної пропозиції державною мовою)
                Para1.Range.Text = "(назва конкурсної пропозиції державною мовою)";
                Para1.Range.Font.Size = fontSmall;
                Para1.SpaceAfter = 1;
                Para1.Range.Font.Bold = 0;
                Para1.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                Para1.Range.InsertParagraphAfter();
                //спеціальність
                temp = $"спеціальність:";
                Para1.Range.Text = temp;
                ll = Para1.Range.End;
                Para1.Format.FirstLineIndent = 0;
                Para1.Range.Font.Size = fontStandart;
                Para1.Range.Font.Color = WdColor.wdColorBlack;
                Para1.SpaceAfter = 0;
                Para1.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                //Сама Спеціальність
                NamedPropos = "Програміст";
                rr = Para1.Range;
                rr.Start = ll;
                rangeDays = rr.Start;
                rr.Text = $"\t{NamedPropos}\t";
                rr.Font.Size = fontBig;
                rr.Font.Bold = 1;
                ll = Para1.Range.End;
                Para1.Range.InsertParagraphAfter();
                //(код та найменування спеціальності, спеціалізації спеціальностей 014, 015, 035, 275)
                Para1.Range.Text = "(код та найменування спеціальності, спеціалізації спеціальностей 014, 015, 035, 275)";
                Para1.Range.Font.Size = fontSmall;
                Para1.SpaceAfter = 1;
                Para1.Range.Font.Bold = 0;
                Para1.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                Para1.Range.InsertParagraphAfter();
                // назва спеціалізацій, освітніх програм, нозологій, мов, музичних інструментів тощо в межах спеціальності
                string[] tem = { "First", "Second", "Third" };
                string text = "";
                for (int i = 0; i < tem.Length; i++)
                {
                    text += tem[i];
                    if (i < tem.Length - 1)
                    {
                        text += " , ";
                    }
                }
                Para1.Range.Text = text;
                Para1.Range.Font.Size = fontBig;
                Para1.Range.Font.Bold = 1;
                Para1.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                Para1.Range.InsertParagraphAfter();
                //(назва спеціалізацій, освітніх програм, нозологій, мов, музичних інструментів тощо в межах спеціальності)
                Para1.Range.Text = "(назва спеціалізацій, освітніх програм, нозологій, мов, музичних інструментів тощо в межах спеціальності)";
                Para1.Range.Font.Size = fontSmall;
                Para1.SpaceAfter = 1;
                Para1.Range.Font.Bold = 0;
                Para1.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                Para1.Range.InsertParagraphAfter();
                //на основі освітньо-кваліфікаційного рівня
                temp = $"на основі освітньо-кваліфікаційного рівня:";
                Para1.Range.Text = temp;
                ll = Para1.Range.End;
                Para1.Format.FirstLineIndent = 0;
                Para1.Range.Font.Size = fontStandart;
                Para1.Range.Font.Color = WdColor.wdColorBlack;
                Para1.SpaceAfter = 0;
                Para1.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                // Кваліфікаційний рівень
                rr = Para1.Range;
                rr.Start = ll;
                rangeDays = rr.Start;
                rr.Text = $"\t{student.CvalLvl.Name}\t";
                rr.Font.Size = fontBig;
                rr.Font.Bold = 1;
                ll = Para1.Range.End;
                Para1.Range.InsertParagraphAfter();
                //(кваліфікований робітник, молодший спеціаліст)
                Para1.Range.Text = "(кваліфікований робітник, молодший спеціаліст)";
                Para1.Range.Font.Size = fontSmall;
                Para1.Format.FirstLineIndent = 80;
                Para1.SpaceAfter = 1;
                Para1.Range.Font.Bold = 0;
                Para1.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                Para1.Range.InsertParagraphAfter();
                //Претендую на участь у конкурсі на місця державного та регіонального замовлення і на участь у конкурсі на
                // місця за кошти фізичних та юридичних осіб у випадку неотримання рекомендації за цією конкурсною пропозицією
                // за державним або регіональним замовленням.
                temp = $"Претендую на участь у конкурсі на місця державного та регіонального замовлення і на участь у конкурсі на" +
                    $"місця за кошти фізичних та юридичних осіб у випадку неотримання рекомендації за цією конкурсною пропозицією" +
                    $"за державним або регіональним замовленням.";
                Para1.Range.Text = temp;
                Para1.Format.FirstLineIndent = 40f;
                Para1.Range.Font.Size = fontStandart;
                Para1.Range.Font.Color = WdColor.wdColorBlack;
                Para1.SpaceAfter = 0;
                Para1.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                Para1.Range.InsertParagraphAfter();
                // Претендую на участь у конкурсі виключно на місця державного та регіонального замовлення.
                Para1.Range.Text = "Претендую на участь у конкурсі виключно на місця державного та регіонального замовлення.";
                Para1.Range.Font.Size = fontBig;
                Para1.SpaceAfter = 2;
                Para1.SpaceBefore = 10;
                if (student.CatZarah.Name == "Державна")
                {
                    Para1.Range.Font.Underline = WdUnderline.wdUnderlineSingle;
                }
                Para1.Range.Font.Bold = 0;
                Para1.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                Para1.Range.InsertParagraphAfter();
                Para1.Range.Font.Underline = WdUnderline.wdUnderlineNone;
                // Претендую на участь у конкурсі виключно на місця за кошти фізичних та юридичних осіб.
                Para1.Range.Text = "Претендую на участь у конкурсі виключно на місця за кошти фізичних та юридичних осіб.";
                Para1.Range.Font.Size = fontBig;
                Para1.SpaceAfter = 2;
                Para1.SpaceBefore = 10;
                if (student.CatZarah.Name == "Приватна")
                {
                    Para1.Range.Font.Underline = WdUnderline.wdUnderlineSingle;
                }
                Para1.Range.Font.Bold = 0;
                Para1.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                Para1.Range.InsertParagraphAfter();
                Para1.Range.Font.Underline = WdUnderline.wdUnderlineNone;

                //Про себе повідомляю
                
                Para1.Range.Text = "Про себе повідомляю";
                styleHeading = "Title";
                Para1.Range.set_Style(ref styleHeading);
                Para1.SpaceAfter = 1;
                Para1.SpaceBefore = 3;
                Para1.Range.Font.Size = fontHead;
                Para1.Range.Font.Bold = 1;
                Para1.Range.Font.Color = WdColor.wdColorBlack;
                Para1.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                Para1.Range.InsertParagraphAfter();
                //Освітньо-кваліфікаційний рівень молодшого спеціаліста за кошти державного бюджету:
                temp = $"Освітньо-кваліфікаційний рівень молодшого спеціаліста за кошти державного бюджету: ніколи не здобувався - ";
                Para1.Range.Text = temp;
                ll = Para1.Range.End;
                Para1.Format.FirstLineIndent = 0;
                Para1.Range.Font.Size = fontStandart;
                Para1.Range.Font.Color = WdColor.wdColorBlack;
                Para1.SpaceAfter = 0;
                Para1.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                //Так
                rr = Para1.Range;
                rr.Start = ll;
                rangeDays = rr.Start;
                rr.Text = $" Так ;";
                rr.Font.Size = fontBig;
                rr.Font.Bold = 1;
                ll = Para1.Range.End;
                Para1.Range.InsertParagraphAfter();
                //вже здобутий раніше -
                temp = $"вже здобутий раніше - ";
                Para1.Range.Text = temp;
                ll = Para1.Range.End;
                Para1.Format.FirstLineIndent = 0;
                Para1.Range.Font.Size = fontStandart;
                Para1.Range.Font.Color = WdColor.wdColorBlack;
                Para1.SpaceAfter = 0;
                Para1.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                //Ні
                rr = Para1.Range;
                rr.Start = ll;
                rangeDays = rr.Start;
                rr.Text = $" Ні ;";
                rr.Font.Size = fontBig;
                rr.Font.Bold = 1;
                ll = Para1.Range.End;
                Para1.Range.InsertParagraphAfter();
                //вже здобувався раніше (навчання не завершено) -
                temp = $"вже здобувався раніше (навчання не завершено) - ";
                Para1.Range.Text = temp;
                ll = Para1.Range.End;
                Para1.Format.FirstLineIndent = 0;
                Para1.Range.Font.Size = fontStandart;
                Para1.Range.Font.Color = WdColor.wdColorBlack;
                Para1.SpaceAfter = 0;
                Para1.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                //Так
                rr = Para1.Range;
                rr.Start = ll;
                rangeDays = rr.Start;
                rr.Text = $" Так ;";
                rr.Font.Size = fontBig;
                rr.Font.Bold = 1;
                ll = Para1.Range.End;
                Para1.Range.InsertParagraphAfter();
                //Закінчив(ла)
                temp = $"Закінчив(ла): ";
                Para1.Range.Text = temp;
                ll = Para1.Range.End;
                Para1.Format.FirstLineIndent = 0;
                Para1.Range.Font.Size = fontStandart;
                Para1.Range.Font.Color = WdColor.wdColorBlack;
                Para1.SpaceAfter = 0;
                Para1.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                //"Тут має бути текст про закінчення закладу!"
                rr = Para1.Range;
                rr.Start = ll;
                rangeDays = rr.Start;
                rr.Text = $" Тут має бути текст про закінчення закладу! ;";
                rr.Font.Size = fontBig;
                rr.Font.Bold = 1;
                ll = Para1.Range.End;
                Para1.Range.InsertParagraphAfter();
                //Іноземна мова, яку вивчав(ла)
                temp = $"Іноземна мова, яку вивчав(ла): ";
                Para1.Range.Text = temp;
                ll = Para1.Range.End;
                Para1.Format.FirstLineIndent = 0;
                Para1.Range.Font.Size = fontStandart;
                Para1.Range.Font.Color = WdColor.wdColorBlack;
                Para1.SpaceAfter = 0;
                Para1.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                //Мова
                rr = Para1.Range;
                rr.Start = ll;
                rangeDays = rr.Start;
                rr.Text = $" Англійська ;";
                rr.Font.Size = fontBig;
                rr.Font.Bold = 1;
                ll = Para1.Range.End;
                Para1.Range.InsertParagraphAfter();
                //Закінчив(ла)
                temp = $"Середній бал диплома: ";
                Para1.Range.Text = temp;
                ll = Para1.Range.End;
                Para1.Format.FirstLineIndent = 0;
                Para1.Range.Font.Size = fontStandart;
                Para1.Range.Font.Color = WdColor.wdColorBlack;
                Para1.SpaceAfter = 0;
                Para1.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                //Оцінка
                rr = Para1.Range;
                rr.Start = ll;
                rangeDays = rr.Start;
                rr.Text = $" 10 ;";
                rr.Font.Size = fontBig;
                rr.Font.Bold = 1;
                ll = Para1.Range.End;
                Para1.Range.InsertParagraphAfter();


                //На час навчання поселення в гуртожиток: потребую - ; не потребую - (можна добавити до студента змінну яка тут буде підставлятися)
                temp = $"На час навчання поселення в гуртожиток: потребую - Так; не потребую - Ні";
                Para1.Range.Text = temp;
                ll = Para1.Range.End;
                Para1.Format.FirstLineIndent = 0;
                Para1.Range.Font.Size = fontStandart;
                Para1.Range.Font.Color = WdColor.wdColorBlack;
                Para1.SpaceAfter = 0;
                Para1.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                Para1.Range.InsertParagraphAfter();
                //Громадянство: Україна -; інша країна:
                temp = $"Громадянство: Україна - Так; інша країна: Ні";
                Para1.Range.Text = temp;
                ll = Para1.Range.End;
                Para1.Format.FirstLineIndent = 0;
                Para1.Range.Font.Size = fontStandart;
                Para1.Range.Font.Color = WdColor.wdColorBlack;
                Para1.SpaceAfter = 0;
                Para1.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                Para1.Range.InsertParagraphAfter();
                //Стать: чоловіча - ; жіноча -
                string Man = (student.Sex.Sex == "Чоловік") ? "Так" : "Ні";
                string Woman = (student.Sex.Sex == "Жінка") ? "Так" : "Ні";

                temp = $"Стать: чоловіча - {Man}; жіноча - {Woman}";
                Para1.Range.Text = temp;
                ll = Para1.Range.End;
                Para1.Format.FirstLineIndent = 0;
                Para1.Range.Font.Size = fontStandart;
                Para1.Range.Font.Color = WdColor.wdColorBlack;
                Para1.SpaceAfter = 0;
                Para1.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                Para1.Range.InsertParagraphAfter();
                //Дата і місце народження:
                temp = $"Дата і місце народження: {student.Residence.Oblast}, {student.Residence.Rajon}, {student.Residence.Town}";
                Para1.Range.Text = temp;
                ll = Para1.Range.End;
                Para1.Format.FirstLineIndent = 0;
                Para1.Range.Font.Size = fontStandart;
                Para1.Range.Font.Color = WdColor.wdColorBlack;
                Para1.SpaceAfter = 0;
                Para1.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                Para1.Range.InsertParagraphAfter();
                //Місце проживання: індекс__________, область ________________________, район_____________________________,
                //місто / смт / село ___________________________, вулиця__________________________, будинок ___, квартира ______,
                //домашній, мобільний телефони _________________________________, електронна пошта __________________________
                temp = $"Місце проживання: індекс: {student.Residence.Index}, область: {student.Residence.Oblast} , район: {student.Residence.Rajon}, " +
                    $"місто / смт / село: {student.Residence.Town}, вулиця: {student.Residence.Street}, будинок: {student.Residence.NumberBuild}, квартира: {student.Residence.NumberKW}," +
                    $"домашній, мобільний телефони: {student.Phone}, {student.MobilePhone}, електронна пошта: {student.Email}";
                Para1.Range.Text = temp;
                ll = Para1.Range.End;
                Para1.Format.FirstLineIndent = 0;
                Para1.Range.Font.Size = fontStandart;
                Para1.Range.Font.Color = WdColor.wdColorBlack;
                Para1.SpaceAfter = 0;
                Para1.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                Para1.Range.InsertParagraphAfter();

                ////Add paragraph with Heading 2 style
                //Microsoft.Office.Interop.Word.Paragraph para2 = document.Content.Paragraphs.Add(ref missing);
                //object styleHeading2 = "Heading 2";
                //para2.Range.set_Style(ref styleHeading2);
                //para2.Range.Text = "ВІДОМІСТЬ ВСТУПНОГО ВИПРОБУВАННЯ";
                //para2.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

                //para2.Range.InsertParagraphAfter();


                //Create a 5X5 table and insert some dummy record
                //Table firstTable = document.Tables.Add(para1.Range, 5, 5, ref missing, ref missing);

                //firstTable.Borders.Enable = 1;
                //foreach (Row row in firstTable.Rows)
                //{
                //    foreach (Cell cell in row.Cells)
                //    {
                //        //Header row
                //        if (cell.RowIndex == 1)
                //        {
                //            cell.Range.Text = "Column " + cell.ColumnIndex.ToString();
                //            cell.Range.Font.Bold = 1;
                //            //other format properties goes here
                //            cell.Range.Font.Name = "verdana";
                //            cell.Range.Font.Size = 10;
                //            //cell.Range.Font.ColorIndex = WdColorIndex.wdGray25;                            
                //            cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
                //            //Center alignment for the Header cells
                //            cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                //            cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

                //        }
                //        //Data row
                //        else
                //        {
                //            cell.Range.Text = (cell.RowIndex - 2 + cell.ColumnIndex).ToString();
                //        }
                //    }
                //}

                //Save the document
                object filename = FilePath + @"\Форма_№_Н_1.01.2.3_" +  student.Name  + "_.docx";
                document.SaveAs2(ref filename);
                document.Close(ref missing, ref missing, ref missing);
                document = null;
                winword.Quit(ref missing, ref missing, ref missing);
                winword = null;
                //throw new Exception("Documet Created");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
