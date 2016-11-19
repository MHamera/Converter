using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Converter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var converter = new PDFManager();
            //This folder contains all the images
            converter.inputFolder = @"../../Images/"; 
            //This contains the locations and names of all the fields
            converter.jsonFile = @"../../JSON/JSONData.json";

            //Populate settings with test data
            var settings = new FormSettings();
            settings.Populate();

            //Here, we just fill in two fields
            var settings2 = new FormSettings();
            settings2.FirstName = "Matthew";
            settings2.LastName = "Hamera";
            settings2.RetirementPlan = true;

            var PDF1 = converter.GeneratePDF(settings);
            var PDF2 = converter.GeneratePDF(settings2);

            File.WriteAllBytes("./PDF1.pdf", PDF1);
        }
    }
}
