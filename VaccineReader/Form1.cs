using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VaccineReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[] removeExtraCharacters(string[] data)
        {
            string[] fixedData = { data[0].Substring(3), data[1].Substring(3), data[2].Substring(3) };
            return fixedData;
        }
        
        string[] parseLicense(string rawData)
        {
            string[] rawDataArr = rawData.Split('\n');
            
            // return error if scan did not return at least 10 lines
            if (rawDataArr.Length < 10)
            {
                string[] err = { "Error" };
                return err;

            }
            string[] data = { rawDataArr[6], rawDataArr[7], rawDataArr[10] }; // assign lastName, firstName, DOB to data array
            data = removeExtraCharacters(data); //remove extra characters at begginning of string
            return data;
        }

        private void submit_Click(object sender, EventArgs e)
        {
            string rawData = "";
            string[] patientData = new string[3];
            
            //parse raw data
            rawData = this.dataBox.Text;
            patientData = parseLicense(rawData);
            
            // Output an error if the scan didn't work properly
            if (patientData[0].Equals("Error")) MessageBox.Show("Error: Scan did not return proper values");
            
            // Scan worked so display the data
            else MessageBox.Show("Last Name: " + patientData[0] + " First Name: " + patientData[1] + " DOB: " + patientData[2]);    
        }

        private void dataBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void clear_Click(object sender, EventArgs e)
        {
            this.dataBox.Text = String.Empty;
        }
    }
}
