// Decompiled with JetBrains decompiler
// Type: ExportXML.Form2
// Assembly: ExportXML, Version=1.0.5434.22479, Culture=neutral, PublicKeyToken=null
// MVID: 59BDAFD2-2241-409B-8258-1C6F53971A8D
// Assembly location: C:\Users\Lenovo\Desktop\X\TEKLA-SAMESOR SORUNU\TEKLADAN SAMESORE AKTARIM YAPAN ARAYUZ\ExportXML.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml;
using Tekla.Structures;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Object = Tekla.Structures.Model.Object;
using Point = System.Drawing.Point;
using RestSharp;
using System.Collections.Generic;

namespace ExportXML
{
    public class Form2 : Form
    {
        private IContainer components = (IContainer)null;
        private Button button_create;
        private TextBox textBox_product;
        private Label label_product;
        private Label label_type;
        private ComboBox comboBox_type;
        private Label label_amount;
        private TextBox textBox_amount;
        private Label label4;
        private TextBox textBox_elemserial;
        private TextBox textBox_assembly;
        private Label label1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
           // DateTime restrictionDate = new DateTime(2021,11,20);
           // if (Convert.ToDateTime(GetDate()) > restrictionDate)
            //{
            //    return;
           // }
            this.button_create = new Button();
            this.textBox_product = new TextBox();
            this.label_product = new Label();
            this.label_type = new Label();
            this.comboBox_type = new ComboBox();
            this.label_amount = new Label();
            this.textBox_amount = new TextBox();
            this.label4 = new Label();
            this.textBox_elemserial = new TextBox();
            this.textBox_assembly = new TextBox();
            this.label1 = new Label();
            this.SuspendLayout();
            this.button_create.Location = new Point(185, 271);
            this.button_create.Name = "button_create";
            this.button_create.Size = new Size(75, 23);
            this.button_create.TabIndex = 0;
            this.button_create.Text = "create";
            this.button_create.UseVisualStyleBackColor = true;
            this.button_create.Click += new EventHandler(this.button_create_Click);
            this.textBox_product.Location = new Point(185, 217);
            this.textBox_product.Name = "textBox_product";
            this.textBox_product.Size = new Size(100, 20);
            this.textBox_product.TabIndex = 2;
            this.label_product.AutoSize = true;
            this.label_product.Location = new Point(12, 220);
            this.label_product.Name = "label_product";
            this.label_product.Size = new Size(77, 13);
            this.label_product.TabIndex = 4;
            this.label_product.Text = "Element name:";
            this.label_type.AutoSize = true;
            this.label_type.Location = new Point(12, 243);
            this.label_type.Name = "label_type";
            this.label_type.Size = new Size(70, 13);
            this.label_type.TabIndex = 10;
            this.label_type.Text = "Product type:";
            this.comboBox_type.AccessibleName = "";
            this.comboBox_type.FormattingEnabled = true;
            this.comboBox_type.Items.AddRange(new object[3]
            {
        (object) "wall",
        (object) "floor",
        (object) "truss"
            });
            this.comboBox_type.Location = new Point(185, 244);
            this.comboBox_type.Name = "comboBox_type";
            this.comboBox_type.Size = new Size(100, 21);
            this.comboBox_type.TabIndex = 11;
            this.comboBox_type.Text = "wall";
            this.label_amount.AutoSize = true;
            this.label_amount.Location = new Point(12, 100);
            this.label_amount.Name = "label_amount";
            this.label_amount.Size = new Size(46, 13);
            this.label_amount.TabIndex = 17;
            this.label_amount.Text = "Amount:";
            this.textBox_amount.Location = new Point(185, 97);
            this.textBox_amount.Name = "textBox_amount";
            this.textBox_amount.Size = new Size(100, 20);
            this.textBox_amount.TabIndex = 16;
            this.textBox_amount.Text = "1";
            this.label4.AutoSize = true;
            this.label4.Location = new Point(12, 197);
            this.label4.Name = "label4";
            this.label4.Size = new Size(75, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Element serial:";
            this.textBox_elemserial.Location = new Point(185, 194);
            this.textBox_elemserial.Name = "textBox_elemserial";
            this.textBox_elemserial.Size = new Size(100, 20);
            this.textBox_elemserial.TabIndex = 25;
            this.textBox_assembly.Location = new Point(185, 138);
            this.textBox_assembly.Name = "textBox_assembly";
            this.textBox_assembly.Size = new Size(100, 20);
            this.textBox_assembly.TabIndex = 26;
            this.textBox_assembly.Text = "ALL";
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 141);
            this.label1.Name = "label1";
            this.label1.Size = new Size(110, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Create from assembly:";
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(390, 311);
            this.Controls.Add((Control)this.label1);
            this.Controls.Add((Control)this.textBox_assembly);
            this.Controls.Add((Control)this.textBox_elemserial);
            this.Controls.Add((Control)this.label4);
            this.Controls.Add((Control)this.label_amount);
            this.Controls.Add((Control)this.textBox_amount);
            this.Controls.Add((Control)this.comboBox_type);
            this.Controls.Add((Control)this.label_type);
            this.Controls.Add((Control)this.label_product);
            this.Controls.Add((Control)this.textBox_product);
            this.Controls.Add((Control)this.button_create);
            //this.Name = nameof(Form2);
            //this.Text = nameof(Form2);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        public string GetDate()
        {
            var client = new RestClient("http://worldclockapi.com");
            var request = new RestRequest("api/json/est/now", Method.GET);
            var queryResult = client.Execute<DateApi>(request).Data.currentDateTime.Split('T')[0];
            return queryResult;
        }
        public class DateApi
        {
            public string currentDateTime { get; set; }
        }

        public Form2() => this.InitializeComponent();

        private void button_create_Click(object sender, EventArgs e)
        {
            Tekla.Structures.Model.Model model = new Tekla.Structures.Model.Model();
            string modelName = model.GetInfo().ModelName;
            string modelPath = model.GetInfo().ModelPath;
            ((object)ModuleManager.Configuration).ToString();
            string currentProgramVersion = TeklaStructuresInfo.GetCurrentProgramVersion();
            string info1 = model.GetProjectInfo().Info1;
            string designer = model.GetProjectInfo().Designer;
            string name = model.GetProjectInfo().Name;
            string projectNumber = model.GetProjectInfo().ProjectNumber;
            string str1 = model.GetProjectInfo().Object;
            string str2 = this.textBox_assembly.Text.ToString();
            using (XmlWriter xmlWriter1 = XmlWriter.Create("c:\\teklastructuresmodels\\" + (name + "_" + this.textBox_product.Text.ToString() + ".xml")))
            {
                xmlWriter1.WriteStartDocument();
                xmlWriter1.WriteWhitespace("\n");
                xmlWriter1.WriteStartElement("BatchDataSet");
                xmlWriter1.WriteWhitespace("\n\n");
                xmlWriter1.WriteStartElement("Meta");
                xmlWriter1.WriteWhitespace("\n  ");
                XmlWriter xmlWriter2 = xmlWriter1;
                DateTime now = DateTime.Now;
                string str3 = now.ToString("o");
                xmlWriter2.WriteElementString("CreationTime", str3);
                xmlWriter1.WriteWhitespace("\n  ");
                xmlWriter1.WriteElementString("CreatedBy", designer);
                xmlWriter1.WriteWhitespace("\n  ");
                XmlWriter xmlWriter3 = xmlWriter1;
                now = DateTime.Now;
                string str4 = now.ToString("o");
                xmlWriter3.WriteElementString("ModificationTime", str4);
                xmlWriter1.WriteWhitespace("\n  ");
                xmlWriter1.WriteElementString("ModificatedBy", "not modified");
                xmlWriter1.WriteWhitespace("\n  ");
                xmlWriter1.WriteElementString("Version", "1.0");
                xmlWriter1.WriteWhitespace("\n  ");
                xmlWriter1.WriteElementString("CadVersion", currentProgramVersion);
                xmlWriter1.WriteWhitespace("\n  ");
                if (info1 != "")
                {
                    xmlWriter1.WriteElementString("Info", info1);
                    xmlWriter1.WriteWhitespace("\n");
                }
                xmlWriter1.WriteEndElement();
                xmlWriter1.WriteWhitespace("\n\n");
                xmlWriter1.WriteStartElement("Project");
                xmlWriter1.WriteWhitespace("\n  ");
                xmlWriter1.WriteElementString("ProjectID", "1");
                xmlWriter1.WriteWhitespace("\n  ");
                if (name != "")
                {
                    xmlWriter1.WriteElementString("ProjectName", name);
                    xmlWriter1.WriteWhitespace("\n  ");
                }
                if (projectNumber != "")
                {
                    xmlWriter1.WriteElementString("ProjectSerial", projectNumber);
                    xmlWriter1.WriteWhitespace("\n  ");
                }
                if (str1 != "")
                {
                    xmlWriter1.WriteElementString("ProjectCustomer", str1);
                    xmlWriter1.WriteWhitespace("\n");
                }
                xmlWriter1.WriteEndElement();
                xmlWriter1.WriteWhitespace("\n\n");
                xmlWriter1.WriteStartElement("Element");
                xmlWriter1.WriteWhitespace("\n  ");
                xmlWriter1.WriteElementString("ElementID", "1");
                xmlWriter1.WriteWhitespace("\n  ");
                xmlWriter1.WriteElementString("ElementProjectID", "1");
                xmlWriter1.WriteWhitespace("\n  ");
                if (this.textBox_elemserial.Text.ToString() != "")
                {
                    xmlWriter1.WriteElementString("ElementSerial", this.textBox_elemserial.Text.ToString());
                    xmlWriter1.WriteWhitespace("\n  ");
                }
                if (this.textBox_product.Text.ToString() != "")
                {
                    xmlWriter1.WriteElementString("ElementName", this.textBox_product.Text.ToString());
                    xmlWriter1.WriteWhitespace("\n  ");
                }
                xmlWriter1.WriteElementString("ElementTypeStr", this.comboBox_type.Text.ToString());
                xmlWriter1.WriteWhitespace("\n  ");
                xmlWriter1.WriteElementString("ElementFilePath", modelPath);
                xmlWriter1.WriteWhitespace("\n  ");
                xmlWriter1.WriteElementString("ElementCount", this.textBox_amount.Text.ToString());
                xmlWriter1.WriteWhitespace("\n");
                xmlWriter1.WriteEndElement();
                xmlWriter1.WriteWhitespace("\n\n");
                int num1 = 0;
                int num2 = 0;
                int num3 = 0;
                ModelObjectEnumerator allObjects = new Tekla.Structures.Model.Model().GetModelObjectSelector().GetAllObjects();
                while (allObjects.MoveNext())
                {
                    if (allObjects.Current is Beam current11)
                        ((Part)current11).GetSolid();
                    if (!(allObjects.Current is Connection))
                        ;
                    if (allObjects.Current is Part current12)
                    {
                        string profileString = current12.Profile.ProfileString;
                        string str5 = "donotcreate14a3fgh";
                        if (profileString.StartsWith("SA-"))
                            str5 = ((Part)allObjects.Current).AssemblyNumber.Prefix.ToString();
                        if (profileString.StartsWith("SA-") && (str2 == "ALL" || str2 == str5))
                        {
                            ++num1;
                            xmlWriter1.WriteStartElement("Beam");
                            xmlWriter1.WriteWhitespace("\n  ");
                            xmlWriter1.WriteElementString("BeamID", num1.ToString());
                            xmlWriter1.WriteWhitespace("\n  ");
                            xmlWriter1.WriteElementString("BeamElementID", "1");
                            xmlWriter1.WriteWhitespace("\n  ");
                            xmlWriter1.WriteElementString("BeamSerial", ((Object)current12).Identifier.ID.ToString());
                            xmlWriter1.WriteWhitespace("\n  ");
                            xmlWriter1.WriteElementString("BeamName", current12.Profile.ProfileString);
                            xmlWriter1.WriteWhitespace("\n  ");
                            xmlWriter1.WriteElementString("BeamMaterialGrade", current12.Material.MaterialString.ToString());
                            xmlWriter1.WriteWhitespace("\n  ");
                            string str6 = ((object)((Part)allObjects.Current).Position.Rotation).ToString();
                            double num4 = Math.Round(((Part)allObjects.Current).Position.RotationOffset);
                            double num5 = 0.0;
                            if (str6 == "FRONT")
                                num5 = 0.0 + num4;
                            else if (str6 == "TOP")
                                num5 = 90.0 + num4;
                            else if (str6 == "BACK")
                                num5 = 180.0 + num4;
                            else if (str6 == "BELOW")
                                num5 = 270.0 + num4;
                            xmlWriter1.WriteElementString("BeamRotation", num5.ToString());
                            xmlWriter1.WriteWhitespace("\n  ");
                            string str7 = profileString.Split('-', '-')[1];
                            string str8 = profileString.Split('-', '-')[2];
                            string str9 = profileString.Split('-', '-')[3];
                            string str10 = profileString.Split('-', '-')[4];
                            double num6 = Convert.ToDouble(str7);
                            double num7 = Convert.ToDouble(str8);
                            double num8 = 0.0;
                            num8 = !(str9 == "C") ? num6 : num6 - 2.0 * num7 / 10.0 - 0.3;
                            int num9 = 0;
                            int num10 = 0;
                            double x1 = (double)((Beam)allObjects.Current).StartPoint.X;
                            double y1 = (double)((Beam)allObjects.Current).StartPoint.Y;
                            double z1 = (double)((Beam)allObjects.Current).StartPoint.Z;
                            double x2 = (double)((Beam)allObjects.Current).EndPoint.X;
                            double y2 = (double)((Beam)allObjects.Current).EndPoint.Y;
                            double z2 = (double)((Beam)allObjects.Current).EndPoint.Z;
                            double num11 = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));
                            double num12 = 0.0;
                            double num13 = 0.0;
                            double num14 = 0.0;
                            string str11 = "Undefined";
                            string str12 = "undef";
                            string str13 = "undef";
                            string str14 = "undef";
                            string str15 = "undef";
                            string str16 = "undef";
                            double num15 = 0.0;
                            ModelObjectEnumerator bolts1 = current12.GetBolts();
                            string str17;
                            string str18;
                            while (bolts1.MoveNext())
                            {
                                BoltArray current2 = bolts1.Current as BoltArray;
                                string str19 = "";
                                ((ModelObject)current2).GetReportProperty("BOLT_USERFIELD_7", ref str19);
                                if (str19 == "dum")
                                {
                                    string str20 = "";
                                    ((ModelObject)current2).GetReportProperty("BOLT_USERFIELD_1", ref str20);
                                    string str21 = str20;
                                    str17 = "";
                                    ((ModelObject)current2).GetReportProperty("BOLT_USERFIELD_4", ref str17);
                                    string str22 = str17;
                                    string str23 = "";
                                    ((ModelObject)current2).GetReportProperty("BOLT_USERFIELD_5", ref str23);
                                    string str24 = str23;
                                    string str25 = "";
                                    ((ModelObject)current2).GetReportProperty("BOLT_USERFIELD_2", ref str25);
                                    string str26 = str25;
                                    str18 = "";
                                    ((ModelObject)current2).GetReportProperty("BOLT_USERFIELD_6", ref str18);
                                    string str27 = str18;
                                    string str28 = "";
                                    ((ModelObject)current2).GetReportProperty("BOLT_USERFIELD_3", ref str28);
                                    string str29 = str28;
                                    double x3 = (double)((BoltGroup)current2).FirstPosition.X;
                                    double y3 = (double)((BoltGroup)current2).FirstPosition.Y;
                                    double z3 = (double)((BoltGroup)current2).FirstPosition.Z;
                                    double x4 = (double)((BoltGroup)current2).SecondPosition.X;
                                    double y4 = (double)((BoltGroup)current2).SecondPosition.Y;
                                    double z4 = (double)((BoltGroup)current2).SecondPosition.Z;
                                    string str30 = "undef";
                                    if (profileString == str22)
                                    {
                                        str30 = str24;
                                        str14 = str27;
                                    }
                                    else if (profileString == str21)
                                    {
                                        str30 = str26;
                                        str14 = str29;
                                    }
                                    double num16 = Math.Round(x3);
                                    double num17 = Math.Round(y3);
                                    double num18 = Math.Round(z3);
                                    double num19 = Math.Round(x1);
                                    double num20 = Math.Round(y1);
                                    double num21 = Math.Round(z1);
                                    Math.Round(x4);
                                    Math.Round(y4);
                                    Math.Round(z4);
                                    double num22 = Math.Round(x2);
                                    double num23 = Math.Round(y2);
                                    double num24 = Math.Round(z2);
                                    double num25 = Math.Abs(num16 - num19);
                                    double num26 = Math.Abs(num17 - num20);
                                    double num27 = Math.Abs(num18 - num21);
                                    double num28 = Math.Abs(num16 - num22);
                                    double num29 = Math.Abs(num17 - num23);
                                    double num30 = Math.Abs(num18 - num24);
                                    if (str30 == "OverlapStraight")
                                    {
                                        if (num25 < 2.0 && num26 < 2.0 && num27 < 2.0)
                                        {
                                            str12 = str30;
                                            num9 = 1;
                                            num12 = num7 * 0.1 - 25.0;
                                            num13 = num7 * 0.1 - 25.0;
                                            str11 = "OverlapStraight";
                                        }
                                        if (num28 < 2.0 && num29 < 2.0 && num30 < 2.0)
                                        {
                                            str13 = str30;
                                            num10 = 1;
                                            num14 = num7 * 0.1 - 25.0;
                                            str11 = "OverlapStraight";
                                        }
                                    }
                                    else if (str30 == "OverlapRounded")
                                    {
                                        if (num25 < 2.0 && num26 < 2.0 && num27 < 2.0)
                                        {
                                            str12 = str30;
                                            num9 = 1;
                                            num12 = -21.0;
                                            num13 = -21.0;
                                            str11 = "OverlapRounded";
                                            num15 = 3.0 + 2.0 * Math.Sqrt((x4 - x3) * (x4 - x3) + (y4 - y3) * (y4 - y3) + (z4 - z3) * (z4 - z3));
                                        }
                                        if (num28 < 2.0 && num29 < 2.0 && num30 < 2.0)
                                        {
                                            str13 = str30;
                                            num10 = 1;
                                            num14 = -21.0;
                                            str11 = "OverlapRounded";
                                            num15 = 3.0 + 2.0 * Math.Sqrt((x4 - x3) * (x4 - x3) + (y4 - y3) * (y4 - y3) + (z4 - z3) * (z4 - z3));
                                        }
                                    }
                                    else if (str30 == "Rounded")
                                    {
                                        if (num25 < 2.0 && num26 < 2.0 && num27 < 2.0)
                                        {
                                            str12 = str30;
                                            num9 = 1;
                                            num12 = -21.0;
                                            num13 = -21.0;
                                            str11 = "Rounded";
                                        }
                                        if (num28 < 2.0 && num29 < 2.0 && num30 < 2.0)
                                        {
                                            str13 = str30;
                                            num10 = 1;
                                            num14 = -21.0;
                                            str11 = "Rounded";
                                        }
                                    }
                                    else if (str30 == "RoundedEnd")
                                    {
                                        string str31 = "Rounded";
                                        if (num25 < 2.0 && num26 < 2.0 && num27 < 2.0)
                                        {
                                            str12 = str31;
                                            num9 = 1;
                                            num12 = 0.0;
                                            num13 = 0.0;
                                            str11 = "Rounded";
                                        }
                                        if (num28 < 2.0 && num29 < 2.0 && num30 < 2.0)
                                        {
                                            str13 = str31;
                                            num10 = 1;
                                            num14 = 0.0;
                                            str11 = "Rounded";
                                        }
                                    }
                                    else if (str30 == "TabBendedDia12")
                                    {
                                        if (num25 < 2.0 && num26 < 2.0 && num27 < 2.0)
                                        {
                                            str12 = str30;
                                            num9 = 1;
                                            num12 = -68.0;
                                            num13 = -68.0;
                                            str11 = "TabBendedDia12";
                                            str15 = str14;
                                        }
                                        if (num28 < 2.0 && num29 < 2.0 && num30 < 2.0)
                                        {
                                            str13 = str30;
                                            num10 = 1;
                                            num14 = -68.0;
                                            str11 = "TabBendedDia12";
                                            str16 = str14;
                                        }
                                    }
                                    else if (str30 == "TabBendedClinch")
                                    {
                                        if (num25 < 2.0 && num26 < 2.0 && num27 < 2.0)
                                        {
                                            str12 = str30;
                                            num9 = 1;
                                            num12 = -68.0;
                                            num13 = -68.0;
                                            str11 = "TabBendedClinch";
                                            str15 = str14;
                                        }
                                        if (num28 < 2.0 && num29 < 2.0 && num30 < 2.0)
                                        {
                                            str13 = str30;
                                            num10 = 1;
                                            num14 = -68.0;
                                            str11 = "TabBendedClinch";
                                            str16 = str14;
                                        }
                                    }
                                    else if (str30 == "Straight")
                                    {
                                        if (num25 < 2.0 && num26 < 2.0 && num27 < 2.0)
                                        {
                                            str12 = str30;
                                            num9 = 1;
                                            num12 = num7 * 0.1 - 25.0;
                                            num13 = num7 * 0.1 - 25.0;
                                            str11 = "Straight";
                                        }
                                        if (num28 < 2.0 && num29 < 2.0 && num30 < 2.0)
                                        {
                                            str13 = str30;
                                            num10 = 1;
                                            num14 = num7 * 0.1 - 25.0;
                                            str11 = "Straight";
                                        }
                                    }
                                    else if (str30 == "ReinforcementPlate")
                                    {
                                        if (num25 < 2.0 && num26 < 2.0 && num27 < 2.0)
                                        {
                                            str12 = str30;
                                            num9 = 1;
                                            num12 = -17.0;
                                            num13 = -17.0;
                                            str11 = "ReinforcementPlate";
                                        }
                                        if (num28 < 2.0 && num29 < 2.0 && num30 < 2.0)
                                        {
                                            str13 = str30;
                                            num10 = 1;
                                            num14 = -17.0;
                                            str11 = "ReinforcementPlate";
                                        }
                                    }
                                }
                            }
                            if (num9 == 0)
                            {
                                str12 = "Straight";
                                num13 = 0.0;
                                num12 = 0.0;
                            }
                            if (num10 == 0)
                            {
                                str13 = "Straight";
                                num14 = 0.0;
                            }
                            double num31 = (x2 - x1) / num11;
                            double num32 = (y2 - y1) / num11;
                            double num33 = (z2 - z1) / num11;
                            double num34 = x1 + num13 * num31;
                            double num35 = y1 + num13 * num32;
                            double num36 = z1 + num13 * num33;
                            double num37 = x2 - num14 * num31;
                            double num38 = y2 - num14 * num32;
                            double num39 = z2 - num14 * num33;
                            string str32 = Convert.ToString(Math.Round(num34 * 100.0) / 100.0);
                            string str33 = Convert.ToString(Math.Round(num35 * 100.0) / 100.0);
                            string str34 = Convert.ToString(Math.Round(num36 * 100.0) / 100.0);
                            string str35 = Convert.ToString(Math.Round(num37 * 100.0) / 100.0);
                            string str36 = Convert.ToString(Math.Round(num38 * 100.0) / 100.0);
                            string str37 = Convert.ToString(Math.Round(num39 * 100.0) / 100.0);
                            string str38 = str32.Replace(',', '.');
                            string str39 = str33.Replace(',', '.');
                            string str40 = str34.Replace(',', '.');
                            string str41 = str35.Replace(',', '.');
                            string str42 = str36.Replace(',', '.');
                            string str43 = str37.Replace(',', '.');
                            xmlWriter1.WriteElementString("BeamXStart", str38);
                            xmlWriter1.WriteWhitespace("\n  ");
                            xmlWriter1.WriteElementString("BeamYStart", str39);
                            xmlWriter1.WriteWhitespace("\n  ");
                            xmlWriter1.WriteElementString("BeamZStart", str40);
                            xmlWriter1.WriteWhitespace("\n  ");
                            xmlWriter1.WriteElementString("BeamXEnd", str41);
                            xmlWriter1.WriteWhitespace("\n  ");
                            xmlWriter1.WriteElementString("BeamYEnd", str42);
                            xmlWriter1.WriteWhitespace("\n  ");
                            xmlWriter1.WriteElementString("BeamZEnd", str43);
                            xmlWriter1.WriteWhitespace("\n  ");
                            double num40 = num11 - num13 - num14;
                            xmlWriter1.WriteElementString("BeamLength", num40.ToString("0.0", (IFormatProvider)CultureInfo.GetCultureInfo("en-US")));
                            xmlWriter1.WriteWhitespace("\n");
                            xmlWriter1.WriteEndElement();
                            xmlWriter1.WriteWhitespace("\n\n");
                            xmlWriter1.WriteStartElement("Detail", (string)null);
                            xmlWriter1.WriteWhitespace("\n  ");
                            ++num2;
                            xmlWriter1.WriteElementString("DetailID", num2.ToString());
                            xmlWriter1.WriteWhitespace("\n  ");
                            xmlWriter1.WriteElementString("DetailBeamID", num1.ToString());
                            xmlWriter1.WriteWhitespace("\n  ");
                            xmlWriter1.WriteElementString("DetailType", "Front");
                            xmlWriter1.WriteWhitespace("\n  ");
                            xmlWriter1.WriteElementString("DetailName", str12);
                            xmlWriter1.WriteWhitespace("\n  ");
                            xmlWriter1.WriteElementString("DetailXPos", "0");
                            xmlWriter1.WriteWhitespace("\n  ");
                            xmlWriter1.WriteElementString("DetailYPos", "0");
                            xmlWriter1.WriteWhitespace("\n  ");
                            xmlWriter1.WriteElementString("DetailProfileFace", "Web");
                            xmlWriter1.WriteWhitespace("\n  ");
                            xmlWriter1.WriteEndElement();
                            xmlWriter1.WriteWhitespace("\n\n");
                            if (str12 == "OverlapStraight" || str12 == "OverlapRounded")
                            {
                                xmlWriter1.WriteStartElement("Parameter", (string)null);
                                xmlWriter1.WriteWhitespace("\n  ");
                                ++num3;
                                xmlWriter1.WriteElementString("ParameterID", num3.ToString());
                                xmlWriter1.WriteWhitespace("\n  ");
                                xmlWriter1.WriteElementString("ParameterDetailID", num2.ToString());
                                xmlWriter1.WriteWhitespace("\n  ");
                                xmlWriter1.WriteElementString("ParameterName", "OverlapWebLength");
                                xmlWriter1.WriteWhitespace("\n  ");
                                if (str12 == "OverlapStraight")
                                    xmlWriter1.WriteElementString("ParameterValue", "52");
                                else
                                    xmlWriter1.WriteElementString("ParameterValue", num15.ToString("0.0", (IFormatProvider)CultureInfo.GetCultureInfo("en-US")));
                                xmlWriter1.WriteWhitespace("\n  ");
                                xmlWriter1.WriteEndElement();
                                xmlWriter1.WriteWhitespace("\n\n");
                            }
                            else if (str12 == "TabBendedDia12" || str12 == "TabBendedClinch")
                            {
                                xmlWriter1.WriteStartElement("Parameter", (string)null);
                                xmlWriter1.WriteWhitespace("\n  ");
                                ++num3;
                                xmlWriter1.WriteElementString("ParameterID", num3.ToString());
                                xmlWriter1.WriteWhitespace("\n  ");
                                xmlWriter1.WriteElementString("ParameterDetailID", num2.ToString());
                                xmlWriter1.WriteWhitespace("\n  ");
                                xmlWriter1.WriteElementString("ParameterName", "HolePosition");
                                xmlWriter1.WriteWhitespace("\n  ");
                                xmlWriter1.WriteElementString("ParameterValue", str15.ToString());
                                xmlWriter1.WriteWhitespace("\n  ");
                                xmlWriter1.WriteEndElement();
                                xmlWriter1.WriteWhitespace("\n\n");
                            }
                            xmlWriter1.WriteStartElement("Detail", (string)null);
                            xmlWriter1.WriteWhitespace("\n  ");
                            ++num2;
                            xmlWriter1.WriteElementString("DetailID", num2.ToString());
                            xmlWriter1.WriteWhitespace("\n  ");
                            xmlWriter1.WriteElementString("DetailBeamID", num1.ToString());
                            xmlWriter1.WriteWhitespace("\n  ");
                            xmlWriter1.WriteElementString("DetailType", "End");
                            xmlWriter1.WriteWhitespace("\n  ");
                            xmlWriter1.WriteElementString("DetailName", str13);
                            xmlWriter1.WriteWhitespace("\n  ");
                            xmlWriter1.WriteElementString("DetailXPos", "0");
                            xmlWriter1.WriteWhitespace("\n  ");
                            xmlWriter1.WriteElementString("DetailYPos", "0");
                            xmlWriter1.WriteWhitespace("\n  ");
                            xmlWriter1.WriteElementString("DetailProfileFace", "Web");
                            xmlWriter1.WriteWhitespace("\n  ");
                            xmlWriter1.WriteEndElement();
                            xmlWriter1.WriteWhitespace("\n\n");
                            if (str13 == "OverlapStraight" || str13 == "OverlapRounded")
                            {
                                xmlWriter1.WriteStartElement("Parameter", (string)null);
                                xmlWriter1.WriteWhitespace("\n  ");
                                ++num3;
                                xmlWriter1.WriteElementString("ParameterID", num3.ToString());
                                xmlWriter1.WriteWhitespace("\n  ");
                                xmlWriter1.WriteElementString("ParameterDetailID", num2.ToString());
                                xmlWriter1.WriteWhitespace("\n  ");
                                xmlWriter1.WriteElementString("ParameterName", "OverlapWebLength");
                                xmlWriter1.WriteWhitespace("\n  ");
                                if (str13 == "OverlapStraight")
                                    xmlWriter1.WriteElementString("ParameterValue", "52");
                                else
                                    xmlWriter1.WriteElementString("ParameterValue", num15.ToString("0.0", (IFormatProvider)CultureInfo.GetCultureInfo("en-US")));
                                xmlWriter1.WriteWhitespace("\n  ");
                                xmlWriter1.WriteEndElement();
                                xmlWriter1.WriteWhitespace("\n\n");
                            }
                            else if (str13 == "TabBendedDia12" || str13 == "TabBendedClinch")
                            {
                                xmlWriter1.WriteStartElement("Parameter", (string)null);
                                xmlWriter1.WriteWhitespace("\n  ");
                                ++num3;
                                xmlWriter1.WriteElementString("ParameterID", num3.ToString());
                                xmlWriter1.WriteWhitespace("\n  ");
                                xmlWriter1.WriteElementString("ParameterDetailID", num2.ToString());
                                xmlWriter1.WriteWhitespace("\n  ");
                                xmlWriter1.WriteElementString("ParameterName", "HolePosition");
                                xmlWriter1.WriteWhitespace("\n  ");
                                xmlWriter1.WriteElementString("ParameterValue", str16.ToString());
                                xmlWriter1.WriteWhitespace("\n  ");
                                xmlWriter1.WriteEndElement();
                                xmlWriter1.WriteWhitespace("\n\n");
                            }
                            ModelObjectEnumerator bolts2 = current12.GetBolts();
                            while (bolts2.MoveNext())
                            {
                                BoltArray current3 = bolts2.Current as BoltArray;
                                double x5 = (double)((BoltGroup)current3).FirstPosition.X;
                                double y5 = (double)((BoltGroup)current3).FirstPosition.Y;
                                double z5 = (double)((BoltGroup)current3).FirstPosition.Z;
                                double x6 = (double)((BoltGroup)current3).SecondPosition.X;
                                double y6 = (double)((BoltGroup)current3).SecondPosition.Y;
                                double z6 = (double)((BoltGroup)current3).SecondPosition.Z;
                                string str44 = "";
                                ((ModelObject)current3).GetReportProperty("BOLT_USERFIELD_7", ref str44);
                                string str45 = str44;
                                str17 = "";
                                ((ModelObject)current3).GetReportProperty("BOLT_USERFIELD_4", ref str17);
                                string str46 = "";
                                ((ModelObject)current3).GetReportProperty("BOLT_USERFIELD_1", ref str46);
                                string str47 = "";
                                ((ModelObject)current3).GetReportProperty("BOLT_USERFIELD_5", ref str47);
                                string str48 = str47;
                                if (str48 == "Flange5Screw" || str48 == "Flange5ScrewCup" || str48 == "5screws")
                                    str48 = !(str10 == "IN") ? "FlangeM5ScrewCup" : "FlangeFM5ScrewCup";
                                if (str48 == "FlangeHexClinch")
                                    str48 = !(str10 == "IN") ? "FlangeDia12" : "FlangeHexClinch";
                                str18 = "";
                                ((ModelObject)current3).GetReportProperty("BOLT_USERFIELD_6", ref str18);
                                string str49 = str18;
                                string str50 = "";
                                ((ModelObject)current3).GetReportProperty("BOLT_USERFIELD_8", ref str50);
                                string str51 = str50;
                                if (!(str48 == "Overlap") && !(str48 == "Rounded") && !(str48 == "OverlapRounded") && !(str48 == "TabBendedDia12") && !(str48 == "TabBendedClinch") && !(str48 == "Straight") && !(str45 == "Mirror"))
                                {
                                    double num41 = x5 - x1;
                                    double num42 = y5 - y1;
                                    double num43 = z5 - z1;
                                    double num44 = Math.Sqrt(num41 * num41 + num42 * num42 + num43 * num43);
                                    double num45 = x6 - x1;
                                    double num46 = y6 - y1;
                                    double num47 = z6 - z1;
                                    Math.Sqrt(num45 * num45 + num46 * num46 + num47 * num47);
                                    double num48 = 0.0;
                                    if (str49 == "Flange")
                                    {
                                        num48 = (Math.Round(num44 * num44 - num6 / 2.0 * (num6 / 2.0)) != 0.0 ? Math.Sqrt(num44 * num44 - num6 / 2.0 * (num6 / 2.0)) : 0.0) - num12;
                                        if (str48 == "FlangeOpening")
                                            num48 = num44 - num12;
                                    }
                                    else if (str49 == "Web")
                                    {
                                        str51 = str51.Replace('.', ',');
                                        double num49 = Convert.ToDouble(str51);
                                        if (str48 == "LateralBracingWebOpening")
                                            num49 = 0.0;
                                        num48 = Math.Sqrt(num44 * num44 - 625.0 - num49 * num49) - num12;
                                    }
                                    xmlWriter1.WriteStartElement("Detail", (string)null);
                                    xmlWriter1.WriteWhitespace("\n  ");
                                    ++num2;
                                    xmlWriter1.WriteElementString("DetailID", num2.ToString());
                                    xmlWriter1.WriteWhitespace("\n  ");
                                    xmlWriter1.WriteElementString("DetailBeamID", num1.ToString());
                                    xmlWriter1.WriteWhitespace("\n  ");
                                    xmlWriter1.WriteElementString("DetailType", "Middle");
                                    xmlWriter1.WriteWhitespace("\n  ");
                                    xmlWriter1.WriteElementString("DetailName", str48);
                                    xmlWriter1.WriteWhitespace("\n  ");
                                    xmlWriter1.WriteElementString("DetailXPos", num48.ToString("0.0", (IFormatProvider)CultureInfo.GetCultureInfo("en-US")));
                                    xmlWriter1.WriteWhitespace("\n  ");
                                    if (str48 == "LateralBracingWebOpening")
                                    {
                                        xmlWriter1.WriteElementString("DetailYPos", "0");
                                    }
                                    else
                                    {
                                        str51 = str51.Replace(',', '.');
                                        xmlWriter1.WriteElementString("DetailYPos", str51);
                                    }
                                    xmlWriter1.WriteWhitespace("\n  ");
                                    xmlWriter1.WriteElementString("DetailProfileFace", str49);
                                    xmlWriter1.WriteWhitespace("\n");
                                    xmlWriter1.WriteEndElement();
                                    xmlWriter1.WriteWhitespace("\n\n");
                                    if (str48 == "FlangeOpening")
                                    {
                                        double num50 = 54.0;
                                        xmlWriter1.WriteStartElement("Parameter", (string)null);
                                        xmlWriter1.WriteWhitespace("\n  ");
                                        ++num3;
                                        xmlWriter1.WriteElementString("ParameterID", num3.ToString());
                                        xmlWriter1.WriteWhitespace("\n  ");
                                        xmlWriter1.WriteElementString("ParameterDetailID", num2.ToString());
                                        xmlWriter1.WriteWhitespace("\n  ");
                                        xmlWriter1.WriteElementString("ParameterName", "DetailLength");
                                        xmlWriter1.WriteWhitespace("\n  ");
                                        xmlWriter1.WriteElementString("ParameterValue", num50.ToString());
                                        xmlWriter1.WriteWhitespace("\n");
                                        xmlWriter1.WriteEndElement();
                                        xmlWriter1.WriteWhitespace("\n\n");
                                    }
                                    else if (str48 == "FlangeEmbossing")
                                    {
                                        xmlWriter1.WriteStartElement("Parameter", (string)null);
                                        xmlWriter1.WriteWhitespace("\n  ");
                                        ++num3;
                                        xmlWriter1.WriteElementString("ParameterID", num3.ToString());
                                        xmlWriter1.WriteWhitespace("\n  ");
                                        xmlWriter1.WriteElementString("ParameterDetailID", num2.ToString());
                                        xmlWriter1.WriteWhitespace("\n  ");
                                        xmlWriter1.WriteElementString("ParameterName", "DetailLength");
                                        xmlWriter1.WriteWhitespace("\n  ");
                                        string str52 = str51.Replace(',', '.');
                                        xmlWriter1.WriteElementString("ParameterValue", str52);
                                        xmlWriter1.WriteWhitespace("\n");
                                        xmlWriter1.WriteEndElement();
                                        xmlWriter1.WriteWhitespace("\n\n");
                                    }
                                    else if (str48 == "LateralBracingWebOpening")
                                    {
                                        xmlWriter1.WriteStartElement("Parameter", (string)null);
                                        xmlWriter1.WriteWhitespace("\n  ");
                                        ++num3;
                                        xmlWriter1.WriteElementString("ParameterID", num3.ToString());
                                        xmlWriter1.WriteWhitespace("\n  ");
                                        xmlWriter1.WriteElementString("ParameterDetailID", num2.ToString());
                                        xmlWriter1.WriteWhitespace("\n  ");
                                        xmlWriter1.WriteElementString("ParameterName", "DetailLength");
                                        xmlWriter1.WriteWhitespace("\n  ");
                                        string str53 = str51.Replace(',', '.');
                                        xmlWriter1.WriteElementString("ParameterValue", str53);
                                        xmlWriter1.WriteWhitespace("\n");
                                        xmlWriter1.WriteEndElement();
                                        xmlWriter1.WriteWhitespace("\n\n");
                                    }
                                }
                            }
                        }
                    }
                }
                xmlWriter1.WriteEndElement();
                xmlWriter1.WriteEndDocument();
            }
            this.Close();
        }

        private void WriteCoordSys(XmlWriter xml, CoordinateSystem CoordSys)
        {
            xml.WriteElementString("Origin", ((object)CoordSys.Origin).ToString());
            xml.WriteWhitespace("\n  ");
            xml.WriteElementString("AxisX", ((object)CoordSys.AxisX).ToString());
            xml.WriteWhitespace("\n  ");
            xml.WriteElementString("AxisY", ((object)CoordSys.AxisY).ToString());
            xml.WriteWhitespace("\n  ");
            // ISSUE: explicit non-virtual call
            xml.WriteElementString("Origin_X", (CoordSys.Origin.X.ToString()));
            xml.WriteWhitespace("\n  ");
            // ISSUE: explicit non-virtual call
            xml.WriteElementString("AxisX_X", (CoordSys.AxisX).X.ToString());
            xml.WriteWhitespace("\n");
            xml.WriteEndElement();
            xml.WriteWhitespace("\n\n");
        }
    }
}
